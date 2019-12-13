using Cosmos.Logging.Sinks.TencentCloudCls.Core.Helpers;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Core {
    /// <summary>
    /// Authorization
    /// </summary>
    public class Authorization {
        private long EndTime { get; set; }

        private string AuthorizationString { get; set; } = "";

        /// <summary>
        /// Gets or sets secret key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets secret id
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// 获取请求 Authorization 头部的授权字符串
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizationString() {
            var (startTime, endTme, timeStr) = TimeStampHelper.Get();

            if (EndTime > startTime)
                return AuthorizationString;

            EndTime = endTme;
            AuthorizationString = CreateAuthorizationString(SecretId, SecretKey, timeStr);

            return AuthorizationString;
        }

        private static string CreateAuthorizationString(string secretId, string secretKey, string timeStr) {
            var signature = CreateSignature(timeStr, secretKey);
            return $"q-sign-algorithm=sha1&q-ak={secretId}&q-sign-time={timeStr}&q-key-time={timeStr}&q-header-list=&q-url-param-list=&q-signature={signature}";
        }

        private static string CreateSignature(string timeStr, string secretKey) {
            return Signature.GetSignature("post", "/structuredlog", "sha1", timeStr, timeStr, secretKey);
        }
    }
}