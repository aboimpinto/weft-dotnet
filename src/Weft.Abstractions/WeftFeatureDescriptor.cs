namespace Weft;

/// <summary>
/// Immutable metadata produced for a single trusted feature.
/// </summary>
public sealed class WeftFeatureDescriptor
{
    /// <summary>
    /// Creates feature metadata.
    /// </summary>
    public WeftFeatureDescriptor(
        string id,
        IReadOnlyList<WeftRouteDescriptor> routes,
        IReadOnlyList<WeftActionDescriptor> actions)
    {
        Id = id;
        Routes = routes ?? throw new ArgumentNullException(nameof(routes));
        Actions = actions ?? throw new ArgumentNullException(nameof(actions));
    }

    /// <summary>
    /// Gets the stable feature identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets declared feature route metadata.
    /// </summary>
    public IReadOnlyList<WeftRouteDescriptor> Routes { get; }

    /// <summary>
    /// Gets declared feature action metadata.
    /// </summary>
    public IReadOnlyList<WeftActionDescriptor> Actions { get; }
}
