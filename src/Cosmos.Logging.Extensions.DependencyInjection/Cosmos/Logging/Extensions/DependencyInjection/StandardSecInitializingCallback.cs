using System;

namespace Cosmos.Logging.Extensions.DependencyInjection {
    /// <summary>
    /// Second initializing callback for Microsoft DI
    /// </summary>
    public class StandardSecInitializingCallback {
        private Action ProcessinAction { get; set; }

        /// <summary>
        /// Append action
        /// </summary>
        /// <param name="action"></param>
        public void AppendAction(Action action) {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            if (ProcessinAction == null)
                ProcessinAction = action;
            else
                ProcessinAction += action;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <returns></returns>
        public Action Invoke() => ProcessinAction;
    }
}