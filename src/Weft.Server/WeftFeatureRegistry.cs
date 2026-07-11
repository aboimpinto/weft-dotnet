namespace Weft.Server;

/// <summary>
/// Immutable registry of the feature instances explicitly trusted by a host.
/// </summary>
public sealed class WeftFeatureRegistry
{
    /// <summary>
    /// Creates a feature registry.
    /// </summary>
    internal WeftFeatureRegistry(IReadOnlyList<WeftRegisteredFeature> features)
    {
        Features = features;
    }

    /// <summary>
    /// Gets registered features in deterministic feature-ID order.
    /// </summary>
    public IReadOnlyList<WeftRegisteredFeature> Features { get; }

    internal bool IsMapped { get; private set; }

    internal void MarkMapped()
    {
        if (IsMapped)
        {
            throw new InvalidOperationException(
                "Weft feature endpoints have already been mapped for this application.");
        }

        IsMapped = true;
    }
}

/// <summary>
/// Couples generated feature metadata to its server module instance.
/// </summary>
public sealed class WeftRegisteredFeature
{
    internal WeftRegisteredFeature(
        WeftFeatureDescriptor descriptor,
        IWeftServerFeature feature)
    {
        Descriptor = descriptor;
        Feature = feature;
    }

    /// <summary>
    /// Gets generated feature metadata.
    /// </summary>
    public WeftFeatureDescriptor Descriptor { get; }

    /// <summary>
    /// Gets the stateless module that owns services and endpoint mapping.
    /// </summary>
    public IWeftServerFeature Feature { get; }
}
