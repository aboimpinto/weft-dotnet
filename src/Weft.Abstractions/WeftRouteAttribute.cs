namespace Weft;

/// <summary>
/// Declares route metadata owned by a feature.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class WeftRouteAttribute : Attribute
{
    /// <summary>
    /// Creates route metadata.
    /// </summary>
    /// <param name="pattern">The route pattern.</param>
    /// <param name="method">The HTTP method. Defaults to GET.</param>
    public WeftRouteAttribute(string pattern, string method = "GET")
    {
        Pattern = pattern;
        Method = method;
    }

    /// <summary>
    /// Gets the HTTP method.
    /// </summary>
    public string Method { get; }

    /// <summary>
    /// Gets the route pattern.
    /// </summary>
    public string Pattern { get; }

    /// <summary>
    /// Gets or sets the optional endpoint name.
    /// </summary>
    public string? Name { get; set; }
}
