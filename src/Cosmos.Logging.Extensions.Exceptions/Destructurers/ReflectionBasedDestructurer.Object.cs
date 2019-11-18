using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public partial class ReflectionBasedDestructurer
    {
        public object DestructureObject(
            object value,
            int level,
            IDictionary<object, IDictionary<string, object>> destructuredObjects,
            ref int nextCyclicRefId,
            Type typeOfValue)
        {
            if (destructuredObjects.TryGetValue(value, out var destructuredObject))
            {
                var refId = GetOrCreateRefId(ref nextCyclicRefId, destructuredObject);

                return new Dictionary<string, object> {{REF_LABEL, refId}};
            }

            var destructureDictionary = new Dictionary<string, object>();

            destructuredObjects.Add(value, destructureDictionary);

            var reflectionInfo = GetOrCreateReflectionInfo(typeOfValue);

            foreach (var property in reflectionInfo.Properties)
            {
                try
                {
                    var valueToBeDestructured = property.Getter(value);
                    var destructedValue = DestructureValue(valueToBeDestructured, level + 1, destructuredObjects, ref nextCyclicRefId);
                    var key = destructureDictionary.ContainsKey(property.Name)
                        ? $"{property.DeclaringType.FullName}.{property.Name}"
                        : property.Name;

                    destructureDictionary.Add(key, destructedValue);
                }
                catch (TargetInvocationException targetInvocationException)
                {
                    var inner = targetInvocationException.InnerException;
                    if (inner != null)
                    {
                        destructureDictionary.Add(property.Name, $"Threw {inner.GetType().FullName}: {inner.Message}");
                    }
                }
                catch (Exception exception)
                {
                    destructureDictionary.Add(property.Name,$"Threw {exception.GetType().FullName}: {exception.Message}");
                }
            }

            return destructureDictionary;
        }
    }
}