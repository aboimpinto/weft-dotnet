# Weft

> HTML-first .NET feature modules with optional, lazy browser C#.

> **Status: architecture/prototype repository.** There is no runnable Weft
> framework, supported lazy browser-C# loader, or public API compatibility
> promise yet.

Weft is an experimental design for building ASP.NET Core applications as
server-owned HTML feature modules. The design goal is for a page to be useful
before any managed browser runtime starts. When local browser behavior is
genuinely valuable, a future supported capability loader should activate only
the relevant C# capability, independently of the initial page.

The name **Weft** is a working identity: a weft is the thread woven across a
fabric. Here, server routes, HTML templates, styles, and optional browser
capabilities form one vertical feature rather than unrelated frontend and
backend layers. Before publishing packages or using the brand commercially, the
name needs normal GitHub, NuGet, domain, and trademark checks.

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
| Local C# capability | Offline work, repeated calculations, rich long-lived interaction | Lazy managed runtime plus the selected capability |

The intended outcome is not “Next.js written in C#,” nor a replacement for all
frontend frameworks. It is a C#-native feature contract with a measurable rule:
**do not start a managed browser runtime until a declared capability needs it.**

## Intended developer experience

The final API is not designed yet. This illustrates the direction:

```csharp
[WebFeature("orders")]
[Route("/orders")]
[ClientCapability("orders-edit", Load = Lazy, Budget = "160 KB br")]
public sealed partial class OrdersFeature
{
}
```

The feature owns its server companion, templates, styles, fallback behavior,
and optional browser capability:

```html
<form method="post" action="/orders/save" c-target="#save-result">
  <label>
    Note
    <input name="note">
  </label>
  <button type="submit">Save</button>
</form>

<button type="button" c-onclick="Orders.EditOffline">
  Edit offline
</button>
```

Without enhancement, the form is ordinary HTML. A server-action enhancement can
keep the page in place and replace a declared region. The offline action is
where loading browser C# may be worth its cost.

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

The repository deliberately distinguishes **scenario specifications** from
runnable samples. The folders exist now to keep the example contracts visible;
they will become runnable only as the core platform reaches the required
milestones.

| Example | Styling approach | What it must prove | Status |
| --- | --- | --- | --- |
| [starter-html](examples/starter-html) | Plain CSS | Useful server HTML with no Node and no browser .NET runtime | Planned |
| [tailwind-orders](examples/tailwind-orders) | Tailwind CSS | Templates are included in Tailwind content scanning without shipping Tailwind runtime JS | Planned |
| [bootstrap-admin](examples/bootstrap-admin) | Bootstrap CSS | Normal forms and responsive admin UI; Bootstrap JS loaded only when explicitly needed | Planned |
| [pico-portal](examples/pico-portal) | Pico CSS | A lightweight, CSS-first portal with minimal tooling | Planned |

See [docs/examples.md](docs/examples.md) for the acceptance criteria. Until the
first implementation milestone is complete, there is intentionally no
misleading `dotnet run` command in this repository.

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

The first real deliverable is a generated feature manifest—not a gallery of
templates or a large component library.

1. Define and generate the feature/module manifest.
2. Build the HTML and enhanced-server-action execution modes with graceful
   fallback.
3. Add browser/server boundary validation, typed transport, and generated
   dispatch.
4. Establish a supported lazy capability loader and capability chunk planner.
5. Add payload budgets, cache diagnostics, and the runnable example suite.

The detailed sequence is in [docs/roadmap.md](docs/roadmap.md).

## Repository layout

```text
src/          Future framework packages and source generator
examples/     Scenario specifications that become runnable samples
prototypes/   Isolated experiments; no prototype API is a compatibility promise
docs/         Architecture decisions, package policy, example contracts, roadmap
```

## Contributing

This repository is at the architecture-and-prototype stage. Design feedback is
welcome, but code contributions and reuse terms are deferred until the owner
selects a public license. The intended contribution principles are in
[CONTRIBUTING.md](CONTRIBUTING.md).

## License

A public license has not yet been selected. Do not assume reuse rights or
submit code contributions until the repository owner chooses and adds one.
