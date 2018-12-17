using Microsoft.Extensions.Logging;
using System;

namespace Logger.Extensions.LoggerFactory
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;

        public LoggerProvider(Func<string, LogLevel, bool> filter)
        {
            _filter = filter;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _filter);
        }

        public void Dispose()
        {

        }
    }
}
