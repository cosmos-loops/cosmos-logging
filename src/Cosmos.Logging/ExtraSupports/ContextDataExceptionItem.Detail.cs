using System;
using System.Collections.Generic;

namespace Cosmos.Logging.ExtraSupports
{
    public class ContextDataExceptionDetail : ContextDataItem
    {
        public ContextDataExceptionDetail(string rootName, IReadOnlyDictionary<string, object> destructuredObject, Exception exception, bool output)
            : base(rootName, exception.GetType(), destructuredObject, output) { }

        public IReadOnlyDictionary<string, object> GetExceptionDetail() {
            return Value as IReadOnlyDictionary<string, object>;
        }
        
        public static implicit operator (string, IReadOnlyDictionary<string, object>)(ContextDataExceptionDetail item) {
            return (item.Name, item.GetExceptionDetail());
        }
    }
}