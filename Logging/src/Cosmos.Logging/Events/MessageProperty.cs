using System;

namespace Cosmos.Logging.Events {
    public class MessageProperty : IMessageProperty {
        public MessageProperty(string name, int positionalValue, MessagePropertyValue value) {
            CheckParams(name, positionalValue, value);
            Name = name;
            Value = value;
            PositionalValue = positionalValue;
        }

        public string Name { get; }
        public MessagePropertyValue Value { get; }
        public readonly int PositionalValue;

        public bool AsNamedProperty { get; set; }
        public bool AsPositionalProperty { get; set; }

        private static void CheckParams(string name, int positionalValue, MessagePropertyValue value) {
            if (positionalValue < -1) throw new ArgumentOutOfRangeException(nameof(positionalValue));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
    }
}