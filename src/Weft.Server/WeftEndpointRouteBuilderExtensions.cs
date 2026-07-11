using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Weft.Server;

/// <summary>
/// Maps endpoints owned by registered Weft feature modules.
/// </summary>
public static class WeftEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Maps all feature endpoints in deterministic feature-ID order.
    /// </summary>
    /// <param name="endpoints">The application endpoint route builder.</param>
    /// <returns>The original endpoint route builder.</returns>
    public static IEndpointRouteBuilder MapWeft(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var registry = endpoints.ServiceProvider.GetRequiredService<WeftFeatureRegistry>();
        registry.MarkMapped();

        foreach (var registeredFeature in registry.Features)
        {
            var mappedEndpoints = GetRouteEndpoints(endpoints)
                .ToHashSet();

            registeredFeature.Feature.MapEndpoints(endpoints);

            ValidateMappedRoutes(
                registeredFeature.Descriptor,
                GetRouteEndpoints(endpoints).Where(
                    endpoint => !mappedEndpoints.Contains(endpoint)));
        }

        return endpoints;
    }

    private static IReadOnlyList<RouteEndpoint> GetRouteEndpoints(
        IEndpointRouteBuilder endpoints)
    {
        return endpoints.DataSources
            .SelectMany(dataSource => dataSource.Endpoints)
            .OfType<RouteEndpoint>()
            .ToArray();
    }

    private static void ValidateMappedRoutes(
        WeftFeatureDescriptor descriptor,
        IEnumerable<RouteEndpoint> mappedEndpoints)
    {
        var declaredRoutes = descriptor.Routes
            .Select(ToRouteKey)
            .ToHashSet(StringComparer.Ordinal);
        var actualRoutes = new HashSet<string>(StringComparer.Ordinal);

        foreach (var endpoint in mappedEndpoints)
        {
            var pattern = endpoint.RoutePattern.RawText;
            var methods = endpoint.Metadata.GetMetadata<IHttpMethodMetadata>()?.HttpMethods;
            var endpointName = endpoint.Metadata
                .GetMetadata<IEndpointNameMetadata>()?
                .EndpointName;

            if (string.IsNullOrWhiteSpace(pattern) ||
                methods is null ||
                methods.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Feature '{descriptor.Id}' mapped an endpoint without a route pattern or HTTP method metadata.");
            }

            foreach (var method in methods)
            {
                actualRoutes.Add(ToRouteKey(method, pattern, endpointName));
            }
        }

        if (declaredRoutes.SetEquals(actualRoutes))
        {
            return;
        }

        var missing = declaredRoutes.Except(actualRoutes).OrderBy(value => value);
        var unexpected = actualRoutes.Except(declaredRoutes).OrderBy(value => value);
        var details = new List<string>();

        if (missing.Any())
        {
            details.Add($"declared but not mapped: {string.Join(", ", missing)}");
        }

        if (unexpected.Any())
        {
            details.Add($"mapped but not declared: {string.Join(", ", unexpected)}");
        }

        throw new InvalidOperationException(
            $"Feature '{descriptor.Id}' route metadata does not match its mapped endpoints ({string.Join("; ", details)}).");
    }

    private static string ToRouteKey(WeftRouteDescriptor route)
    {
        return ToRouteKey(route.Method, route.Pattern, route.Name);
    }

    private static string ToRouteKey(
        string method,
        string pattern,
        string? endpointName)
    {
        return string.Concat(
            method.ToUpperInvariant(),
            " ",
            pattern,
            " | ",
            endpointName ?? string.Empty);
    }
}
