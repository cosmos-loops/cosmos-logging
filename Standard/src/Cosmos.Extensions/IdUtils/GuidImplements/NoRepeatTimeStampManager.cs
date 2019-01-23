using Cosmos.IdUtils.CombImplements.Providers;

namespace Cosmos.IdUtils.GuidImplements
{
    internal static class NoRepeatTimeStampManager
    {
        private static readonly NoRepeatTimeStampFactory _factory;

        static NoRepeatTimeStampManager()
        {
            _factory = new NoRepeatTimeStampFactory();
        }

        public static NoRepeatTimeStampFactory GetFactory() => _factory;

        public static InternalTimeStampProvider GetTimeStampProvider(NoRepeatMode mode)
        {
            if (mode == NoRepeatMode.On)
                return GetFactory().GetTimeStamp;
            return null;
        }
    }
}