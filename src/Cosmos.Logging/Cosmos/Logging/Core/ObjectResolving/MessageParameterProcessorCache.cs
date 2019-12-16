using System;

namespace Cosmos.Logging.Core.ObjectResolving {
    /// <summary>
    /// Message parameter provessor cache
    /// </summary>
    public static class MessageParameterProcessorCache {
        private static MessageParameterProcessor MessageParameterProcessor { get; set; }

        internal static void Set(MessageParameterProcessor processor) {
            MessageParameterProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Get message parameter processor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static MessageParameterProcessor Get() {
            if (MessageParameterProcessor == null)
                throw new NullReferenceException("Message parameter provessor has not been initialized.");
            return MessageParameterProcessor;
        }
    }
}