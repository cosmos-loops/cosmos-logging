using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    public interface IPreferencesRender {
        string Name { get; }
        bool IsNull { get; }

        string ToString(string format, string paramsText, IFormatProvider formatProvider = null);
        string ToString(IList<FormatEvent> formattingEvents, string paramsText, IFormatProvider formatProvider = null);
        string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, IFormatProvider formatProvider = null);
        void Render(string format, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null);
        void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null);
        void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null);
    }
}