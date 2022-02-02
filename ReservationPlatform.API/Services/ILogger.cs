namespace OloPlatform.Services
{
    public interface ILogger
    {
        void LogWarning(string message, object data = null);
    }
}