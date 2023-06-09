using Microsoft.Extensions.Logging;

namespace WebApplicationAPICore.Recipies.Infrastructure.Loggers;

public class LoggerDefaultMessage :ILogger
{
    #region public methods
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Console.WriteLine($"[{DateTime.Now}]: ## {logLevel.ToString()} ## {formatter(state,exception)}");
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.Trace;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
    #endregion public methods
}