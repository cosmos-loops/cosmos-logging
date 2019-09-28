using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Logging.ExtraSupports {
    public class ContextData : Dictionary<string, ContextDataItem> {
        public ContextData() : base(StringComparer.OrdinalIgnoreCase) { }
        public ContextData(IDictionary<string, ContextDataItem> ctx) : base(ctx, StringComparer.OrdinalIgnoreCase) { }

        #region exception

        public void SetException(Exception exception) => this[ContextDataTypes.Exception] = new ContextDataExceptionItem(exception);

        public bool HasException() => ContainsKey(ContextDataTypes.Exception);

        public Exception GetException() {
            if (!HasException()) return null;
            return this[ContextDataTypes.Exception] as ContextDataExceptionItem;
        }

        #endregion

        #region general opts

        public void AddItem(string name, object value, bool output = true) {
            if (ContainsKey(name)) throw new ArgumentException($"Key '{name}' has been added.", nameof(name));
            if (value is ContextDataItem item) {
                Add(item.Name, item);
            } else {
                Add(name, new ContextDataItem(name, value.GetType(), value, output));
            }
        }

        public void AddOrUpdateItem(string name, object value, bool output = true) {
            if (value is ContextDataItem item) {
                AddOrUpdateInternal(item.Name, item);
            } else {
                AddOrUpdateInternal(name, new ContextDataItem(name, value.GetType(), value, output));
            }
        }

        private void AddOrUpdateInternal(string name, ContextDataItem item) {
            if (ContainsKey(name)) {
                this[name] = item;
            } else {
                Add(name, item);
            }
        }

        #endregion

        internal void ImportUpstreamContextData(ContextData contextData) {
            if (contextData == null) return;
            foreach (var data in contextData) {
                if (ContainsKey(data.Key)) continue;
                Add(data.Key, data.Value);
            }
        }

        public override string ToString()
        {
            if (Count == 0)
                return string.Empty;
            
            var sb = new StringBuilder();
            var fen = "";
            
            sb.Append("[");
            
            foreach (var item in this)
            {
                if(!item.Value.Output)
                    continue;

                sb.Append(fen);
                fen = ",";
                
                sb.Append($"{{\"{item.Key}\":\"{item.Value}\"}}");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}