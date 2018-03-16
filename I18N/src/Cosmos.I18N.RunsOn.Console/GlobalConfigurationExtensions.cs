using System;
using Cosmos.I18N.Configurations;
using Cosmos.I18N.Core;

namespace Cosmos.I18N.RunsOn.Console {
    public static class GlobalConfigurationExtensions {
        public static II18NServiceCollection ToGlobal(this II18NServiceCollection services, Action<I18NOptions> optionsAct) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (optionsAct == null) throw new ArgumentNullException(nameof(optionsAct));

            services.AppendOptionsAction(optionsAct);

            return services;
        }
    }
}