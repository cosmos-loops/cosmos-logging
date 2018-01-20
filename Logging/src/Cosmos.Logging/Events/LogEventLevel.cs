using System;
using System.ComponentModel;

namespace Cosmos.Logging.Events {
    [Flags]
    public enum LogEventLevel : uint {
        /// <summary>
        /// Anything and everything you might want to know about
        /// a running block of code.
        /// </summary>
        [Description("Verbose")] Verbose = 0,

        /// <summary>
        /// Internal system events that aren't necessarily
        /// observable from the outside.
        /// </summary>
        [Description("Debug")] Debug = 1,

        /// <summary>
        /// The lifeblood of operational intelligence - things
        /// happen.
        /// </summary>
        [Description("Information")] Information = 2,

        /// <summary>
        /// Service is degraded or endangered.
        /// </summary>
        [Description("Warning")] Warning = 4,

        /// <summary>
        /// Functionality is unavailable, invariants are broken
        /// or data is lost.
        /// </summary>
        [Description("Error")] Error = 8,

        /// <summary>
        /// If you have a pager, it goes off when one of these
        /// occurs.
        /// </summary>
        [Description("Fatal")] Fatal = 16,

        /// <summary>
        /// Do not recode all logs
        /// </summary>
        [Description("Off")] Off = 32
    }
}