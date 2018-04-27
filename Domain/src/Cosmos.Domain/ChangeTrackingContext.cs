using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Extensions;

namespace Cosmos.Domain {
    public sealed class ChangeTrackingContext {
        private readonly ChangedValueDescriptorCollection _changedValueCollection;

        public ChangeTrackingContext() {
            _changedValueCollection = new ChangedValueDescriptorCollection();
        }

        public ChangeTrackingContext(ChangedValueDescriptorCollection collection) {
            _changedValueCollection = collection == null
                ? new ChangedValueDescriptorCollection()
                : new ChangedValueDescriptorCollection(collection);
        }

        public void Add<TValue>(string propertyName, string description, TValue valueBeforeChange, TValue valueAfterChange) {
            if (Equals(valueBeforeChange, valueAfterChange))
                return;

            var stringBeforeChange = valueBeforeChange.SafeString().ToLower().Trim();
            var stringAfterChange = valueAfterChange.SafeString().ToLower().Trim();
            if (stringBeforeChange == stringAfterChange)
                return;

            _changedValueCollection.Add(propertyName, description, stringBeforeChange, stringAfterChange);
        }

        public void Add<TObject>(IChangeTrackable<TObject> leftObj, TObject rightObj)
            where TObject : IDomainObject {
            if (Equals(leftObj, null))
                return;
            if (Equals(rightObj, null))
                return;

            _changedValueCollection.AddRange(leftObj.GetChanges(rightObj));
        }

        public void Add<TObject, TProperty, TValue>(Expression<Func<TObject, TProperty>> expression, TValue newValue)
            where TObject : IDomainObject {
            var name = Lambdas.GetName(expression);
            var desc = Reflections.GetDescription(Lambdas.GetMember(expression));
            var value = Lambdas.GetValue(expression);
            Add(name, desc, value.CastTo<TValue>(), newValue);
        }

        public void Add<TObject>(IEnumerable<IChangeTrackable<TObject>> leftObjs, IEnumerable<TObject> rightObjs)
            where TObject : IDomainObject {
            if (Equals(leftObjs, null))
                return;
            if (Equals(rightObjs, null))
                return;

            var leftObjList = leftObjs.ToList();
            var rightObjList = rightObjs.ToList();

            var length = leftObjList.Count > rightObjList.Count
                ? rightObjList.Count
                : leftObjList.Count;

            for (var i = 0; i < length; i++)
                Add(leftObjList[i], rightObjList[i]);
        }

        public void Populate(ChangedValueDescriptorCollection collection) {
            _changedValueCollection.Populate(collection);
        }

        public void FlushCache() {
            _changedValueCollection.FlushCache();
        }

        public ChangedValueDescriptorCollection GetChangedValueDescriptor() {
            return _changedValueCollection;
        }

        public string Output() {
            return _changedValueCollection.ToString();
        }

        public override string ToString() {
            return Output();
        }
    }
}