using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Rendering configuration
    /// </summary>
    public class RenderingConfiguration : Dictionary<string, bool?> {
        /// <inheritdoc />
        public RenderingConfiguration() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <inheritdoc />
        public RenderingConfiguration(IDictionary<string, bool?> config) : base(config, StringComparer.OrdinalIgnoreCase) { }

        /// <inheritdoc />
        public RenderingConfiguration(RenderingConfiguration config, RenderingConfiguration options) {
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

        internal void ImportFromSettings(RenderingConfiguration options) {
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

        /// <summary>
        /// Gets or sets the enabled state of displaying caller info
        /// </summary>
        public bool? DisplayingCallerInfoEnabled {
            get => GetValue("DisplayingCallerInfoEnabled");
            set => SetValue("DisplayingCallerInfoEnabled", value);
        }

        /// <summary>
        /// Gets or sets the enabled state of displaying log id info
        /// </summary>
        public bool? DisplayingEventIdInfoEnabled {
            get => GetValue("DisplayingEventIdInfoEnabled");
            set => SetValue("DisplayingEventIdInfoEnabled", value);
        }

        /// <summary>
        /// Gets or sets the enabled state of displaying new-line at end of message (EOM).
        /// </summary>
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

        /// <summary>
        /// To calc
        /// </summary>
        /// <param name="downstreamOptions"></param>
        /// <returns></returns>
        public RenderingConfiguration ToCalc(RenderingConfiguration downstreamOptions) {
            return downstreamOptions == null
                ? new RenderingConfiguration {
                    DisplayingCallerInfoEnabled = DisplayingCallerInfoEnabled,
                    DisplayingEventIdInfoEnabled = DisplayingEventIdInfoEnabled,
                    DisplayingNewLineEomEnabled = DisplayingNewLineEomEnabled
                }
                : new RenderingConfiguration {
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