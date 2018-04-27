namespace Cosmos.Domain {
    /// <summary>
    /// To descript what value has been changed
    /// </summary>
    public class ChangedValueDescriptor {
        public ChangedValueDescriptor(string propertyName, string description, string oldValue, string newValue) {
            PropertyName = propertyName;
            Description = description;
            ValueBeforeChange = oldValue;
            ValueAfterChange = newValue;
        }

        public string PropertyName { get; }
        public string Description { get; }
        public string ValueBeforeChange { get; }
        public string ValueAfterChange { get; }

        public override string ToString() {
            return $"{PropertyName}({Description}), old value is {ValueBeforeChange} and new value is {ValueAfterChange}";
        }
    }
}