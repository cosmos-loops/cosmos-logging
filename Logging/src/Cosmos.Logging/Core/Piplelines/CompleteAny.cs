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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/CompleteAny.cs
    /// Author: Sunlighter
    /// </summary>
    public abstract class CancellableResult<V> {
        public abstract V Complete();
        public abstract void Cancel();
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/CompleteAny.cs
    /// Author: Sunlighter
    /// </summary>
    public class CancellableOperation<V> : IDisposable {
        private Task<CancellableResult<V>> task;
        private CancellationTokenSource cts;

        public CancellableOperation(Task<CancellableResult<V>> task, CancellationTokenSource cts) {
            this.task = task;
            this.cts = cts;
        }

        public Task<CancellableResult<V>> Task {
            get { return task; }
        }

        public bool HasEnded {
            get { return task.IsCompleted || task.IsFaulted || task.IsCanceled; }
        }

        public void Cancel() {
            cts.Cancel();
        }

        public void Dispose() {
            cts.Dispose();
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/CompleteAny.cs
    /// Author: Sunlighter
    /// </summary>
    public delegate CancellableOperation<V> CancellableOperationStarter<V>(CancellationToken ctoken);

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/CompleteAny.cs
    /// Author: Sunlighter
    /// </summary>
    public static partial class Utils {
        private class GetCancellableResult<U, V> : CancellableResult<V> {
            private IQueueSource<U> queue;
            private U value;
            private Func<U, V> convertResult;
            private bool done;

            public GetCancellableResult(IQueueSource<U> queue, U value, Func<U, V> convertResult) {
                this.queue = queue;
                this.value = value;
                this.convertResult = convertResult;
                this.done = false;
            }

            public override V Complete() {
                if (!done) {
                    queue.ReleaseRead(1);
                    return convertResult(value);
                } else {
                    throw new InvalidOperationException("Get: Complete or Cancel can be called only once");
                }
            }

            public override void Cancel() {
                if (!done) {
                    queue.ReleaseRead(0);
                } else {
                    throw new InvalidOperationException("Get: Complete or Cancel can be called only once");
                }

                done = true;
            }
        }

        private class GetEofCancellableResult<U, V> : CancellableResult<V> {
            private IQueueSource<U> queue;
            private V eofResult;
            private bool done;

            public GetEofCancellableResult(IQueueSource<U> queue, V eofResult) {
                this.queue = queue;
                this.eofResult = eofResult;
                this.done = false;
            }

            public override V Complete() {
                if (!done) {
                    queue.ReleaseRead(0);
                    return eofResult;
                } else {
                    throw new InvalidOperationException("Get EOF: Complete or Cancel can be called only once");
                }
            }

            public override void Cancel() {
                if (!done) {
                    queue.ReleaseRead(0);
                } else {
                    throw new InvalidOperationException("Get EOF: Complete or Cancel can be called only once");
                }

                done = true;
            }
        }

        public static CancellableOperationStarter<V> StartableGet<U, V>(this IQueueSource<U> queue, Func<U, V> convertResult, V eofResult) {
            return delegate(CancellationToken ctoken) {
                CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(ctoken);

                Func<Task<CancellableResult<V>>> taskSource = async delegate() {
                    AcquireReadResult arr = await queue.AcquireReadAsync(1, cts.Token);

                    if (arr is AcquireReadSucceeded<U>) {
                        AcquireReadSucceeded<U> succeededResult = (AcquireReadSucceeded<U>) arr;

                        if (succeededResult.ItemCount == 1) {
                            return new GetCancellableResult<U, V>(queue, succeededResult.Items[0], convertResult);
                        } else {
                            System.Diagnostics.Debug.Assert(succeededResult.ItemCount == 0);
                            return new GetEofCancellableResult<U, V>(queue, eofResult);
                        }
                    } else if (arr is AcquireReadFaulted) {
                        AcquireReadFaulted faultedResult = (AcquireReadFaulted) arr;

                        throw faultedResult.Exception;
                    } else {
                        AcquireReadCancelled cancelledResult = (AcquireReadCancelled) arr;

                        throw new OperationCanceledException();
                    }
                };

                Task<CancellableResult<V>> task = null;
                try {
                    task = Task.Run(taskSource);
                }
                catch (OperationCanceledException e) {
#if NET451
                    var tcs = new TaskCompletionSource<CancellableResult<V>>();
                    tcs.SetException(e);
                    tcs.SetCanceled();
                    task = tcs.Task;
#else
                    task = Task.FromCanceled<CancellableResult<V>>(e.CancellationToken);
#endif
                }
                catch (Exception exc) {
#if NET451
                    var tcs = new TaskCompletionSource<CancellableResult<V>>();
                    tcs.TrySetException(exc);
                    task = tcs.Task;
#else
                    task = Task.FromException<CancellableResult<V>>(exc);
#endif
                }

                return new CancellableOperation<V>(task, cts);
            };
        }

        private class PutCancellableResult<U, V> : CancellableResult<V> {
            private IQueueSink<U> queue;
            private U valueToPut;
            private V successfulPut;
            private bool done;

            public PutCancellableResult(IQueueSink<U> queue, U valueToPut, V successfulPut) {
                this.queue = queue;
                this.valueToPut = valueToPut;
                this.successfulPut = successfulPut;
                done = false;
            }

            public override V Complete() {
                if (!done) {
                    queue.ReleaseWrite(valueToPut);
                    return successfulPut;
                } else {
                    throw new InvalidOperationException("Put: Complete or Cancel can be called only once");
                }
            }

            public override void Cancel() {
                if (!done) {
                    queue.ReleaseWrite();
                } else {
                    throw new InvalidOperationException("Put: Complete or Cancel can be called only once");
                }

                done = true;
            }
        }

        public static CancellableOperationStarter<V> StartablePut<U, V>(this IQueueSink<U> queue, U valueToPut, V successfulPut) {
            return delegate(CancellationToken ctoken) {
                CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(ctoken);

                Func<Task<CancellableResult<V>>> taskSource = async delegate() {
                    AcquireWriteResult awr = await queue.AcquireWriteAsync(1, cts.Token);

                    if (awr is AcquireWriteSucceeded) {
                        AcquireWriteSucceeded aws = (AcquireWriteSucceeded) awr;

                        System.Diagnostics.Debug.Assert(aws.ItemCount == 1);

                        return new PutCancellableResult<U, V>(queue, valueToPut, successfulPut);
                    } else if (awr is AcquireWriteFaulted) {
                        AcquireWriteFaulted awf = (AcquireWriteFaulted) awr;

                        throw awf.Exception;
                    } else {
                        AcquireWriteCancelled awc = (AcquireWriteCancelled) awr;

                        throw new OperationCanceledException();
                    }
                };

                Task<CancellableResult<V>> task = null;
                try {
                    task = taskSource();
                }
                catch (OperationCanceledException e) {
#if NET451
                    var tcs = new TaskCompletionSource<CancellableResult<V>>();
                    tcs.SetException(e);
                    tcs.SetCanceled();
                    task = tcs.Task;
#else
                    task = Task.FromCanceled<CancellableResult<V>>(e.CancellationToken);
#endif
                }
                catch (Exception exc) {
#if NET451
                    var tcs = new TaskCompletionSource<CancellableResult<V>>();
                    tcs.TrySetException(exc);
                    task = tcs.Task;
#else
                    task = Task.FromException<CancellableResult<V>>(exc);
#endif
                }

                return new CancellableOperation<V>(task, cts);
            };
        }

        public static ImmutableList<Tuple<K, CancellableOperationStarter<V>>> OperationStarters<K, V>() {
            return ImmutableList<Tuple<K, CancellableOperationStarter<V>>>.Empty;
        }

        public static ImmutableList<Tuple<K, CancellableOperationStarter<V>>> Add<K, V>
        (
            this ImmutableList<Tuple<K, CancellableOperationStarter<V>>> list,
            K key,
            CancellableOperationStarter<V> value
        ) {
            return list.Add(new Tuple<K, CancellableOperationStarter<V>>(key, value));
        }

        public static ImmutableList<Tuple<K, CancellableOperationStarter<V>>> AddIf<K, V>
        (
            this ImmutableList<Tuple<K, CancellableOperationStarter<V>>> list,
            bool condition,
            K key,
            CancellableOperationStarter<V> value
        ) {
            return condition ? list.Add(new Tuple<K, CancellableOperationStarter<V>>(key, value)) : list;
        }

        public static Task<Tuple<K, V>> CompleteAny<K, V>(this ImmutableList<Tuple<K, CancellableOperationStarter<V>>> operationStarters, CancellationToken ctoken) {
            object syncRoot = new object();
            TaskCompletionSource<Tuple<K, V>> tcs = new TaskCompletionSource<Tuple<K, V>>();

            ImmutableHashSet<int> waits = ImmutableHashSet<int>.Empty;
            ImmutableHashSet<int> canceled = ImmutableHashSet<int>.Empty;
            CancellableOperation<V>[] operations = new CancellableOperation<V>[operationStarters.Count];
            int? firstIndex = null;
            V firstResult = default(V);

            CancellationTokenRegistration? ctr = null;

            Action<CancellationTokenRegistration> setRegistration = delegate(CancellationTokenRegistration value) {
                lock (syncRoot) {
                    if (firstIndex.HasValue && waits.IsEmpty) {
                        value.PostDispose();
                    } else {
                        ctr = value;
                    }
                }
            };

            Action deliverFinalResult = delegate() {

                #region

                List<Exception> exc = new List<Exception>();

                foreach (int i in Enumerable.Range(0, operations.Length)) {
                    if (operations[i] == null) continue;

                    System.Diagnostics.Debug.Assert(operations[i].HasEnded);

                    if (operations[i].Task.IsFaulted) {
                        Exception eTask = operations[i].Task.Exception;
                        if (!(eTask is OperationCanceledException) || !(canceled.Contains(i))) {
                            exc.Add(eTask);
                        }
                    } else if (operations[i].Task.IsCanceled) {
                        if (!canceled.Contains(i)) {
                            exc.Add(new OperationCanceledException());
                        }
                    }
                }

                System.Diagnostics.Debug.Assert(firstIndex.HasValue);
                int fi = firstIndex.Value;

                if (exc.Count == 0) {
                    if (fi >= 0) {
                        tcs.PostResult(new Tuple<K, V>(operationStarters[fi].Item1, firstResult));
                    } else {
                        tcs.PostException(new OperationCanceledException(ctoken));
                    }
                } else if (exc.Count == 1) {
                    tcs.PostException(exc[0]);
                } else {
                    tcs.PostException(new AggregateException(exc));
                }

                if (ctr.HasValue) {
                    ctr.Value.PostDispose();
                }

                #endregion

            };

            Action unwind = delegate() {
                int j = operationStarters.Count;
                while (j > 0) {
                    --j;
                    if ((!firstIndex.HasValue) || j != firstIndex.Value) {
                        if (operations[j] != null) {
                            operations[j].Cancel();
                            canceled = canceled.Add(j);
                        }
                    }
                }
            };

            Action handleCancellation = delegate() {
                lock (syncRoot) {
                    if (!firstIndex.HasValue) {
                        firstIndex = -1;
                        unwind();
                    }
                }
            };

            Action<int> handleItemCompletion = delegate(int i) {
                lock (syncRoot) {
                    System.Diagnostics.Debug.Assert(waits.Contains(i));
                    waits = waits.Remove(i);

                    if (firstIndex.HasValue) {
                        if (operations[i].Task.Status == TaskStatus.RanToCompletion) {
                            operations[i].Task.Result.Cancel();
                            canceled = canceled.Add(i);
                        }
                    } else {
                        firstIndex = i;

                        if (operations[i].Task.Status == TaskStatus.RanToCompletion) {
                            firstResult = operations[i].Task.Result.Complete();
                        }

                        unwind();
                    }

                    if (waits.IsEmpty) {
                        deliverFinalResult();
                    }
                }
            };

            lock (syncRoot) {
                bool shouldUnwind = false;

                ctoken.PostRegistration(setRegistration, handleCancellation);

                foreach (int i in Enumerable.Range(0, operationStarters.Count)) {
                    CancellableOperation<V> op = operationStarters[i].Item2(ctoken);
                    operations[i] = op;
                    if (op.HasEnded) {
                        shouldUnwind = true;
                        firstIndex = i;
                        if (op.Task.IsCompleted) {
                            firstResult = op.Task.Result.Complete();
                        }

                        break;
                    } else {
                        waits = waits.Add(i);

                        //continuations[i] =
                        op.Task.PostContinueWith
                        (
                            taskUnused => { handleItemCompletion(i); }
                        );
                    }
                }

                if (shouldUnwind) {
                    if (!waits.IsEmpty) {
                        unwind();
                    } else {
                        deliverFinalResult();
                    }
                }
            }

            return tcs.Task;
        }
    }
}