using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals.Abstractions;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals
{
    public class TencentCloudClsClient : IHttpClient
    {
        private readonly Authorization _authorization;
        private readonly HttpClient _client;
        private const string Authorization = "Authorization";

        public TencentCloudClsClient(Authorization authorization, TimeSpan timeout)
        {
            _authorization = authorization;
            _client = new HttpClient {Timeout = timeout};
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation(Authorization, _authorization.GetAuthorizationString());
            return await _client.PostAsync(requestUri, content, cancellationToken);
        }
    }
}