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

namespace Cosmos.Logging.Core.Piplelines {
    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/Option.cs
    /// Author: Sunlighter
    /// </summary>
    public abstract class Option<T> {
        private bool hasValue;

        protected Option(bool hasValue) {
            this.hasValue = hasValue;
        }

        public bool HasValue {
            get { return hasValue; }
        }

        public abstract T Value { get; }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/Option.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class Some<T> : Option<T> {
        private T value;

        public Some(T value) : base(true) {
            this.value = value;
        }

        public override T Value {
            get { return value; }
        }
    }

    /// <summary>
    /// One copy from https://github.com/Sunlighter/AsyncQueues/blob/master/AsyncQueueLib/Option.cs
    /// Author: Sunlighter
    /// </summary>
    public sealed class None<T> : Option<T> {
        public None() : base(false) { }

        public override T Value {
            get { throw new InvalidOperationException(); }
        }
    }
}