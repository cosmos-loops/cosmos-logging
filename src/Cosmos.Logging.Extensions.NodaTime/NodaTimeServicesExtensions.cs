using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.NodaTime.Internals;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class NodaTimeServicesExtensions
    {
        public static ILogServiceCollection ConfigureForNodaTime(this ILogServiceCollection services, IDateTimeZoneProvider provider)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            services.AsScalar<Offset>();
            services.AsScalar<CalendarSystem>();

            services.With<InstantDestructureResolveRule>();
            services.With<LocalDateDestructureResolveRule>();
            services.With<LocalDateTimeDestructureResolveRule>();
            services.With<LocalTimeDestructureResolveRule>();
            services.With<OffsetDateTimeDestructureResolveRule>();
            services.With<DateTimeZoneDestructureResolveRule>();
            services.With(new ZonedDateTimeDestructureResolveRule(provider));
            services.With<DurationDestructureResolveRule>();
            services.With<PeriodDestructureResolveRule>();
            services.With<IntervalDestructureResolveRule>();

            return services;
        }
    }
}