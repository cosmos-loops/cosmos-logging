using Cosmos.I18N.Core;
using Cosmos.I18N.RunsOn.Console;
using Cosmos.I18N.RunsOn.Console.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.I18N {
    public static class DoneExtensions {
        public static void AllDone(this II18NServiceCollection services) {
            SoloDependencyContainer.AllDone(services);
        }
    }
}