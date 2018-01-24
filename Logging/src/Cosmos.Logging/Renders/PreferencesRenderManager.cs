using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Renders {
    public static class PreferencesRenderManager {
        private static readonly Dictionary<string, IPreferencesRender> _preferencesRenders;
        private static readonly Dictionary<string, Dictionary<string, IPreferencesSinkRender>> _preferencesSinkRenders;
        private static readonly object _preferencesRendersLock = new object();
        private static readonly object _preferencesSinkRendersLock = new object();
        private static readonly object _preferencesSinkRendersAliasLock = new object();

        static PreferencesRenderManager() {
            _preferencesRenders = new Dictionary<string, IPreferencesRender>();
            _preferencesSinkRenders = new Dictionary<string, Dictionary<string, IPreferencesSinkRender>>();
        }

        public static void AddPreferencesRender(IPreferencesRender render) {
            if (render == null) throw new ArgumentNullException(nameof(render));
            var ignoreCaseName = render.Name.ToLowerInvariant();
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesRenders.ContainsKey(ignoreCaseName)) {
                lock (_preferencesRendersLock) {
                    if (!_preferencesRenders.ContainsKey(ignoreCaseName))
                        _preferencesRenders.Add(ignoreCaseName, render);
                }
            }
        }

        public static void AddPreferencesRender<TPreferencesRender>() where TPreferencesRender : class, IPreferencesRender, new() {
            AddPreferencesRender(new TPreferencesRender());
        }

        public static void AddPreferencesSinkRender(IPreferencesSinkRender render) {
            if (render == null) throw new ArgumentNullException(nameof(render));
            
            var ignoreSinkPrefix = render.SinkPrefix.ToLowerInvariant();
            CheckSinkAlias(ignoreSinkPrefix);
            
            var ignoreCaseName = render.Name.ToLowerInvariant();
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesSinkRenders[ignoreSinkPrefix].ContainsKey(ignoreCaseName)) {
                lock (_preferencesSinkRendersLock) {
                    if (!_preferencesSinkRenders[ignoreSinkPrefix].ContainsKey(ignoreCaseName)) {
                        _preferencesSinkRenders[ignoreSinkPrefix].Add(ignoreCaseName, render);
                    }
                }
            }
        }

        public static void AddPreferencesSinkRender<TPreferencesSinkRender>() where TPreferencesSinkRender : class, IPreferencesSinkRender, new() {
            AddPreferencesSinkRender(new TPreferencesSinkRender());
        }

        private static void CheckSinkAlias(string prefix) {
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesSinkRenders.ContainsKey(prefix)) {
                lock (_preferencesSinkRendersAliasLock) {
                    if (!_preferencesSinkRenders.ContainsKey(prefix)) {
                        _preferencesSinkRenders.Add(prefix, new Dictionary<string, IPreferencesSinkRender>());
                    }
                }
            }
        }

        public static IPreferencesRender GetRender(string name) {
            if (string.IsNullOrWhiteSpace(name)) return NullPreferencesRender.Instance;
            var ignoreCaseName = name.ToLowerInvariant();
            return _preferencesRenders.TryGetValue(ignoreCaseName, out var ret) ? ret : NullPreferencesRender.Instance;
        }

        public static IPreferencesSinkRender GetRender(string prefix, string name) {
            if (string.IsNullOrWhiteSpace(prefix) || string.IsNullOrWhiteSpace(name)) return NullPreferencesSinkRender.Instance;
            var ignoreSinkPrefix =prefix.ToLowerInvariant();
            var ignoreCaseName = name.ToLowerInvariant();
            return _preferencesSinkRenders.TryGetValue(ignoreSinkPrefix, out var dict)
                ? dict.TryGetValue(ignoreCaseName, out var ret) ? ret : NullPreferencesSinkRender.Instance
                : NullPreferencesSinkRender.Instance;
        }
    }
}