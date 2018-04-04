using System.Collections.Generic;

namespace Cosmos.Validations {
    public interface IValidator { }

    public interface IValidator<out TObject> : IValidator
        where TObject : class, IValidatable {
        void Validate(IValidateStrategy<TObject> strategy);

        void Validate(IEnumerable<IValidateStrategy<TObject>> strategies);

        ValidationResultCollection GetValidationResult();
    }
}