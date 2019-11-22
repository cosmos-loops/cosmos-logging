using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib
{
    [Renderer("Exception")]
    public class ExceptionRenderer : BasicPreferencesRenderer
    {
        public override string Name => "Exception";

        private static string FixedExceptionInfo(ILogEventInfo logEventInfo, string format, string paramsText)
        {
            if (logEventInfo?.Exception is null)
                return string.Empty;

            var commanders = MakeCommanders(format, paramsText).ToList();
            var usedCommanders = new List<string> {"unwrap", "U"};

            if (!commanders.Any())
                return logEventInfo.Exception?.Message;

            var builder = new StringBuilder();
            var withNewLine = false;

            var targetException = commanders.Any(x => x == "unwrap" || x == "U")
                ? logEventInfo.Exception.Unwrap()
                : logEventInfo.Exception;

            foreach (var cmd in CleanCommanders(commanders))
            {
                if (usedCommanders.Contains(cmd))
                    continue;
                AppendBuilder(logEventInfo, targetException, builder, cmd, ref withNewLine);
            }

            return builder.ToString();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static void AppendBuilder(ILogEventInfo logEventInfo, Exception targetException,
            StringBuilder builder, string cmd, ref bool withNewLine)
        {
            switch (cmd)
            {
                case "N":
                {
                    __processNewList(ref withNewLine);
                    builder.Append(targetException.GetType().Name);
                    break;
                }

                case "T":
                {
                    __processNewList(ref withNewLine);
                    builder.Append(targetException.GetType().FullName);
                    break;
                }
                
                case "M":
                {
                    __processNewList(ref withNewLine);
                    builder.Append(targetException.Message);
                    break;
                }
                
                case "D":
                {
                    __processNewList(ref withNewLine);
                    var logEvent = logEventInfo.ToLogEvent();
                    if (logEvent.ContextData.HasExceptionDetail())
                    {
                        var detailName = logEvent.ContextData.GetExceptionDetailName();
                        var extraProperty = logEvent.ExtraProperties[detailName];
                        builder.Append(extraProperty);
                    }
                    else
                    {
                        builder.Append(logEventInfo.Exception);
                    }

                    break;
                }
                
                case "S":
                {
                    __processNewList(ref withNewLine);
                    builder.Append(targetException.Source);
                    break;
                }
            }

            void __processNewList(ref bool __withNewLine)
            {
                if (__withNewLine)
                {
                    builder.AppendLine();
                }
                else
                {
                    __withNewLine = true;
                }
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static IEnumerable<string> MakeCommanders(string format, string paramsText)
        {
            var validParamsText = __combine(format, paramsText);

            return string.IsNullOrWhiteSpace(validParamsText)
                ? Enumerable.Empty<string>()
                : validParamsText.Split(',');

            string __combine(string __format, string __paramsText)
            {
                if (string.IsNullOrWhiteSpace(__format))
                    return __fixedParamsText(__paramsText);
                var fixedParamsText = __fixedParamsText(__paramsText);
                return string.IsNullOrWhiteSpace(fixedParamsText)
                    ? $"{__format}"
                    : $"{__format},{fixedParamsText}";
            }

            string __fixedParamsText(string value)
            {
                return string.IsNullOrWhiteSpace(value)
                    ? string.Empty
                    : value.TrimStart(',').TrimEnd(',');
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static IEnumerable<string> CleanCommanders(IEnumerable<string> commanders)
        {
            var usedCommanders = new List<string>();
            var result = new List<string>();

            foreach (var commander in commanders)
            {
                var cmd = commander.Trim();

                switch (cmd)
                {
                    case "name":
                    case "N":
                    {
                        result.Add("N");
                        __updateUsedCommanders(usedCommanders, "name", "N");
                        break;
                    }

                    case "type":
                    case "T":
                    {
                        result.Add("T");
                        __updateUsedCommanders(usedCommanders, "type", "T");
                        break;
                    }

                    case "msg":
                    case "message":
                    case "M":
                    {
                        result.Add("M");
                        __updateUsedCommanders(usedCommanders, "msg", "message", "M");
                        break;
                    }

                    case "detail":
                    case "D":
                    {
                        result.Add("D");
                        __updateUsedCommanders(usedCommanders, "detail", "D");

                        break;
                    }

                    case "source":
                    case "S":
                    {
                        result.Add("S");
                        __updateUsedCommanders(usedCommanders, "source", "S");
                        break;
                    }
                }
            }

            return result;

            void __updateUsedCommanders(List<string> __usedCommanders, params string[] __cmds)
            {
                if (__cmds != null)
                {
                    __usedCommanders.AddRange(__cmds);
                }
            }
        }

        #region ToString

        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return FixedExceptionInfo(logEventInfo, format, paramsText);
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return formattingEvents.ToFormat(FixedExceptionInfo(logEventInfo, null, paramsText), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return formattingFuncs.ToFormat(FixedExceptionInfo(logEventInfo, null, paramsText), formatProvider);
        }

        #endregion

        #region Render

        public override void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        public override void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        public override void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }

        #endregion

        public override CustomFormatProvider CustomFormatProvider => null;
    }
}