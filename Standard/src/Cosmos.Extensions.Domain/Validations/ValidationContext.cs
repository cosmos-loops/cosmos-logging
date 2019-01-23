using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Validations
{
    public class ValidationContext<TObject>
        where TObject : class, IValidatable<TObject>
    {
        private TObject Instance { get; set; }
        private List<IValidateStrategy<TObject>> ValidateStrategyList { get; }
        private ValidationResultCollection _resultCollection { get; set; }
        private Action<ValidationHandleOperation> Handle { get; set; }

        public ValidationContext(TObject instanceToValidate)
        {
            Instance = instanceToValidate;
            ValidateStrategyList = new List<IValidateStrategy<TObject>>();
        }

        public void AddStrategy(IValidateStrategy<TObject> strategy)
        {
            if (strategy == null)
                throw new ArgumentNullException(nameof(strategy));
            if (ValidateStrategyList.Any(x => x.StrategyName == strategy.StrategyName))
                return;
            ValidateStrategyList.Add(strategy);
        }

        public void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            foreach (var strategy in strategies)
                AddStrategy(strategy);
        }

        public void SetHandler(Action<ValidationHandleOperation> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (Handle == null)
            {
                Handle = action;
            }
            else
            {
                Handle += action;
            }
        }

        public void RaiseException<TException>(Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            if (_resultCollection != null && !_resultCollection.IsValid)
                _resultCollection.RaiseException(appendAction);
        }

        public void Validate()
        {
            var tempList = ValidateStrategyList.Select(strategy => strategy.Validate(Instance)).ToList();
            _resultCollection = new ValidationResultCollection(tempList);
            Handle?.Invoke(_resultCollection.Handle());
        }

        public void ValidateAndRaise<TException>(Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            Validate();
            RaiseException(appendAction);
        }

        public ValidationResultCollection GetValidationResultCollection()
        {
            return _resultCollection;
        }


        public bool IsValid => _resultCollection?.IsValid ?? true;
    }
}