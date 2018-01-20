using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core {
    internal interface IMessageTemplateParser {
        MessageTemplate Parse(string messageTemplate);
    }
}