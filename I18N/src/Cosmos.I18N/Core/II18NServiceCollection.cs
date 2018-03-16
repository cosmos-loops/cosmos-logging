using System;
using Cosmos.I18N.Configurations;
using Cosmos.I18N.Languages;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.I18N.Core {
    public interface II18NServiceCollection {
        I18NOptions ExposeOptions { get; }
        LanguageManager ExposeLanguageManager { get; }

        II18NServiceCollection AppendOptionsAction(Action<I18NOptions> optionsAct);
        II18NServiceCollection AddDependency(Action<IServiceCollection> servicesAction);

        IServiceProvider Build();

        void BeforeBuild(Action<IServiceCollection> serviceAct);
        void AfterBuild(Action<IServiceProvider> providerAct);
    }
}