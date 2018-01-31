//using System;
//using Cosmos.Logging.Sinks.NHibernate.Core;
//using NHibernate;
//
//// ReSharper disable once CheckNamespace
//namespace Cosmos.Logging {
//    public static class SessionFactoryExtensions {
//        internal static LoggingInterceptor GlobalSpecifiedLoggingInterceptor { get; set; }
//
//        public static void UseCosmosLogging(this ISessionFactory sf) {
//            if (sf == null) throw new ArgumentNullException(nameof(sf));
//            sf.WithOptions().Interceptor(GlobalSpecifiedLoggingInterceptor);
//        }
//
//        public static void UseCosmosLogging(this ISessionFactory sf, IInterceptor interceptor) {
//            if (sf == null) throw new ArgumentNullException(nameof(sf));
//            if (interceptor == null) throw new ArgumentNullException(nameof(interceptor));
//            sf.WithOptions().Interceptor(GlobalSpecifiedLoggingInterceptor).Interceptor(interceptor);
//        }
//
//        public static void UseCosmosLogging(this ISessionFactory sf, IInterceptor[] interceptors) {
//            if (sf == null) throw new ArgumentNullException(nameof(sf));
//            if (interceptors == null) throw new ArgumentNullException(nameof(interceptors));
//            var builder = sf.WithOptions().Interceptor(GlobalSpecifiedLoggingInterceptor);
//            for (var i = 0; i < interceptors.Length; i++) {
//                builder.Interceptor(interceptors[i]);
//            }
//        }
//    }
//}