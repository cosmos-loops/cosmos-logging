using System;
using Cosmos.IdUtils.CombImplements.Strategies;
using Cosmos.IdUtils.GuidImplements;

namespace Cosmos.IdUtils.CombImplements.Providers
{
    internal delegate Guid InternalGuidProvider();

    internal delegate DateTime InternalTimeStampProvider();

    internal abstract class BaseProvider : ICombProvider
    {
        protected IDateStrategy _dateTimeStrategy;

        public BaseProvider(IDateStrategy strategy,
            InternalTimeStampProvider customTimeStampProvider = null,
            InternalGuidProvider customGuidProvider = null)
        {
            if (strategy.NumDateBytes != 4 && strategy.NumDateBytes != 6)
            {
                throw new NotSupportedException("ICombDateTimeStrategy is limited to either 4 or 6 bytes.");
            }

            _dateTimeStrategy = strategy;
            InternalTimeStampProvider = customTimeStampProvider ?? DefaultTimeStampProvider;
            InternalGuidProvider = customGuidProvider ?? NoParamGuidImplementProxy.Basic;
        }

        public Guid Create() => Create(InternalGuidProvider.Invoke(), InternalTimeStampProvider.Invoke());

        public Guid Create(Guid value) => Create(value, InternalTimeStampProvider.Invoke());

        public Guid Create(DateTime timestamp) => Create(InternalGuidProvider.Invoke(), timestamp);

        public abstract Guid Create(Guid value, DateTime timestamp);

        public abstract DateTime GetTimeStamp(Guid value);
        
        protected static DateTime DefaultTimeStampProvider() => DateTime.UtcNow;

        public InternalTimeStampProvider InternalTimeStampProvider { get; } = DefaultTimeStampProvider;

        public InternalGuidProvider InternalGuidProvider { get; } = NoParamGuidImplementProxy.Basic;
    }
}