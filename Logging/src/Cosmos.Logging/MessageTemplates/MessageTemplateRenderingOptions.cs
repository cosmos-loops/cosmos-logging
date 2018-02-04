using System.Collections.Generic;
using Cosmos.Logging.Configurations;

namespace Cosmos.Logging.MessageTemplates {
    public class MessageTemplateRenderingOptions {
        public MessageTemplateRenderingOptions() { }

        internal MessageTemplateRenderingOptions(IDictionary<string, bool?> dictionary, bool? d1, bool? d2, bool? d3) {
            DisplayingCallerInfoEnabled = _calc(dictionary.TryGetValue("DisplayingCallerInfoEnabled", out var _d1) ? _d1 : ThreeValuedBoolean.Default, d1);
            DisplayingEventIdInfoEnabled = _calc(dictionary.TryGetValue("DisplayingEventIdInfoEnabled", out var _d2) ? _d2 : ThreeValuedBoolean.Default, d2);
            DisplayingNewLineEomEnabled = _calc(dictionary.TryGetValue("DisplayingNewLineEomEnabled", out var _d3) ? _d3 : ThreeValuedBoolean.Default, d3);

            bool? _calc(bool? conf, bool? sets) {
                if (sets == null) return conf;
                if (conf == null) return sets;
                return sets;
            }
        }

        internal MessageTemplateRenderingOptions(IDictionary<string, bool?> dictionary, MessageTemplateRenderingOptions d)
            : this(dictionary, d.DisplayingCallerInfoEnabled, d.DisplayingEventIdInfoEnabled, d.DisplayingNewLineEomEnabled) { }

        public bool? DisplayingCallerInfoEnabled { get; set; }
        public bool? DisplayingEventIdInfoEnabled { get; set; }
        public bool? DisplayingNewLineEomEnabled { get; set; }

        private bool? ToCalcDisplayingCallerInfoEnabled(bool? displayingCallerInfoEnabled) => Calc(DisplayingCallerInfoEnabled, displayingCallerInfoEnabled);
        private bool? ToCalcDisplayingEventIdInfoEnabled(bool? displayingEventIdInfoEnabled) => Calc(DisplayingEventIdInfoEnabled, displayingEventIdInfoEnabled);
        private bool? ToCalcDisplayingNewLineEomEnabled(bool? displayingNewLineEomEnabled) => Calc(DisplayingNewLineEomEnabled, displayingNewLineEomEnabled);

        private static bool? Calc(bool? upstream, bool? downstream) {
            if (upstream == null) return downstream;
            if (downstream == null) return upstream;
            return upstream.Value && downstream.Value;
        }

        public MessageTemplateRenderingOptions ToCalc(MessageTemplateRenderingOptions downstreamOptions) {
            return downstreamOptions == null
                ? new MessageTemplateRenderingOptions {
                    DisplayingCallerInfoEnabled = DisplayingCallerInfoEnabled,
                    DisplayingEventIdInfoEnabled = DisplayingEventIdInfoEnabled,
                    DisplayingNewLineEomEnabled = DisplayingNewLineEomEnabled
                }
                : new MessageTemplateRenderingOptions {
                    DisplayingCallerInfoEnabled = ToCalcDisplayingCallerInfoEnabled(downstreamOptions.DisplayingCallerInfoEnabled),
                    DisplayingEventIdInfoEnabled = ToCalcDisplayingEventIdInfoEnabled(downstreamOptions.DisplayingEventIdInfoEnabled),
                    DisplayingNewLineEomEnabled = ToCalcDisplayingNewLineEomEnabled(downstreamOptions.DisplayingNewLineEomEnabled)
                };
        }
    }
}