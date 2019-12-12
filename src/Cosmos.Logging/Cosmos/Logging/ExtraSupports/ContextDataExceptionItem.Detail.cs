using System;
using System.Collections.Generic;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Log event context data exception detail
    /// </summary>
    public class ContextDataExceptionDetail : ContextDataItem {
        /// <inheritdoc />
        public ContextDataExceptionDetail(string rootName, IReadOnlyDictionary<string, object> destructuredObject, Exception exception, bool output)
            : base(rootName, exception.GetType(), destructuredObject, output) { }

        /// <summary>
        /// Get exception detail
        /// </summary>
        /// <returns></returns>
        public IReadOnlyDictionary<string, object> GetExceptionDetail() {
            return Value as IReadOnlyDictionary<string, object>;
        }

        /// <summary>
        /// -________-''
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static implicit operator (string, IReadOnlyDictionary<string, object>)(ContextDataExceptionDetail item) {
            return (item.Name, item.GetExceptionDetail());
        }
    }
}