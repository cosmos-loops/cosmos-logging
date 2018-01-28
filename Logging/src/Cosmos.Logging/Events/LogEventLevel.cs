using System;
using System.ComponentModel;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Events {
    [Flags]
    public enum LogEventLevel : uint {
        /// <summary>
        /// Anything and everything you might want to know about
        /// a running block of code.
        /// </summary>
        [Description(LogEventLevelConstants.Verbose)]
        Verbose = 0,

        /// <summary>
        /// Internal system events that aren't necessarily
        /// observable from the outside.
        /// </summary>
        [Description(LogEventLevelConstants.Debug)]
        Debug = 1,

        /// <summary>
        /// The lifeblood of operational intelligence - things
        /// happen.
        /// </summary>
        [Description(LogEventLevelConstants.Information)]
        Information = 2,

        /// <summary>
        /// Service is degraded or endangered.
        /// </summary>
        [Description(LogEventLevelConstants.Warning)]
        Warning = 4,

        /// <summary>
        /// Functionality is unavailable, invariants are broken
        /// or data is lost.
        /// </summary>
        [Description(LogEventLevelConstants.Error)]
        Error = 8,

        /// <summary>
        /// If you have a pager, it goes off when one of these
        /// occurs.
        /// </summary>
        [Description(LogEventLevelConstants.Fatal)]
        Fatal = 16,

        /// <summary>
        /// Do not recode all logs
        /// </summary>
        [Description(LogEventLevelConstants.Off)]
        Off = 32
    }


}