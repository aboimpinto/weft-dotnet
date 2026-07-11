namespace Weft.Server;

/// <summary>
/// Default manifest implementation used by generated feature code.
/// </summary>
public sealed class WeftFeatureManifest : IWeftFeatureManifest
{
    private readonly Func<IWeftServerFeature> _factory;

    /// <summary>
    /// Creates a feature manifest.
    /// </summary>
    public WeftFeatureManifest(
        WeftFeatureDescriptor descriptor,
        Func<IWeftServerFeature> factory)
    {
        Descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    /// <inheritdoc />
    public WeftFeatureDescriptor Descriptor { get; }

    /// <inheritdoc />
    public IWeftServerFeature CreateFeature()
    {
        return _factory()
            ?? throw new InvalidOperationException(
                $"The Weft feature factory for '{Descriptor.Id}' returned null.");
    }
}
