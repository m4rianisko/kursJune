using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Sign.Api.Middlewares
{
    public class LoggingMiddleware
    {
        public static Func<HttpContext, Func<Task>, Task> Handle()
        {
            return async (context, next) =>
            {
                var logger = context.RequestServices.GetService<ILogger<LoggingMiddleware>>()!;
                logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);
                await next();

                logger.LogInformation("Finished handling request.");
            };

        }
    }        
}

