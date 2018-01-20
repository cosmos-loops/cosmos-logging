using System;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    internal class DelegateResolveRule : IDestructureResolveRule {
        public bool TryResolve(object value, IMessagePropertyValueFactory factory, out MessagePropertyValue result) {
            result = value is Delegate @delegate ? new ScalarValue(@delegate) : null;
            return result != null;
        }
    }
}