using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.NodaTime;
using NodaTime;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for NodaTime
    /// </summary>
    public static class NodaTimeServicesExtensions {
        /// <summary>
        /// Add NodaTime integration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection AddNodaTimeIntegration(this ILogServiceCollection services, IDateTimeZoneProvider provider) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (provider is null)
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