using System.Net;
using System.Text;

namespace Weft.Examples.StarterHtml.Feature;

/// <summary>
/// Server-only rendering for the starter feature.
/// </summary>
public sealed class TasksPage
{
    /// <summary>
    /// Renders the feature's complete HTML document.
    /// </summary>
    public string Render(
        IReadOnlyList<TaskItem> tasks,
        string antiforgeryToken,
        string? validationError = null)
    {
        ArgumentNullException.ThrowIfNull(tasks);
        ArgumentNullException.ThrowIfNull(antiforgeryToken);

        return TemplateAssets.TasksHtml
            .Replace(
                "{{antiforgeryToken}}",
                WebUtility.HtmlEncode(antiforgeryToken),
                StringComparison.Ordinal)
            .Replace(
                "{{validationError}}",
                RenderValidationError(validationError),
                StringComparison.Ordinal)
            .Replace(
                "{{tasks}}",
                RenderTasks(tasks),
                StringComparison.Ordinal);
    }

    private static string RenderValidationError(string? validationError)
    {
        return string.IsNullOrWhiteSpace(validationError)
            ? string.Empty
            : $"<p class=\"validation-summary\" role=\"alert\">{WebUtility.HtmlEncode(validationError)}</p>";
    }

    private static string RenderTasks(IReadOnlyList<TaskItem> tasks)
    {
        if (tasks.Count == 0)
        {
            return "<li class=\"empty-state\">No tasks have been added yet.</li>";
        }

        var output = new StringBuilder();

        foreach (var task in tasks)
        {
            output.Append("<li data-task-id=\"")
                .Append(task.Id)
                .Append("\">")
                .Append(WebUtility.HtmlEncode(task.Title))
                .AppendLine("</li>");
        }

        return output.ToString();
    }
}
