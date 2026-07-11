namespace Weft.Examples.StarterHtml.Feature;

/// <summary>
/// Thread-safe in-memory state for the starter feature.
/// </summary>
public sealed class TaskStore
{
    private const int MaximumTitleLength = 120;
    private const int MaximumTasks = 25;
    private readonly object _gate = new();
    private readonly List<TaskItem> _tasks =
    [
        new TaskItem(1, "Read the generated feature manifest"),
        new TaskItem(2, "Submit this form without JavaScript")
    ];

    private int _nextId = 3;

    /// <summary>
    /// Returns a stable snapshot of the current tasks.
    /// </summary>
    public IReadOnlyList<TaskItem> GetAll()
    {
        lock (_gate)
        {
            return _tasks.ToArray();
        }
    }

    /// <summary>
    /// Validates and adds a task.
    /// </summary>
    public bool TryAdd(string? title, out string? validationError)
    {
        var normalizedTitle = title?.Trim();

        if (string.IsNullOrWhiteSpace(normalizedTitle))
        {
            validationError = "Enter a task title.";
            return false;
        }

        if (normalizedTitle.Length > MaximumTitleLength)
        {
            validationError =
                $"A task title must be {MaximumTitleLength} characters or fewer.";
            return false;
        }

        lock (_gate)
        {
            if (_tasks.Count >= MaximumTasks)
            {
                validationError =
                    "The bounded demonstration task list is full. Restart the application to reset it.";
                return false;
            }

            _tasks.Add(new TaskItem(_nextId++, normalizedTitle));
        }

        validationError = null;
        return true;
    }
}
