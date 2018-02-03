namespace Cosmos.Logging.MessageTemplates {
    public class MessageTemplateRenderingOptions {
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