using System;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.RunsOn.AspNet.Autofac.Core {
    public class StaticProviderHack {
        public StaticProviderHack(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            StaticInstanceOfLoggingServiceProvider.SetInstance(loggingServiceProvider);
        }
    }
}