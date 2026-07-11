using Microsoft.Extensions.DependencyInjection;

namespace Weft.Server;

/// <summary>
/// Registers explicitly trusted generated Weft feature manifests.
/// </summary>
public static class WeftServiceCollectionExtensions
{
    /// <summary>
    /// Adds feature modules selected by the host application.
    /// </summary>
    /// <param name="services">The application service collection.</param>
    /// <param name="manifests">Generated manifests selected by the host.</param>
    /// <returns>The original service collection.</returns>
    public static IServiceCollection AddWeft(
        this IServiceCollection services,
        params IWeftFeatureManifest[] manifests)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(manifests);

        if (services.Any(
                descriptor => descriptor.ServiceType == typeof(WeftFeatureRegistry)))
        {
            throw new InvalidOperationException(
                "Weft features have already been added to this service collection.");
        }

        var registeredFeatures = manifests
            .Select(manifest => manifest ?? throw new ArgumentException(
                "A Weft manifest cannot be null.",
                nameof(manifests)))
            .OrderBy(manifest => manifest.Descriptor.Id, StringComparer.Ordinal)
            .Select(CreateAndValidate)
            .ToArray();

        ValidateDuplicates(registeredFeatures);

        foreach (var registeredFeature in registeredFeatures)
        {
            registeredFeature.Feature.RegisterServices(services);
        }

        services.AddSingleton(new WeftFeatureRegistry(registeredFeatures));
        return services;
    }

    private static WeftRegisteredFeature CreateAndValidate(IWeftFeatureManifest manifest)
    {
        ArgumentNullException.ThrowIfNull(manifest.Descriptor);

        if (string.IsNullOrWhiteSpace(manifest.Descriptor.Id))
        {
            throw new InvalidOperationException("A Weft feature ID cannot be empty.");
        }

        var feature = manifest.CreateFeature();
        return new WeftRegisteredFeature(manifest.Descriptor, feature);
    }

    private static void ValidateDuplicates(
        IReadOnlyCollection<WeftRegisteredFeature> features)
    {
        var ids = new HashSet<string>(StringComparer.Ordinal);
        var routes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var endpointNames = new Dictionary<string, string>(StringComparer.Ordinal);

        foreach (var feature in features)
        {
            if (!ids.Add(feature.Descriptor.Id))
            {
                throw new InvalidOperationException(
                    $"The Weft feature ID '{feature.Descriptor.Id}' is registered more than once.");
            }

            foreach (var route in feature.Descriptor.Routes)
            {
                var key = $"{route.Method.ToUpperInvariant()} {route.Pattern}";
                if (!routes.Add(key))
                {
                    throw new InvalidOperationException(
                        $"The Weft route '{key}' is declared by more than one trusted feature.");
                }

                if (!string.IsNullOrWhiteSpace(route.Name) &&
                    endpointNames.TryGetValue(route.Name, out var namedPattern) &&
                    !string.Equals(namedPattern, route.Pattern, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException(
                        $"The Weft endpoint name '{route.Name}' is declared more than once.");
                }

                if (!string.IsNullOrWhiteSpace(route.Name))
                {
                    endpointNames[route.Name] = route.Pattern;
                }
            }
        }
    }
}
