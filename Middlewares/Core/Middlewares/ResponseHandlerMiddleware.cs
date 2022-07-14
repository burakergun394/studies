using Microsoft.AspNetCore.Http;
using System.Text;

namespace Core.Middlewares;

public class ResponseHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ResponseHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalResponseBody = context.Response.Body;

        using var tempResponseBodyMemoryStream = new MemoryStream();
        context.Response.Body = tempResponseBodyMemoryStream;

        await _next.Invoke(context);

        tempResponseBodyMemoryStream.Seek(0, SeekOrigin.Begin);

        using var bodyReaderStream = new StreamReader(tempResponseBodyMemoryStream);
        var body = await bodyReaderStream.ReadToEndAsync();

        tempResponseBodyMemoryStream.Seek(0, SeekOrigin.Begin);

        await tempResponseBodyMemoryStream.CopyToAsync(originalResponseBody);
    }
}
