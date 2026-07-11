namespace Weft;

/// <summary>
/// Immutable metadata for a feature action.
/// </summary>
public sealed class WeftActionDescriptor
{
    /// <summary>
    /// Creates an action descriptor.
    /// </summary>
    public WeftActionDescriptor(string name, WeftExecutionMode mode)
    {
        Name = name;
        Mode = mode;
    }

    /// <summary>
    /// Gets the feature-local action name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the planned execution placement.
    /// </summary>
    public WeftExecutionMode Mode { get; }
}
