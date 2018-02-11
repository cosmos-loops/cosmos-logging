using Cosmos.Logging.RunsOn.NancyFX.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class AutofacNancyLogServiceCollection : NancyLogServiceCollection {

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