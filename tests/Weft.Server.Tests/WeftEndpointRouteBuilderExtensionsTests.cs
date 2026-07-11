using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Weft;
using Weft.Server;
using Xunit;

namespace Weft.Server.Tests;

public sealed class WeftEndpointRouteBuilderExtensionsTests
{
    [Fact]
    public void MapWeft_rejects_routes_that_differ_from_the_manifest()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddWeft(
            new WeftFeatureManifest(
                new WeftFeatureDescriptor(
                    "mismatch",
                    [
                        new WeftRouteDescriptor(
                            "GET",
                            "/declared",
                            "mismatch.page")
                    ],
                    Array.Empty<WeftActionDescriptor>()),
                static () => new MismatchedFeature()));

        using var app = builder.Build();

        var exception = Assert.Throws<InvalidOperationException>(
            () => app.MapWeft());

        Assert.Contains("mapped but not declared", exception.Message);
        Assert.Contains("/actual", exception.Message);
    }

    private sealed class MismatchedFeature : IWeftServerFeature
    {
        public void RegisterServices(IServiceCollection services)
        {
        }

        public void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(
                    "/actual",
                    static () => Results.Ok())
                .WithName("mismatch.page");
        }
    }
}
