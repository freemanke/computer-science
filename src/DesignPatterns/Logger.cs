using System.Diagnostics;
using System.Text;
using System.Text.Json;
using NUnit.Framework.Internal;

namespace DesignPatterns;

public enum LogLevel
{
    Debug = 1,
    Info = 2,
}

public class LogFormatterOptions
{
    public string Seperator { get; set; } = "|";
    public string TimestampFormat { get; set; } = "yyyy-MM-dd HH:mm:ss.fff";
}

public class LogEntry
{
    public DateTime Time { get; set; } = DateTime.Now;
    public string Content { get; set; } = "";

    public string ToString(LogLevel level, string category, LogFormatterOptions formatter)
    {
        var sb = new StringBuilder();
        var seperator = string.IsNullOrEmpty(formatter.Seperator) ? " " : $" {formatter.Seperator} ";
        sb.Append(Time.ToString(formatter.TimestampFormat));
        sb.Append(seperator + level.ToString().ToUpper());
        if (!string.IsNullOrEmpty(category)) sb.Append(seperator + category);
        if (!string.IsNullOrEmpty(Content)) sb.Append(seperator + Content);

        return sb.ToString();
    }
}

public interface ILogger
{
    public string CategoryName { get; }
    void Log(LogLevel level, string category, LogEntry logEntry);
}

public static class ILoggerExtensions
{
    public static void Debug(this ILogger logger, string message)
    {
        logger.Log(LogLevel.Debug, logger.CategoryName, new LogEntry { Content = message });
    }

    public static void Info(this ILogger logger, string message)
    {
        logger.Log(LogLevel.Info, logger.CategoryName, new LogEntry { Content = message });
    }
}

public interface ILoggerProvider
{
    ILogger CreateLogger(string categoryName);
}

public interface ILoggerFactory
{
    ILogger CreateLogger(string categoryName);
}

public class LoggerFactory : ILoggerFactory
{
    public const string DefaultLoggerName = "Default";
    public readonly Dictionary<string, ILogger> loggers = new();
    public LogFormatterOptions FormatterOptions { get; }
    private static readonly object sync = new();

    public LoggerFactory(LogFormatterOptions formatterOptions)
    {
        FormatterOptions = formatterOptions;
    }

    public ILogger CreateLogger(string categoryName)
    {
        if (string.IsNullOrEmpty(categoryName)) categoryName = DefaultLoggerName;
        lock (sync)
        {
            if (!loggers.TryGetValue(categoryName, out var logger))
            {
                logger = new ConsoleLogger(categoryName, FormatterOptions);
                loggers.Add(categoryName, logger);
            }

            return logger;
        }
    }
}

public class ConsoleLogger : ILogger
{
    private readonly LogFormatterOptions formatOptions;
    
    public ConsoleLogger(string categoryName, LogFormatterOptions formatOptions)
    {
        CategoryName = categoryName;
        this.formatOptions = formatOptions;
    }

    public string CategoryName { get; }
    public void Log(LogLevel level, string category, LogEntry logEntry)
    {
        Console.WriteLine(logEntry.ToString(level, category, formatOptions));
    }
}