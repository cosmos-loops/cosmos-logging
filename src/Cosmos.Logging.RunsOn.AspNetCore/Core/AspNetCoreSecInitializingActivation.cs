using System;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal sealed class AspNetCoreSecInitializingActivation : ISecInitializingActivation {

        private Action ProcessinAction { get; set; }

        public void AppendAction(Action action) => ProcessinAction += action ?? throw new ArgumentNullException(nameof(action));

        public Action GetSecProcessing() => ProcessinAction;
    }
}