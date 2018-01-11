using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Cosmos.Logging.Core {
    public static class LogAdditionalOperationFilter {
        public static IEnumerable<IAdditionalOperation> Filter(AdditionalOptContext context, Type flagType, AdditionalOperationTypes optType) {
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