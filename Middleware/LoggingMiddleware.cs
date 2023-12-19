namespace NewProductManagement.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        // Log message at the beginning of the request
        _logger.LogInformation("Action entered - Start");

        await _next(context);

        // Log message at the end of the request
        _logger.LogInformation("Action entered - Completed");
    }
}