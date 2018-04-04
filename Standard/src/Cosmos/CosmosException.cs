using System;
using System.Collections.Generic;

namespace Cosmos {
    // ReSharper disable InconsistentNaming
    public abstract class CosmosException : Exception {
        protected const string EMPTY_FLAG = "__EMPTY_FLG";
        protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";
        protected const long DEFAULT_ERROR_CODE = 1001;
        protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

        protected CosmosException()
            : this(DEFAULT_ERROR_CODE, DEFAULT_ERROR_MESSAGE, EMPTY_FLAG) { }

        protected CosmosException(string errorMessage, Exception innerException = null)
            : this(errorMessage, EMPTY_FLAG, innerException) { }

        protected CosmosException(string errorMessage, string flag, Exception innerException = null)
            : this(DEFAULT_EXTEND_ERROR_CODE, errorMessage, flag, innerException) { }

        protected CosmosException(long errorCode, string errorMessage, Exception innerException = null)
            : this(errorCode, errorMessage, EMPTY_FLAG, innerException) { }

        protected CosmosException(long errorCode, string errorMessage, string flag, Exception innerException = null)
            : base(errorMessage, innerException) {
            if (string.IsNullOrWhiteSpace(flag)) {
                flag = EMPTY_FLAG;
            }

            ExtraData = new Dictionary<string, object>();
            Code = errorCode;
            Flag = flag;
        }

        public long Code { get; }

        public string Flag { get; }

        public Dictionary<string, object> ExtraData { get; }

        public virtual string GetFullMessage() => $"{Code}:({Flag}){Message}";
    }
}