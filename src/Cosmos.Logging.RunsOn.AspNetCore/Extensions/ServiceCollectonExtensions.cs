using System;
using Cosmos.Logging;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNetCore;
using Cosmos.Logging.RunsOn.AspNetCore.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection {
    public static class ServiceCollectonExtensions {
        public static IServiceCollection AddCosmosLogging(this IServiceCollection services, IConfigurationRoot root, Action<ILogServiceCollection> config) {
            return RegisterToAspNetCore(services, root, config);
        }

        private static IServiceCollection RegisterToAspNetCore(IServiceCollection services, IConfigurationRoot root, Action<ILogServiceCollection> config = null) {
            var servicesImpl = new AspNetCoreLogServiceCollection(services, root);

            config?.Invoke(servicesImpl);

            services.TryAdd(ServiceDescriptor.Scoped<IHttpContextAccessor, HttpContextAccessor>());
            services.TryAdd(ServiceDescriptor.Singleton<ILoggingServiceProvider, AspNetCoreLoggingServiceProvider>());
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(AspNetCoreLoggerWrapper<>)));

            servicesImpl.BuildConfiguration();
            servicesImpl.ActiveSinkSettings();
            servicesImpl.ActiveOriginConfiguration();

            services.TryAdd(ServiceDescriptor.Singleton(Options.Options.Create((LoggingOptions) servicesImpl.ExposeLogSettings())));
            services.TryAdd(ServiceDescriptor.Singleton(servicesImpl.ExposeLoggingConfiguration()));
            services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory>(provider => new AspNetCoreLoggerFactory(provider.GetService<ILoggingServiceProvider>())));

            if (StaticServiceResolveInitialization.UsingSecInitializingActivation) {
                services.TryAdd(ServiceDescriptor.Singleton<ISecInitializingActivation>(provider => {
                    var initializingActivationImpl = new AspNetCoreSecInitializingActivation();
                    initializingActivationImpl.AppendAction(() => StaticServiceResolver.SetResolver(provider.GetRequiredService<ILoggingServiceProvider>()));
                    return initializingActivationImpl;
                }));
            } else {
                services.TryAdd(ServiceDescriptor.Singleton(provider => new StaticServiceResolveInitialization(provider.GetRequiredService<ILoggingServiceProvider>())));
            }


            return services;
        }

        public static IApplicationBuilder UseCosmosLogging(this IApplicationBuilder app) {
            var initializingActivationImpl = app.ApplicationServices.GetService<ISecInitializingActivation>();
            initializingActivationImpl?.GetSecProcessing()?.Invoke();

            return app;
        }
    }
}