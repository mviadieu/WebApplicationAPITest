namespace WebApplicationAPI.IU.Middlewares;

public class LogRequestMiddleware
{
    #region Fields

    private RequestDelegate _next = null; 
    private ILogger<LogRequestMiddleware> _logger = null; 

    #endregion

    #region Constructors

    public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
    {
        this._next = next;
        this._logger = logger;
    }

    #endregion

    #region Public methods

    public async Task Invoke(HttpContext context)
    {
        this._logger.LogDebug(context.Request.Path.Value);
        await this._next(context);
    }

    #endregion
}