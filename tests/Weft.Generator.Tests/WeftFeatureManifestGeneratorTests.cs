using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Weft;
using Weft.Generator;
using Weft.Server;
using Xunit;

namespace Weft.Generator.Tests;

public sealed class WeftFeatureManifestGeneratorTests
{
    [Fact]
    public void Valid_feature_generates_a_direct_manifest_factory()
    {
        var result = RunGenerator(
            """
            using Microsoft.AspNetCore.Routing;
            using Microsoft.Extensions.DependencyInjection;
            using Weft;
            using Weft.Server;

            namespace Sample;

            [WeftFeature("tasks")]
            [WeftRoute("/tasks", Name = "tasks.page")]
            [WeftAction("create")]
            public sealed partial class TasksFeature : IWeftServerFeature
            {
                public void RegisterServices(IServiceCollection services) { }

                public void MapEndpoints(IEndpointRouteBuilder endpoints) { }
            }
            """);

        var generatedSource = Assert.Single(
                Assert.Single(result.Results).GeneratedSources)
            .SourceText
            .ToString();

        Assert.Contains(
            "public static global::Weft.Server.IWeftFeatureManifest Manifest",
            generatedSource);
        Assert.Contains(
            "static () => new global::Sample.TasksFeature()",
            generatedSource);
        Assert.DoesNotContain(
            result.Diagnostics,
            diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
    }

    [Fact]
    public void Non_partial_feature_reports_a_clear_diagnostic()
    {
        var result = RunGenerator(
            """
            using Weft;

            [WeftFeature("broken")]
            public sealed class BrokenFeature
            {
            }
            """);

        Assert.Contains(
            Assert.Single(result.Results).Diagnostics,
            diagnostic => diagnostic.Id == "WFT001");
    }

    [Fact]
    public void Feature_without_a_parameterless_constructor_reports_a_clear_diagnostic()
    {
        var result = RunGenerator(
            """
            using Microsoft.AspNetCore.Routing;
            using Microsoft.Extensions.DependencyInjection;
            using Weft;
            using Weft.Server;

            [WeftFeature("broken")]
            public sealed partial class BrokenFeature : IWeftServerFeature
            {
                public BrokenFeature(IServiceProvider services) { }

                public void RegisterServices(IServiceCollection services) { }

                public void MapEndpoints(IEndpointRouteBuilder endpoints) { }
            }
            """);

        Assert.Contains(
            Assert.Single(result.Results).Diagnostics,
            diagnostic => diagnostic.Id == "WFT009");
    }

    private static GeneratorDriverRunResult RunGenerator(string source)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source);
        var compilation = CSharpCompilation.Create(
            "GeneratorTests",
            [syntaxTree],
            GetMetadataReferences(),
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            new WeftFeatureManifestGenerator().AsSourceGenerator());

        driver = driver.RunGenerators(compilation);
        return driver.GetRunResult();
    }

    private static IEnumerable<MetadataReference> GetMetadataReferences()
    {
        var trustedPlatformAssemblies = (string?)AppContext.GetData(
            "TRUSTED_PLATFORM_ASSEMBLIES")
            ?? throw new InvalidOperationException(
                "The .NET test host did not provide trusted platform assemblies.");

        var platformReferences = trustedPlatformAssemblies
            .Split(Path.PathSeparator)
            .Select(path => (MetadataReference)MetadataReference.CreateFromFile(path));

        return platformReferences.Concat(
        [
            MetadataReference.CreateFromFile(typeof(WeftFeatureAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(IWeftServerFeature).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(IEndpointRouteBuilder).Assembly.Location)
        ]);
    }
}
