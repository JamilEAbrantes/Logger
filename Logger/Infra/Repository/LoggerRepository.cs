using Dapper;
using Logger.Infra.Context;
using Logger.Model;
using System.Data;

namespace Logger.Infra.Repository
{
    public class LoggerRepository
    {
        private readonly LoggerContext _context;

        public LoggerRepository()
        {
            _context = new LoggerContext();
        }

        public void AddLog(EventLog eventLog)
        {
            var query = $"INSERT INTO EventLog (Id, EventId, LogLevel, Message, CreatedTime)  VALUES  (@Id, @EventId, @LogLevel, @Message, @CreatedTime)";

            var param = new DynamicParameters();
            param.Add(name: "Id", value: eventLog.Id, direction: ParameterDirection.Input);
            param.Add(name: "EventId", value: eventLog.EventId, direction: ParameterDirection.Input);
            param.Add(name: "LogLevel", value: eventLog.LogLevel, direction: ParameterDirection.Input);
            param.Add(name: "Message", value: eventLog.Message, direction: ParameterDirection.Input);
            param.Add(name: "CreatedTime", value: eventLog.CreatedTime, direction: ParameterDirection.Input);

            _context.Connection.Execute(query.ToString(), param);
        }
    }
}
