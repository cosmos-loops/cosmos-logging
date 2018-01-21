using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.RunsOn.Console.RendersLib {
    public class ConsoleHelloWorld : IPreferencesRender {

        private const string Content = "Console, Hello World";

        public string Name => "ConsoleHelloWorld";
        public bool IsNull => false;

        public void Render(string format, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, Content, formatProvider));
        }

        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, Content, formatProvider));
        }

        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, Content, formatProvider));
        }

        public string ToString(IList<FormatEvent> formattingEvents, string paramsText, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(Content, formatProvider);
        }

        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(Content, formatProvider);
        }

        public string ToString(string format, string paramsText, IFormatProvider formatProvider = null) {
            return Content;
        }

        public override string ToString() {
            return ToString((string) null, null, null);
        }
    }
}