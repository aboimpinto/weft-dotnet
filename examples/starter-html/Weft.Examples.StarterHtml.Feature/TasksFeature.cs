using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Weft;
using Weft.Server;

namespace Weft.Examples.StarterHtml.Feature;

/// <summary>
/// A feature-owned task list with a normal HTML form fallback.
/// </summary>
[WeftFeature("tasks")]
[WeftRoute("/tasks", Name = "tasks.page")]
[WeftRoute("/tasks", "POST", Name = "tasks.create")]
[WeftRoute("/_weft/tasks/tasks.css", Name = "tasks.styles")]
[WeftRoute("/_weft/tasks/tasks.css", "HEAD", Name = "tasks.styles")]
[WeftAction("create", Mode = WeftExecutionMode.Html)]
public sealed partial class TasksFeature : IWeftServerFeature
{
    /// <inheritdoc />
    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<TaskStore>();
        services.AddSingleton<TasksPage>();
        services.AddAntiforgery();
    }

    /// <inheritdoc />
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/tasks", Render)
            .WithName("tasks.page");

        endpoints.MapPost("/tasks", CreateAsync)
            .WithMetadata(new RequireAntiforgeryTokenAttribute(true))
            .WithName("tasks.create");

        endpoints.MapMethods(
                "/_weft/tasks/tasks.css",
                ["GET", "HEAD"],
                static () => Results.Content(
                    TemplateAssets.TasksCss,
                    "text/css; charset=utf-8"))
            .WithName("tasks.styles");
    }

    private static IResult Render(
        HttpContext context,
        IAntiforgery antiforgery,
        TaskStore tasks,
        TasksPage page)
    {
        return RenderPage(context, antiforgery, tasks, page);
    }

    private static async Task<IResult> CreateAsync(
        HttpContext context,
        IAntiforgery antiforgery,
        TaskStore tasks,
        TasksPage page)
    {
        var antiforgeryValidation = context.Features.Get<IAntiforgeryValidationFeature>();
        if (antiforgeryValidation is null || !antiforgeryValidation.IsValid)
        {
            return Results.BadRequest();
        }

        var form = await context.Request.ReadFormAsync(context.RequestAborted);
        var title = form["title"].ToString();

        if (!tasks.TryAdd(title, out var validationError))
        {
            return RenderPage(
                context,
                antiforgery,
                tasks,
                page,
                validationError,
                StatusCodes.Status400BadRequest);
        }

        return Results.Redirect("/tasks");
    }

    private static IResult RenderPage(
        HttpContext context,
        IAntiforgery antiforgery,
        TaskStore tasks,
        TasksPage page,
        string? validationError = null,
        int? statusCode = null)
    {
        var token = antiforgery.GetAndStoreTokens(context).RequestToken
            ?? throw new InvalidOperationException(
                "ASP.NET Core did not create an antiforgery request token.");

        return Results.Content(
            page.Render(tasks.GetAll(), token, validationError),
            "text/html; charset=utf-8",
            statusCode: statusCode);
    }
}
