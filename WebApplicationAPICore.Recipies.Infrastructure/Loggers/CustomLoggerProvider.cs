using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace WebApplicationAPICore.Recipies.Infrastructure.Loggers;

public class CustomLoggerProvider :ILoggerProvider
{
    #region Fields
    
    private ConcurrentDictionary<string,LoggerDefaultMessage> _loggers = new ConcurrentDictionary<string,LoggerDefaultMessage>(); // Dico qui permet de vérifier qu'il est unique
        
    #endregion Fields
    
    #region public methods
    
    public void Dispose()
    {
        this._loggers.Clear();
    }

    public ILogger CreateLogger(string categoryName)
    {
        this._loggers.GetOrAdd(categoryName, key => new LoggerDefaultMessage());
        return this._loggers[categoryName];
    }
    
    #endregion public methods
}