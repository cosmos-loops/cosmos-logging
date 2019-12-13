using System;
using Cosmos.Logging.ExtraSupports;
using Cosmos.Logging.RunsOn.NancyFX.Core;
using Nancy;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for NancyFX Context
    /// </summary>
    public static class NancyContextSoloExtensions {
        /// <summary>
        /// Add NancyFX Context into ContextData
        /// </summary>
        /// <param name="context"></param>
        /// <param name="nancyContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddNancyContext(this ContextData context, NancyContext nancyContext) {
            if (context is null) throw new ArgumentNullException(nameof(context));
            context.Add(Constants.NancyContextName, new NancyContextSolo(nancyContext));
        }

        /// <summary>
        /// Has NancyFX Context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool HasNancyContext(this ContextData context) {
            return context?.ContainsKey(Constants.NancyContextName) ?? false;
        }

        /// <summary>
        /// Gets NancyFX Context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NancyContext GetNancyContext(this ContextData context) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.TryGetValue(Constants.NancyContextName, out var value) && value is NancyContextSolo solo) {
                return solo.GetContext();
            }

            return null;
        }

        /// <summary>
        /// Add NancyFX Context into LogEventContext
        /// </summary>
        /// <param name="context"></param>
        /// <param name="nancyContext"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LogEventContext AddNancyContext(this LogEventContext context, NancyContext nancyContext) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.AddData(Constants.NancyContextName, new NancyContextSolo(nancyContext), false);
            return context;
        }
    }
}