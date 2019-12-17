using System;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Message property
    /// </summary>
    public class MessageProperty : IMessageProperty {
       
        /// <summary>
        /// Create a new instance of <see cref="MessageProperty"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="positionalValue"></param>
        /// <param name="value"></param>
        public MessageProperty(string name, int positionalValue, MessagePropertyValue value) {
            CheckParams(name, positionalValue, value);
            Name = name;
            Value = value;
            PositionalValue = positionalValue;
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public MessagePropertyValue Value { get; }

        /// <summary>
        /// Positional value
        /// </summary>
        public readonly int PositionalValue;

        /// <summary>
        /// As named property
        /// </summary>
        public bool AsNamedProperty { get; set; }

        /// <summary>
        /// As positional property
        /// </summary>
        public bool AsPositionalProperty { get; set; }

        private static void CheckParams(string name, int positionalValue, MessagePropertyValue value) {
            if (positionalValue < -1) throw new ArgumentOutOfRangeException(nameof(positionalValue));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
    }
}