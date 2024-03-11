namespace DesignPatterns.Tests;

public class LoggerTest
{
    [Test]
    public void CreateLogger()
    {
        ILoggerFactory loggerFactory;
        ILogger logger;

        loggerFactory = new ConsoleLoggerFactory(new LogFormatterOptions { Seperator = "" });
        logger = loggerFactory.CreateLogger("LoggerTest");
        logger.Debug("This is a debug message");
        logger.Info("This is a info message");

        loggerFactory = new DebugLoggerFactory(new LogFormatterOptions { Seperator = "" });
        logger = loggerFactory.CreateLogger("LoggerTest");
        logger.Debug("This is a debug message");
        logger.Info("This is a info message");
    }
}