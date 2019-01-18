using System;

namespace Cosmos.IdUtils
{
    public sealed class ModelIdAccessor
    {
        private NoRepeatTimeStampFactory _factory = new NoRepeatTimeStampFactory();
        private int Index { get; set; }
        private DateTime Now { get; set; }

        private readonly object _lockObj = new object();

        public ModelIdAccessor()
        {
            Now = _factory.GetTimeStamp();
        }

        public int GetNextIndex()
        {
            int ix;

            lock (_lockObj)
            {
                ix = Index;
                Index = Index + 1;
            }

            return ix;
        }

        public DateTime GetTimeSpot() => Now;

        public void RefreshTimeSpot() => Now = _factory.GetTimeStamp();
    }
}