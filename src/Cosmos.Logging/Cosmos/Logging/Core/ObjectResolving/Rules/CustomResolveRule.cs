using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    /// <summary>
    /// Custom resolve rule
    /// </summary>
    public class CustomResolveRule : IDestructureResolveRule {
        private readonly Func<Type, bool> _conditionFunc;
        private readonly Func<object, object> _convertFunc;

        /// <summary>
        /// Create a new instance of <see cref="CustomResolveRule"/>.
        /// </summary>
        /// <param name="conditionFunc"></param>
        /// <param name="convertFunc"></param>
        public CustomResolveRule(Func<Type, bool> conditionFunc, Func<object, object> convertFunc) {
            _conditionFunc = conditionFunc ?? throw new ArgumentNullException(nameof(conditionFunc));
            _convertFunc = convertFunc ?? throw new ArgumentNullException(nameof(convertFunc));
        }


        /// <inheritdoc />
        public bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (_conditionFunc(value.GetType())) {
                result = nest.CreatePropertyValue(_convertFunc(value), PropertyResolvingMode.Destructure);
                return true;
            }

            result = null;
            return false;
        }
    }
}