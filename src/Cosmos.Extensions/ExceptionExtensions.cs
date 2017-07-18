using System;

namespace Cosmos
{
    public static class ExceptionExtensions
    {
        public static Exception Unwrap(this Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException(nameof(ex));
            }

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }

        public static string ToUwrapedString(this Exception ex)
        {
            return ex.Unwrap().Message;
        }
    }
}
