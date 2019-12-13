using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.Renderers {
    /// <summary>
    /// Output preferences render manager
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class OutputPreferencesRenderManager {
        private static readonly Dictionary<string, IOutputPreferencesRenderer> _preferencesRenderers;
        private static readonly object _preferencesRendersLock = new object();

        static OutputPreferencesRenderManager() {
            _preferencesRenderers = new Dictionary<string, IOutputPreferencesRenderer>();
        }

        /// <summary>
        /// Add preferences renderer
        /// </summary>
        /// <param name="renderer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddPreferencesRenderer(IOutputPreferencesRenderer renderer) {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));
            var ignoreCaseName = renderer.Name.ToLowerInvariant();
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesRenderers.ContainsKey(ignoreCaseName)) {
                lock (_preferencesRendersLock) {
                    if (!_preferencesRenderers.ContainsKey(ignoreCaseName))
                        _preferencesRenderers.Add(ignoreCaseName, renderer);
                }
            }
        }

        /// <summary>
        /// Add preferences renderer
        /// </summary>
        /// <param name="names"></param>
        /// <param name="renderer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddPreferencesRenderer(List<string> names, IOutputPreferencesRenderer renderer) {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));
            if (names == null || !names.Any()) throw new ArgumentNullException(nameof(names));
            lock (_preferencesRendersLock) {
                foreach (var name in names) {
                    var ignoreCaseName = name.ToLowerInvariant();
                    if (!_preferencesRenderers.ContainsKey(ignoreCaseName))
                        _preferencesRenderers.Add(ignoreCaseName, renderer);
                }

                if (names.All(name => string.Compare(name, renderer.Name, StringComparison.OrdinalIgnoreCase) != 0)) {
                    var ignoreCaseName = renderer.Name.ToLowerInvariant();
                    if (!_preferencesRenderers.ContainsKey(ignoreCaseName))
                        _preferencesRenderers.Add(ignoreCaseName, renderer);
                }
            }
        }

        /// <summary>
        /// Add preferences renderer
        /// </summary>
        /// <typeparam name="TPreferencesRenderer"></typeparam>
        public static void AddPreferencesRenderer<TPreferencesRenderer>() where TPreferencesRenderer : class, IOutputPreferencesRenderer, new() {
            AddPreferencesRenderer(new TPreferencesRenderer());
        }

        /// <summary>
        /// Get renderer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IOutputPreferencesRenderer GetRenderer(string name) {
            if (string.IsNullOrWhiteSpace(name)) return NullOutputPreferencesRenderer.Instance;
            var ignoreCaseName = name.ToLowerInvariant();
            lock (_preferencesRendersLock) {
                return _preferencesRenderers.TryGetValue(ignoreCaseName, out var ret) ? ret : NullOutputPreferencesRenderer.Instance;
            }
        }
    }
}