#region License

/*
 * All content copyright Sunlighter, unless otherwise indicated. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy
 * of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 */

#endregion

using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/Utils.cs
    /// Author: Sunlighter
    /// </summary>
    public static partial class Utils {
        public static void PostResult<T>(this TaskCompletionSource<T> k, T result) {
            ThreadPool.QueueUserWorkItem(notUsed => k.SetResult(result));
        }

        public static void PostException<T>(this TaskCompletionSource<T> k, Exception exc) {
            ThreadPool.QueueUserWorkItem(notUsed => k.SetException(exc));
        }

        public static void PostCancellation<T>(this TaskCompletionSource<T> k) {
            ThreadPool.QueueUserWorkItem(notUsed => k.SetCanceled());
        }

        public static void PostRegistration(this CancellationToken ct, Action<CancellationTokenRegistration> setRegistration, Action callback) {
            ThreadPool.QueueUserWorkItem
            (
                notUsed => {
                    CancellationTokenRegistration ctr = ct.Register
                    (
                        () => {
                            ThreadPool.QueueUserWorkItem
                            (
                                notUsed2 => { callback(); }
                            );
                        }
                    );
                    setRegistration(ctr);
                }
            );
        }

        public static Task PostContinueWith<T>(this Task<T> task, Action<Task<T>> action) {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            task.ContinueWith
            (
                task2 => {
                    ThreadPool.QueueUserWorkItem
                    (
                        obj => {
                            try {
                                action(task2);
                                tcs.SetResult(true);
                            }
                            catch (Exception exc) {
                                tcs.SetException(exc);
                            }
                        }
                    );
                },
                TaskContinuationOptions.None
            );

            return tcs.Task;
        }

        [Obsolete]
        public static bool IsCompletedNormally(this Task t) {
            return t.Status == TaskStatus.RanToCompletion;
        }

        public static void ReleaseWrite<T>(this IQueueSink<T> queue) {
            queue.ReleaseWrite(ImmutableList<T>.Empty);
        }

        public static void ReleaseWrite<T>(this IQueueSink<T> queue, T producedItem) {
            queue.ReleaseWrite(ImmutableList<T>.Empty.Add(producedItem));
        }

        public static async Task Enqueue<T>(this IQueueSink<T> queue, T item, CancellationToken ctoken) {
            AcquireWriteResult result = await queue.AcquireWriteAsync(1, ctoken);

            result.Visit<DBNull>
            (
                new Func<AcquireWriteSucceeded, DBNull>
                (
                    succeeded => {
                        System.Diagnostics.Debug.Assert(succeeded.ItemCount == 1);

                        bool wasCancelled = false;
                        if (ctoken.IsCancellationRequested) {
                            wasCancelled = true;
                            queue.ReleaseWrite();
                        } else {
                            queue.ReleaseWrite(item);
                        }

                        if (wasCancelled) {
                            throw new OperationCanceledException(ctoken);
                        }

                        return DBNull.Value;
                    }
                ),
                new Func<AcquireWriteCancelled, DBNull>
                (
                    cancelled => { throw new OperationCanceledException(ctoken); }
                ),
                new Func<AcquireWriteFaulted, DBNull>
                (
                    faulted => { throw faulted.Exception; }
                )
            );
        }

        public static async Task<Option<T>> Dequeue<T>(this IQueueSource<T> queue, CancellationToken ctoken) {
            AcquireReadResult result = await queue.AcquireReadAsync(1, ctoken);

            return result.Visit<Option<T>>
            (
                new Func<AcquireReadSucceeded, Option<T>>
                (
                    succeeded => {
                        if (succeeded.ItemCount == 0) {
                            return new None<T>();
                        } else {
                            System.Diagnostics.Debug.Assert(succeeded.ItemCount == 1);

                            bool wasCancelled = false;
                            if (ctoken.IsCancellationRequested) {
                                wasCancelled = true;
                                queue.ReleaseRead(0);
                            } else {
                                queue.ReleaseRead(1);
                            }

                            if (wasCancelled) {
                                throw new OperationCanceledException(ctoken);
                            }

                            return new Some<T>(((AcquireReadSucceeded<T>) succeeded).Items[0]);
                        }
                    }
                ),
                new Func<AcquireReadCancelled, Option<T>>
                (
                    cancelled => { throw new OperationCanceledException(ctoken); }
                ),
                new Func<AcquireReadFaulted, Option<T>>
                (
                    faulted => { throw faulted.Exception; }
                )
            );
        }

        public static void PostDispose(this CancellationTokenRegistration ctr) {
            ThreadPool.QueueUserWorkItem
            (
                obj => { ctr.Dispose(); }
            );
        }
    }
}