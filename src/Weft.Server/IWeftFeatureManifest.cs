namespace Weft.Server;

/// <summary>
/// A generated, explicitly trusted entry point for a feature module.
/// </summary>
public interface IWeftFeatureManifest
{
    /// <summary>
    /// Gets compile-time feature metadata.
    /// </summary>
    WeftFeatureDescriptor Descriptor { get; }

    /// <summary>
    /// Creates the feature module used to register services and map endpoints.
    /// </summary>
    /// <returns>A stateless feature module instance.</returns>
    IWeftServerFeature CreateFeature();
}
