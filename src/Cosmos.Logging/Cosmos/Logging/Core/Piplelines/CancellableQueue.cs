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
using Cosmos.Optionals;

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/CancellableQueue.cs
    /// Author: Sunlighter
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CancellableQueue<T> : IDisposable {
        private long nextId;
        private ImmutableDictionary<long, T> itemMap;
        private ImmutableList<long> queue;

        /// <summary>
        /// Cancellable queue
        /// </summary>
        public CancellableQueue() {
            nextId = 0L;
            itemMap = ImmutableDictionary<long, T>.Empty;
            queue = ImmutableList<long>.Empty;
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public long Enqueue(T item) {
            long id;
            do {
                id = nextId;
                ++nextId;
            } while (itemMap.ContainsKey(id));

            queue = queue.Add(id);
            itemMap = itemMap.Add(id, item);
            return id;
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count {
            get { return itemMap.Count; }
        }

        /// <summary>
        /// Peek
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek() {
            if (itemMap.Count == 0) {
                throw new InvalidOperationException("Can't Peek from an empty queue");
            }

            while (!itemMap.ContainsKey(queue[0])) {
                queue = queue.RemoveAt(0);
            }

            return itemMap[queue[0]];
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue() {
            if (itemMap.Count == 0) {
                throw new InvalidOperationException("Can't Dequeue from an empty queue");
            }

            long id;
            do {
                id = queue[0];
                queue = queue.RemoveAt(0);
            } while (!(itemMap.ContainsKey(id)));

            T item = itemMap[id];
            itemMap = itemMap.Remove(id);
            return item;
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IOptional<T> Cancel(long id) {
            if (itemMap.ContainsKey(id)) {
                T value = itemMap[id];
                itemMap = itemMap.Remove(id);
                return Optional.Wrapped.Some(value);
            }

            return Optional.Wrapped.None<T>();
        }

        /// <summary>
        /// Contains id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContainsId(long id) {
            return itemMap.ContainsKey(id);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id) {
            return itemMap[id];
        }

        private bool disposed;

        /// <inheritdoc />
        public void Dispose() {
            if (disposed) return;

            nextId = 0L;
            itemMap.Clear();
            queue.Clear();
            disposed = true;
        }
    }
}