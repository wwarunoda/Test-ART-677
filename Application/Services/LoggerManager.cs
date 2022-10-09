using Application.Services.Abstractions;
using NLog;
using System.Text;

namespace Application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogInfo(string apiEndPoint, string param) => logger.Info("-"+apiEndPoint+"?state="+ param);
        public void LogWarn(string message) => logger.Warn(message);
    }
}
