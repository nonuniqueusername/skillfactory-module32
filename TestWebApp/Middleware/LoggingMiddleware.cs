using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Middleware
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogRepository _logRepository;

        public LoggingMiddleware(RequestDelegate next, ILogRepository logRepository)
        {
            _next = next;
            _logRepository = logRepository;
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogDb(HttpContext context)
        {
            await _logRepository.Log($"http://{context.Request.Host.Value + context.Request.Path}");
        }

        public async Task InvokeAsync(HttpContext request)
        {
            LogConsole(request);
            await LogDb(request);

            await _next.Invoke(request);
        }
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
