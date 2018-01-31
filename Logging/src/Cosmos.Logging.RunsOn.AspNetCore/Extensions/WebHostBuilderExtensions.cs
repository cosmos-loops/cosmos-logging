using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNetCore.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class WebHostBuilderExtensions {
        public static IWebHostBuilder AddCosmosLogging(this IWebHostBuilder builder, Action<ILogServiceCollection> config = null) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            HackStaticInstance.UsingSecInitializingActivation = false;
            builder.ConfigureServices((ctx, services) => services.AddCosmosLogging((IConfigurationRoot) ctx.Configuration, config));

            return builder;
        }

        public static IWebHostBuilder AddCosmosLogging(this IWebHostBuilder builder, IConfigurationRoot root, Action<ILogServiceCollection> config = null) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            HackStaticInstance.UsingSecInitializingActivation = false;
            builder.ConfigureServices(services => services.AddCosmosLogging(root, config));

            return builder;
        }
    }
}