using System.Collections.Generic;

namespace Cosmos.Validations
{
    public interface IValidatable { }

    public interface IValidatable<TObject> : IValidatable
        where TObject : class, IValidatable
    {
        void SetValidateHandler(IValidationHandler handler);

        void AddStrategy(IValidateStrategy<TObject> strategy);

        void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies);

        ValidationResultCollection Validate();
    }
}