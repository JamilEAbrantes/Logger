using System;

namespace Logger.Model
{
    public class EventLog
    {
        public EventLog() { }

        public EventLog(int? eventId, string logLevel, string message)
        {
            Id = Guid.NewGuid();
            EventId = eventId;
            LogLevel = logLevel;
            Message = message;
            CreatedTime = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public int? EventId { get; private set; }
        public string LogLevel { get; private set; }
        public string Message { get; private set; }
        public DateTime CreatedTime { get; private set; }
    }
}
