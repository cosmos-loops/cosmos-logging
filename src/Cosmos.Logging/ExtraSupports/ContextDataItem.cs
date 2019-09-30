using System;
using System.Text;

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

        public override string ToString()
        {
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