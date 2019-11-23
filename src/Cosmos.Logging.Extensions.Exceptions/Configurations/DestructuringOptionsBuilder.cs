using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;
using Cosmos.Logging.Extensions.Exceptions.Filters;

namespace Cosmos.Logging.Extensions.Exceptions.Configurations
{
    public class DestructuringOptionsBuilder : IDestructuringOptions
    {
        public static readonly IExceptionDestructurer[] DefaultDestructurers =
        {
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

        public string Name { get; private set; } = Constants.RootName;

        public int DestructureDepth { get; private set; } = Constants.DefaultDestructureDepth;

        public IEnumerable<IExceptionDestructurer> Destructurers => _destructurers;

        public IExceptionPropertyFilter Filter { get; private set; }

        public DestructuringOptionsBuilder WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            return this;
        }

        public DestructuringOptionsBuilder WithDepth(int depth)
        {
            if (depth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depth), depth, "The value of depth must be positive.");
            }

            DestructureDepth = depth;
            return this;
        }

        public DestructuringOptionsBuilder WithDestructurer(IExceptionDestructurer destructurer)
        {
            if (destructurer is null)
                throw new ArgumentNullException(nameof(destructurer));
            _destructurers.Add(destructurer);
            return this;
        }

        public DestructuringOptionsBuilder WithDestructurers(IEnumerable<IExceptionDestructurer> destructurers)
        {
            if (destructurers is null)
                throw new ArgumentNullException(nameof(destructurers));
            _destructurers.AddRange(destructurers);
            return this;
        }

        public DestructuringOptionsBuilder WithDefaultDestructurer()
        {
            return WithDestructurers(DefaultDestructurers);
        }

        public DestructuringOptionsBuilder WithFiler(IExceptionPropertyFilter filter)
        {
            if (Filter != null)
            {
                throw new InvalidOperationException(
                    $"Filter has been set, only one filter can be configured. Use {nameof(CompositePropertyFilter)} or other aggregate to combine filters");
            }

            Filter = filter;
            return this;
        }

        public DestructuringOptionsBuilder WithDefaultFilter()
        {
            return WithFiler(DefaultIgnoreFilter);
        }
    }
}