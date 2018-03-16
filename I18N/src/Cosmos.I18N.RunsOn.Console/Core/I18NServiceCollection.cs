using System;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Cosmos.I18N.Configurations;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.I18N.RunsOn.Console.Core {
    public class I18NServiceCollection : II18NServiceCollection {
        private bool _hasBuild;
        private readonly IServiceCollection _services;
        private readonly I18NOptions _options;
        private readonly LanguageManager _languageManager;

        public I18NServiceCollection(IServiceCollection services = null, I18NOptions options = null) {
            _services = services ?? new ServiceCollection();
            _options = options ?? new I18NOptions();
            _languageManager = new LanguageManager();

            AfterBuild(UpdateStaticResolver);
        }

        public II18NServiceCollection AppendOptionsAction(Action<I18NOptions> optionsAct) {
            if (_hasBuild) {
                throw new InvalidOperationException("Cannot update options after building.");
            }

            optionsAct?.Invoke(_options);
            return this;
        }

        public II18NServiceCollection AddDependency(Action<IServiceCollection> servicesAction) {
            if (_hasBuild) {
                throw new InvalidOperationException("Cannot add dependency after building.");
            }

            servicesAction?.Invoke(_services);
            return this;
        }

        public IServiceProvider Build() {
            if (_hasBuild) {
                throw new InvalidOperationException("Only can be built once.");
            }

            BeforeBuildAction?.Invoke(_services);

            var resolver = _services.ToServiceContainer().Build();

            AfterBuildAction?.Invoke(resolver);

            _hasBuild = true;

            return resolver;
        }

        private Action<IServiceCollection> BeforeBuildAction { get; set; }
        private Action<IServiceProvider> AfterBuildAction { get; set; }

        public void BeforeBuild(Action<IServiceCollection> serviceAct) {
            if (serviceAct != null) {
                BeforeBuildAction += serviceAct;
            }
        }

        public void AfterBuild(Action<IServiceProvider> providerAct) {
            if (providerAct != null) {
                AfterBuildAction += providerAct;
            }
        }

        public I18NOptions ExposeOptions => _options;

        public LanguageManager ExposeLanguageManager => _languageManager;

        private static void UpdateStaticResolver(IServiceProvider resolver) {
            StaticInstanceForILanguageServiceProvider.SetInstance(resolver.GetRequiredService<ILanguageServiceProvider>());
        }
    }
}