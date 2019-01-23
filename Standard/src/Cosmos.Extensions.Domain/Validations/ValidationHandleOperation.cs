using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Cosmos.Validations
{
    public sealed class ValidationHandleOperation
    {
        private readonly ValidationResultCollection _collection;

        public ValidationHandleOperation(ValidationResultCollection collection)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        internal void Handle(IValidationHandler handler, Action<IEnumerable<ValidationResult>> filterFunc = null)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            var coll = filterFunc == null ? _collection : _collection.Filter(filterFunc);

            if (coll == null)
                return;

            handler.Handle(coll);
        }

        internal void Handle(IValidationHandler handler, string strategyName)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            var coll = _collection.Filter(strategyName);

            if (coll == null)
                return;

            handler.Handle(coll);
        }

        public void RaiseException<TException>(Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            _collection.RaiseException(appendAction);
        }
    }
}