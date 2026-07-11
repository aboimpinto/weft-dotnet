# Framework source

The source packages will be introduced only when their public contract is
defined and covered by a runnable example.

The intended package boundaries are:

```text
Weft.Abstractions   Feature metadata and shared contracts
Weft.Generator      Source-generated manifest, registration, and diagnostics
Weft.Server         ASP.NET Core hosting, rendering, and server actions
Weft.Browser        Browser-safe capability hosting and typed interop
Weft.Assets         Asset-manifest build and publish integration
```

These are design names, not published packages or compatibility commitments.
