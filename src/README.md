# Framework source

The first server-only packages are implemented and exercised by the runnable
starter example. They remain experimental and are not published NuGet packages
or compatibility commitments.

```text
Weft.Abstractions   Implemented: feature metadata and manifest descriptors
Weft.Generator      Implemented: generated Feature.Manifest properties and diagnostics
Weft.Server         Implemented: explicit registration and deterministic endpoint mapping
```

The later package boundaries are:

```text
Weft.Browser        Browser-safe capability hosting and typed interop
Weft.Assets         Asset-manifest build and publish integration
```

The first implementation intentionally keeps general template rendering and
asset-pipeline APIs private to the example until their contracts are designed.
