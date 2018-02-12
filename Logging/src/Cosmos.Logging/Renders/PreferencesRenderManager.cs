using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cosmos.Logging.Renders {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class PreferencesRenderManager {
        private static readonly Dictionary<string, IPreferencesRenderer> _preferencesRenders;
        private static readonly Dictionary<string, Dictionary<string, IPreferencesSinkRenderer>> _preferencesSinkRenders;
        private static readonly object _preferencesRendersLock = new object();
        private static readonly object _preferencesSinkRendersLock = new object();
        private static readonly object _preferencesSinkRendersAliasLock = new object();

        static PreferencesRenderManager() {
            _preferencesRenders = new Dictionary<string, IPreferencesRenderer>();
            _preferencesSinkRenders = new Dictionary<string, Dictionary<string, IPreferencesSinkRenderer>>();
        }

        public static void AddPreferencesRenderer(IPreferencesRenderer renderer) {
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

        public static void AddPreferencesRenderer<TPreferencesRenderer>() where TPreferencesRenderer : class, IPreferencesRenderer, new() {
            AddPreferencesRenderer(new TPreferencesRenderer());
        }

        public static void AddPreferencesSinkRenderer(IPreferencesSinkRenderer renderer) {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));
            
            var ignoreSinkPrefix = renderer.SinkPrefix.ToLowerInvariant();
            CheckSinkAlias(ignoreSinkPrefix);
            
            var ignoreCaseName = renderer.Name.ToLowerInvariant();
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesSinkRenders[ignoreSinkPrefix].ContainsKey(ignoreCaseName)) {
                lock (_preferencesSinkRendersLock) {
                    if (!_preferencesSinkRenders[ignoreSinkPrefix].ContainsKey(ignoreCaseName)) {
                        _preferencesSinkRenders[ignoreSinkPrefix].Add(ignoreCaseName, renderer);
                    }
                }
            }
        }

        public static void AddPreferencesSinkRenderer<TPreferencesSinkRender>() where TPreferencesSinkRender : class, IPreferencesSinkRenderer, new() {
            AddPreferencesSinkRenderer(new TPreferencesSinkRender());
        }

        private static void CheckSinkAlias(string prefix) {
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesSinkRenders.ContainsKey(prefix)) {
                lock (_preferencesSinkRendersAliasLock) {
                    if (!_preferencesSinkRenders.ContainsKey(prefix)) {
                        _preferencesSinkRenders.Add(prefix, new Dictionary<string, IPreferencesSinkRenderer>());
                    }
                }
            }
        }

        public static IPreferencesRenderer GetRender(string name) {
            if (string.IsNullOrWhiteSpace(name)) return NullPreferencesRenderer.Instance;
            var ignoreCaseName = name.ToLowerInvariant();
            return _preferencesRenders.TryGetValue(ignoreCaseName, out var ret) ? ret : NullPreferencesRenderer.Instance;
        }

        public static IPreferencesSinkRenderer GetRender(string prefix, string name) {
            if (string.IsNullOrWhiteSpace(prefix) || string.IsNullOrWhiteSpace(name)) return NullPreferencesSinkRenderer.Instance;
            var ignoreSinkPrefix =prefix.ToLowerInvariant();
            var ignoreCaseName = name.ToLowerInvariant();
            return _preferencesSinkRenders.TryGetValue(ignoreSinkPrefix, out var dict)
                ? dict.TryGetValue(ignoreCaseName, out var ret) ? ret : NullPreferencesSinkRenderer.Instance
                : NullPreferencesSinkRenderer.Instance;
        }
    }
}