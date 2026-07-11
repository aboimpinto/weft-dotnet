namespace Weft;

/// <summary>
/// Declares an interaction name and its planned execution placement.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class WeftActionAttribute : Attribute
{
    /// <summary>
    /// Creates action metadata.
    /// </summary>
    /// <param name="name">A feature-local action name.</param>
    public WeftActionAttribute(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets the feature-local action name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets or sets the declared execution placement.
    /// </summary>
    public WeftExecutionMode Mode { get; set; } = WeftExecutionMode.Html;
}
