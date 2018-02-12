using System;

namespace Cosmos.Logging.ExtraSupports {
    public class ContextDataItem {
        public ContextDataItem(string name, Type type, object value, bool output = true) {
            ItemType = type;
            Value = value;
            Name = name;
            Output = output;
        }

        public string Name { get; }

        public Type ItemType { get; }

        public object Value { get; }

        public bool Output { get; }
    }
}