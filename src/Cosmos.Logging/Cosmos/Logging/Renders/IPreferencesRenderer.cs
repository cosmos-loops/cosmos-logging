using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Interface for preferences renderer
    /// </summary>
    public interface IPreferencesRenderer {

        /// <summary>
        /// Gets renderer name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Is renderer null 
        /// </summary>
        bool IsNull { get; }

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="format"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formattingEvents"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formattingFuncs"></param>
        /// <param name="paramsText"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="format"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="formattingEvents"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="formattingFuncs"></param>
        /// <param name="paramsText"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="formatProvider"></param>
        void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Gets custom format provider
        /// </summary>
        CustomFormatProvider CustomFormatProvider { get; }
    }
}