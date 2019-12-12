using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals.Core {
    internal abstract class NodaTimeDestructureResolveRule<T> : IDestructureResolveRule {
        protected abstract IPattern<T> Pattern { get; }
        protected readonly Action<T> Validator;

        protected NodaTimeDestructureResolveRule(Action<T> validator = null) {
            Validator = validator;
        }

        public bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result) {
            if (value is T t) {
                Validator?.Invoke(t);
                result = nest.CreatePropertyValue(Pattern.Format(t), PropertyResolvingMode.Default);
                return true;
            }

            result = null;
            return false;
        }

        protected static Action<T> CreateIsoValidator(Func<T, CalendarSystem> calendarProjection) {
            return value => {
                var calendar = calendarProjection(value);
                // We rely on CalendarSystem.Iso being a singleton here.
                if (calendar != CalendarSystem.Iso)
                    throw new ArgumentException($"Values of type {typeof(T).Name} must (currently) use the ISO calendar in order to be serialized.");
            };
        }
    }
}