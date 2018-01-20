using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Resources;

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
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesRenders.ContainsKey(render.Name)) {
                lock (_preferencesRendersLock) {
                    if (!_preferencesRenders.ContainsKey(render.Name))
                        _preferencesRenders.Add(render.Name, render);
                }
            }
        }

        public static void AddPreferencesRender<TPreferencesRender>() where TPreferencesRender : class, IPreferencesRender, new() {
            AddPreferencesRender(new TPreferencesRender());
        }

        public static void AddPreferencesSinkRender(IPreferencesSinkRender render) {
            if (render == null) throw new ArgumentNullException(nameof(render));
            CheckSinkAlias(render.SinkPrefix);
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_preferencesSinkRenders[render.SinkPrefix].ContainsKey(render.Name)) {
                lock (_preferencesSinkRendersLock) {
                    if (!_preferencesSinkRenders[render.SinkPrefix].ContainsKey(render.Name)) {
                        _preferencesSinkRenders[render.SinkPrefix].Add(render.Name, render);
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
            return _preferencesRenders.TryGetValue(name, out var ret) ? ret : NullPreferencesRender.Instance;
        }

        public static IPreferencesSinkRender GetRender(string prefix, string name) {
            if (string.IsNullOrWhiteSpace(prefix) || string.IsNullOrWhiteSpace(name)) return NullPreferencesSinkRender.Instance;
            return _preferencesSinkRenders.TryGetValue(prefix, out var dict)
                ? dict.TryGetValue(name, out var ret) ? ret : NullPreferencesSinkRender.Instance
                : NullPreferencesSinkRender.Instance;
        }
    }
}