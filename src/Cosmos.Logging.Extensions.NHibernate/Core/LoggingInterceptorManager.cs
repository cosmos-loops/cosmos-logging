namespace Cosmos.Logging.Extensions.NHibernate.Core
{
    internal static class LoggingInterceptorManager
    {
        private static LoggingInterceptor LoggingInterceptor { get; set; }

        public static void Create(LoggingInterceptor interceptor)
        {
            LoggingInterceptor = interceptor ?? LoggingInterceptor.Default;
        }

        /// <summary>
        /// Gets global specified logging interceptor
        /// </summary>
        /// <returns></returns>
        public static LoggingInterceptor Get() => LoggingInterceptor;
    }
}