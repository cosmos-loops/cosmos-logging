using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cosmos.Validations;

namespace Cosmos.Domain
{
    public abstract class DomainObject<TObject> : IDomainObject, IValidatable<TObject>, IChangeTrackable<TObject>
        where TObject : class, IDomainObject, IValidatable<TObject>
    {
        private readonly ValidationContext<TObject> _validationContext;
        private readonly DescriptionContext _descriptionContext;
        private readonly ChangeTrackingContext _changeTrackingContext;

        protected DomainObject()
        {
            _validationContext = new ValidationContext<TObject>(AssignableType(this));
            _descriptionContext = new DescriptionContext();
            _changeTrackingContext = new ChangeTrackingContext();
        }

        #region Validation

        public void SetValidateHandler(IValidationHandler handler)
        {
            _validationContext.SetHandler(op => op.HandleAll(handler));
        }

        public void AddStrategy(IValidateStrategy<TObject> strategy)
        {
            _validationContext.AddStrategy(strategy);
        }

        public void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies)
        {
            _validationContext.AddStrategyList(strategies);
        }

        public ValidationResultCollection Validate()
        {
            _validationContext.Validate();
            return _validationContext.GetValidationResultCollection();
        }

        #endregion

        #region Change Tracking

        protected virtual void AddChanges(TObject newObj) { }

        protected void AddChange<TProperty, TValue>(Expression<Func<TObject, TProperty>> expression, TValue newValue)
        {
            _changeTrackingContext.Add(expression, newValue);
        }

        protected void AddChange<TValue>(string propertyName, string description, TValue valueBeforeChange,
            TValue valueAfterChange)
        {
            _changeTrackingContext.Add(propertyName, description, valueBeforeChange, valueAfterChange);
        }

        protected void AddChange(IChangeTrackable<TObject> objectBeforeChangeTrackable, TObject objectAfterChange)
        {
            _changeTrackingContext.Add(objectBeforeChangeTrackable, objectAfterChange);
        }

        protected void AddChange(IEnumerable<IChangeTrackable<TObject>> leftObjs, IEnumerable<TObject> rightObjs)
        {
            _changeTrackingContext.Add(leftObjs, rightObjs);
        }

        public ChangedValueDescriptorCollection GetChanges(TObject newObj)
        {
            _changeTrackingContext.FlushCache();
            if (Equals(newObj, null))
                return _changeTrackingContext.GetChangedValueDescriptor();
            AddChanges(newObj);
            return _changeTrackingContext.GetChangedValueDescriptor();
        }

        #endregion

        #region Description

        protected virtual void AddDescription() { }

        protected void AddDescription(string description)
        {
            _descriptionContext.Add(description);
        }

        protected void AddDescription<TValue>(string name, TValue value)
        {
            _descriptionContext.Add(name, value);
        }

        #endregion

        #region Misc

        private TObject AssignableType(DomainObject<TObject> me) => me as TObject;

        #endregion

        public override string ToString()
        {
            _descriptionContext.FlushCache();
            AddDescription();
            return _descriptionContext.Output();
        }
    }
}