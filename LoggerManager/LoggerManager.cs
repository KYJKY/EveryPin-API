using Contracts;
using Microsoft.Extensions.Logging;

namespace LoggerManager
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger _logger;

        public LoggerManager(ILogger<LoggerManager> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void LogDebug(string message) => _logger.LogDebug(message);
        public void LogError(string message) => _logger.LogError(message);
        public void LogInfo(string message) => _logger.LogInformation(message);
        public void LogWarn(string message) => _logger.LogWarning(message);
    }
}
