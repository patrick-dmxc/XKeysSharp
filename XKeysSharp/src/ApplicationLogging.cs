﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace XKeysSharp
{
    /// <summary>
    /// Shared logger
    /// </summary>
    internal static class ApplicationLogging
    {
        internal static ILoggerFactory LoggerFactory { get; set; } = NullLoggerFactory.Instance;
        internal static ILogger<T> CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        internal static ILogger CreateLogger(Type type) => LoggerFactory.CreateLogger(type);
        internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
