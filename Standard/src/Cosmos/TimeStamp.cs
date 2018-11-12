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

    /// <summary>
    /// Unix timestamp
    /// </summary>
    public class UnixTimeStamp : TimeStamp
    {
        public UnixTimeStamp() : this(DateTime.Now) { }
        public UnixTimeStamp(long timestamp) : this(FromUnixTimestampFunc(timestamp), timestamp) { }
        public UnixTimeStamp(DateTime dt) : this(dt, ToUnixTimestampFunc(dt)) { }

        private UnixTimeStamp(DateTime dt, long timestamp)
        {
            m_timestamp = timestamp;
            m_datetime = dt;
        }

        /// <summary>
        /// 根据 Unix 时间戳，获取对应时间
        /// </summary>
        /// <returns></returns>
        public override DateTime ToDateTime() => m_datetime;

        /// <summary>
        /// 获取 Unix 时间戳
        /// </summary>
        /// <returns></returns>
        public override long ToTimestamp() => m_timestamp;

        private static readonly Func<DateTime, long> ToUnixTimestampFunc = time =>
            (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

        private static readonly Func<long, DateTime> FromUnixTimestampFunc = timestamp =>
            (TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local))
            .Add(new TimeSpan(long.Parse(timestamp + "0000000")));

        public static Func<long> NowUnixTimeStamp = () => ToUnixTimestampFunc(DateTime.Now);
        public static Func<long> UtcNowUnixTimeStamp = () => ToUnixTimestampFunc(DateTime.UtcNow);
    }
}