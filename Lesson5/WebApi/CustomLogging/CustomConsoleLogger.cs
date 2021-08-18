using Microsoft.Extensions.Logging;
using System;

namespace WebApi.CustomLogging
{
    public class CustomConsoleLogger : ILogger
    {
        protected readonly CustomLoggerProvider _customLoggerProvider;

        public CustomConsoleLogger(CustomLoggerProvider customLoggerProvider)
        {
            _customLoggerProvider = customLoggerProvider;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            if (_customLoggerProvider.consoleLoggerOptions.LogLevelColors.TryGetValue(logLevel, out var color))
            {
                Console.ForegroundColor = color;

                Console.WriteLine($" {logLevel}\n\t{formatter(state, exception)}");

                Console.ResetColor();
            }
        }
    }
}