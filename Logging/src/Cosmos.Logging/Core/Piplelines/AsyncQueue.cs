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
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public enum ResultType {
        Succeeded,
        Cancelled,
        Faulted
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public abstract class AcquireReadResult {
        private readonly ResultType resultType;

        protected AcquireReadResult(ResultType resultType) {
            this.resultType = resultType;
        }

        public abstract T Visit<T>
        (
            Func<AcquireReadSucceeded, T> onSucceeded,
            Func<AcquireReadCancelled, T> onCancelled,
            Func<AcquireReadFaulted, T> onFaulted
        );

        public ResultType ResultType {
            get { return resultType; }
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireReadCancelled : AcquireReadResult {
        public AcquireReadCancelled() : base(ResultType.Cancelled) { }

        public override T Visit<T>
        (
            Func<AcquireReadSucceeded, T> onSucceeded,
            Func<AcquireReadCancelled, T> onCancelled,
            Func<AcquireReadFaulted, T> onFaulted
        ) {
            return onCancelled(this);
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireReadFaulted : AcquireReadResult {
        private Exception exc;

        public AcquireReadFaulted(Exception exc) : base(ResultType.Faulted) {
            this.exc = exc;
        }

        public Exception Exception {
            get { return exc; }
        }

        public override T Visit<T>
        (
            Func<AcquireReadSucceeded, T> onSucceeded,
            Func<AcquireReadCancelled, T> onCancelled,
            Func<AcquireReadFaulted, T> onFaulted
        ) {
            return onFaulted(this);
        }

    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public abstract class AcquireReadSucceeded : AcquireReadResult {
        private BigInteger offset;

        protected AcquireReadSucceeded(BigInteger offset) : base(ResultType.Succeeded) {
            this.offset = offset;
        }

        public BigInteger Offset {
            get { return offset; }
        }

        public abstract int ItemCount { get; }

        public override T Visit<T>
        (
            Func<AcquireReadSucceeded, T> onSucceeded,
            Func<AcquireReadCancelled, T> onCancelled,
            Func<AcquireReadFaulted, T> onFaulted
        ) {
            return onSucceeded(this);
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireReadSucceeded<T> : AcquireReadSucceeded {
        private ImmutableList<T> items;

        public AcquireReadSucceeded(BigInteger offset, ImmutableList<T> items)
            : base(offset) {
            this.items = items;
        }

        public override int ItemCount {
            get { return items.Count; }
        }

        public ImmutableList<T> Items {
            get { return items; }
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public abstract class AcquireWriteResult {
        private readonly ResultType resultType;

        protected AcquireWriteResult(ResultType resultType) {
            this.resultType = resultType;
        }

        public abstract T Visit<T>
        (
            Func<AcquireWriteSucceeded, T> onSucceeded,
            Func<AcquireWriteCancelled, T> onCancelled,
            Func<AcquireWriteFaulted, T> onFaulted
        );

        public ResultType ResultType {
            get { return resultType; }
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireWriteCancelled : AcquireWriteResult {
        public AcquireWriteCancelled() : base(ResultType.Cancelled) { }

        public override T Visit<T>
        (
            Func<AcquireWriteSucceeded, T> onSucceeded,
            Func<AcquireWriteCancelled, T> onCancelled,
            Func<AcquireWriteFaulted, T> onFaulted
        ) {
            return onCancelled(this);
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireWriteFaulted : AcquireWriteResult {
        private Exception exc;

        public AcquireWriteFaulted(Exception exc) : base(ResultType.Faulted) {
            this.exc = exc;
        }

        public Exception Exception {
            get { return exc; }
        }

        public override T Visit<T>
        (
            Func<AcquireWriteSucceeded, T> onSucceeded,
            Func<AcquireWriteCancelled, T> onCancelled,
            Func<AcquireWriteFaulted, T> onFaulted
        ) {
            return onFaulted(this);
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class AcquireWriteSucceeded : AcquireWriteResult {
        private BigInteger offset;
        private int maxItemCount;

        public AcquireWriteSucceeded(BigInteger offset, int maxItemCount) : base(ResultType.Succeeded) {
            this.offset = offset;
            this.maxItemCount = maxItemCount;
        }

        public BigInteger Offset {
            get { return offset; }
        }

        public int ItemCount {
            get { return maxItemCount; }
        }

        public override T Visit<T>
        (
            Func<AcquireWriteSucceeded, T> onSucceeded,
            Func<AcquireWriteCancelled, T> onCancelled,
            Func<AcquireWriteFaulted, T> onFaulted
        ) {
            return onSucceeded(this);
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public interface IQueueSource<T> {
        Task<AcquireReadResult> AcquireReadAsync(int desiredItems, CancellationToken ctoken);
        void ReleaseRead(int consumedItems);
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public interface IQueueSink<T> {
        Task<AcquireWriteResult> AcquireWriteAsync(int desiredSpace, CancellationToken ctoken);
        void ReleaseWrite(ImmutableList<T> producedItems);
        void WriteEof();
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/AsyncQueue.cs
    /// Author: Sunlighter
    /// </summary>
    public class AsyncQueue<T> : IQueueSource<T>, IQueueSink<T>, IDisposable {
        private object syncRoot;
        private int? capacity;
        private BigInteger readPtr;
        private int? readLocked;
        private int? writeLocked;
        private bool eofSignaled;
        private ImmutableList<T> items;
        private CancellableQueue<WaitingRead> waitingReads;
        private CancellableQueue<WaitingWrite> waitingWrites;

        private class WaitingRead {
            public long? id;
            public int desiredItems;
            public TaskCompletionSource<AcquireReadResult> k;
            public CancellationTokenRegistration? ctr;
        }

        private class WaitingWrite {
            public long? id;
            public int desiredSpace;
            public TaskCompletionSource<AcquireWriteResult> k;
            public CancellationTokenRegistration? ctr;
        }

        public AsyncQueue(int? capacity) {
            if (capacity.HasValue && capacity.Value < 1) {
                throw new ArgumentOutOfRangeException("Capacity must be at least one");
            }

            this.syncRoot = new object();
            this.capacity = capacity;
            this.readPtr = BigInteger.Zero;
            this.readLocked = null;
            this.writeLocked = null;
            this.eofSignaled = false;
            this.items = ImmutableList<T>.Empty;
            this.waitingReads = new CancellableQueue<WaitingRead>();
            this.waitingWrites = new CancellableQueue<WaitingWrite>();
        }

        private void CancelAcquireRead(long id) {
            lock (syncRoot) {
                Option<WaitingRead> opt = waitingReads.Cancel(id);
                if (opt.HasValue) {
                    opt.Value.k.PostResult(new AcquireReadCancelled());

                    if (opt.Value.ctr.HasValue) {
                        opt.Value.ctr.Value.PostDispose();
                    }
                }
            }
        }

        private void SetRegistrationForAcquireRead(long id, CancellationTokenRegistration ctr) {
            lock (syncRoot) {
                if (waitingReads.ContainsId(id)) {
                    waitingReads.GetById(id).ctr = ctr;
                } else {
                    ctr.PostDispose();
                }
            }
        }

        public Task<AcquireReadResult> AcquireReadAsync(int desiredItems, CancellationToken ctoken) {
            if (desiredItems < 1) {
                return Task.FromResult<AcquireReadResult>(new AcquireReadFaulted(new ArgumentOutOfRangeException("desiredItems", "Must be at least one")));
            }

            if (ctoken.IsCancellationRequested) {
                return Task.FromResult<AcquireReadResult>(new AcquireReadCancelled());
            } else {
                lock (syncRoot) {
                    if (!readLocked.HasValue && (items.Count >= desiredItems || eofSignaled)) {
                        readLocked = Math.Min(items.Count, desiredItems);
                        return Task.FromResult<AcquireReadResult>(new AcquireReadSucceeded<T>(readPtr, items.GetRange(0, readLocked.Value)));
                    } else {
                        TaskCompletionSource<AcquireReadResult> k = new TaskCompletionSource<AcquireReadResult>();

                        WaitingRead wr = new WaitingRead() {
                            id = null,
                            desiredItems = desiredItems,
                            k = k,
                            ctr = null,
                        };

                        long id = waitingReads.Enqueue(wr);
                        wr.id = id;

                        Utils.PostRegistration(ctoken, ctr => SetRegistrationForAcquireRead(id, ctr), () => CancelAcquireRead(id));

                        return k.Task;
                    }
                }
            }
        }

        private void CancelAcquireWrite(long id) {
            lock (syncRoot) {
                Option<WaitingWrite> opt = waitingWrites.Cancel(id);
                if (opt.HasValue) {
                    opt.Value.k.PostResult(new AcquireWriteCancelled());

                    if (opt.Value.ctr.HasValue) {
                        opt.Value.ctr.Value.PostDispose();
                    }
                }
            }
        }

        private void SetRegistrationForAcquireWrite(long id, CancellationTokenRegistration ctr) {
            lock (syncRoot) {
                if (waitingWrites.ContainsId(id)) {
                    waitingWrites.GetById(id).ctr = ctr;
                } else {
                    ctr.PostDispose();
                }
            }
        }

        public Task<AcquireWriteResult> AcquireWriteAsync(int desiredSpace, CancellationToken ctoken) {
            if (desiredSpace < 1) {
                return Task.FromResult<AcquireWriteResult>(new AcquireWriteFaulted(new ArgumentOutOfRangeException("desiredSpace", "Must be at least one")));
            }

            if (ctoken.IsCancellationRequested) {
                return Task.FromResult<AcquireWriteResult>(new AcquireWriteCancelled());
            } else {
                lock (syncRoot) {
                    if (eofSignaled) {
                        return Task.FromResult<AcquireWriteResult>(new AcquireWriteFaulted(new InvalidOperationException("Can't acquire for write after EOF has been signaled")));
                    } else if (!writeLocked.HasValue && (!capacity.HasValue || (capacity.Value - items.Count) >= desiredSpace)) {
                        writeLocked = desiredSpace;
                        return Task.FromResult<AcquireWriteResult>(new AcquireWriteSucceeded(readPtr + items.Count, desiredSpace));
                    } else if (capacity.HasValue && desiredSpace > capacity.Value) {
                        return Task.FromResult<AcquireWriteResult>(
                            new AcquireWriteFaulted(new InvalidOperationException("Attempting to acquire more space than will ever become available")));
                    } else {
                        TaskCompletionSource<AcquireWriteResult> k = new TaskCompletionSource<AcquireWriteResult>();

                        WaitingWrite ww = new WaitingWrite() {
                            id = null,
                            desiredSpace = desiredSpace,
                            k = k,
                            ctr = null
                        };

                        long id = waitingWrites.Enqueue(ww);
                        ww.id = id;

                        Utils.PostRegistration(ctoken, ctr => SetRegistrationForAcquireWrite(id, ctr), () => CancelAcquireWrite(id));

                        return k.Task;
                    }
                }
            }
        }

        private void CheckWaitingWrites() {
            if (!writeLocked.HasValue && waitingWrites.Count > 0) {
                WaitingWrite ww = waitingWrites.Peek();

                System.Diagnostics.Debug.Assert(capacity.HasValue, "If there is no capacity limit, there should never be any waiting writes");

                if (capacity.Value - items.Count >= ww.desiredSpace) {
                    waitingWrites.Dequeue();

                    writeLocked = ww.desiredSpace;

                    ww.k.PostResult(new AcquireWriteSucceeded(readPtr + items.Count, ww.desiredSpace));
                    if (ww.ctr.HasValue) {
                        ww.ctr.Value.PostDispose();
                    }
                }
            }
        }

        private void CheckWaitingReads() {
            if (!readLocked.HasValue && waitingReads.Count > 0) {
                WaitingRead wr = waitingReads.Peek();

                if (items.Count >= wr.desiredItems || (eofSignaled && !writeLocked.HasValue && waitingWrites.Count == 0)) {
                    waitingReads.Dequeue();

                    readLocked = Math.Min(wr.desiredItems, items.Count);

                    wr.k.PostResult(new AcquireReadSucceeded<T>(readPtr, readLocked.Value == 0 ? ImmutableList<T>.Empty : items.GetRange(0, readLocked.Value)));
                    if (wr.ctr.HasValue) {
                        wr.ctr.Value.PostDispose();
                    }

                    if (readLocked.Value == 0) {
                        while (waitingReads.Count > 0) {
                            WaitingRead wr2 = waitingReads.Dequeue();
                            wr2.k.PostResult(new AcquireReadSucceeded<T>(readPtr, ImmutableList<T>.Empty));
                            if (wr2.ctr.HasValue) {
                                wr2.ctr.Value.PostDispose();
                            }
                        }
                    }
                }
            }
        }

        public void ReleaseRead(int consumedItems) {
            lock (syncRoot) {
                if (!readLocked.HasValue) {
                    throw new InvalidOperationException("Can't release read lock if it is not held");
                } else if (consumedItems < 0) {
                    throw new ArgumentOutOfRangeException("consumedItems", "Must be zero or more");
                } else if (consumedItems > readLocked.Value) {
                    throw new InvalidOperationException("Can't consume more items than were locked");
                } else {
                    readLocked = null;
                    items = items.GetRange(consumedItems, items.Count - consumedItems);
                    readPtr += consumedItems;

                    CheckWaitingWrites();
                    CheckWaitingReads();
                }
            }
        }

        public void ReleaseWrite(ImmutableList<T> producedItems) {
            lock (syncRoot) {
                if (!writeLocked.HasValue) {
                    throw new InvalidOperationException("Can't release write lock if it is not held");
                } else if (producedItems.Count > writeLocked.Value) {
                    throw new InvalidOperationException("Can't write more items than space was locked for");
                } else {
                    writeLocked = null;
                    items = items.AddRange(producedItems);

                    CheckWaitingReads();
                    CheckWaitingWrites();
                }
            }
        }

        public void WriteEof() {
            lock (syncRoot) {
                eofSignaled = true;
                CheckWaitingReads();
            }
        }

        private bool disposed;

        public void Dispose() {
            if (disposed) return;

            this.readPtr = BigInteger.Zero;
            this.readLocked = null;
            this.writeLocked = null;
            this.eofSignaled = false;
            this.items.Clear();
            this.waitingReads.Dispose();
            this.waitingWrites.Dispose();
            disposed = true;
        }
    }
}