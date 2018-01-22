using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;
using Cosmos.Logging.Core.ObjectResolving.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    internal static class TypeFeeler {

        public static bool TryResolveToEnumerable(object value, PropertyResolvingMode mode, NestParameterResolver nest, Type typeOfValue,
            int maxLoopCountForCollection, out MessagePropertyValue result) {
            if (value is IEnumerable __enumerable) {
                if (TryGetDictionary(value, typeOfValue, out var dictionary)) {
                    result = new DictionaryValue(DictionaryElements());
                    return true;

                    IEnumerable<KeyValuePair<ScalarValue, MessagePropertyValue>> DictionaryElements() {
                        var __index = 0;
                        foreach (DictionaryEntry __item in dictionary) {
                            if (++__index > maxLoopCountForCollection) yield break;
                            if (nest.CreatePropertyValue(__item.Key, mode) is ScalarValue __key) {
                                var __value = nest.CreatePropertyValue(__item.Value, mode);
                                yield return new KeyValuePair<ScalarValue, MessagePropertyValue>(__key, __value);
                            }
                        }
                    }
                }

                result = new SequenceValue(SequenceElements());
                return true;

                IEnumerable<MessagePropertyValue> SequenceElements() {
                    var __index = 0;
                    foreach (var __item in __enumerable) {
                        if (++__index > maxLoopCountForCollection) yield break;
                        yield return nest.CreatePropertyValue(__item, mode);
                    }
                }
            }

            result = null;
            return false;
        }

        public static bool TryResolveToValueTuple(object value, PropertyResolvingMode mode, NestParameterResolver nest, Type typeOfValue,
            out MessagePropertyValue result) {
            result = CheckingValueTypeDefinition(typeOfValue, value) ? new SequenceValue(SequenceElements()) : null;
            return result != null;

            IEnumerable<MessagePropertyValue> SequenceElements() {
                var __fields = typeOfValue.GetTypeInfo().DeclaredFields.Where(f => f.IsPublic && !f.IsStatic);
                foreach (var __field in __fields) {
                    yield return nest.CreatePropertyValue(__field.GetValue(value), mode);
                }
            }
        }

        public static bool TryResolveCompilerGeneratedType(object value, PropertyResolvingMode mode, NestParameterResolver nest, Type typeOfValue,
            bool raiseException, int positionalValue, out MessagePropertyValue result) {
            if (mode == PropertyResolvingMode.Destructure) {

                result = new StructureValue(StructureElements(), Tag());
                return true;

                string Tag() {
                    var __tag = typeOfValue.Name;
                    if (string.IsNullOrWhiteSpace(__tag) || typeOfValue.IsCompilerGeneratedType()) __tag = null;
                    return __tag;
                }

                IEnumerable<MessageProperty> StructureElements() {
                    foreach (var property in value.GetType().GetPropertiesRecursive()) {
                        dynamic propertyValue;
                        try {
                            propertyValue = property.GetValue(value);
                        }
                        catch (TargetParameterCountException) {
                            InternalLogger.WriteLine("The property accessor '{0}' is a non-default indexer", property);
                            continue;
                        }
                        catch (TargetInvocationException ex) {
                            InternalLogger.WriteLine("The property accessor '{0}' threw exception: {1}", property, ex);
                            if (raiseException)
                                throw;
                            propertyValue = $"Threw an exception at: {ex.InnerException?.GetType().Name}";
                        }

                        yield return new MessageProperty(property.Name, positionalValue, nest.CreatePropertyValue(propertyValue, PropertyResolvingMode.Destructure));
                    }
                }
            }

            result = null;
            return false;
        }

        private static bool TryGetDictionary(object value, Type typeOfValue, out IDictionary dictionary) {
            dictionary = CheckingGenericTypeDefinition(typeOfValue) && CheckingKeyTypeOfDictionary(typeOfValue)
                ? (IDictionary) value
                : null;

            return dictionary != null;
        }

        private static bool CheckingGenericTypeDefinition(Type typeOfValue) {
            return typeOfValue.IsConstructedGenericType && typeOfValue.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        private static bool CheckingKeyTypeOfDictionary(Type typeOfValue) {
            var typeOfKey = typeOfValue.GetGenericArguments()[0];
            return typeOfKey.IsScalarType() || typeOfKey.IsEnum;
        }

        private static bool CheckingValueTypeDefinition(Type typeOfValue, object value) {
            if (value is IStructuralEquatable && typeOfValue.IsConstructedGenericType) {
                var definition = typeOfValue.GetGenericTypeDefinition();
                if (definition == typeof(ValueTuple<>) ||
                    definition == typeof(ValueTuple<,>) ||
                    definition == typeof(ValueTuple<,,>) ||
                    definition == typeof(ValueTuple<,,,>) ||
                    definition == typeof(ValueTuple<,,,,>) ||
                    definition == typeof(ValueTuple<,,,,,>) ||
                    definition == typeof(ValueTuple<,,,,,,>)) {

                    return true;
                }
            }

            return false;
        }
    }
}