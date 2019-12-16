using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;
using Cosmos.Logging.Sinks.File.Strategies;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    /// <summary>
    /// Namespace navigation parser
    /// </summary>
    public class NamespaceNavigationParser : IFileSinkNamespaceNavigationParser {
        /// <inheritdoc />
        public void Parse(string basePath, OutputOptions options, out EndValueNamespaceNavigationNode endValueNode) {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var root = RootNamespaceNavigation.GetInstance();

            var strategy = StrategyFactory.Create(basePath, options);
            Console.WriteLine(strategy.Path);
            endValueNode = new EndValueNamespaceNavigationNode(strategy);

            if (IsDefault(options)) {
                root.SetDefaultNavValue(endValueNode);
                return;
            }
            
            if (IncludeStar(options)) {
                root.SetAllNavValue(endValueNode);
                return;
            }

            var validNamespaceList = GetValidNamespaceList(options);

            foreach (var @namespace in validNamespaceList) {
                if (@namespace.IndexOf(".", StringComparison.Ordinal) < 0) {
                    root.SetFirstLevelNavValue(@namespace, endValueNode);
                } else {
                    root.SetFluentLinkedNavValue(@namespace, endValueNode);
                }
            }
        }

        private static bool IncludeStar(OutputOptions options) {
            return options.Navigators.Contains("*");
        }

        private static bool IsDefault(OutputOptions options) {
            return options.Navigators.Contains("Default");
        }

        private static IEnumerable<string> GetValidNamespaceList(OutputOptions options) {
            return options.Navigators.Where(x => x != "*").OrderBy(x => x).Distinct();
        }
    }
}