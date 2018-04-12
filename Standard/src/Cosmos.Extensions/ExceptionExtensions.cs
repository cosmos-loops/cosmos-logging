using System;
using System.Text;

namespace Cosmos {
    public static class ExceptionExtensions {
        public static Exception Unwrap(this Exception ex) {
            if (ex == null) {
                throw new ArgumentNullException(nameof(ex));
            }

            while (ex.InnerException != null) {
                ex = ex.InnerException;
            }

            return ex;
        }

        public static Exception Unwrap(this Exception ex, Type untilType, bool canbeSubClass = true) {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));
            if (untilType == null)
                throw new ArgumentNullException(nameof(untilType));
            if (!untilType.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{untilType}' does not devide from {typeof(Exception)}", nameof(untilType));
            if (ex.InnerException == null)
                return null;
            var exception = ex.Unwrap();
            return exception.GetType() == untilType || canbeSubClass && exception.GetType().IsSubclassOf(untilType)
                ? exception
                : Unwrap(exception, untilType);
        }

        public static Exception Unwrap<TException>(this Exception ex)
            where TException : Exception {
            return ex.Unwrap(Types.Of<TException>());
        }

        public static string ToUnwrapedString(this Exception ex) {
            return ex.Unwrap().Message;
        }

        public static string ToFullUnwrapedString(this Exception ex) {
            StringBuilder sb = new StringBuilder();
            if (ex is CosmosException cosmosException) {
                sb.AppendLine(cosmosException.GetFullMessage());
                if (ex.InnerException != null) {
                    sb.Append(ex.InnerException.ToUnwrapedString());
                }
            } else {
                sb.Append(ex.ToUnwrapedString());
            }

            return sb.ToString();
        }
    }
}