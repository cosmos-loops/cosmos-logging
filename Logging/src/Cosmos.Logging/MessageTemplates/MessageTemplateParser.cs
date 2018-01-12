using System;
using System.Collections.Generic;

namespace Cosmos.Logging.MessageTemplates {
    internal class MessageTemplateParser {
        private readonly string _messageTemplate;

        public MessageTemplateParser(string messageTemplate) {
            _messageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
        }

        public MessageTemplate Parse() {
            return new MessageTemplate(_messageTemplate, Tokenize(_messageTemplate));
        }

        static IEnumerable<MessageTemplateToken> Tokenize(string messageTemplate) {

            //todo tokenize, more info please view notes in my evernote.

            return new List<MessageTemplateToken>();
        }
    }
}