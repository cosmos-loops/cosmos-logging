using System;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals.Helpers
{
    internal static class TimeStampHelper
    {

        public static (long Start, long End, string TimeStr) Get()
        {
            var offset = DateTimeOffset.Now;
            return Get(offset);
        }

        public static (long Start, long End, string TimeStr) Get(DateTimeOffset offset)
        {
            var endOffset = offset.AddHours(1);
            var start = offset.ToUnixTimeSeconds();
            var end = endOffset.ToUnixTimeSeconds();
            return (start, end, $"{start};{end}");
        }
    }
}