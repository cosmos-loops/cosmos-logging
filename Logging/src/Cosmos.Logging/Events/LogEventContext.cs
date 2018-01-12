using System.Collections.Generic;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Events {
    public class LogEventContext {
        public AdditionalOptContext AdditionalOptContext { get; set; }
        public IEnumerable<MessageProperty> MessageProperties { get; set; }
    }
}