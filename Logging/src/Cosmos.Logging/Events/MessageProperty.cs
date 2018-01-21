using System;

namespace Cosmos.Logging.Events {
    public class MessageProperty : IMessageProperty {
        public MessageProperty(string name, int positionalIndex, MessagePropertyValue value) {
            CheckParams(name, positionalIndex, value);
            Name = name;
            Value = value;
            PositionalIndex = positionalIndex;
        }

        public string Name { get; }
        public MessagePropertyValue Value { get; }
        public int PositionalIndex { get; set; }
        
        public bool AsNamedProperty { get; set; }
        public bool AsPositionalProperty { get; set; }

        private static void CheckParams(string name, int positionalIndex, MessagePropertyValue value) {
            if (positionalIndex < -1) throw new ArgumentOutOfRangeException(nameof(positionalIndex));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
    }
}