using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Destructurers {
    /// <summary>
    /// TaskCanceled exception destructurer
    /// </summary>
    public class TaskCanceledExceptionDestructurer : OperationCanceledExceptionDestructurer {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] {typeof(TaskCanceledException)};

        /// <inheritdoc />
        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var tce = (TaskCanceledException) exception;

            propertyBag.AddProperty(nameof(TaskCanceledException.Task), DestructureTask(tce.Task, destructureExceptionHandle));
        }

        private static object DestructureTask(Task task, Func<Exception, IReadOnlyDictionary<string, object>> innerDestructure) {
            if (task is null) {
                return "null";
            }

            var taskStatus = task.Status.ToString("G");
            var taskCreationOptions = task.CreationOptions.ToString("F");

            if (task.IsFaulted && task.Exception != null) {
                return new {
                    task.Id,
                    Status = taskStatus,
                    CreationOptions = taskCreationOptions,
                    Exception = innerDestructure(task.Exception),
                };
            }

            return new {
                task.Id,
                Status = taskStatus,
                CreationOptions = taskCreationOptions,
            };
        }
    }
}