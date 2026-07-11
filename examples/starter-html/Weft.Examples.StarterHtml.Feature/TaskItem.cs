namespace Weft.Examples.StarterHtml.Feature;

/// <summary>
/// A task displayed by the starter feature.
/// </summary>
public sealed class TaskItem
{
    /// <summary>
    /// Creates a task.
    /// </summary>
    public TaskItem(int id, string title)
    {
        Id = id;
        Title = title;
    }

    /// <summary>
    /// Gets the task identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the task title.
    /// </summary>
    public string Title { get; }
}
