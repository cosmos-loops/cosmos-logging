using System;
using System.Text;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Log event context data item
    /// </summary>
    public class ContextDataItem {
        /// <inheritdoc />
        public ContextDataItem(string name, Type type, object value, bool output = true) {
            ItemType = type;
            Value = value;
            Name = name;
            Output = output;
        }

        /// <summary>
        /// Gets name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets item type
        /// </summary>
        public Type ItemType { get; }

        /// <summary>
        /// Gets value
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Output or not.
        /// </summary>
        public bool Output { get; }

        /// <inheritdoc />
        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append("{");

            sb.Append($"\"Name\":\"{Name}\",");
            sb.Append($"\"Type\":\"{ItemType}\",");
            sb.Append($"\"Value\":\"{Value}\"");

            sb.Append("}");

            return sb.ToString();
        }
    }
}