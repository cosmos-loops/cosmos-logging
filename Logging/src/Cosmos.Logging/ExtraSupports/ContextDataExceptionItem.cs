using System;

namespace Cosmos.Logging.ExtraSupports {
    public class ContextDataExceptionItem : ContextDataItem {
        public ContextDataExceptionItem(Exception exception)
            : base(ContextDataTypes.Exception, exception.GetType(), exception) { }

        public Exception GetException() {
            return Value as Exception;
        }

        public static implicit operator Exception(ContextDataExceptionItem item) {
            return item.GetException();
        }
    }
}