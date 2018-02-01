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
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/ParallelWorker.cs
    /// Author: Sunlighter
    /// </summary>
    public class ParallelWorker {
        private object syncRoot;
        private int capacity;
        private ImmutableHashSet<int> idleWorkers;
        private ImmutableHashSet<int> busyWorkers;

        private CancellableQueue<WaitingWorkItem> waitingWorkItems;

        private class WaitingWorkItem {
            public long? id;
            public TaskCompletionSource<Task> k;
            public Delegate work;
            public CancellationToken ctoken;
            public CancellationTokenRegistration? ctr;
        }

        public ParallelWorker(int workerCount) {
            if (workerCount < 1) throw new ArgumentException(nameof(workerCount));

            this.syncRoot = new object();
            this.capacity = workerCount;
            this.idleWorkers = ImmutableHashSet<int>.Empty.Union(Enumerable.Range(0, workerCount));
            this.busyWorkers = ImmutableHashSet<int>.Empty;

            this.waitingWorkItems = new CancellableQueue<WaitingWorkItem>();
        }

        public int Capacity {
            get { return capacity; }
        }

        private void CancelWorkItem(long id) {
            lock (syncRoot) {
                Option<WaitingWorkItem> opt = waitingWorkItems.Cancel(id);
                if (opt.HasValue) {
                    opt.Value.k.PostException(new OperationCanceledException(opt.Value.ctoken));

                    if (opt.Value.ctr.HasValue) {
                        opt.Value.ctr.Value.PostDispose();
                    }
                }
            }
        }

        private void SetRegistrationForWorkItem(long id, CancellationTokenRegistration ctr) {
            lock (syncRoot) {
                if (waitingWorkItems.ContainsId(id)) {
                    waitingWorkItems.GetById(id).ctr = ctr;
                } else {
                    ctr.PostDispose();
                }
            }
        }

        private Task StartWorker(Func<int, Task> work) {
            int workerId = idleWorkers.Min();
            idleWorkers = idleWorkers.Remove(workerId);

            Task doingWork = Task.Run
            (
                async () => {
                    try {
                        await work(workerId);
                    }
                    finally {
                        CompleteWork(workerId);
                    }
                }
            );

            busyWorkers = busyWorkers.Add(workerId);

            return Task.FromResult(doingWork);
        }

        private Task StartWorker(Func<int, CancellationToken, Task> work, CancellationToken ctoken) {
            int workerId = idleWorkers.Min();
            idleWorkers = idleWorkers.Remove(workerId);

            Task doingWork = Task.Run
            (
                async () => {
                    try {
                        await work(workerId, ctoken);
                    }
                    finally {
                        CompleteWork(workerId);
                    }
                }
            );

            busyWorkers = busyWorkers.Add(workerId);

            return Task.FromResult(doingWork);
        }

        public Task<Task> StartWorkItem(Func<int, Task> work, CancellationToken ctoken) {
            if (ctoken.IsCancellationRequested) {
#if NET451
                var tcs = new TaskCompletionSource<Task>();
                tcs.SetException(new OperationCanceledException(ctoken));
                return tcs.Task;
#else
                return Task.FromException<Task>(new OperationCanceledException(ctoken));
#endif
            } else {
                lock (syncRoot) {
                    if (idleWorkers.Count > 1) {
                        return Task.FromResult<Task>(StartWorker(work));
                    } else {
                        TaskCompletionSource<Task> k = new TaskCompletionSource<Task>();

                        WaitingWorkItem wa = new WaitingWorkItem() {
                            id = null,
                            work = work,
                            ctoken = ctoken,
                            ctr = null,
                            k = k
                        };

                        long id = waitingWorkItems.Enqueue(wa);
                        wa.id = id;

                        Cosmos.Logging.Core.Piplelines.Utils.PostRegistration(ctoken, ctr => SetRegistrationForWorkItem(id, ctr), () => CancelWorkItem(id));

                        return k.Task;
                    }
                }
            }
        }

        public Task<Task> StartWorkItem(Func<int, CancellationToken, Task> work, CancellationToken ctoken) {
            if (ctoken.IsCancellationRequested) {
#if NET451
                var tcs = new TaskCompletionSource<Task>();
                tcs.SetException(new OperationCanceledException(ctoken));
                return tcs.Task;
#else
                return Task.FromException<Task>(new OperationCanceledException(ctoken));
#endif
            } else {
                lock (syncRoot) {
                    if (idleWorkers.Count > 1) {
                        return Task.FromResult<Task>(StartWorker(work, ctoken));
                    } else {
                        TaskCompletionSource<Task> k = new TaskCompletionSource<Task>();

                        WaitingWorkItem wa = new WaitingWorkItem() {
                            id = null,
                            work = work,
                            ctoken = ctoken,
                            ctr = null,
                            k = k
                        };

                        long id = waitingWorkItems.Enqueue(wa);
                        wa.id = id;

                        Cosmos.Logging.Core.Piplelines.Utils.PostRegistration(ctoken, ctr => SetRegistrationForWorkItem(id, ctr), () => CancelWorkItem(id));

                        return k.Task;
                    }
                }
            }
        }

        private void CompleteWork(int workerId) {
            lock (syncRoot) {
                busyWorkers = busyWorkers.Remove(workerId);
                idleWorkers = idleWorkers.Add(workerId);

                if (waitingWorkItems.Count > 0) {
                    WaitingWorkItem wwi = waitingWorkItems.Dequeue();

                    if (wwi.work is Func<int, Task>) {
                        wwi.k.PostResult(StartWorker((Func<int, Task>) wwi.work));
                    } else {
                        wwi.k.PostResult(StartWorker((Func<int, CancellationToken, Task>) wwi.work, wwi.ctoken));
                    }

                    if (wwi.ctr.HasValue) {
                        wwi.ctr.Value.Dispose();
                    }
                }
            }
        }
    }
}