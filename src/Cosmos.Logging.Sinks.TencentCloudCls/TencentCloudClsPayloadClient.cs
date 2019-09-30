using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals;
using Google.Protobuf;

namespace Cosmos.Logging.Sinks.TencentCloudCls
{
    public class TencentCloudClsPayloadClient : ILogEventSink, ILogPayloadClient
    {
        private readonly IFormatProvider _formatProvider;
        private readonly TencentCloudClsSinkConfiguration _sinkConfiguration;

        private const string ContentType = "application/x-protobuf";

        public TencentCloudClsPayloadClient(string name, TencentCloudClsSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null)
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
                var logger = TencentCloudClsClientManager.GetClsClient(payload.Name, out var requestBaseUri, out var topicId);

                if (logger == null || string.IsNullOrWhiteSpace(requestBaseUri) || string.IsNullOrWhiteSpace(topicId))
                    return;

                var requestUri = $"http://{requestBaseUri}/structuredlog?topic_id={topicId}";

                var clsLogPackage = TencentCloudClsFormatter.Format(legalityEvents, _sinkConfiguration.Rendering, _formatProvider);

                var content = new ByteArrayContent(clsLogPackage.ToByteArray());
                content.Headers.Clear();
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

                var response = await logger.PostAsync(requestUri, content, cancellationToken);

                ProcessError(response, requestUri);
            }
        }

        private static void ProcessError(HttpResponseMessage response, string uri)
        {
            if (!response.IsSuccessStatusCode)
            {
                InternalLogger.WriteLine(@"Tencent Cloud CLS call failed:
    Status Code  : {0}
    Request Uri  : {1}",
                    response.StatusCode, uri);
            }
        }
    }
}