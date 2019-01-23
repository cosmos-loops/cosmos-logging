using System.Collections.Generic;

namespace Cosmos.Validations
{
    public static class ValidationActivator
    {
        public static ValidationResultCollection Validate<TObject>(TObject instance)
            where TObject : class, IValidatable<TObject>
        {
            return instance.Validate();
        }

        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IValidateStrategy<TObject> strategy)
            where TObject : class, IValidatable<TObject>
        {
            instance.AddStrategy(strategy);
            return instance.Validate();
        }

        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IValidateStrategy<TObject> strategy, IValidationHandler handler)
            where TObject : class, IValidatable<TObject>
        {
            instance.AddStrategy(strategy);
            instance.SetValidateHandler(handler);
            return instance.Validate();
        }

        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IEnumerable<IValidateStrategy<TObject>> strategies)
            where TObject : class, IValidatable<TObject>
        {
            instance.AddStrategyList(strategies);
            return instance.Validate();
        }

        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IEnumerable<IValidateStrategy<TObject>> strategies, IValidationHandler handler)
            where TObject : class, IValidatable<TObject>
        {
            instance.AddStrategyList(strategies);
            instance.SetValidateHandler(handler);
            return instance.Validate();
        }
    }
}