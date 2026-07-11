# Starter HTML

This is the first runnable Weft example. It proves the HTML-first, server-only
foundation without Node, JavaScript, WebAssembly, or a browser .NET runtime.

## Run

From the repository root:

```bash
dotnet test Weft.sln
dotnet run --project examples/starter-html/Weft.Examples.StarterHtml.Web
```

Open the URL printed by ASP.NET Core and navigate to `/tasks`.

## What it proves

- `Weft.Examples.StarterHtml.Feature` is a separate feature class library.
- `[WeftFeature]` generates `TasksFeature.Manifest` at compile time.
- the web host explicitly trusts that manifest with `AddWeft(...)`;
- `MapWeft()` activates the feature's own GET, POST, and CSS routes;
- feature HTML and CSS are embedded with the feature assembly;
- submitted task titles are HTML-encoded;
- a normal form uses ASP.NET Core antiforgery validation;
- valid submissions use post/redirect/get;
- the initial document has no script tag, `_framework` resource, or `.wasm`
  reference.

## Deliberate limits

This example does not yet demonstrate enhanced server fetch, Tailwind,
Bootstrap, Pico, npm/pnpm, browser C#, or lazy capabilities. Those need their
own validated infrastructure rather than a placeholder implementation.
