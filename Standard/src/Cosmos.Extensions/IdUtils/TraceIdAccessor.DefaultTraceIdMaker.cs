using System;

namespace Cosmos.IdUtils
{
    public class DefaultTraceIdMaker : ITraceIdMaker
    {
        public string CreateId()
        {
            var now = DateTime.Now;

            return $"{now:yyyyMMddHHmmddffff}{RandomIdProvider.Create(7)}{now.Ticks}";
        }
    }
}