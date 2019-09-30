using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliyun.Api.LogService.Domain.Log;
using Aliyun.Api.LogService.Infrastructure.Protocol;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using Cosmos.Logging.Sinks.AliyunSls.Internals;
using AliyunLogInfo = Aliyun.Api.LogService.Domain.Log.LogInfo;
using AliyunLogGroup = Aliyun.Api.LogService.Domain.Log.LogGroupInfo;

namespace Cosmos.Logging.Sinks.AliyunSls
{
    public class AliyunSlsPayloadClient : ILogEventSink, ILogPayloadClient
    {
        private readonly IFormatProvider _formatProvider;
        private readonly AliyunSlsSinkConfiguration _sinkConfiguration;
        private const string MessageBody = "Message";

        public AliyunSlsPayloadClient(string name, AliyunSlsSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null)
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
                var logger = AliyunSlsClientManager.GetSlsClient(payload.Name, out var logStoreName);

                if (logger == null || string.IsNullOrWhiteSpace(logStoreName))
                    return;

                var aliyunLogGroup = new AliyunLogGroup
                {
                    Source = payload.SourceType.FullName,
                    Topic = payload.Name,
                };

                foreach (var logEvent in legalityEvents)
                {
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider))
                    {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    var aliyunLogInfo = new AliyunLogInfo
                    {
                        Contents = {{MessageBody, stringBuilder.ToString()}},
                        Time = logEvent.Timestamp
                    };

                    if (logEvent.ExtraProperties.Count > 0)
                    {
                        foreach (var extra in logEvent.ExtraProperties)
                        {
                            var property = extra.Value;
                            if (property != null &&
                                0 != string.Compare(property.Name, MessageBody, StringComparison.OrdinalIgnoreCase))
                                aliyunLogInfo.Contents.Add(property.Name, property.Value.ToString());
                        }
                    }

                    aliyunLogGroup.Logs.Add(aliyunLogInfo);
                }

                var response = await logger.PostLogStoreLogsAsync(new PostLogsRequest(logStoreName, aliyunLogGroup));

                ProcessError(response);
            }
        }

        private static void ProcessError(IResponse response)
        {
            if (!response.IsSuccess)
            {
                InternalLogger.WriteLine(@"Aliyun SLS call failed:
    Request Id   : {0}
    Error Code   : {1}
    Error Message: {2}",
                    response.RequestId, response.Error.ErrorCode, response.Error.ErrorMessage);
            }
        }
    }
}