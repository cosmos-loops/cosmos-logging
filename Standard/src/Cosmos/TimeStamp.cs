using System;

namespace Cosmos
{
    /// <summary>
    /// Timestamp
    /// </summary>
    public class TimeStamp
    {
        protected long m_timestamp;
        protected DateTime m_datetime;

        public TimeStamp() : this(DateTime.Now) { }

        public TimeStamp(long timestamp) : this(FromTimestampFunc(timestamp), timestamp) { }

        public TimeStamp(DateTime dt) : this(dt, ToTimestampFunc(dt)) { }

        private TimeStamp(DateTime dt, long timestamp)
        {
            m_timestamp = timestamp;
            m_datetime = dt;
        }

        /// <summary>
        /// 根据时间戳，获取对应时间
        /// </summary>
        /// <returns></returns>
        public virtual DateTime ToDateTime() => m_datetime;

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public virtual long ToTimestamp() => m_timestamp;

        private static readonly Func<DateTime, long> ToTimestampFunc = time => time.Ticks;

        private static readonly Func<long, DateTime> FromTimestampFunc = timestamp => new DateTime(timestamp);

        public static Func<long> NowTimeStamp = () => ToTimestampFunc(DateTime.Now);
        public static Func<long> UtcNowTimeStamp = () => ToTimestampFunc(DateTime.UtcNow);
    }
}