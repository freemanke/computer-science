namespace DesignPatterns.Tests;

public class LoggerTest
{
    [Test]
    public void CreateLogger()
    {
        ILoggerFactory loggerFactory = new LoggerFactory(new LogFormatterOptions{Seperator = "|"});
        ILogger logger = loggerFactory.CreateLogger("LoggerTest");
        logger.Debug("This is a debug message");
        logger.Info("This is a info message");
    }
}