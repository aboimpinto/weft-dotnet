namespace Weft;

/// <summary>
/// Immutable metadata for a feature-owned route.
/// </summary>
public sealed class WeftRouteDescriptor
{
    /// <summary>
    /// Creates a route descriptor.
    /// </summary>
    public WeftRouteDescriptor(string method, string pattern, string? name)
    {
        Method = method;
        Pattern = pattern;
        Name = name;
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
    /// Gets the optional endpoint name.
    /// </summary>
    public string? Name { get; }
}
