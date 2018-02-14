using System;
using System.Linq;
using Cosmos.I18N;
using Cosmos.I18N.Configurations;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;
using Cosmos.I18N.RunsOn.AspNetCore;
using Cosmos.I18N.RunsOn.AspNetCore.Core;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddCosmosLocalization(this IServiceCollection services, Action<I18NOptions> optionAct) {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var options = new I18NOptions();
            optionAct?.Invoke(options);

            var languageManager = new LanguageManager();
            foreach (var lang in options.RegisteredLanguages) languageManager.RegisterUsedLangage(lang);
            foreach (var package in options.LanguagePackages) services.AddSingleton(package.Value);

            services.AddSingleton(languageManager);
            services.AddSingleton<ILanguageServiceProvider, AspNetCoreLanguageServiceProvider>();
            services.AddSingleton(provider => new TranslationProcessor(provider.GetServices<ILanguagePackage>().ToDictionary(package => package.Language.Name)));
            services.AddSingleton(provider => new StaticProviderHack(provider.GetRequiredService<ILanguageServiceProvider>()));

            return services;
        }
    }
}