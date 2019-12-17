using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Sinks.TencentCloudCls.Core.Abstractions;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Core {
    /// <summary>
    /// Tencent Cloud CLS core client
    /// </summary>
    public class TencentCloudClsClient : IHttpClient {
        private readonly Authorization _authorization;
        private readonly HttpClient _client;
        private const string Authorization = "Authorization";

        /// <summary>
        /// Create a new instance of <see cref="TencentCloudClsClient"/>.
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        public TencentCloudClsClient(Authorization authorization, TimeSpan timeout) {
            _authorization = authorization;
            _client = new HttpClient {Timeout = timeout};
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default) {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation(Authorization, _authorization.GetAuthorizationString());
            return await _client.PostAsync(requestUri, content, cancellationToken);
        }
    }
}