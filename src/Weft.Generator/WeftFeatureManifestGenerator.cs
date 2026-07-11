using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Weft.Generator;

/// <summary>
/// Generates one explicitly trusted manifest property for each valid
/// <c>WeftFeature</c> class in a feature assembly.
/// </summary>
[Generator]
public sealed class WeftFeatureManifestGenerator : IIncrementalGenerator
{
    private const string FeatureAttributeName = "Weft.WeftFeatureAttribute";
    private const string RouteAttributeName = "Weft.WeftRouteAttribute";
    private const string ActionAttributeName = "Weft.WeftActionAttribute";
    private const string ServerFeatureInterfaceName = "Weft.Server.IWeftServerFeature";

    private static readonly DiagnosticDescriptor FeatureMustBePartial = new(
        id: "WFT001",
        title: "A Weft feature must be partial",
        messageFormat: "Feature '{0}' must be declared partial so Weft can generate its Manifest property",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor FeatureMustImplementServerFeature = new(
        id: "WFT002",
        title: "A Weft feature must implement IWeftServerFeature",
        messageFormat: "Feature '{0}' must implement Weft.Server.IWeftServerFeature",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor InvalidFeatureShape = new(
        id: "WFT003",
        title: "Invalid Weft feature shape",
        messageFormat: "Feature '{0}' must be a public, non-abstract, non-generic top-level class",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor InvalidFeatureId = new(
        id: "WFT004",
        title: "Invalid Weft feature ID",
        messageFormat: "Feature '{0}' must declare a non-empty feature ID",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor DuplicateFeatureId = new(
        id: "WFT005",
        title: "Duplicate Weft feature ID",
        messageFormat: "Feature ID '{0}' is declared more than once in this assembly",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor InvalidRoute = new(
        id: "WFT006",
        title: "Invalid Weft route metadata",
        messageFormat: "Feature '{0}' has invalid route metadata: {1}",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor DuplicateAction = new(
        id: "WFT007",
        title: "Duplicate Weft action",
        messageFormat: "Feature '{0}' declares action '{1}' more than once",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor ManifestMemberConflict = new(
        id: "WFT008",
        title: "Weft Manifest member conflict",
        messageFormat: "Feature '{0}' already declares a member named Manifest",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor MissingParameterlessConstructor = new(
        id: "WFT009",
        title: "A Weft feature needs a parameterless constructor",
        messageFormat: "Feature '{0}' must have a parameterless constructor because its generated manifest creates a stateless module instance",
        category: "Weft",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var featureCandidates = context.SyntaxProvider.ForAttributeWithMetadataName(
            FeatureAttributeName,
            static (node, _) => node is ClassDeclarationSyntax,
            static (attributeContext, _) => (INamedTypeSymbol)attributeContext.TargetSymbol);

        var compilationAndCandidates = context.CompilationProvider.Combine(
            featureCandidates.Collect());

        context.RegisterSourceOutput(
            compilationAndCandidates,
            static (productionContext, source) =>
                Execute(productionContext, source.Left, source.Right));
    }

    private static void Execute(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<INamedTypeSymbol> candidates)
    {
        var serverFeatureInterface = compilation.GetTypeByMetadataName(
            ServerFeatureInterfaceName);
        var features = new List<FeatureModel>();
        var seenSymbols = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

        foreach (var candidate in candidates)
        {
            if (!seenSymbols.Add(candidate))
            {
                continue;
            }

            var feature = TryCreateFeature(
                context,
                candidate,
                serverFeatureInterface);

            if (feature is not null)
            {
                features.Add(feature);
            }
        }

        var duplicateIds = features
            .GroupBy(feature => feature.Id, StringComparer.Ordinal)
            .Where(group => group.Count() > 1)
            .ToArray();

        var invalidFeatures = new HashSet<INamedTypeSymbol>(
            SymbolEqualityComparer.Default);

        foreach (var group in duplicateIds)
        {
            foreach (var feature in group)
            {
                invalidFeatures.Add(feature.Symbol);
                context.ReportDiagnostic(Diagnostic.Create(
                    DuplicateFeatureId,
                    feature.Location,
                    feature.Id));
            }
        }

        foreach (var feature in features
                     .Where(feature => !invalidFeatures.Contains(feature.Symbol))
                     .OrderBy(feature => feature.Id, StringComparer.Ordinal))
        {
            context.AddSource(
                GetHintName(feature.Symbol),
                SourceText.From(RenderManifest(feature), Encoding.UTF8));
        }
    }

    private static FeatureModel? TryCreateFeature(
        SourceProductionContext context,
        INamedTypeSymbol symbol,
        INamedTypeSymbol? serverFeatureInterface)
    {
        var attribute = symbol.GetAttributes()
            .FirstOrDefault(IsAttribute(FeatureAttributeName));

        if (attribute is null)
        {
            return null;
        }

        var location = GetAttributeLocation(attribute, symbol);
        var isValid = true;

        if (!IsSupportedFeatureShape(symbol))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                InvalidFeatureShape,
                location,
                symbol.Name));
            isValid = false;
        }

        if (!IsPartial(symbol))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                FeatureMustBePartial,
                location,
                symbol.Name));
            isValid = false;
        }

        if (serverFeatureInterface is null ||
            !symbol.AllInterfaces.Any(
                implementedInterface =>
                    SymbolEqualityComparer.Default.Equals(
                        implementedInterface,
                        serverFeatureInterface)))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                FeatureMustImplementServerFeature,
                location,
                symbol.Name));
            isValid = false;
        }

