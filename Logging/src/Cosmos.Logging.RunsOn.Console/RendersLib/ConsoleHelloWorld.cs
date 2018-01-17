using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Formattings.Helpers;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.RunsOn.Console.RendersLib {
    public class ConsoleHelloWorld : IPreferencesRender {

        private const string Content = "Console, Hello World";

        public string Name => "ConsoleHelloWorld";
        public bool IsNull => false;

        public void Render(string format, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, formatProvider));
        }

        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, formatProvider));
        }

        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, formatProvider));
        }

        public string ToString(IList<FormatEvent> formattingEvents, string paramsText, IFormatProvider formatProvider = null) {
            var content = Content;
            if (formattingEvents == null || !formattingEvents.Any()) return content;
            var ordered = formattingEvents.OrderBy(x => x.Sort);
            foreach (var cmd in ordered) {
                content = cmd.Command(content, formatProvider) as string;
            }

            return content;
        }

        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, IFormatProvider formatProvider = null) {
            var content = Content;
            if (formattingFuncs == null || !formattingFuncs.Any()) return content;
            foreach (var cmd in formattingFuncs) {
                content = cmd(content, formatProvider) as string;
            }

            return content;
        }

        public string ToString(string format, string paramsText, IFormatProvider formatProvider = null) {
            return Content;
        }

        public override string ToString() {
            return ToString((string) null, null, null);
        }
    }
}