using Microsoft.AspNetCore.Http;

namespace ShipitSmarter.Core.Middlewares;

/// <summary>
/// Middleware to correlate requests (reads the correlation id from the header, or adds on if it doesn't exist.
/// </summary>
/// <code>
/// builder.Services.AddScoped&lt;ICorrelator, YourCorrelator&gt;();
/// app.UseMiddleware&lt;CorrelationMiddleware&gt;();
/// </code>
public class CorrelationMiddleware
{
    private const string _correlationIdHeaderName = "x-correlation-id";
    
    private readonly RequestDelegate _next;

    /// <see cref="CorrelationMiddleware"/>
    public CorrelationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// When the middleware is invoked
    /// </summary>
    public async Task InvokeAsync(HttpContext context, ICorrelator correlator)
    {
        var correlationId = GetOrCreateCorrelationId(context.Request);
        correlator.SetCorrelationId(correlationId);
        await _next(context);
    }

    private Guid GetOrCreateCorrelationId(HttpRequest request)
    {
        var headers = request.Headers.ToDictionary(k => k.Key.ToLowerInvariant(), v => v.Value);
        if (headers.TryGetValue(_correlationIdHeaderName, out var correlationHeaders)
            && Guid.TryParse(correlationHeaders.FirstOrDefault(), out var correlationGuid)
            && correlationGuid != Guid.Empty)
        {
            return correlationGuid;
        }

        var correlationId = Guid.NewGuid();

        // Adding back to request headers as exception handling controller is technically a new scope.
        // This ensures the same correlation id is used for errors
        request.Headers[_correlationIdHeaderName] = correlationId.ToString();

        return correlationId;
    }
}