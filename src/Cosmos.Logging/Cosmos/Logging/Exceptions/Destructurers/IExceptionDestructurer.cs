using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Destructurers {
    /// <summary>
    /// Interface that all exception destructurer should implement.
    /// </summary>
    public interface IExceptionDestructurer {
        /// <summary>
        /// Types of exception that the destructurer can be handle.
        /// </summary>
        Type[] TargetTypes { get; }

        /// <summary>
        /// To destructure the given <paramref name="exception"/>,
        /// the results will be put into <paramref name="propertyBag"/>.
        /// </summary>
        /// <param name="exception">Exception what should be destructured.</param>
        /// <param name="propertyBag">Exception property bag.</param>
        /// <param name="destructureExceptionHandle">Function that can be used to destructure inner exceptions if needed.</param>
        void Destructure(Exception exception, IExceptionPropertyBag propertyBag, Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle);
    }
}