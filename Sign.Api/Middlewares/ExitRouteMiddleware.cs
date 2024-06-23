using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Sign.Api.Middlewares;

// Przerabiamy dany middleware na logujący czas wykonania, route. 
// W tym celu dajemy 2 route'y, jeden z exp, drugi bez. bazując na tym co już mamy w Ctrl.
public class ExitRouteMiddleware
{
    public static Func<HttpContext, Func<Task>, Task> Handle()
    {
        return async (context, next) =>
        {
            var logger = context.RequestServices.GetService<ILogger<ExitRouteMiddleware>>()!;
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception caught in route: {Route}", context.Request.Path);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation("Exit route: {Route}, Execution Time: {ElapsedMilliseconds} ms",
                    context.Request.Path, stopwatch.ElapsedMilliseconds);
            }
        };

    }
}