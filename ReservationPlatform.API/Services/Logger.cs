using System;

namespace OloPlatform.Services
{
    public class Logger: ILogger
    {
        public void LogWarning(string message, object data = null)
        {
            Console.WriteLine(message, data);
        }
    }
}