using System;

namespace Cosmos.Logging.MessageTemplates {
    public class MessageProperty : IMessageProperty {
        public MessageProperty(string name, int index, MessagePropertyValue value) {
            CheckParams(name, index, value);
            Name = name;
            Value = value;
            Index = index;
        }

        public string Name { get; }
        public MessagePropertyValue Value { get; }
        public readonly int Index;

        private static void CheckParams(string name, int index, MessagePropertyValue value) {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
    }
}