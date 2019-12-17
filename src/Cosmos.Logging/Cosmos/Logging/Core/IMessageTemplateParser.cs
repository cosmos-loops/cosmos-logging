using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for message template parser
    /// </summary>
    internal interface IMessageTemplateParser {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <returns></returns>
        MessageTemplate Parse(string messageTemplate);
    }
}