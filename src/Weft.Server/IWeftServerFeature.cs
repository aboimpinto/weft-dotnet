using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Weft.Server;

/// <summary>
/// Server behavior owned by a Weft feature.
/// </summary>
/// <remarks>
/// Feature modules are created during service registration and should remain
/// stateless. Endpoint handlers receive application services through normal
/// ASP.NET Core dependency injection.
/// </remarks>
public interface IWeftServerFeature
{
    /// <summary>
    /// Registers services owned by the feature.
    /// </summary>
    /// <param name="services">The application service collection.</param>
    void RegisterServices(IServiceCollection services);

    /// <summary>
    /// Maps endpoints owned by the feature.
    /// </summary>
    /// <param name="endpoints">The application's endpoint route builder.</param>
    /// <remarks>
    /// Every mapped method, route pattern, and endpoint name must match the
    /// feature's generated route metadata. Hosts call <c>MapWeft</c> before
    /// mapping host-owned endpoints in this initial implementation.
    /// </remarks>
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}
