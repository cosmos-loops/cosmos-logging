using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Filters.Navigators;
using EnumsNET;

namespace Cosmos.Logging {
    public partial class LoggingConfiguration {
        private void SetSelf(LoggingConfiguration configuration) {
            var settings = _loggingSettings as LoggingOptions ?? LoggingOptions.Defaults;

            if (configuration == null) {
                IncludeScopes = false;
                LogLevel = new Dictionary<string, string> {{"Default", "Information"}};
            } else {
                IncludeScopes = configuration.IncludeScopes;
                LogLevel = configuration.LogLevel;
            }
            
            Aliases.MergeAndOverWrite(settings.InternalAliases, k => k, v => v.GetName());
            LogLevel.MergeAndOverWrite(settings.InternalNavigatorLogEventLevels, k => k, v => v.GetName());

            foreach (var item in LogLevel) {
                var nav = _namespaceNavigatorCache.Parse(item.Key, item.Value, out _);
                if (nav is EmptyNamespaceNavigationNode) continue;
                if (!_namespaceFilterNavRoots.Contains(nav)) {
                    _namespaceFilterNavRoots.Add(nav);
                }
            }

            NavigationFilterProcessor.SetGlobalFilterNavMatcher(_namespaceNavigatorCache,
                settings.MinimumLevel.HasValue
                    ? settings.MinimumLevel.Value.GetName()
                    : LogLevel.TryGetValue("Default", out var x)
                        ? x
                        : LogEventLevelConstants.Verbose);

            foreach (var item in Aliases) {
                LogEventLevelAliasManager.AddAlias(item.Key, LogEventLevelConverter.Convert(item.Value));
            }
        }
    }
}