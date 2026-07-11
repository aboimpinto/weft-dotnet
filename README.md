# Weft

> HTML-first .NET feature modules with optional, lazy browser C#.

> **Status: runnable server-only foundation.** Generated feature manifests,
> explicit ASP.NET Core module registration, and the HTML-first starter example
> work today. Browser C#, lazy capability loading, enhanced fetch, and npm
> integration are not implemented.

Weft is an experimental .NET foundation for building ASP.NET Core applications
as server-owned HTML feature modules. A page is useful before any managed
browser runtime starts. When local browser behavior is genuinely valuable, a
future supported capability loader should activate only the relevant C# module,
independently of the initial page.

The name **Weft** is a working identity: a weft is the thread woven across a
fabric. Here, server routes, HTML templates, styles, and optional browser
capabilities form one vertical feature rather than unrelated frontend and
backend layers. Before publishing packages or using the brand commercially, the
name needs normal GitHub, NuGet, domain, and trademark checks.

## What works now

The first implementation proves the server side of the model:

- a feature module is a separate class-library project;
- `[WeftFeature]` metadata produces a generated `Feature.Manifest` property;
- the host explicitly selects trusted manifests with `AddWeft(...)`;
- `MapWeft()` calls each feature's own route-mapping method in deterministic
  feature-ID order;
- the starter renders feature-owned HTML and CSS, uses a real antiforgery form,
  and performs post/redirect/get with no JavaScript or browser runtime.

The generated manifest is direct compiled code. Weft does not scan every DLL
deployed on the server and does not use reflection to dispatch feature routes.

```csharp
[WeftFeature("tasks")]
[WeftRoute("/tasks", Name = "tasks.page")]
public sealed partial class TasksFeature : IWeftServerFeature
{
    public void RegisterServices(IServiceCollection services) { /* feature DI */ }

    public void MapEndpoints(IEndpointRouteBuilder endpoints) { /* feature routes */ }
}
```

```csharp
builder.Services.AddWeft(TasksFeature.Manifest);

var app = builder.Build();
app.UseAntiforgery();
app.MapWeft();
```

## The idea

Most business applications do not need a large client runtime to render their
first useful page. They need fast, accessible HTML; normal URLs and forms;
server-side authorization; and only some interactions need sustained local
behavior.

Weft makes that execution choice explicit:

| Interaction mode | Typical use | Browser cost |
| --- | --- | --- |
| HTML action | Navigation, save, simple workflow | No application runtime |
| Enhanced server action | Busy state, fetch, replace a region | Small generic enhancement kernel |
| Local C# capability | Offline work, repeated calculations, rich long-lived interaction | Future: lazy managed runtime plus the selected capability |

The intended outcome is not “Next.js written in C#,” nor a replacement for all
frontend frameworks. It is a C#-native feature contract with a measurable rule:
**do not start a managed browser runtime until a declared capability needs it.**

## Package policy

Weft will be **NuGet-first and npm-compatible**:

- NuGet distributes Weft features, server modules, generators, C# browser
  capabilities, and .NET integrations.
- npm-compatible tooling is optional for CSS frameworks and JavaScript bridges
  such as Tailwind, Bootstrap, Chart.js, or Monaco.
- Node is an opt-in build-time option, never a browser deployment requirement.
- An explicitly declared JavaScript bridge may deploy as a content-hashed
  browser asset; it is not a global application bundle.
- Weft will not invent a second JavaScript package registry or force a Node
  toolchain on projects that do not need one.

The full decision is in [docs/package-ecosystem.md](docs/package-ecosystem.md).

## Architecture in one view

```text
Feature module
├── Server companion   DI, routes, authorization, data access
├── HTML + CSS         server-rendered templates and private styles
├── Fallback           ordinary forms, links, and HTTP semantics
├── Enhancement        small generic browser infrastructure when useful
└── C# capability      optional, lazy browser code for local behavior

Build output
├── server route/module catalog
├── content-hashed HTML/CSS/JS/Wasm assets
├── generated feature and asset manifest
└── payload and dependency-budget report
```

Read [docs/architecture.md](docs/architecture.md) for the design boundaries.

## Examples

The starter is a real runnable server application. The remaining folders are
scenario specifications until their infrastructure exists.

| Example | Styling approach | What it must prove | Status |
| --- | --- | --- | --- |
| [starter-html](examples/starter-html) | Plain CSS | Feature manifest, trusted module registration, server HTML, antiforgery form, and no browser runtime | Available |
| [tailwind-orders](examples/tailwind-orders) | Tailwind CSS | Templates are included in Tailwind content scanning without shipping Tailwind runtime JS | Planned |
| [bootstrap-admin](examples/bootstrap-admin) | Bootstrap CSS | Normal forms and responsive admin UI; Bootstrap JS loaded only when explicitly needed | Planned |
| [pico-portal](examples/pico-portal) | Pico CSS | A lightweight, CSS-first portal with minimal tooling | Planned |

Run the starter:

```bash
dotnet test Weft.sln
dotnet run --project examples/starter-html/Weft.Examples.StarterHtml.Web
```

Then open `http://localhost:5000/tasks` (or the URL printed by ASP.NET Core).
See [docs/examples.md](docs/examples.md) for the full example contract.

## What Weft is not

- Not Blazor UI under a different name.
- Not a claim that C# is interpreted by browsers or requires zero compilation.
- Not “full .NET Core” in the browser; browser code must target a safe,
  browser-valid capability profile.
- Not a React/JSX/virtual-DOM clone.
- Not one WebAssembly bundle per button or visual component.
- Not a promise that managed code eliminates browser memory or performance
  problems.

## Roadmap

The first real deliverable—generated trusted feature registration—is now in
place. The next work is to expand it carefully rather than rushing into a
browser runtime.

1. Extend manifest diagnostics and metadata beyond source-local feature
   modules.
2. Build the enhanced-server-action execution mode with graceful
   fallback.
3. Add browser/server boundary validation, typed transport, and generated
   dispatch.
4. Establish a supported lazy capability loader and capability chunk planner.
5. Add payload budgets, cache diagnostics, and the runnable example suite.

The detailed sequence is in [docs/roadmap.md](docs/roadmap.md).

## Repository layout

```text
src/          Abstractions, server host, and source generator
examples/     Runnable starter plus future scenario specifications
tests/        Generator and end-to-end starter tests
prototypes/   Isolated experiments; no prototype API is a compatibility promise
docs/         Architecture decisions, package policy, example contracts, roadmap
```

## Contributing

This repository is at the architecture-and-prototype stage. Design feedback is
welcome, but code contributions and reuse terms are deferred until the owner
selects a public license. The intended contribution principles are in
[CONTRIBUTING.md](CONTRIBUTING.md).

## License

Weft is licensed under the [MIT License](LICENSE).
