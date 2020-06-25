#if NET461

using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Internals;
using Cosmos.Logging.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting {
    /// <summary>
    /// Extensions for Microsoft generic host 
    /// </summary>
    public static class GenericHostExtensions {
        /// <summary>
        /// Add Cosmos Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="serviceConfigure"></param>
        /// <returns></returns>
        public static IHostBuilder AddCosmosLogging(
            this IHostBuilder builder,
            Action<ILogServiceCollection> serviceConfigure = null) {

            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices((ctx, services) => {

                var loggingServices = services.AddCosmosLogging(ctx.Configuration as IConfigurationRoot);

                serviceConfigure?.Invoke(loggingServices);

                loggingServices.AppendOrOverride();

                loggingServices.AddDependency(s => s.TryAddScoped<IHttpContextAccessor, HttpContextAccessor>());

                loggingServices.Done();
            });

            builder.ConfigureContainer<IServiceProvider>((ctx, resolver) => {
                var callback = resolver.GetRequiredService<StandardSecInitializingCallback>();
                callback?.Invoke();
            });

            return builder;
        }
    }
}

#endif