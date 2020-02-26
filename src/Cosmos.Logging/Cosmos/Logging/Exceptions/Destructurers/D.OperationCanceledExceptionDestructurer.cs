using System;
using System.Collections.Generic;
using System.Threading;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Destructurers {
    /// <summary>
    /// OperationCanceled exception destructurer
    /// </summary>
    public class OperationCanceledExceptionDestructurer : ExceptionDestructurer<OperationCanceledException> {
        /// <inheritdoc />
        protected override void DestructureException(OperationCanceledException exception, IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(OperationCanceledException.CancellationToken), DestructureCancellationToken(exception.CancellationToken));
        }

        private const string CancellationTokenTrue = "CancellationRequested: true";
        private const string CancellationTokenFalse = "CancellationRequested: false";

        internal static object DestructureCancellationToken(in CancellationToken cancellationToken) {
            return cancellationToken.IsCancellationRequested
                ? CancellationTokenTrue
                : CancellationTokenFalse;
        }
    }
}