using System;

namespace Application.Logging
{
    public interface ILoggerService<T>
    {
        void LogInfo(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
        void LogCritical(Exception ex, string message, params object[] args);
    }
}
