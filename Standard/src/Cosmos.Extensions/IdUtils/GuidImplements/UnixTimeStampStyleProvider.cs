using System;

namespace Cosmos.IdUtils.GuidImplements
{
    public static class UnixTimeStampStyleProvider
    {
        private static DateTime GetUnixUtcNow() => new UnixTimeStamp(DateTime.UtcNow).ToDateTime();
        private static DateTime GetNoRepeatUnixUtcNow() => NoRepeatTimeStampManager.GetFactory().GetUtcUnixTimeStampObject().ToDateTime();

        public static Guid Create()
            => Create(NoRepeatMode.Off);

        public static Guid Create(Guid value)
            => Create(value, NoRepeatMode.Off);

        public static Guid Create(NoRepeatMode mode)
            => Create(Guid.NewGuid(), mode);

        public static Guid Create(Guid value, NoRepeatMode mode)
            => Create(value, mode == NoRepeatMode.On ? GetNoRepeatUnixUtcNow() : GetUnixUtcNow());

        public static Guid Create(DateTime secureTimestamp)
            => Create(Guid.NewGuid(), secureTimestamp);

        public static Guid Create(Guid value, DateTime secureTimestamp)
        {
            byte[] guidArray = value.ToByteArray();
            DateTime basedTime = new DateTime(1_900, 1, 1);

            //To get the number of day and ms
            TimeSpan days = new TimeSpan(secureTimestamp.Ticks - basedTime.Ticks);
            TimeSpan msecs = new TimeSpan(secureTimestamp.Ticks - (new DateTime(secureTimestamp.Year, secureTimestamp.Month, secureTimestamp.Day).Ticks));

            //Convert to byte array
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long) (msecs.TotalMilliseconds / 3.333_333));

            //Reserve byte
            daysArray.Reverse();
            msecsArray.Reverse();

            //Copy bytes into Guid
            daysArray.Copy(daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            msecsArray.Copy(msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}