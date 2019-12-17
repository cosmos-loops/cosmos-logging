using System;
using Cosmos.Logging.Extensions.NHibernate.Core;
using NHibernate;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Session factory
    /// </summary>
    public static class SessionFactoryExtensions {
        /// <summary>
        /// Add Cosmos Logging for NHibernate
        /// </summary>
        /// <param name="sf"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseCosmosLogging(this ISessionFactory sf) {
            if (sf is null)
                throw new ArgumentNullException(nameof(sf));
            sf.WithOptions().Interceptor(LoggingInterceptorManager.Get());
        }

        /// <summary>
        /// Add Cosmos Logging for NHibernate
        /// </summary>
        /// <param name="sf"></param>
        /// <param name="interceptor"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseCosmosLogging(this ISessionFactory sf, IInterceptor interceptor) {
            if (sf is null)
                throw new ArgumentNullException(nameof(sf));
            if (interceptor is null)
                throw new ArgumentNullException(nameof(interceptor));
            sf.WithOptions().Interceptor(LoggingInterceptorManager.Get()).Interceptor(interceptor);
        }

        /// <summary>
        /// Add Cosmos Logging for NHibernate
        /// </summary>
        /// <param name="sf"></param>
        /// <param name="interceptors"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseCosmosLogging(this ISessionFactory sf, IInterceptor[] interceptors) {
            if (sf is null)
                throw new ArgumentNullException(nameof(sf));
            if (interceptors is null)
                throw new ArgumentNullException(nameof(interceptors));
            var builder = sf.WithOptions().Interceptor(LoggingInterceptorManager.Get());
            for (var i = 0; i < interceptors.Length; i++) {
                builder.Interceptor(interceptors[i]);
            }
        }
    }
}