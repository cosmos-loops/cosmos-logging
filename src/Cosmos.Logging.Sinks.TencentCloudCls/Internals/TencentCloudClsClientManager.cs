using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Cosmos.Logging.Sinks.TencentCloudCls.Configurations;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals.Abstractions;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals
{
    internal static class TencentCloudClsClientManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, IHttpClient> _clients = new Dictionary<string, IHttpClient>();

        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, string> _clientRequestBaseUri = new Dictionary<string, string>();

        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, string> _clientTopicIds = new Dictionary<string, string>();

        // ReSharper disable once InconsistentNaming
        private static readonly object _clientLockObj = new object();

        public static IHttpClient GetClsClient(out string requestBaseUri, out string topicId)
            => GetClsClient(Constants.GeneralClientKey, out requestBaseUri, out topicId);

        [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
        public static IHttpClient GetClsClient(string key, out string requestBaseUri, out string topicId)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                requestBaseUri = _clientRequestBaseUri[Constants.GeneralClientKey];
                topicId = _clientTopicIds[Constants.GeneralClientKey];
                return _clients[Constants.GeneralClientKey];
            }

            if (_clients.TryGetValue(key, out var ret))
            {
                requestBaseUri = _clientRequestBaseUri[key];
                topicId = _clientTopicIds[key];
                return ret;
            }

            if (_clients.TryGetValue(Constants.GeneralClientKey, out ret))
            {
                requestBaseUri = _clientRequestBaseUri[Constants.GeneralClientKey];
                topicId = _clientTopicIds[Constants.GeneralClientKey];
                return ret;
            }

            if (_clients.Any())
            {
                var kvp = _clients.First();
                requestBaseUri = _clientRequestBaseUri[kvp.Key];
                topicId = _clientTopicIds[kvp.Key];
                return kvp.Value;
            }

            requestBaseUri = string.Empty;
            topicId = string.Empty;
            return null;
        }

        public static void SetClsClient(string key, string requestBaseUri, IHttpClient instance, string topicId, bool asGeneral = false)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(requestBaseUri))
                throw new ArgumentNullException(nameof(requestBaseUri));

            if (string.IsNullOrWhiteSpace(topicId))
                throw new ArgumentNullException(nameof(topicId));

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            lock (_clientLockObj)
            {
                if (_clients.ContainsKey(key))
                {
                    _clients[key] = instance;
                    _clientRequestBaseUri[key] = requestBaseUri;
                    _clientTopicIds[key] = topicId;
                }
                else
                {
                    _clients.Add(key, instance);
                    _clientRequestBaseUri.Add(key, requestBaseUri);
                    _clientTopicIds.Add(key, topicId);
                }

                var generalFlag = !_clients.ContainsKey(Constants.GeneralClientKey) || asGeneral;

                if (!generalFlag)
                    return;

                if (_clients.ContainsKey(Constants.GeneralClientKey))
                {
                    _clients[Constants.GeneralClientKey] = instance;
                    _clientRequestBaseUri[key] = requestBaseUri;
                    _clientTopicIds[key] = topicId;
                }
                else
                {
                    _clients.Add(Constants.GeneralClientKey, instance);
                    _clientRequestBaseUri.Add(key, requestBaseUri);
                    _clientTopicIds.Add(key, topicId);
                }
            }
        }

        public static void SetClsClient(string key, string requestUri,
            string secretId, string secretKey, string topicId, int timeout,
            bool asGeneral = false)
        {
            var authorization = new Authorization
            {
                SecretId = secretId,
                SecretKey = secretKey,
            };

            var client = new TencentCloudClsClient(authorization, new TimeSpan(0, 0, timeout));

            SetClsClient(key, requestUri, client, topicId, asGeneral);
        }

        public static void SetClsClient(string key, TencentCloudClsNativeConfig nativeConfig)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (nativeConfig == null)
                throw new ArgumentNullException(nameof(nativeConfig));

            nativeConfig.Check();

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            var authorization = new Authorization
            {
                SecretId = nativeConfig.SecretId,
                SecretKey = nativeConfig.SecretKey,
            };

            var client = new TencentCloudClsClient(authorization, new TimeSpan(0, 0, nativeConfig.RequestTimeout));

            SetClsClient(key, nativeConfig.RequestUri, client, nativeConfig.TopicId, nativeConfig.IsGeneralClient);
        }
    }
}