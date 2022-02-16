using System;

namespace OloPlatform.Services
{
    public class Logger: ILogger
    {
        public void LogWarning(string message, object data = null)
        {
            Console.WriteLine(message, data);
        }
        
        public void LogError(string message, Exception e, object data = null)
        {
            Console.WriteLine(message, e, data);
        }
    }
}