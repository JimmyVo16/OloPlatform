using System;

namespace OloPlatform.Services
{
    public interface ILogger
    {
        void LogWarning(string message, object data = null);
        void LogError(string message, Exception e, object data = null);
    }
}