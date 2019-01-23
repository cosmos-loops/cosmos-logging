using System;

namespace Cosmos
{
    public class NoRepeatTimeStampFactory
    {
        private DateTime lastValue = DateTime.MinValue;
        private object lockObj = new object();

        public double IncrementMs { get; set; } = 4;

        public DateTime GetTimeStamp() => GetTimeStampCore(DateTime.Now);

        public DateTime GetUtcTimeStamp() => GetTimeStampCore(DateTime.UtcNow);

        public TimeStamp GetTimeStampObject() => new TimeStamp(GetTimeStamp());

        public TimeStamp GetUtcTimeStampObject() => new TimeStamp(GetUtcTimeStamp());

        public UnixTimeStamp GetUnixTimeStampObject() => new UnixTimeStamp(GetTimeStamp());

        public UnixTimeStamp GetUtcUnixTimeStampObject() => new UnixTimeStamp(GetUtcTimeStamp());

        private DateTime GetTimeStampCore(DateTime refDt)
        {
            var now = refDt;
            lock (lockObj)
            {
                if ((now - lastValue).TotalMilliseconds < IncrementMs)
                {
                    now = lastValue.AddMilliseconds(IncrementMs);
                }

                lastValue = now;
            }

            return now;
        }
    }
}