using Cosmos.Logging.RunsOn.AspNet.Core;

namespace Cosmos.Logging.RunsOn.AspNet.Autofac {
    public class AutofacAspNetServiceCollection: AspNetLogServiceCollection {
        internal new void BuildConfiguration() {
            base.BuildConfiguration();
        }

        internal new void ActiveSinkSettings() {
            base.ActiveSinkSettings();
        }

        internal new void ActiveOriginConfiguration() {
            base.ActiveOriginConfiguration();
        }
    }
}