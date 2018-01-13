using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cosmos.Logging.MessageTemplates {
    internal static class MessageTemplateRenderer {
        public static void Render(MessageTemplate messageTemplate, IReadOnlyDictionary<string, MessagePropertyValue> properties,
            TextWriter output, string format = null, IFormatProvider formatProvider = null) {

            //todo 临时代码
            var stringBuilder = new StringBuilder(messageTemplate.ToString());
            var buffer = new char[stringBuilder.Length];
            stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);

            output.Write(buffer);
        }
    }
}