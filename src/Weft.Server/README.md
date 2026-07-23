# WeftDotNet.Server

Experimental ASP.NET Core hosting infrastructure for Weft HTML-first feature
modules.

The package provides explicit feature registration and deterministic endpoint
mapping. It currently supports the server-only foundation; browser C#, enhanced
fetch, and the general asset pipeline are not implemented.

```csharp
builder.Services.AddWeft(TasksFeature.Manifest);

var app = builder.Build();
app.MapWeft();
```

The API is experimental and may change before a stable release.

Project: <https://github.com/aboimpinto/weft-dotnet>
