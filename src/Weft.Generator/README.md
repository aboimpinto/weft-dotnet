# Weft.Generator

Experimental source generator for the Weft HTML-first .NET foundation.

The package supplies an analyzer that generates a `Manifest` property into a
valid partial feature class marked with `[WeftFeature]`. The resulting manifest
is explicitly selected by an ASP.NET Core host through
`builder.Services.AddWeft(Feature.Manifest)`.

This package is not production-ready. It requires the corresponding
`Weft.Abstractions` and `Weft.Server` contracts, which have not yet been
published. Browser C#, lazy capabilities, enhanced server actions, and asset
pipeline support are intentionally outside this package's current scope.
