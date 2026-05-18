#nullable enable
namespace UniT.Logging
{
    using System.Collections.Generic;

    public abstract class LoggerManager : ILoggerManager
    {
        private readonly LogLevel logLevel;

        private readonly Dictionary<string, ILogger> loggers = new();

        protected LoggerManager(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        }

        ILogger ILoggerManager.GetLogger(string name)
        {
            if (this.loggers.TryGetValue(name, out var logger)) return logger;
            logger = this.CreateLogger(name, this.logLevel);
            this.loggers.Add(name, logger);
            return logger;
        }

        IEnumerable<ILogger> ILoggerManager.GetAllLoggers()
        {
            return this.loggers.Values;
        }

        protected abstract ILogger CreateLogger(string name, LogLevel logLevel);
    }
}