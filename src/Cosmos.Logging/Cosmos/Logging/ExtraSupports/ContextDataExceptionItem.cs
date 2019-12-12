using System;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Log event context data exception item
    /// </summary>
    public class ContextDataExceptionItem : ContextDataItem {
        /// <inheritdoc />
        public ContextDataExceptionItem(Exception exception)
            : base(ContextDataTypes.Exception, exception.GetType(), exception) { }

        /// <summary>
        /// Get exception
        /// </summary>
        /// <returns></returns>
        public Exception GetException() {
            return Value as Exception;
        }

        /// <summary>
        /// ╮(￣▽￣")╭
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static implicit operator Exception(ContextDataExceptionItem item) {
            return item.GetException();
        }
    }
}