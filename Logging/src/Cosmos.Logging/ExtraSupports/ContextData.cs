using System;
using System.Collections.Generic;

namespace Cosmos.Logging.ExtraSupports {
    public class ContextData : Dictionary<string, object> {
        public ContextData() : base(StringComparer.OrdinalIgnoreCase) { }
        public ContextData(IDictionary<string, object> ctx) : base(ctx, StringComparer.OrdinalIgnoreCase) { }

        public void SetException(Exception exception) => this[ContextDataTypes.Exception] = exception;

        public bool HasException() => ContainsKey(ContextDataTypes.Exception);
    }
}