        if (symbol.GetMembers("Manifest").Length > 0)
        {
            context.ReportDiagnostic(Diagnostic.Create(
                ManifestMemberConflict,
                location,
                symbol.Name));
            isValid = false;
        }

        if (!symbol.InstanceConstructors.Any(
                constructor => constructor.Parameters.Length == 0))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                MissingParameterlessConstructor,
                location,
                symbol.Name));
            isValid = false;
        }

        var id = GetStringArgument(attribute, 0);
        if (string.IsNullOrWhiteSpace(id))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                InvalidFeatureId,
                location,
                symbol.Name));
            isValid = false;
        }

        var routes = GetRoutes(context, symbol, ref isValid);
        var actions = GetActions(context, symbol, ref isValid);

        return isValid
            ? new FeatureModel(
                symbol,
                id!,
                routes,
                actions,
                location)
            : null;
    }

    private static ImmutableArray<RouteModel> GetRoutes(
        SourceProductionContext context,
        INamedTypeSymbol symbol,
        ref bool isValid)
    {
        var routes = ImmutableArray.CreateBuilder<RouteModel>();
        var routeKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var attribute in symbol.GetAttributes().Where(
                     IsAttribute(RouteAttributeName)))
        {
            var pattern = GetStringArgument(attribute, 0);
            var method = GetStringArgument(attribute, 1) ?? "GET";
            var name = GetNamedStringArgument(attribute, "Name");
            var location = GetAttributeLocation(attribute, symbol);

            if (pattern is null)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRoute,
                    location,
                    symbol.Name,
                    "the route pattern must start with '/'."));
                isValid = false;
                continue;
            }

            if (pattern.Length == 0 || pattern[0] != '/')
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRoute,
                    location,
                    symbol.Name,
                    "the route pattern must start with '/'."));
                isValid = false;
                continue;
            }

            if (string.IsNullOrWhiteSpace(method))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRoute,
                    location,
                    symbol.Name,
                    "the HTTP method must be a single non-empty token."));
                isValid = false;
                continue;
            }

            if (method.Any(char.IsWhiteSpace))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRoute,
                    location,
                    symbol.Name,
                    "the HTTP method must be a single non-empty token."));
                isValid = false;
                continue;
            }

            var normalizedMethod = method.ToUpperInvariant();
            var routeKey = normalizedMethod + " " + pattern;
            if (!routeKeys.Add(routeKey))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRoute,
                    location,
                    symbol.Name,
                    $"'{routeKey}' is declared more than once."));
                isValid = false;
                continue;
            }

            routes.Add(new RouteModel(normalizedMethod, pattern, name));
        }

        return routes.ToImmutable();
    }

    private static ImmutableArray<ActionModel> GetActions(
        SourceProductionContext context,
        INamedTypeSymbol symbol,
        ref bool isValid)
    {
        var actions = ImmutableArray.CreateBuilder<ActionModel>();
        var actionNames = new HashSet<string>(StringComparer.Ordinal);

        foreach (var attribute in symbol.GetAttributes().Where(
                     IsAttribute(ActionAttributeName)))
        {
            var name = GetStringArgument(attribute, 0);
            var location = GetAttributeLocation(attribute, symbol);

            if (name is null || string.IsNullOrWhiteSpace(name))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    DuplicateAction,
                    location,
                    symbol.Name,
                    "<empty>"));
                isValid = false;
                continue;
            }

            var actionName = name;
            if (!actionNames.Add(actionName))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    DuplicateAction,
                    location,
                    symbol.Name,
                    actionName));
                isValid = false;
                continue;
            }

            actions.Add(new ActionModel(
                actionName,
                GetNamedEnumArgument(attribute, "Mode")));
        }

        return actions.ToImmutable();
    }

    private static bool IsSupportedFeatureShape(INamedTypeSymbol symbol)
    {
        return symbol.DeclaredAccessibility == Accessibility.Public &&
               !symbol.IsAbstract &&
               symbol.TypeParameters.Length == 0 &&
               symbol.ContainingType is null;
    }

    private static bool IsPartial(INamedTypeSymbol symbol)
    {
        return symbol.DeclaringSyntaxReferences.All(
            syntaxReference =>
                syntaxReference.GetSyntax() is ClassDeclarationSyntax declaration &&
                declaration.Modifiers.Any(
                    modifier => modifier.IsKind(
                        Microsoft.CodeAnalysis.CSharp.SyntaxKind.PartialKeyword)));
    }

    private static Func<AttributeData, bool> IsAttribute(string metadataName)
    {
        return attribute =>
            string.Equals(
                attribute.AttributeClass?.ToDisplayString(),
                metadataName,
                StringComparison.Ordinal);
    }

    private static string? GetStringArgument(AttributeData attribute, int index)
    {
        if (attribute.ConstructorArguments.Length <= index)
        {
            return null;
        }

        return attribute.ConstructorArguments[index].Value as string;
    }

    private static string? GetNamedStringArgument(
        AttributeData attribute,
        string name)
    {
        foreach (var namedArgument in attribute.NamedArguments)
        {
            if (string.Equals(namedArgument.Key, name, StringComparison.Ordinal))
            {
                return namedArgument.Value.Value as string;
            }
        }

        return null;
    }

    private static int GetNamedEnumArgument(
        AttributeData attribute,
        string name)
    {
        foreach (var namedArgument in attribute.NamedArguments)
        {
            if (string.Equals(namedArgument.Key, name, StringComparison.Ordinal) &&
                namedArgument.Value.Value is int value)
            {
                return value;
            }
        }

        return 0;
    }

    private static Location GetAttributeLocation(
        AttributeData? attribute,
        ISymbol symbol)
    {
        return attribute?.ApplicationSyntaxReference?.GetSyntax().GetLocation()
            ?? symbol.Locations.FirstOrDefault()
            ?? Location.None;
    }

    private static string RenderManifest(FeatureModel feature)
    {
        var builder = new StringBuilder();
        var namespaceName = feature.Symbol.ContainingNamespace.ToDisplayString();
        var featureTypeName = feature.Symbol.ToDisplayString(
            SymbolDisplayFormat.FullyQualifiedFormat);

        builder.AppendLine("// <auto-generated />");
        builder.AppendLine("#nullable enable");

        if (!string.IsNullOrEmpty(namespaceName))
        {
            builder.Append("namespace ")
                .Append(namespaceName)
                .AppendLine();
            builder.AppendLine("{");
        }

        builder.Append("    public partial class ")
            .Append(feature.Symbol.Name)
            .AppendLine();
        builder.AppendLine("    {");
        builder.AppendLine("        /// <summary>");
        builder.AppendLine("        /// Gets the generated manifest used to explicitly trust this feature.");
        builder.AppendLine("        /// </summary>");
        builder.AppendLine("        public static global::Weft.Server.IWeftFeatureManifest Manifest { get; } =");
        builder.AppendLine("            new global::Weft.Server.WeftFeatureManifest(");
        builder.AppendLine("                new global::Weft.WeftFeatureDescriptor(");
        builder.Append("                    ")
            .Append(ToLiteral(feature.Id))
            .AppendLine(",");
        AppendRoutes(builder, feature.Routes);
        builder.AppendLine(",");
        AppendActions(builder, feature.Actions);
        builder.AppendLine("),");
        builder.Append("                static () => new ")
            .Append(featureTypeName)
            .AppendLine("());");
        builder.AppendLine("    }");

        if (!string.IsNullOrEmpty(namespaceName))
        {
            builder.AppendLine("}");
        }

        return builder.ToString();
    }

    private static void AppendRoutes(
        StringBuilder builder,
        ImmutableArray<RouteModel> routes)
    {
        if (routes.IsDefaultOrEmpty)
        {
            builder.Append("                    global::System.Array.Empty<global::Weft.WeftRouteDescriptor>()");
            return;
        }

        builder.AppendLine("                    new global::Weft.WeftRouteDescriptor[]");
        builder.AppendLine("                    {");

        foreach (var route in routes)
        {
            builder.Append("                        new global::Weft.WeftRouteDescriptor(")
                .Append(ToLiteral(route.Method))
                .Append(", ")
                .Append(ToLiteral(route.Pattern))
                .Append(", ")
                .Append(route.Name is null ? "null" : ToLiteral(route.Name))
                .AppendLine("),");
        }

        builder.Append("                    }");
    }

    private static void AppendActions(
        StringBuilder builder,
        ImmutableArray<ActionModel> actions)
    {
        if (actions.IsDefaultOrEmpty)
        {
            builder.Append("                    global::System.Array.Empty<global::Weft.WeftActionDescriptor>()");
            return;
        }

        builder.AppendLine("                    new global::Weft.WeftActionDescriptor[]");
        builder.AppendLine("                    {");

        foreach (var action in actions)
        {
            builder.Append("                        new global::Weft.WeftActionDescriptor(")
                .Append(ToLiteral(action.Name))
                .Append(", (global::Weft.WeftExecutionMode)")
                .Append(action.Mode)
                .AppendLine("),");
        }

        builder.Append("                    }");
    }

    private static string GetHintName(INamedTypeSymbol symbol)
    {
        var value = symbol.ToDisplayString();
        var builder = new StringBuilder("Weft.");

        foreach (var character in value)
        {
            builder.Append(char.IsLetterOrDigit(character) ? character : '_');
        }

        builder.Append(".Manifest.g.cs");
        return builder.ToString();
    }

    private static string ToLiteral(string value)
    {
        return SymbolDisplay.FormatLiteral(value, quote: true);
    }

    private sealed class FeatureModel
    {
        public FeatureModel(
            INamedTypeSymbol symbol,
            string id,
            ImmutableArray<RouteModel> routes,
            ImmutableArray<ActionModel> actions,
            Location location)
        {
            Symbol = symbol;
            Id = id;
            Routes = routes;
            Actions = actions;
            Location = location;
        }

        public INamedTypeSymbol Symbol { get; }

        public string Id { get; }

        public ImmutableArray<RouteModel> Routes { get; }

        public ImmutableArray<ActionModel> Actions { get; }

        public Location Location { get; }
    }

    private sealed class RouteModel
    {
        public RouteModel(string method, string pattern, string? name)
        {
            Method = method;
            Pattern = pattern;
            Name = name;
        }

        public string Method { get; }

        public string Pattern { get; }

        public string? Name { get; }
    }

    private sealed class ActionModel
    {
        public ActionModel(string name, int mode)
        {
            Name = name;
            Mode = mode;
        }

        public string Name { get; }

        public int Mode { get; }
    }
}
