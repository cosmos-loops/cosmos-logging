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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public static class WorkerTask {
        public static Func<Task> ForEach<T>(IQueueSource<T> source, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync, ExceptionCollector ec) {
            Func<Task> t = async delegate() {
                try {
                    while (true) {
                        var item = await source.Dequeue(ec.CancellationToken);
                        if (!item.HasValue) break;
                        try {
                            await processAsync(new ForEachInfo<T>(item.Value, 0, 0, ec.CancellationToken));
                        }
                        catch (Exception exc) {
                            ec.Add(exc);
                            break;
                        }
                    }
                }
                finally {
                    if (onCloseAsync != null) {
                        try {
                            await onCloseAsync();
                        }
                        catch (Exception exc) {
                            ec.Add(exc);
                        }
                    }
                }
            };

            return t;
        }

        public static Func<Task> ForEach<T>(IQueueSource<T>[] sources, InputPriorities inputPriorities, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync,
            ExceptionCollector ec) {
            Func<Task> t = async delegate() {
                try {
                    int sourceCount = sources.Length;
                    bool[] atEof = new bool[sourceCount];
                    RoundRobinLoopGenerator loop = new RoundRobinLoopGenerator(sourceCount, inputPriorities);
                    while (!(atEof.All(e => e))) {
                        var ops = Cosmos.Logging.Core.Piplelines.Utils.OperationStarters<int, Option<T>>();

                        loop.ForEach
                        (
                            j => { ops = ops.AddIf(!atEof[j], j, Cosmos.Logging.Core.Piplelines.Utils.StartableGet<T, Option<T>>(sources[j], a => new Some<T>(a), new None<T>())); }
                        );

                        Tuple<int, Option<T>> result = await ops.CompleteAny(ec.CancellationToken);

                        if (result.Item2.HasValue) {
                            try {
                                await processAsync(new ForEachInfo<T>(result.Item2.Value, result.Item1, 0, ec.CancellationToken));
                            }
                            catch (Exception exc) {
                                ec.Add(exc);
                            }
                        } else {
                            atEof[result.Item1] = true;
                        }
                    }
                }
                finally {
                    if (onCloseAsync != null) {
                        try {
                            await onCloseAsync();
                        }
                        catch (Exception exc) {
                            ec.Add(exc);
                        }
                    }
                }
            };

            return t;
        }

        public static Func<Task> ParallelForEach<T>(IQueueSource<T> source, ParallelWorker parallelWorker, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync,
            ExceptionCollector ec) {
            Func<Task> t = async delegate() {
                IdleDetector idleDetector = new IdleDetector();
                try {
                    while (true) {
                        var item = await source.Dequeue(ec.CancellationToken);
                        if (!item.HasValue) break;
                        T itemValue = item.Value;

                        idleDetector.Enter();

                        await parallelWorker.StartWorkItem
                        (
                            async workerId => {
                                try {
                                    await processAsync(new ForEachInfo<T>(itemValue, 0, workerId, ec.CancellationToken));
                                }
                                catch (Exception exc) {
                                    ec.Add(exc);
                                }
                                finally {
                                    idleDetector.Leave();
                                }
                            },
                            ec.CancellationToken
                        );
                    }
                }
                finally {
                    await idleDetector.WaitForIdle(CancellationToken.None);
                    if (onCloseAsync != null) {
                        try {
                            await onCloseAsync();
                        }
                        catch (Exception exc) {
                            ec.Add(exc);
                        }
                    }
                }
            };

            return t;
        }

        public static Func<Task> ParallelForEach<T>(IQueueSource<T>[] sources, InputPriorities inputPriorities, ParallelWorker parallelWorker,
            Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync, ExceptionCollector ec) {
            Func<Task> t = async delegate() {
                IdleDetector idleDetector = new IdleDetector();
                try {
                    int sourceCount = sources.Length;
                    bool[] atEof = new bool[sourceCount];
                    RoundRobinLoopGenerator loop = new RoundRobinLoopGenerator(sourceCount, inputPriorities);
                    while (!(atEof.All(e => e))) {
                        var ops = Cosmos.Logging.Core.Piplelines.Utils.OperationStarters<int, Option<T>>();

                        loop.ForEach
                        (
                            j => { ops = ops.AddIf(!atEof[j], j, Cosmos.Logging.Core.Piplelines.Utils.StartableGet<T, Option<T>>(sources[j], a => new Some<T>(a), new None<T>())); }
                        );

                        Tuple<int, Option<T>> result = await ops.CompleteAny(ec.CancellationToken);

                        if (result.Item2.HasValue) {
                            int sourceIndex = result.Item1;
                            T itemValue = result.Item2.Value;

                            idleDetector.Enter();

                            await parallelWorker.StartWorkItem
                            (
                                async workerId => {
                                    try {
                                        await processAsync(new ForEachInfo<T>(itemValue, sourceIndex, workerId, ec.CancellationToken));
                                    }
                                    catch (Exception exc) {
                                        ec.Add(exc);
                                    }
                                    finally {
                                        idleDetector.Leave();
                                    }
                                },
                                ec.CancellationToken
                            );
                        } else {
                            atEof[result.Item1] = true;
                        }
                    }
                }
                finally {
                    if (onCloseAsync != null) {
                        try {
                            await onCloseAsync();
                        }
                        catch (Exception exc) {
                            ec.Add(exc);
                        }
                    }
                }
            };

            return t;
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public enum InputPriorities {
        AsWritten,
        RoundRobin
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public class ForEachInfo<T> {
        private T item;
        private int inputIndex;
        private int workerId;
        private CancellationToken ctoken;

        public ForEachInfo(T item, int inputIndex, int workerId, CancellationToken ctoken) {
            this.item = item;
            this.inputIndex = inputIndex;
            this.workerId = workerId;
            this.ctoken = ctoken;
        }

        public T Item => item;
        public int InputIndex => inputIndex;
        public int WorkerId => workerId;
        public CancellationToken CancellationToken => ctoken;
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public class RoundRobinLoopGenerator {
        private int size;
        private InputPriorities inputPriorities;
        private int counter;

        public RoundRobinLoopGenerator(int size, InputPriorities inputPriorities) {
            this.size = size;
            this.inputPriorities = inputPriorities;
            this.counter = 0;
        }

        public void ForEach(Action<int> action) {
            for (int i = 0; i < size; ++i) {
                int j;
                if (inputPriorities == InputPriorities.AsWritten) {
                    j = i;
                } else {
                    j = i + counter;
                    if (j >= size) j -= size;
                }

                action(j);
            }

            ++counter;
            if (counter >= size) counter -= size;
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public class ExceptionCollector {
        private object syncRoot;
        private ImmutableList<Exception> exceptions;
        private CancellationTokenSource cts;

        public ExceptionCollector() {
            syncRoot = new object();
            exceptions = ImmutableList<Exception>.Empty;
            cts = new CancellationTokenSource();
        }

        public ExceptionCollector(params CancellationToken[] tokens) {
            syncRoot = new object();
            exceptions = ImmutableList<Exception>.Empty;
            cts = CancellationTokenSource.CreateLinkedTokenSource(tokens);
        }

        private void AddInternal(Exception exc) {
            if (exc is AggregateException) {
                foreach (Exception e2 in ((AggregateException) exc).InnerExceptions) {
                    AddInternal(e2);
                }
            } else {
                exceptions = exceptions.Add(exc);
            }
        }

        public void Add(Exception exc) {
            lock (syncRoot) {
                cts.Cancel();
                AddInternal(exc);
            }
        }

        public ImmutableList<Exception> Exceptions => exceptions;

        public CancellationToken CancellationToken => cts.Token;

        public void ThrowAll() {
            lock (syncRoot) {
                if (exceptions.Count == 1) {
                    throw exceptions[0];
                } else if (exceptions.Count > 1) {
                    throw new AggregateException(exceptions);
                } else {
                    // do nothing
                }
            }
        }

        public void WaitAll(params Task[] tasks) {
            try {
                Task.WaitAll(tasks);
            }
            catch (Exception exc) {
                Add(exc);
            }

            ThrowAll();
        }
    }
}