using System;
using FluentValidation;

namespace Cosmos.Validations {
    public abstract class ValidateStrategy<TObject> : AbstractValidator<TObject>, IValidateStrategy<TObject>
        where TObject : class, IValidatable {
        protected ValidateStrategy(string name) {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);

            StrategyName = name;
        }

        public string StrategyName { get; }
    }
}