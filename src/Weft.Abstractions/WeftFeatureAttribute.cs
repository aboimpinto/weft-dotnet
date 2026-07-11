namespace Weft;

/// <summary>
/// Declares a server feature that can receive a generated Weft manifest.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class WeftFeatureAttribute : Attribute
{
    /// <summary>
    /// Creates metadata for a feature.
    /// </summary>
    /// <param name="id">A stable, application-unique feature identifier.</param>
    public WeftFeatureAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the stable feature identifier.
    /// </summary>
    public string Id { get; }
}
