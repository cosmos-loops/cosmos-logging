using Cosmos.I18N.RunsOn.Console.Core;

namespace Cosmos.I18N.RunsOn.Console {
    public static class CosmosLocalization {
        public static I18NServiceCollection Initialize() {
            return SoloDependencyContainer.Initialize(new I18NServiceCollection());
        }
    }
}