using System;
using System.Text.RegularExpressions;

namespace Cosmos.Extensions {
    public static class JsonDateTimeHelper {
        /// <summary>
        /// 处理Json的时间格式为正常格式
        /// </summary>
        /// <param name="json">Json 字符串</param>
        /// <param name="format">时间格式</param>
        /// <returns></returns>
        public static string JsonDateTimeFormat(string json, string format = "yyyy-MM-dd HH:mm:ss.fff")
            => Regex.Replace(json, @"\\/Date\((\d+)\)\\/",
                match => (new DateTime(1970, 1, 1))
                    .AddMilliseconds(long.Parse(match.Groups[1].Value))
                    .ToLocalTime()
                    .ToString(format));
    }
}