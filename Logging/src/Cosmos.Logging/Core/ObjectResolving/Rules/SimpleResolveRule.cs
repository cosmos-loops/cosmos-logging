using System;
using System.Collections.Generic;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    internal class SimpleResolveRule : IScalarResolveRule {
        readonly HashSet<Type> _scalarTypes;

        public SimpleResolveRule(IEnumerable<Type> scalarTypes) {
            _scalarTypes = new HashSet<Type>(scalarTypes);
        }

        public bool TryResolve(object value, out MessagePropertyValue result) {
            result = _scalarTypes.Contains(value.GetType()) ? new ScalarValue(value) : null;
            return result != null;
        }
    }
}