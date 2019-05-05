using System;

namespace Cosmos.Logging.Core.ObjectResolving {
    public static class MessageParameterProcessorCache {
        private static MessageParameterProcessor MessageParameterProcessor { get; set; }

        internal static void Set(MessageParameterProcessor processor) {
            MessageParameterProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public static MessageParameterProcessor Get() {
            if (MessageParameterProcessor == null)
                throw new NullReferenceException("Message parameter provessor has not been initialized.");
            return MessageParameterProcessor;
        }
    }
}