using System.Collections.Generic;
using FluentValidation.Results;

namespace Cosmos.Validations {
    public interface IValidationResult : IEnumerable<ValidationResult> {
        int Count { get; }

        bool IsValid { get; }

        long ErrorCode { get; set; }

        string Flag { get; set; }

        void Add(ValidationResult result);

        void AddRange(IEnumerable<ValidationResult> results);

        string ToMessage();
    }
}