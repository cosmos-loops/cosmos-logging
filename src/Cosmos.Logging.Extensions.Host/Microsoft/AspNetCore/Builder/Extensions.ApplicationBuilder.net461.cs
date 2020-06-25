#if NET461

using System;
using Cosmos.Logging.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder {
    /// <summary>
    /// Application builder extensions
    /// </summary>
    public static class ApplicationBuilderExtensions {
        /// <summary>
        /// Use cosmos localization
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCosmosLogging(this IApplicationBuilder builder) {

            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            var resolver = builder.ApplicationServices;

            var callback = resolver.GetRequiredService<StandardSecInitializingCallback>();
            callback?.Invoke();

            return builder;
        }
    }
}

#endif