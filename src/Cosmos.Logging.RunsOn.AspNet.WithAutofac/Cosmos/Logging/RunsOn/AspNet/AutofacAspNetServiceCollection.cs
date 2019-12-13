using Cosmos.Logging.RunsOn.AspNet.Core;

namespace Cosmos.Logging.RunsOn.AspNet {
    /// <summary>
    /// ASP.NET-Autofac service collection
    /// </summary>
    public class AutofacAspNetServiceCollection : AspNetLogServiceCollection {
        internal new void BuildConfiguration() {
            base.BuildConfiguration();
        }

        internal new void ActiveSinkSettings() {
            base.ActiveSinkSettings();
        }

        internal new void ActiveOriginConfiguration() {
            base.ActiveOriginConfiguration();
        }

        internal new void ActiveLogEventEnrichers() {
            base.ActiveLogEventEnrichers();
        }
    }
}