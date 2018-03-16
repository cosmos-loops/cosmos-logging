using System;
using System.Linq;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.I18N.RunsOn.Console.Core {
    internal static class SoloDependencyContainer {
        private static IServiceProvider ServiceResolver { get; set; }
        public static void SetResolver(IServiceProvider resolver) => ServiceResolver = resolver;

        internal static I18NServiceCollection Initialize(I18NServiceCollection serviceImpl) {

            return serviceImpl;
        }

        internal static void AllDone(II18NServiceCollection services) {
            if (services is I18NServiceCollection serviceImpl) {
                var languageManager = serviceImpl.ExposeLanguageManager;
                foreach (var lang in serviceImpl.ExposeOptions.RegisteredLanguages) languageManager.RegisterUsedLangage(lang);
                foreach (var package in serviceImpl.ExposeOptions.LanguagePackages) serviceImpl.AddDependency(s => s.AddSingleton(package.Value));

                serviceImpl.AddDependency(s => {
                    s.AddSingleton(languageManager);
                    s.AddSingleton<ILanguageServiceProvider, ConsoleLanguageServiceProvider>();
                    s.AddSingleton(provider => new TranslationProcessor(provider.GetServices<ILanguagePackage>().ToDictionary(package => package.Language)));

                });
            }

            SetResolver(services.Build());
        }

        public static IServiceProvider GetServiceResolver() => ServiceResolver ?? throw new NullReferenceException(nameof(ServiceResolver));
    }
}