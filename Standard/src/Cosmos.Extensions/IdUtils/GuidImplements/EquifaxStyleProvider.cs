using System;

namespace Cosmos.IdUtils.GuidImplements
{
    /*
     * Reference To:
     *     https://github.com/abock/EquifaxGuid
     *     Aaron Bockover (abock)
     *         @Microsoft @Xamarin
     *     https://twitter.com/abock
     */

    internal static class EquifaxStyleProvider
    {
        public static Guid Create()
            => Create(DateTime.UtcNow);

        public static Guid Create(NoRepeatMode mode)
            => Create(mode == NoRepeatMode.On ? NoRepeatTimeStampManager.GetFactory().GetUtcTimeStamp() : DateTime.UtcNow);

        public static Guid Create(DateTime secureTimestamp)
            => new Guid($"00000000-0000-0000-0000-00" +
                        $"{secureTimestamp.Month:00}" +
                        $"{secureTimestamp.Day:00}" +
                        $"{secureTimestamp.Year % 100:00}" +
                        $"{secureTimestamp.Hour:00}" +
                        $"{secureTimestamp.Minute:00}");
    }
}