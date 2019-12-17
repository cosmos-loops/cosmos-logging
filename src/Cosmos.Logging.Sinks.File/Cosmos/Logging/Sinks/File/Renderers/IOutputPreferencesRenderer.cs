using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers {
    /// <summary>
    /// Interface for output preferences renderer
    /// </summary>
    public interface IOutputPreferencesRenderer {

        /// <summary>
        /// Gets name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets is null or not.
        /// </summary>
        bool IsNull { get; }

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="format"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formattingEvents"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formattingFuncs"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="format"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        void Render(string format, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="formattingEvents"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="formattingFuncs"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEvent"></param>
        /// <param name="targetMessageBuilder"></param>
        /// <param name="formatProvider"></param>
        void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);
    }
}