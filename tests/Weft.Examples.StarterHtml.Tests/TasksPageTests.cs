using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Weft.Examples.StarterHtml.Tests;

public sealed class TasksPageTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TasksPageTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_tasks_returns_html_without_a_browser_runtime()
    {
        using var client = CreateClient();

        var response = await client.GetAsync("/tasks");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<form method=\"post\" action=\"/tasks\">", html);
        Assert.Contains("Read the generated feature manifest", html);
        Assert.Contains("/_weft/tasks/tasks.css", html);
        Assert.DoesNotContain("<script", html.ToLowerInvariant());
        Assert.DoesNotContain("_framework", html);
        Assert.DoesNotContain(".wasm", html);
    }

    [Fact]
    public async Task Post_tasks_without_an_antiforgery_token_is_rejected()
    {
        using var client = CreateClient();
        using var form = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("title", "This must not be saved")
        ]);

        var response = await client.PostAsync("/tasks", form);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Post_tasks_with_an_antiforgery_token_uses_post_redirect_get()
    {
        using var client = CreateClient();
        var initialResponse = await client.GetAsync("/tasks");
        var initialHtml = await initialResponse.Content.ReadAsStringAsync();
        var requestToken = ExtractAntiforgeryToken(initialHtml);

        using var form = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("title", "Write a no-JavaScript test"),
            new KeyValuePair<string, string>("__RequestVerificationToken", requestToken)
        ]);

        var postResponse = await client.PostAsync("/tasks", form);

        Assert.Equal(HttpStatusCode.Found, postResponse.StatusCode);
        Assert.Equal("/tasks", postResponse.Headers.Location?.OriginalString);

        var reloadedHtml = await client.GetStringAsync("/tasks");
        Assert.Contains("Write a no-JavaScript test", reloadedHtml);
    }

    [Fact]
    public async Task Feature_owned_styles_are_served_without_node()
    {
        using var client = CreateClient();

        var response = await client.GetAsync("/_weft/tasks/tasks.css");
        var css = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("text/css", response.Content.Headers.ContentType?.MediaType);
        Assert.Contains(".task-list", css);

        using var headRequest = new HttpRequestMessage(
            HttpMethod.Head,
            "/_weft/tasks/tasks.css");
        using var headResponse = await client.SendAsync(headRequest);

        Assert.Equal(HttpStatusCode.OK, headResponse.StatusCode);
        Assert.Equal("text/css", headResponse.Content.Headers.ContentType?.MediaType);
    }

    private HttpClient CreateClient()
    {
        return _factory.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
    }

    private static string ExtractAntiforgeryToken(string html)
    {
        var match = Regex.Match(
            html,
            "name=\"__RequestVerificationToken\" value=\"(?<token>[^\"]+)\"");

        Assert.True(match.Success, "The rendered HTML did not contain an antiforgery token.");
        return WebUtility.HtmlDecode(match.Groups["token"].Value);
    }
}
