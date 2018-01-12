using System;
using System.Collections.Generic;
using System.IO;

namespace Cosmos.Logging.MessageTemplates {
    internal static class MessageTemplateRenderer {
        public static void Render(MessageTemplate messageTemplate, IReadOnlyDictionary<string, MessagePropertyValue> properties,
            TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            output.Write(messageTemplate.ToString());
            //todo 临时代码
        }
    }
}