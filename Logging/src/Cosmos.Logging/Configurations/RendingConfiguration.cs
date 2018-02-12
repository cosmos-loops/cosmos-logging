using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Configurations {
    public class RendingConfiguration : Dictionary<string, bool?> {
        public RendingConfiguration() : base(StringComparer.OrdinalIgnoreCase) { }
        public RendingConfiguration(IDictionary<string, bool?> config) : base(config, StringComparer.OrdinalIgnoreCase) { }

        public RendingConfiguration(RendingConfiguration config, RendingConfiguration options) {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (options == null) throw new ArgumentNullException(nameof(options));
            DisplayingCallerInfoEnabled = _calc(config.DisplayingCallerInfoEnabled, options.DisplayingCallerInfoEnabled);
            DisplayingEventIdInfoEnabled = _calc(config.DisplayingEventIdInfoEnabled, options.DisplayingEventIdInfoEnabled);
            DisplayingNewLineEomEnabled = _calc(config.DisplayingNewLineEomEnabled, options.DisplayingNewLineEomEnabled);

            // ReSharper disable once InconsistentNaming
            bool? _calc(bool? conf, bool? sets) {
                //sets 优先于 conf
                if (sets == null) return conf;
                if (conf == null) return sets;
                return sets;
            }
        }

        internal void ImportFromSettings(RendingConfiguration options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            DisplayingCallerInfoEnabled = _calc(DisplayingCallerInfoEnabled, options.DisplayingCallerInfoEnabled);
            DisplayingEventIdInfoEnabled = _calc(DisplayingEventIdInfoEnabled, options.DisplayingEventIdInfoEnabled);
            DisplayingNewLineEomEnabled = _calc(DisplayingNewLineEomEnabled, options.DisplayingNewLineEomEnabled);

            // ReSharper disable once InconsistentNaming
            bool? _calc(bool? conf, bool? sets) {
                //sets 优先于 conf
                if (sets == null) return conf;
                if (conf == null) return sets;
                return sets;
            }
        }

        private readonly object _lock = new object();

        public bool? DisplayingCallerInfoEnabled {
            get => GetValue("DisplayingCallerInfoEnabled");
            set => SetValue("DisplayingCallerInfoEnabled", value);
        }

        public bool? DisplayingEventIdInfoEnabled {
            get => GetValue("DisplayingEventIdInfoEnabled");
            set => SetValue("DisplayingEventIdInfoEnabled", value);
        }

        public bool? DisplayingNewLineEomEnabled {
            get => GetValue("DisplayingNewLineEomEnabled");
            set => SetValue("DisplayingNewLineEomEnabled", value);
        }

        private bool? GetValue(string key) {
            if (string.IsNullOrWhiteSpace(key) || !ContainsKey(key)) return ThreeValuedBoolean.Default;
            return this[key];
        }

        private void SetValue(string key, bool? value) {
            if (string.IsNullOrWhiteSpace(key)) return;
            lock (_lock) {
                if (ContainsKey(key)) this[key] = value;
                else Add(key, value);
            }
        }

        public RendingConfiguration ToCalc(RendingConfiguration downstreamOptions) {
            return downstreamOptions == null
                ? new RendingConfiguration {
                    DisplayingCallerInfoEnabled = DisplayingCallerInfoEnabled,
                    DisplayingEventIdInfoEnabled = DisplayingEventIdInfoEnabled,
                    DisplayingNewLineEomEnabled = DisplayingNewLineEomEnabled
                }
                : new RendingConfiguration {
                    DisplayingCallerInfoEnabled = __calc(DisplayingCallerInfoEnabled, downstreamOptions.DisplayingCallerInfoEnabled),
                    DisplayingEventIdInfoEnabled = __calc(DisplayingEventIdInfoEnabled, downstreamOptions.DisplayingEventIdInfoEnabled),
                    DisplayingNewLineEomEnabled = __calc(DisplayingNewLineEomEnabled, downstreamOptions.DisplayingNewLineEomEnabled)
                };

            // ReSharper disable once InconsistentNaming
            bool? __calc(bool? upstream, bool? downstream) {
                //上游优先于下游
                if (upstream == null) return downstream;
                if (downstream == null) return upstream;
                return upstream.Value && downstream.Value;
            }
        }
    }
}