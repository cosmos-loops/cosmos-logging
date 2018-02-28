using Cosmos.Logging.Sinks.File.Configurations;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public static class StrategyFactory {
        public static SavingStrategy Create(OutputOptions options) {

            var saving = new SavingStrategy(options.Path, options.Rolling);

            //解析 output template

            //创建 format strategy

            return saving;
        }
    }
}