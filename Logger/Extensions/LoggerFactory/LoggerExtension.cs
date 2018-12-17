using Microsoft.Extensions.Logging;
using System;

namespace Logger.Extensions.LoggerFactory
{
    public static class LoggerExtension
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory, Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new LoggerProvider(filter));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, string connectionString)
        {
            return AddContext(factory, (_, logLevel) => logLevel >= minLevel);
        }
    }
}
