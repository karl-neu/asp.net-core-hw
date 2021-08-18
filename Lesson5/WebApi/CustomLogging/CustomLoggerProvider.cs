using Microsoft.Extensions.Logging;

namespace WebApi.CustomLogging
{
    [ProviderAlias("CustomConsoleLogger")]
    public class CustomLoggerProvider : ILoggerProvider
    {
        public readonly CustomConsoleLoggerOptions consoleLoggerOptions;

        public CustomLoggerProvider(CustomConsoleLoggerOptions consoleLoggerOptions)
        {
            this.consoleLoggerOptions = consoleLoggerOptions;

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomConsoleLogger(this);
        }

        public void Dispose() { }
    }
}