namespace Error404NotLost_WEBASP.Middleware
{
    /// <summary>
    /// This middleware logs incoming HTTP requests and outgoing responses.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the incoming request
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the response status code
            _logger.LogInformation($"Outgoing Response: {context.Response.StatusCode}");
        }
    }
}
