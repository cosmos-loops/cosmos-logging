using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Cosmos.Logging.Sinks.JdCloud.Configurations;
using JDCloudSDK.Core.Auth;
using JDCloudSDK.Core.Http;
using JdCloudLogsClient = JDCloudSDK.Logs.Client.LogsClient;

namespace Cosmos.Logging.Sinks.JdCloud.Internals
{
    internal static class JdCloudLogClientManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, JdCloudLogsClient> _clients = new Dictionary<string, JdCloudLogsClient>();

        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, string> _ClientStreamNameMaps = new Dictionary<string, string>();

        // ReSharper disable once InconsistentNaming
        private static readonly object _clientLockObj = new object();

        public static JdCloudLogsClient GetLogClient(out string logStreamName) => GetLogClient(Constants.GeneralClientKey, out logStreamName);

        [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
        public static JdCloudLogsClient GetLogClient(string key, out string logStreamName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                logStreamName = _ClientStreamNameMaps[Constants.GeneralClientKey];
                return _clients[Constants.GeneralClientKey];
            }

            if (_clients.TryGetValue(key, out var ret))
            {
                logStreamName = _ClientStreamNameMaps[key];
                return ret;
            }

            if (_clients.TryGetValue(Constants.GeneralClientKey, out ret))
            {
                logStreamName = _ClientStreamNameMaps[Constants.GeneralClientKey];
                return ret;
            }

            if (_clients.Any())
            {
                var kvp = _clients.First();
                logStreamName = _ClientStreamNameMaps[kvp.Key];
                return kvp.Value;
            }

            logStreamName = string.Empty;
            return null;
        }

        public static void SetLogClient(string key, string logStreamName, JdCloudLogsClient instance, bool asGeneral = false)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(logStreamName))
                throw new ArgumentNullException(nameof(logStreamName));

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            lock (_clientLockObj)
            {
                if (_clients.ContainsKey(key))
                {
                    _clients[key] = instance;
                    _ClientStreamNameMaps[key] = logStreamName;
                }
                else
                {
                    _clients.Add(key, instance);
                    _ClientStreamNameMaps.Add(key, logStreamName);
                }

                var generalFlag = !_clients.ContainsKey(Constants.GeneralClientKey) || asGeneral;

                if (!generalFlag)
                    return;

                if (_clients.ContainsKey(Constants.GeneralClientKey))
                {
                    _clients[Constants.GeneralClientKey] = instance;
                    _ClientStreamNameMaps[Constants.GeneralClientKey] = logStreamName;
                }
                else
                {
                    _clients.Add(Constants.GeneralClientKey, instance);
                    _ClientStreamNameMaps.Add(Constants.GeneralClientKey, logStreamName);
                }
            }
        }

        public static void SetLogClient(string key, string logStreamName,
            string accessKey, string secretKey, bool security, int requestTimeout,
            bool asGeneral = false)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(nameof(secretKey));

            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            var credentialsProvider = new StaticCredentialsProvider(accessKey, secretKey);

            var instance = new JDCloudSDK.Logs.Client.LogsClient.DefaultBuilder()
                .CredentialsProvider(credentialsProvider)
                .HttpRequestConfig(new HttpRequestConfig(security ? Protocol.HTTPS : Protocol.HTTP, requestTimeout))
                .Build();

            SetLogClient(key, logStreamName, instance, asGeneral);
        }

        public static void SetLogClient(string key, JdCloudNativeConfig nativeConfig)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (nativeConfig == null)
                throw new ArgumentNullException(nameof(nativeConfig));

            nativeConfig.Check();

            if (key == Constants.GeneralClientKey)
                throw new ArgumentException($"Key cannot be same as '{Constants.GeneralClientKey}'.");

            var credentialsProvider = new StaticCredentialsProvider(nativeConfig.AccessKey, nativeConfig.SecretKey);

            var instance = new JDCloudSDK.Logs.Client.LogsClient.DefaultBuilder()
                .CredentialsProvider(credentialsProvider)
                .HttpRequestConfig(new HttpRequestConfig(nativeConfig.Security ? Protocol.HTTPS : Protocol.HTTP, nativeConfig.RequestTimeout))
                .Build();

            SetLogClient(key, nativeConfig.LogStreamName, instance, nativeConfig.IsGeneralClient);
        }
    }
}