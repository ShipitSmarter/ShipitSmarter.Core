using ShipitSmarter.Core;

// ReSharper disable once CheckNamespace
namespace System.Net.Http.Headers;

/// <summary>
/// Extensions for <see cref="HttpHeaders"/>
/// </summary>
public static class HttpHeadersExtensions
{
    /// <summary>
    /// Add a CorrelationId to the <see cref="HttpHeaders"/> using the <see cref="ICorrelator"/>
    /// </summary>
    /// <param name="headers">The Http Headers to be updated</param>
    /// <param name="correlator">The correlator containing the actual correlation id</param>
    public static void AddCorrelationId(this HttpHeaders headers, ICorrelator correlator)
    {
        headers.Add("x-correlation-id", correlator.CurrentCorrelationId.ToString());
    }
}