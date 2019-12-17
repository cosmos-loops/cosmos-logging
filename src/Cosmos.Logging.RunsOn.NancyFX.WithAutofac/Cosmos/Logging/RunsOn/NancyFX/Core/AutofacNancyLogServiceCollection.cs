namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    /// <summary>
    /// NancyFX-Autofac log service collection
    /// </summary>
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

        internal new void ActiveLogEventEnrichers() {
            base.ActiveLogEventEnrichers();
        }
    }
}