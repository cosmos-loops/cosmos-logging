using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNetCore.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for WebHost builder
    /// </summary>
    public static class WebHostBuilderExtensions {
        /// <summary>
        /// Add Cosmos.Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IWebHostBuilder AddCosmosLogging(this IWebHostBuilder builder, Action<ILogServiceCollection> config = null) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            StaticServiceResolveInitialization.UsingSecInitializingActivation = false;
            builder.ConfigureServices((ctx, services) => services.AddCosmosLogging((IConfigurationRoot) ctx.Configuration, config));

            return builder;
        }

        /// <summary>
        /// Add Cosmos.Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="root"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IWebHostBuilder AddCosmosLogging(this IWebHostBuilder builder, IConfigurationRoot root, Action<ILogServiceCollection> config = null) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            StaticServiceResolveInitialization.UsingSecInitializingActivation = false;
            builder.ConfigureServices(services => services.AddCosmosLogging(root, config));

            return builder;
        }
    }
}