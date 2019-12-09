using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Cosmos.Logging.Extensions.Exceptions.Core.Internals;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public partial class ReflectionBasedDestructurer : IExceptionDestructurer {
        private const string ID_LABEL = "$id";
        private const string REF_LABEL = "$ref";
        private const string CYCLIC_REF_MSG = "Cyclic reference";

        private readonly int _destructuringDepth;
        private readonly object _lockObj = new object();

        private readonly Dictionary<Type, ReflectionInfo> _reflectionInfoCache = new Dictionary<Type, ReflectionInfo>();
        private readonly PropertyInfo[] _exceptionProperties;

        public ReflectionBasedDestructurer(int destructuringDepth) {
            if (destructuringDepth <= 0)
                throw new ArgumentOutOfRangeException(nameof(destructuringDepth), destructuringDepth,
                    "Destructuring depth must be positive.");

            _destructuringDepth  = destructuringDepth;
            _exceptionProperties = GetExceptionPropertiesForDestructuring(typeof(Exception));
        }

        public Type[] TargetTypes => new[] {typeof(Exception)};

        public void Destructure(Exception exception, IExceptionPropertyBag propertyBag, Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            if (exception is null)
                throw new ArgumentNullException(nameof(exception));

            if (propertyBag is null)
                throw new ArgumentNullException(nameof(propertyBag));

            if (destructureExceptionHandle is null)
                throw new ArgumentNullException(nameof(destructureExceptionHandle));

            var nextCyclicRefId     = 1;
            var destructuredObjects = new Dictionary<object, IDictionary<string, object>>();

            ExceptionDestructurer.DestructureCommonExceptionProperties(
                exception,
                propertyBag,
                destructureExceptionHandle,
                d => DestructureValueDictionary(d, 1, destructuredObjects, ref nextCyclicRefId));

            var reflectionInfo = GetOrCreateReflectionInfo(exception.GetType());

            AppendProperties(exception, reflectionInfo.PropertiesExceptBaseOnes, propertyBag.AddProperty, destructuredObjects, 0, ref nextCyclicRefId);

            AppendTypeIfNeed(propertyBag, exception.GetType());
        }

        private object DestructureValue(object value, int level, IDictionary<object, IDictionary<string, object>> destructuredObjects, ref int nextCyclicRefId) {
            if (value is null)
                return null;

            var typeOfValue     = value.GetType();
            var typeInfoOfValue = typeOfValue.GetTypeInfo();

            if (value is MemberInfo)
                return value;

            if (typeOfValue.GetTypeCode() != TypeCode.Object || typeInfoOfValue.IsValueType)
                return value;

            if (level > _destructuringDepth)
                return value;

            if (value is IDictionary dictionary)
                return DestructureValueDictionary(dictionary, level, destructuredObjects, ref nextCyclicRefId);

            if (value is IEnumerable enumerable)
                return DestructureValueEnumerable(enumerable, level, destructuredObjects, ref nextCyclicRefId);

            if (value is Uri uri)
                return DestructureUri(uri);

            if (value is CancellationToken ct)
                return OperationCanceledExceptionDestructurer.DestructureCancellationToken(ct);

            if (value is Task task)
                return DestructureTask(task, level, destructuredObjects, ref nextCyclicRefId);

            return DestructureObject(value, level, destructuredObjects, ref nextCyclicRefId, typeOfValue);
        }

        private static string GetOrCreateRefId(ref int nextCycleRefId, IDictionary<string, object> destructureObjects) {
            string refId;
            if (destructureObjects.ContainsKey(ID_LABEL)) {
                refId = (string) destructureObjects[ID_LABEL];
            }
            else {
                // ReSharper disable once InconsistentNaming
                var __id = nextCycleRefId;
                nextCycleRefId++;
                refId                        = __id.ToString(CultureInfo.InvariantCulture);
                destructureObjects[ID_LABEL] = refId;
            }

            return refId;
        }

        private static PropertyInfo[] GetExceptionPropertiesForDestructuring(Type type) {
            return type
                  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .Where(x => x.CanRead && x.GetIndexParameters().Length == 0)
                  .ToArray();
        }

        private static Func<object, object> GenerateFastGetterForProperty(Type type, PropertyInfo propertyInfo) {
            var objParams    = Expression.Parameter(typeof(object), "num");
            var typeObj      = Expression.Convert(objParams, type);
            var memberExp    = Expression.Property(typeObj, propertyInfo);
            var typedResult  = Expression.Convert(memberExp, typeof(object));
            var resultLambda = Expression.Lambda<Func<object, object>>(typedResult, objParams);
            return resultLambda.Compile();
        }

        private ReflectionInfo GenerateReflectionInfoForType(Type type) {
            var properties = GetExceptionPropertiesForDestructuring(type);
            var propertyInfos = properties.Select(p => new ReflectionPropertyInfo() {
                Name          = p.Name,
                DeclaringType = p.DeclaringType,
                Getter        = GenerateFastGetterForProperty(type, p)
            }).ToArray();

            var propertyInfosExceptBaseOnes = propertyInfos.Where(p => _exceptionProperties.All(b => b.Name != p.Name)).ToArray();

            var reflectInfo = new ReflectionInfo {
                Properties               = propertyInfos,
                PropertiesExceptBaseOnes = propertyInfosExceptBaseOnes
            };

            return reflectInfo;
        }

        private ReflectionInfo GetOrCreateReflectionInfo(Type type) {
            lock (_lockObj) {
                if (!_reflectionInfoCache.TryGetValue(type, out var reflectionInfo)) {
                    reflectionInfo = GenerateReflectionInfoForType(type);
                    _reflectionInfoCache.Add(type, reflectionInfo);
                }

                return reflectionInfo;
            }
        }

        private void AppendProperties(object value, ReflectionPropertyInfo[] reflectionPropertyInfos,
                                      Action<string, object> addPropertiesAct,
                                      IDictionary<object, IDictionary<string, object>> destructuredObjects,
                                      int level,
                                      ref int nextCyclicRefId) {
            foreach (var property in reflectionPropertyInfos) {
                try {
                    var valueToBeDestructed  = property.Getter(value);
                    var localNextCyclicRefId = nextCyclicRefId;
                    var destructuredValue    = DestructureValue(valueToBeDestructed, level + 1, destructuredObjects, ref localNextCyclicRefId);
                    nextCyclicRefId = localNextCyclicRefId;
                    addPropertiesAct(property.Name, destructuredValue);
                }
                catch (TargetInvocationException targetInvocationException) {
                    var inner = targetInvocationException.InnerException;
                    if (inner != null) {
                        addPropertiesAct(property.Name, $"Threw {inner.GetType().FullName}: {inner.Message}");
                    }
                }
                catch (Exception exception) {
                    addPropertiesAct(property.Name, $"Threw {exception.GetType().FullName}: {exception.Message}");
                }
            }
        }

        private void AppendTypeIfNeed(IExceptionPropertyBag propertyBag, Type type) {
            if (propertyBag.ContainProperty("Type")) {
                if (!propertyBag.ContainProperty("$Type")) {
                    propertyBag.AddProperty("$Type", type.FullName);
                }
            }
            else {
                propertyBag.AddProperty("Type", type.FullName);
            }
        }

        private object DestructureUri(Uri value) {
            return value.ToString();
        }
    }
}