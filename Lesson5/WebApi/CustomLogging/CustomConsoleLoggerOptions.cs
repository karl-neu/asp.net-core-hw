using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApi.CustomLogging
{
    public class CustomConsoleLoggerOptions
    {
        public Dictionary<LogLevel, ConsoleColor> LogLevelColors { get; set; } = new();
    }
}