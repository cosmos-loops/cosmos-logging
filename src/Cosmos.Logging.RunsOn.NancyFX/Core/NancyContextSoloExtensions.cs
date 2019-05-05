using System;
using Cosmos.Logging.ExtraSupports;
using Cosmos.Logging.RunsOn.NancyFX.Core;
using Nancy;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class NancyContextSoloExtensions {
        public static void AddNancyContext(this ContextData context, NancyContext nancyContext) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.Add(Constants.NancyContextName, new NancyContextSolo(nancyContext));
        }

        public static bool HasNancyContext(this ContextData context) {
            return context?.ContainsKey(Constants.NancyContextName) ?? false;
        }

        public static NancyContext GetNancyContext(this ContextData context) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.TryGetValue(Constants.NancyContextName, out var value) && value is NancyContextSolo solo) {
                return solo.GetContext();
            }

            return null;
        }

        public static LogEventContext AddNancyContext(this LogEventContext context, NancyContext nancyContext) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.AddData(Constants.NancyContextName, new NancyContextSolo(nancyContext), false);
            return context;
        }
    }
}