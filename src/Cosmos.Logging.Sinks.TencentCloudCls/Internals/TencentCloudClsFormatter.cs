using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;
using ClsLogGroupList = TencentCloud.Cls.LogGroupList;
using ClsLogGroup = TencentCloud.Cls.LogGroup;
using ClsLog = TencentCloud.Cls.Log;
using ClsContent = TencentCloud.Cls.Log.Types.Content;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals
{
    internal static class TencentCloudClsFormatter
    {
        public static ClsLogGroupList Format(List<LogEvent> logEvents, RendingConfiguration rendingConfiguration, IFormatProvider formatProvider)
        {
            if (logEvents == null)
                throw new ArgumentNullException(nameof(logEvents));

            var logGroup = new ClsLogGroup();

            foreach (var logEvent in logEvents)
            {
                var log = new ClsLog();

                try
                {
                    LogEventEnricherManager.Enricher(logEvent);
                    var contents = GetLogEventContents(logEvent, rendingConfiguration, formatProvider);
                    log.Contents.AddRange(contents);
                    log.Time = logEvent.Timestamp.ToUnixTimeMilliseconds();
                }
                catch (Exception e)
                {
                    LogNonFormattableEvent(logEvent, e);
                }

                logGroup.Logs.Add(log);
            }

            var logGroupList = new ClsLogGroupList();
            logGroupList.LogGroupList_.Add(logGroup);

            return logGroupList;
        }

        private static List<ClsContent> GetLogEventContents(LogEvent logEvent, RendingConfiguration rendingConfiguration, IFormatProvider formatProvider)
        {
            var contents = new List<ClsContent>();

            contents
                .AddContent("Timestamp", logEvent.Timestamp.ToString("o"))
                .AddContent("Level", logEvent.Level.ToString())
                .AddContent("MessageTemplate", logEvent.MessageTemplate.Text);

            var stringBuilder = new StringBuilder();
            using (var output = new StringWriter(stringBuilder, formatProvider))
            {
                logEvent.RenderMessage(output, rendingConfiguration, formatProvider);
            }

            contents.AddContent("RenderedMessage", stringBuilder.ToString());

            if (logEvent.Exception != null)
            {
                contents.AddContent("Exception", logEvent.Exception.ToUnwrappedString());

//                if (logEvent.ContextData.HasExceptionDetail())
//                {
//                    var wrapper = logEvent.ContextData.GetExceptionDetails();
//                    contents.AddContent(wrapper.RootName, wrapper.Detils.ToJson());
//                }
            }

            if (logEvent.ExtraProperties.Count > 0)
            {
                stringBuilder.Clear();
                WriteProperties(logEvent.ExtraProperties, stringBuilder, formatProvider);
                contents.AddContent("ExtraProperties", stringBuilder.ToString());
            }

            return contents;
        }

        private static void WriteProperties(IReadOnlyDictionary<string, ExtraMessageProperty> properties, StringBuilder stringBuilder, IFormatProvider formatProvider)
        {
            stringBuilder.Append("{");

            var precedingDelimiter = "";

            foreach (var propertyWrapper in properties)
            {
                var property = propertyWrapper.Value;

                stringBuilder.Append(precedingDelimiter);
                precedingDelimiter = ",";

                stringBuilder.Append($"\"{property.Name}\"");
                stringBuilder.Append(":");
                stringBuilder.Append($"{property.Value.ToString(null, formatProvider)}");
            }

            stringBuilder.Append("}");
        }

        private static void LogNonFormattableEvent(LogEvent logEvent, Exception e)
        {
            InternalLogger.WriteLine(
                "Event at {0} with message template {1} could not be formatted into JSON and will be dropped: {2}",
                logEvent.Timestamp.ToString("o"),
                logEvent.MessageTemplate.Text,
                e);
        }
    }
}