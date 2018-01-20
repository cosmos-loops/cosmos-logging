using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Settings {
    public static class MessageParameterProcessorActivation {
        public static void ActiveMessageParameterProcessor(this ILogServiceCollection services) {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var settings = services.ExposeLogSettings();
            var destructure = settings?.GetDestructure() ?? new DestructureConfiguration();

            var resolver = new MessageParameterResolver(
                destructure.MaximumLengthOfString,
                destructure.MaximumLevelOfNestLevelLimited,
                destructure.MaximumLoopCountForCollection,
                destructure.AdditionalScalarTypes,
                destructure.AdditionalDestructureResolveRules,
                false);
            
            MessageParameterProcessorCache.Set(new MessageParameterProcessor(resolver));
        }
    }
}