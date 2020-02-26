using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using Cosmos.Logging.Exceptions.Filters;

namespace Cosmos.Logging.Exceptions.Configurations {
    /// <summary>
    /// Destructuring options builder
    /// </summary>
    public class DestructuringOptionsBuilder : IDestructuringOptions {
        /// <summary>
        /// Default destructurers
        /// </summary>
        public static readonly IExceptionDestructurer[] DefaultDestructurers = {
            new ExceptionDestructurer(),
            new ArgumentExceptionDestructurer(),
            new ArgumentOutOfRangeExceptionDestructurer(),
            new AggregateExceptionDestructurer(),
            new OperationCanceledExceptionDestructurer(),
            new ReflectionTypeLoadExceptionDestructurer(),
            new TaskCanceledExceptionDestructurer()
        };

        /// <summary>
        /// Default filter to ignore Stack trace and target site
        /// </summary>
        public static readonly IExceptionPropertyFilter DefaultIgnoreFilter =
#if NET461 ||NET472
            new IgnorePropertyByNameFilter(nameof(Exception.StackTrace), nameof(Exception.TargetSite));
#else
            new IgnorePropertyByNameFilter(nameof(Exception.StackTrace));
#endif

        private readonly List<IExceptionDestructurer> _destructurers = new List<IExceptionDestructurer>();

        internal DestructuringOptionsBuilder() { }

        /// <inheritdoc />
        public string Name { get; private set; } = Constants.RootName;

        /// <inheritdoc />
        public int DestructureDepth { get; private set; } = Constants.DefaultDestructureDepth;

        /// <inheritdoc />
        public IEnumerable<IExceptionDestructurer> Destructurers => _destructurers;

        /// <inheritdoc />
        public IExceptionPropertyFilter Filter { get; private set; }

        /// <summary>
        /// With name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DestructuringOptionsBuilder WithName(string name) {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            return this;
        }

        /// <summary>
        /// With depth
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DestructuringOptionsBuilder WithDepth(int depth) {
            if (depth <= 0) {
                throw new ArgumentOutOfRangeException(nameof(depth), depth, "The value of depth must be positive.");
            }

            DestructureDepth = depth;
            return this;
        }

        /// <summary>
        /// With destructurer
        /// </summary>
        /// <param name="destructurer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DestructuringOptionsBuilder WithDestructurer(IExceptionDestructurer destructurer) {
            if (destructurer is null) throw new ArgumentNullException(nameof(destructurer));
            _destructurers.Add(destructurer);
            return this;
        }

        /// <summary>
        /// With destructurers
        /// </summary>
        /// <param name="destructurers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DestructuringOptionsBuilder WithDestructurers(IEnumerable<IExceptionDestructurer> destructurers) {
            if (destructurers is null) throw new ArgumentNullException(nameof(destructurers));
            _destructurers.AddRange(destructurers);
            return this;
        }

        /// <summary>
        /// With default destructurer
        /// </summary>
        /// <returns></returns>
        public DestructuringOptionsBuilder WithDefaultDestructurer() {
            return WithDestructurers(DefaultDestructurers);
        }

        /// <summary>
        /// With filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public DestructuringOptionsBuilder WithFilter(IExceptionPropertyFilter filter) {
            if (Filter != null) {
                throw new InvalidOperationException(
                    $"Filter has been set, only one filter can be configured. Use {nameof(CompositePropertyFilter)} or other aggregate to combine filters");
            }

            Filter = filter;
            return this;
        }

        /// <summary>
        /// With default filter
        /// </summary>
        /// <returns></returns>
        public DestructuringOptionsBuilder WithDefaultFilter() {
            return WithFilter(DefaultIgnoreFilter);
        }
    }
}