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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/IdleDetector.cs
    /// Author: Sunlighter
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    public class IdleDetector {
        private object syncRoot;
        private int referenceCount;
        private CancellableQueue<Waiter> waiters;

        private class Waiter {
            public long? id;
            public TaskCompletionSource<bool> k;
            public CancellationToken ctoken;
            public CancellationTokenRegistration? ctr;
        }

        /// <summary>
        /// IdleDetector
        /// </summary>
        public IdleDetector() {
            syncRoot = new object();
            referenceCount = 0;
            waiters = new CancellableQueue<Waiter>();
        }

        /// <summary>
        /// Enter
        /// </summary>
        public void Enter() {
            lock (syncRoot) {
                ++referenceCount;
            }
        }

        /// <summary>
        /// Leave
        /// </summary>
        public void Leave() {
            lock (syncRoot) {
                --referenceCount;

                if (referenceCount == 0) {
                    while (waiters.Count > 0) {
                        Waiter waiter = waiters.Dequeue();

                        waiter.k.PostResult(true);

                        if (waiter.ctr.HasValue) {
                            waiter.ctr.Value.Dispose();
                        }
                    }
                }
            }
        }

        private void CancelWait(long id) {
            lock (syncRoot) {
                Optional<Waiter> opt = waiters.Cancel(id);
                if (opt.HasValue) {
                    opt.Value.k.PostException(new OperationCanceledException(opt.Value.ctoken));

                    if (opt.Value.ctr.HasValue) {
                        opt.Value.ctr.Value.Dispose();
                    }
                }
            }
        }

        private void SetRegistrationForWait(long id, CancellationTokenRegistration ctr) {
            lock (syncRoot) {
                if (waiters.ContainsId(id)) {
                    waiters.GetById(id).ctr = ctr;
                }
                else {
                    ctr.PostDispose();
                }
            }
        }

        public Task WaitForIdle(CancellationToken ctoken) {
            if (ctoken.IsCancellationRequested) {
#if NET451
                var tcs = new TaskCompletionSource<Task>();
                tcs.SetException(new OperationCanceledException(ctoken));
                return tcs.Task;
#else
                return Task.FromException<bool>(new OperationCanceledException(ctoken));
#endif
            }
            else {
                lock (syncRoot) {
                    if (referenceCount == 0) {
                        return Task.FromResult(true);
                    }
                    else {
                        TaskCompletionSource<bool> k = new TaskCompletionSource<bool>();

                        Waiter waiter = new Waiter() {
                            id = null,
                            k = k,
                            ctoken = ctoken,
                            ctr = null,
                        };

                        long id = waiters.Enqueue(waiter);
                        waiter.id = id;

                        Utils.PostRegistration(ctoken, ctr => SetRegistrationForWait(id, ctr), () => CancelWait(id));

                        return k.Task;
                    }
                }
            }
        }
    }
}