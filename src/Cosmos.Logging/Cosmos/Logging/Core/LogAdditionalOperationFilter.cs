using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Log additional operation filter
    /// </summary>
    public static class LogAdditionalOperationFilter {
        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="context"></param>
        /// <param name="flagType"></param>
        /// <param name="optType"></param>
        /// <returns></returns>
        public static IEnumerable<IAdditionalOperation> Filter(LogEventContext context, Type flagType, AdditionalOperationTypes optType) {
            if (context == null) return ReturnEmptyAdditionalOperations();
            if (flagType == null) return ReturnEmptyAdditionalOperations();
            return FilterAfterChecking(context.ExposeOpts(), flagType, optType);
        }

        private static IEnumerable<IAdditionalOperation> ReturnEmptyAdditionalOperations() => Enumerable.Empty<IAdditionalOperation>();

        private static IEnumerable<IAdditionalOperation> FilterAfterChecking(IEnumerable<IAdditionalOperation> opts, Type flagType, AdditionalOperationTypes optType) {
            return opts.Where(x => x.Flag == flagType && x.Type == optType).ToImmutableList();
        }
    }
}