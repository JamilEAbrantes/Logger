using Logger.Infra.Repository;
using Logger.Model;
using Microsoft.Extensions.Logging;
using System;

namespace Logger.Extensions.LoggerFactory
{
    public class Logger : ILogger
    {
        private readonly string _categoryName;
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly LoggerRepository _loggerRepository;
        private const int MAXMESSAGELENGTH = 1000;
        

        public Logger(string categoryName, Func<string, LogLevel, bool> filter)
        {
            _categoryName = categoryName;
            _filter = filter;
            _loggerRepository = new LoggerRepository();
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
                return;

            if (exception != null)
                message += $"\n{ exception.ToString() }";

            message = message.Length > MAXMESSAGELENGTH ? message.Substring(0, MAXMESSAGELENGTH) : message;

            _loggerRepository.AddLog(new EventLog(eventId.Id, logLevel.ToString(), message));
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
