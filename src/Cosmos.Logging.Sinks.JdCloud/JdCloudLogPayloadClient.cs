using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using JDCloudSDK.Logs.Apis;
using JdCloudLogInfo = JDCloudSDK.Logs.Model.Entry;
using JdCloudLogGroup = JDCloudSDK.Logs.Apis.PutRequest;

namespace Cosmos.Logging.Sinks.JdCloud
{
    public class JdCloudLogPayloadClient : ILogEventSink, ILogPayloadClient
    {
        private readonly IFormatProvider _formatProvider;
        private readonly JdCloudLogSinkConfiguration _sinkConfiguration;

        public JdCloudLogPayloadClient(string name, JdCloudLogSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null)
        {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = _sinkConfiguration.GetDefaultMinimumLevel();
            _formatProvider = formatProvider;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public async Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default)
        {
            if (payload != null)
            {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();
                var logger = Internals.JdCloudLogClientManager.GetLogClient(payload.Name, out var logStreamName);

                if (logger == null || string.IsNullOrWhiteSpace(logStreamName))
                    return;

                var jdcloudLogGroup = new JdCloudLogGroup
                {
                    Stream = logStreamName,
                };

                foreach (var logEvent in legalityEvents)
                {
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider))
                    {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    var jdcloudLogInfo = new JdCloudLogInfo
                    {
                        Content = stringBuilder.ToString(),
                        Stream = logStreamName,
                        Timestamp = logEvent.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") //2019-04-08T03:08:04.123Z
                    };

                    if (logEvent.ExtraProperties.Count > 0)
                    {
                        jdcloudLogInfo.Tags = logEvent.ExtraProperties
                            .Select(extra => extra.Value)
                            .ToDictionary(property => property.Name, property => property.Value.ToString());
                    }

                    jdcloudLogGroup.Entries.Add(jdcloudLogInfo);
                }

                var response = await logger.Put(jdcloudLogGroup);

                ProcessError(response);
            }
        }

        private static void ProcessError(PutResponse response)
        {
            if (response.Error != null)
            {
                InternalLogger.WriteLine(@"JD Cloud Log Service call failed:
    Request Id   : {0}
    Error Code   : {1}
    Error Message: {2}",
                    response.RequestId, response.Error.Code, response.Error.Message);
            }
        }
    }
}