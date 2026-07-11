using System.Reflection;

namespace Weft.Examples.StarterHtml.Feature;

/// <summary>
/// Reads private feature-owned templates embedded in this feature assembly.
/// </summary>
internal static class TemplateAssets
{
    private const string HtmlResourceName =
        "Weft.Examples.StarterHtml.Feature.UI.Tasks.html";

    private const string CssResourceName =
        "Weft.Examples.StarterHtml.Feature.UI.Tasks.css";

    private static readonly Lazy<string> Html = new(
        () => ReadResource(HtmlResourceName));

    private static readonly Lazy<string> Css = new(
        () => ReadResource(CssResourceName));

    public static string TasksHtml => Html.Value;

    public static string TasksCss => Css.Value;

    private static string ReadResource(string resourceName)
    {
        var assembly = typeof(TemplateAssets).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException(
                $"Feature asset '{resourceName}' was not embedded in '{assembly.GetName().Name}'.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
