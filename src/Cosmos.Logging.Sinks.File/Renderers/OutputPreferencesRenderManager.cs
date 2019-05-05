using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.Renderers {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class OutputPreferencesRenderManager {
        private static readonly Dictionary<string, IOutputPreferencesRenderer> _preferencesRenders;
        private static readonly object _preferencesRendersLock = new object();

        static OutputPreferencesRenderManager() {
            _preferencesRenders = new Dictionary<string, IOutputPreferencesRenderer>();
        }

        public static void AddPreferencesRenderer(IOutputPreferencesRenderer renderer) {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));
            var ignoreCaseName = renderer.Name.ToLowerInvariant();
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesRenders.ContainsKey(ignoreCaseName)) {
                lock (_preferencesRendersLock) {
                    if (!_preferencesRenders.ContainsKey(ignoreCaseName))
                        _preferencesRenders.Add(ignoreCaseName, renderer);
                }
            }
        }

        public static void AddPreferencesRenderer(List<string> names, IOutputPreferencesRenderer renderer) {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));
            if (names == null || !names.Any()) throw new ArgumentNullException(nameof(names));
            lock (_preferencesRendersLock) {
                foreach (var name in names) {
                    var ignoreCaseName = name.ToLowerInvariant();
                    if (!_preferencesRenders.ContainsKey(ignoreCaseName))
                        _preferencesRenders.Add(ignoreCaseName, renderer);
                }

                if (names.All(name => string.Compare(name, renderer.Name, StringComparison.OrdinalIgnoreCase) != 0)) {
                    var ignoreCaseName = renderer.Name.ToLowerInvariant();
                    if (!_preferencesRenders.ContainsKey(ignoreCaseName))
                        _preferencesRenders.Add(ignoreCaseName, renderer);
                }
            }
        }

        public static void AddPreferencesRenderer<TPreferencesRenderer>() where TPreferencesRenderer : class, IOutputPreferencesRenderer, new() {
            AddPreferencesRenderer(new TPreferencesRenderer());
        }

        public static IOutputPreferencesRenderer GetRender(string name) {
            if (string.IsNullOrWhiteSpace(name)) return NullOutputPreferencesRenderer.Instance;
            var ignoreCaseName = name.ToLowerInvariant();
            return _preferencesRenders.TryGetValue(ignoreCaseName, out var ret) ? ret : NullOutputPreferencesRenderer.Instance;
        }
    }
}