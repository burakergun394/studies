using Microsoft.AspNetCore.Http;
using System.Text;

namespace Core.Middlewares;

public class RequestHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public RequestHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await TryReadBody(context);
        TryReadQuery(context);
        await _next(context);
    }

    private async Task TryReadBody(HttpContext context)
    {
        context.Request.Body.Position = 0;
        var bodyText = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();
        context.Request.Body.Position = 0;
    }

    private void TryReadQuery(HttpContext context)
    {
        var requestQuery = context.Request.Query;
        if (requestQuery.Any())
        {
            foreach (var key in requestQuery.Keys)
            {
                var isValueExist = requestQuery.TryGetValue(key, out Microsoft.Extensions.Primitives.StringValues value);
                if (isValueExist)
                {
                    var myValue = value.ToString();
                }
            }
        }

    }
}
