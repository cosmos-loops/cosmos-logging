using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Interface for log payload
    /// </summary>
    public interface ILogPayload : IEnumerable<LogEvent> {
        /// <summary>
        /// Gets name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get source type
        /// </summary>
        Type SourceType { get; }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="logEvent"></param>
        void Add(LogEvent logEvent);

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="logEvents"></param>
        void AddRange(IEnumerable<LogEvent> logEvents);

        /// <summary>
        /// Export
        /// </summary>
        /// <returns></returns>
        ILogPayload Export();

        /// <summary>
        /// Reset
        /// </summary>
        void Reset();

        /// <summary>
        /// Cleat
        /// </summary>
        void Clear();
    }
}