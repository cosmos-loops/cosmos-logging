using System;
using Cosmos.I18N.Configurations;
using Cosmos.I18N.RunsOn.Console.Core;

namespace Cosmos.I18N.RunsOn.Console {
    public static class CosmosLocalization {
        public static I18NServiceCollection Initialize(Action<I18NOptions> optionAct) {
            var serviceImpl = new I18NServiceCollection();
            serviceImpl.AppendOptionsAction(optionAct);
            return SoloDependencyContainer.Initialize(serviceImpl);
        }
    }
}