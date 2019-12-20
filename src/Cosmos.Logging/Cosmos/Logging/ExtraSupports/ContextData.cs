using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Logging event context data
    /// </summary>
    public class ContextData : Dictionary<string, ContextDataItem> {
        /// <inheritdoc />
        public ContextData() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <inheritdoc />
        public ContextData(IDictionary<string, ContextDataItem> ctx) : base(ctx, StringComparer.OrdinalIgnoreCase) { }

        #region exception

        /// <summary>
        /// Set exception
        /// </summary>
        /// <param name="exception"></param>
        public void SetException(Exception exception) => this[ContextDataTypes.Exception] = new ContextDataExceptionItem(exception);

        /// <summary>
        /// Set exception detail
        /// </summary>
        /// <param name="rootName"></param>
        /// <param name="destructuredObject"></param>
        /// <param name="exception"></param>
        /// <param name="output"></param>
        public void SetExceptionDetail(string rootName, IReadOnlyDictionary<string, object> destructuredObject, Exception exception, bool output) =>
            this[ContextDataTypes.ExceptionDetail] = new ContextDataExceptionDetail(rootName, destructuredObject, exception, output);

        /// <summary>
        /// Has exception
        /// </summary>
        /// <returns></returns>
        public bool HasException() => ContainsKey(ContextDataTypes.Exception);

        /// <summary>
        /// Has exception detail
        /// </summary>
        /// <returns></returns>
        public bool HasExceptionDetail() => ContainsKey(ContextDataTypes.ExceptionDetail);

        /// <summary>
        /// Get exception
        /// </summary>
        /// <returns></returns>
        public Exception GetException() {
            if (!HasException()) return null;
            return this[ContextDataTypes.Exception] as ContextDataExceptionItem;
        }

        /// <summary>
        /// Get exception detail
        /// </summary>
        /// <returns></returns>
        public (string RootName, IReadOnlyDictionary<string, object> DestructuredObject) GetExceptionDetail() {
            if (!HasExceptionDetail()) return (string.Empty, null);
            return this[ContextDataTypes.ExceptionDetail] as ContextDataExceptionDetail;
        }

        /// <summary>
        /// Get exception detail name
        /// </summary>
        /// <returns></returns>
        public string GetExceptionDetailName() {
            return GetExceptionDetail().RootName;
        }

        #endregion

        #region general opts

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="output"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddItem(string name, object value, bool output = true) {
            if (ContainsKey(name)) throw new ArgumentException($"Key '{name}' has been added.", nameof(name));
            if (value is ContextDataItem item) {
                Add(item.Name, item);
            } else {
                Add(name, new ContextDataItem(name, value.GetType(), value, output));
            }
        }

        /// <summary>
        /// Add or update item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="output"></param>
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

        #region Import and export upstream context data

        private ContextData CurrentUpstreamContextPointer { get; set; }

        internal void ImportUpstreamContextData(ContextData contextData) {
            if (contextData == null) return;

            CurrentUpstreamContextPointer = contextData;

            foreach (var data in contextData) {
                if (ContainsKey(data.Key))
                    continue;
                Add(data.Key, data.Value);
            }
        }

        internal ContextData ExportUpstreamContextData() => CurrentUpstreamContextPointer;

        #endregion

        /// <inheritdoc />
        public override string ToString() {
            if (Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            var fen = "";

            sb.Append("[");

            foreach (var item in this) {
                if (!item.Value.Output)
                    continue;

                sb.Append(fen);
                fen = ",";

                sb.Append($"{{\"{item.Key}\":\"{item.Value}\"}}");
            }

            sb.Append("]");

            return sb.ToString();
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <returns></returns>
        public ContextData Copy() => new ContextData(this);
    }
}