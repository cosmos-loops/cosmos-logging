using System;
using System.Reflection;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    public class ReflectionTypesResolveRule : IDestructureResolveRule {

        public bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result) {
            result = IsBasicReflectionType(value) ? new ScalarValue(value) : null;
            return result != null;
        }

        private static bool IsBasicReflectionType(object value) => value is Type || value is MethodInfo || value is FieldInfo;
    }
}