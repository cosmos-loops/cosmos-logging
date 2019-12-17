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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public static class WorkerTask {
        /// <summary>
        /// ForEach
        /// </summary>
        /// <param name="source"></param>
        /// <param name="processAsync"></param>
        /// <param name="onCloseAsync"></param>
        /// <param name="ec"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<Task> ForEach<T>(IQueueSource<T> source, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync, ExceptionCollector ec) {
            Func<Task> t = async delegate {
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

        /// <summary>
        /// ForEach
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="inputPriorities"></param>
        /// <param name="processAsync"></param>
        /// <param name="onCloseAsync"></param>
        /// <param name="ec"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<Task> ForEach<T>(IQueueSource<T>[] sources, InputPriorities inputPriorities, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync,
            ExceptionCollector ec) {
            Func<Task> t = async delegate {
                try {
                    int sourceCount = sources.Length;
                    bool[] atEof = new bool[sourceCount];
                    RoundRobinLoopGenerator loop = new RoundRobinLoopGenerator(sourceCount, inputPriorities);
                    while (!(atEof.All(e => e))) {
                        var ops = Utils.OperationStarters<int, Optional<T>>();

                        loop.ForEach
                        (
                            j => { ops = ops.AddIf(!atEof[j], j, Utils.StartableGet<T, Optional<T>>(sources[j], a => new Some<T>(a), Optional<T>.None())); }
                        );

                        Tuple<int, Optional<T>> result = await ops.CompleteAny(ec.CancellationToken);

                        if (result.Item2.HasValue) {
                            try {
                                await processAsync(new ForEachInfo<T>(result.Item2.Value, result.Item1, 0, ec.CancellationToken));
                            }
                            catch (Exception exc) {
                                ec.Add(exc);
                            }
                        }
                        else {
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

        /// <summary>
        /// ParallelForEach
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="processAsync"></param>
        /// <param name="onCloseAsync"></param>
        /// <param name="ec"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<Task> ParallelForEach<T>(IQueueSource<T> source, ParallelWorker parallelWorker, Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync,
            ExceptionCollector ec) {
            Func<Task> t = async delegate {
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

        /// <summary>
        /// ParallelForEach
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="inputPriorities"></param>
        /// <param name="parallelWorker"></param>
        /// <param name="processAsync"></param>
        /// <param name="onCloseAsync"></param>
        /// <param name="ec"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<Task> ParallelForEach<T>(IQueueSource<T>[] sources, InputPriorities inputPriorities, ParallelWorker parallelWorker,
            Func<ForEachInfo<T>, Task> processAsync, Func<Task> onCloseAsync, ExceptionCollector ec) {
            Func<Task> t = async delegate {
                IdleDetector idleDetector = new IdleDetector();
                try {
                    int sourceCount = sources.Length;
                    bool[] atEof = new bool[sourceCount];
                    RoundRobinLoopGenerator loop = new RoundRobinLoopGenerator(sourceCount, inputPriorities);
                    while (!(atEof.All(e => e))) {
                        var ops = Utils.OperationStarters<int, Optional<T>>();

                        loop.ForEach
                        (
                            j => { ops = ops.AddIf(!atEof[j], j, Utils.StartableGet<T, Optional<T>>(sources[j], a => new Some<T>(a), Optional<T>.None())); }
                        );

                        Tuple<int, Optional<T>> result = await ops.CompleteAny(ec.CancellationToken);

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
                        }
                        else {
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
        /// <summary>
        /// AsWritten
        /// </summary>
        AsWritten,

        /// <summary>
        /// RoundRobin
        /// </summary>
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

        /// <summary>
        /// ForEachInfo
        /// </summary>
        /// <param name="item"></param>
        /// <param name="inputIndex"></param>
        /// <param name="workerId"></param>
        /// <param name="ctoken"></param>
        public ForEachInfo(T item, int inputIndex, int workerId, CancellationToken ctoken) {
            this.item = item;
            this.inputIndex = inputIndex;
            this.workerId = workerId;
            this.ctoken = ctoken;
        }

        /// <summary>
        /// Item
        /// </summary>
        public T Item => item;

        /// <summary>
        /// InputIndex
        /// </summary>
        public int InputIndex => inputIndex;

        /// <summary>
        /// WorkerId
        /// </summary>
        public int WorkerId => workerId;

        /// <summary>
        /// CancellationToken
        /// </summary>
        public CancellationToken CancellationToken => ctoken;
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
    public class RoundRobinLoopGenerator {
        private int size;
        private InputPriorities inputPriorities;
        private int _counter;

        /// <summary>
        /// RoundRobinLoopGenerator
        /// </summary>
        /// <param name="size"></param>
        /// <param name="inputPriorities"></param>
        public RoundRobinLoopGenerator(int size, InputPriorities inputPriorities) {
            this.size = size;
            this.inputPriorities = inputPriorities;
            this._counter = 0;
        }

        /// <summary>
        /// ForEach
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<int> action) {
            for (int i = 0; i < size; ++i) {
                int j;
                if (inputPriorities == InputPriorities.AsWritten) {
                    j = i;
                }
                else {
                    j = i + _counter;
                    if (j >= size) j -= size;
                }

                action(j);
            }

            ++_counter;
            if (_counter >= size) _counter -= size;
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/WorkerTask.cs
    /// Author: Sunlighter
    /// </summary>
    public class ExceptionCollector {
        private object syncRoot;

        // ReSharper disable once InconsistentNaming
        private ImmutableList<Exception> exceptions;
        private CancellationTokenSource cts;

        /// <summary>
        /// ExceptionCollector
        /// </summary>
        public ExceptionCollector() {
            syncRoot = new object();
            exceptions = ImmutableList<Exception>.Empty;
            cts = new CancellationTokenSource();
        }

        /// <summary>
        /// ExceptionCollector
        /// </summary>
        /// <param name="tokens"></param>
        public ExceptionCollector(params CancellationToken[] tokens) {
            syncRoot = new object();
            exceptions = ImmutableList<Exception>.Empty;
            cts = CancellationTokenSource.CreateLinkedTokenSource(tokens);
        }

        private void AddInternal(Exception exc) {
            if (exc is AggregateException aggregateException) {
                foreach (var e2 in aggregateException.InnerExceptions) {
                    AddInternal(e2);
                }
            }
            else {
                exceptions = exceptions.Add(exc);
            }
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="exc"></param>
        public void Add(Exception exc) {
            lock (syncRoot) {
                cts.Cancel();
                AddInternal(exc);
            }
        }

        // ReSharper disable once InconsistentlySynchronizedField
        /// <summary>
        /// Exceptions
        /// </summary>
        public ImmutableList<Exception> Exceptions => exceptions;

        /// <summary>
        /// CancellationToken
        /// </summary>
        public CancellationToken CancellationToken => cts.Token;

        /// <summary>
        /// ThrowAll
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="AggregateException"></exception>
        public void ThrowAll() {
            lock (syncRoot) {
                if (exceptions.Count == 1) {
                    throw exceptions[0];
                }
                else if (exceptions.Count > 1) {
                    throw new AggregateException(exceptions);
                }
                else {
                    // do nothing
                }
            }
        }

        /// <summary>
        /// WaitAll
        /// </summary>
        /// <param name="tasks"></param>
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