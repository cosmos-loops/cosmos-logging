using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Aliyun.Api.LogService;
using Cosmos.Logging.Sinks.AliyunSls.Configurations;

namespace Cosmos.Logging.Sinks.AliyunSls.Internals
{
    internal static class AliyunSlsClientManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, ILogServiceClient> _clients = new Dictionary<string, ILogServiceClient>();

        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, string> _ClientStoreNameMaps = new Dictionary<string, string>();

        // ReSharper disable once InconsistentNaming
        private static readonly object _clientLockObj = new object();

        public static ILogServiceClient GetSlsClient(out string logStoreName) => GetSlsClient(Constants.GeneralClientKey, out logStoreName);

        [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
        public static ILogServiceClient GetSlsClient(string key, out string logStoreName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                logStoreName = _ClientStoreNameMaps[Constants.GeneralClientKey];
                return _clients[Constants.GeneralClientKey];
            }

            if (_clients.TryGetValue(key, out var ret))
            {
                logStoreName = _ClientStoreNameMaps[key];
                return ret;
            }

            if (_clients.TryGetValue(Constants.GeneralClientKey, out ret))
            {
                logStoreName = _ClientStoreNameMaps[Constants.GeneralClientKey];
                return ret;
            }

            if (_clients.Any())
            {
                var kvp = _clients.First();
                logStoreName = _ClientStoreNameMaps[kvp.Key];
                return kvp.Value;
            }

            logStoreName = string.Empty;
            return null;
        }

        public static void SetSlsClient(string key, string logStoreName, ILogServiceClient instance, bool asGeneral = false)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(logStoreName))
                throw new ArgumentNullException(nameof(logStoreName));

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            lock (_clientLockObj)
            {
                if (_clients.ContainsKey(key))
                {
                    _clients[key] = instance;
                    _ClientStoreNameMaps[key] = logStoreName;
                }
                else
                {
                    _clients.Add(key, instance);
                    _ClientStoreNameMaps.Add(key, logStoreName);
                }

                var generalFlag = !_clients.ContainsKey(Constants.GeneralClientKey) || asGeneral;

                if (!generalFlag)
                    return;

                if (_clients.ContainsKey(Constants.GeneralClientKey))
                {
                    _clients[Constants.GeneralClientKey] = instance;
                    _ClientStoreNameMaps[Constants.GeneralClientKey] = logStoreName;
                }
                else
                {
                    _clients.Add(Constants.GeneralClientKey, instance);
                    _ClientStoreNameMaps.Add(Constants.GeneralClientKey, logStoreName);
                }
            }
        }

        public static void SetSlsClient(string key, string logStoreName,
            string endpoint, string projectName, string accessKeyId, string accessKey,
            bool asGeneral = false)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentNullException(nameof(endpoint));

            if (string.IsNullOrWhiteSpace(projectName))
                throw new ArgumentNullException(nameof(projectName));

            if (string.IsNullOrWhiteSpace(accessKeyId))
                throw new ArgumentNullException(nameof(accessKeyId));

            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            var instance = LogServiceClientBuilders.HttpBuilder
                .Endpoint(endpoint, projectName)
                .Credential(accessKeyId, accessKey)
                .Build();

            SetSlsClient(key, logStoreName, instance, asGeneral);
        }

        public static void SetSlsClient(string key, AliyunSlsNativeConfig nativeConfig)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (nativeConfig == null)
                throw new ArgumentNullException(nameof(nativeConfig));

            nativeConfig.Check();

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            var builder = LogServiceClientBuilders.HttpBuilder
                .Endpoint(nativeConfig.EndPoint, nativeConfig.ProjectName)
                .Credential(nativeConfig.AccessKeyId, nativeConfig.AccessKey);

            if (nativeConfig.Timeout >= 100)
                builder.RequestTimeout(nativeConfig.Timeout);

            if (nativeConfig.UseProxy)
            {
                builder.UseProxy(true);

                if (nativeConfig.ProxyUserEnabled)
                    builder.Proxy(
                        nativeConfig.ProxyHost,
                        nativeConfig.ProxyPort,
                        nativeConfig.ProxyUserName,
                        nativeConfig.ProxyPassword,
                        nativeConfig.ProxyDomain);
            }

            var instance = builder.Build();

            SetSlsClient(key, nativeConfig.LogStoreName, instance, nativeConfig.IsGeneralClient);
        }
    }
}