using System;
using Cosmos.Logging.Extensions.NHibernate.Core;
using NHibernate;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class SessionFactoryExtensions {
        public static void UseCosmosLogging(this ISessionFactory sf) {
            if (sf is null)
                throw new ArgumentNullException(nameof(sf));
            sf.WithOptions().Interceptor(LoggingInterceptorManager.Get());
        }

        public static void UseCosmosLogging(this ISessionFactory sf, IInterceptor interceptor) {
            if (sf is null)
                throw new ArgumentNullException(nameof(sf));
            if (interceptor is null)
                throw new ArgumentNullException(nameof(interceptor));
            sf.WithOptions().Interceptor(LoggingInterceptorManager.Get()).Interceptor(interceptor);
        }

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