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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Optionals;

namespace Cosmos.Logging.Core.Piplelines {

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/PipelineExtensions.cs
    /// Author: Sunlighter
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    [SuppressMessage("ReSharper", "RedundantLambdaParameterType")]
    public static class PipelineExtensions {
        /// <summary>
        /// AsQueueSource
        /// </summary>
        /// <param name="items"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<T> AsQueueSource<T>(this IEnumerable<T> items, int? capacity = null) {
            AsyncQueue<T> queue = new AsyncQueue<T>(capacity ?? 2);

            Func<Task> feed = async delegate {
                foreach (var item in items) {
                    await queue.Enqueue(item, CancellationToken.None);
                }

                queue.WriteEof();
            };

            Task _dummy = Task.Run(feed);

            return queue;
        }

        /// <summary>
        /// AsEnumerable
        /// </summary>
        /// <param name="queue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this IQueueSource<T> queue) {
            BlockingCollection<T> bc = new BlockingCollection<T>();

            Func<Task> feed = async delegate {
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);

                    if (item.HasValue) {
                        bc.Add(item.Value);
                    } else break;
                }

                bc.CompleteAdding();
            };

            Task _dummy = Task.Run(feed);

            while (true) {
                T item2 = default(T);
                bool success = false;
                try {
                    item2 = bc.Take();
                    success = true;
                } catch (InvalidOperationException exc) {
                    // BlockingCollection ran out of items
                    System.Diagnostics.Debug.WriteLine(exc);
                }

                if (!success) break;

                yield return item2;
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="func"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static IQueueSource<U> Select<T, U>(this IQueueSource<T> queue, Func<T, Task<U>> func, int? capacity = null) {
            AsyncQueue<U> outQueue = new AsyncQueue<U>(capacity ?? 2);

            Func<Task> worker = async delegate {
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);
                    if (!item.HasValue) break;
                    U item2 = await func(item.Value);
                    await outQueue.Enqueue(item2, CancellationToken.None);
                }

                outQueue.WriteEof();
            };

            Task.Run(worker);

            return outQueue;
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="predicate"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<T> Where<T>(this IQueueSource<T> queue, Func<T, Task<bool>> predicate, int? capacity = null) {
            AsyncQueue<T> outQueue = new AsyncQueue<T>(capacity ?? 2);

            Func<Task> worker = async delegate {
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);
                    if (!item.HasValue) break;
                    if (await predicate(item.Value)) {
                        await outQueue.Enqueue(item.Value, CancellationToken.None);
                    }
                }

                outQueue.WriteEof();
            };

            Task _dummy = Task.Run(worker);

            return outQueue;
        }

        /// <summary>
        /// ParallelSelect
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="func"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static IQueueSource<U> ParallelSelect<T, U>(this IQueueSource<T> queue, ParallelWorker parallelWorker, Func<T, Task<U>> func, int? capacity = null) {
            AsyncQueue<U> outQueue = new AsyncQueue<U>(capacity ?? 2);

            IdleDetector idleDetector = new IdleDetector();

            Func<Task> workPoster = async delegate {
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);
                    if (!item.HasValue) break;
                    T itemValue = item.Value;

                    idleDetector.Enter();

                    Task doingWork = await parallelWorker.StartWorkItem
                    (
                        async (int workerId) => {
                            try {
                                U item2 = await func(itemValue);
                                await outQueue.Enqueue(item2, CancellationToken.None);
                            } finally {
                                idleDetector.Leave();
                            }
                        },
                        CancellationToken.None
                    );
                }

                await idleDetector.WaitForIdle(CancellationToken.None);

                outQueue.WriteEof();
            };

            Task.Run(workPoster);

            return outQueue;
        }

        /// <summary>
        /// ParallelWhere
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="predicate"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<T> ParallelWhere<T>(this IQueueSource<T> queue, ParallelWorker parallelWorker, Func<T, Task<bool>> predicate, int? capacity = null) {
            AsyncQueue<T> outQueue = new AsyncQueue<T>(capacity ?? 2);

            IdleDetector idleDetector = new IdleDetector();

            Func<Task> workPoster = async delegate {
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);
                    if (!item.HasValue) break;
                    T itemValue = item.Value;

                    idleDetector.Enter();

                    Task doingWork = await parallelWorker.StartWorkItem
                    (
                        async (int workerId) => {
                            try {
                                if (await predicate(itemValue)) {
                                    await outQueue.Enqueue(itemValue, CancellationToken.None);
                                }
                            } finally {
                                idleDetector.Leave();
                            }
                        },
                        CancellationToken.None
                    );
                }

                await idleDetector.WaitForIdle(CancellationToken.None);

                outQueue.WriteEof();
            };

            Task.Run(workPoster);

            return outQueue;
        }

        private class IndexedSource<T> : IQueueSource<Tuple<int, T>> {
            private IQueueSource<T> parent;
            private int index;

            public IndexedSource(IQueueSource<T> parent) {
                this.parent = parent;
            }

            public async Task<AcquireReadResult> AcquireReadAsync(int desiredItems, CancellationToken ctoken) {
                AcquireReadResult parentResult = await parent.AcquireReadAsync(desiredItems, ctoken);

                if (parentResult is AcquireReadSucceeded<T>) {
                    AcquireReadSucceeded<T> parentSuccess = (AcquireReadSucceeded<T>) parentResult;
                    ImmutableList<Tuple<int, T>> sequence = ImmutableList<Tuple<int, T>>.Empty;
                    foreach (var x in Enumerable.Range(0, parentSuccess.ItemCount)) {
                        sequence = sequence.Add(new Tuple<int, T>(index + x, parentSuccess.Items[x]));
                    }

                    return new AcquireReadSucceeded<Tuple<int, T>>(parentSuccess.Offset, sequence);
                } else {
                    return parentResult;
                }
            }

            public void ReleaseRead(int consumedItems) {
                parent.ReleaseRead(consumedItems);
                index += consumedItems;
            }
        }

        /// <summary>
        /// Indexed
        /// </summary>
        /// <param name="queue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<Tuple<int, T>> Indexed<T>(this IQueueSource<T> queue) {
            return new IndexedSource<T>(queue);
        }

        private class SynchronousSelectedSource<T, U> : IQueueSource<U> {
            private IQueueSource<T> parent;
            private Func<T, U> func;

            public SynchronousSelectedSource(IQueueSource<T> parent, Func<T, U> func) {
                this.parent = parent;
                this.func = func;
            }

            public async Task<AcquireReadResult> AcquireReadAsync(int desiredItems, CancellationToken ctoken) {
                AcquireReadResult parentResult = await parent.AcquireReadAsync(desiredItems, ctoken);

                if (parentResult is AcquireReadSucceeded<T>) {
                    AcquireReadSucceeded<T> parentSuccess = (AcquireReadSucceeded<T>) parentResult;
                    ImmutableList<U> sequence = ImmutableList<U>.Empty.AddRange(parentSuccess.Items.Select(func));
                    return new AcquireReadSucceeded<U>(parentSuccess.Offset, sequence);
                } else {
                    return parentResult;
                }
            }

            public void ReleaseRead(int consumedItems) {
                parent.ReleaseRead(consumedItems);
            }
        }

        /// <summary>
        /// SynchronousSelect
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static IQueueSource<U> SynchronousSelect<T, U>(this IQueueSource<T> queue, Func<T, U> func) {
            return new SynchronousSelectedSource<T, U>(queue, func);
        }

        /// <summary>
        /// Reorder
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="getOrder"></param>
        /// <param name="first"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<T> Reorder<T>(this IQueueSource<T> queue, Func<T, int> getOrder, int first, int? capacity = null) {
            AsyncQueue<T> outQueue = new AsyncQueue<T>(capacity ?? 2);

            Func<Task> worker = async delegate {
                int next = first;
                ImmutableDictionary<int, T> buffer = ImmutableDictionary<int, T>.Empty;
                while (true) {
                    IOptional<T> item = await queue.Dequeue(CancellationToken.None);
                    if (!item.HasValue) break;
                    int order = getOrder(item.Value);
                    if (order == next) {
                        await outQueue.Enqueue(item.Value, CancellationToken.None);
                        ++next;
                        while (buffer.ContainsKey(next)) {
                            await outQueue.Enqueue(buffer[next], CancellationToken.None);
                            buffer = buffer.Remove(next);
                            ++next;
                        }
                    } else {
                        buffer = buffer.Add(order, item.Value);
                    }
                }

                outQueue.WriteEof();
            };

            Task.Run(worker);

            return outQueue;
        }

        /// <summary>
        /// OrderedParallelSelect
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="func"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static IQueueSource<U> OrderedParallelSelect<T, U>(this IQueueSource<T> queue, ParallelWorker parallelWorker, Func<T, Task<U>> func, int? capacity = null) {
            Func<Tuple<int, T>, Task<Tuple<int, U>>> func2 = async pair => new Tuple<int, U>(pair.Item1, await func(pair.Item2));

            return queue.Indexed().ParallelSelect(parallelWorker, func2, capacity).Reorder(pair => pair.Item1, 0, capacity).SynchronousSelect(pair => pair.Item2);
        }

        /// <summary>
        /// OrderedParallelWhere
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="predicate"></param>
        /// <param name="capacity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueueSource<T> OrderedParallelWhere<T>(this IQueueSource<T> queue, ParallelWorker parallelWorker, Func<T, Task<bool>> predicate, int? capacity = null) {
            Func<Tuple<int, T>, Task<Tuple<int, T, bool>>> func2 = async pair => new Tuple<int, T, bool>(pair.Item1, pair.Item2, await predicate(pair.Item2));

            return queue.Indexed().ParallelSelect(parallelWorker, func2, capacity).Reorder(pair => pair.Item1, 0, capacity).Where(i => Task.FromResult(i.Item3), capacity)
                        .SynchronousSelect(i => i.Item2);
        }
    }
}