# Package ecosystem

## Decision

Weft is **NuGet-first and npm-compatible**.

NuGet is the primary distribution mechanism for framework packages, feature
modules, server integrations, source generators, browser C# capabilities, and
typed contracts. npm-compatible tooling is an optional build-time source of
frontend assets and JavaScript bridges.

Weft will not create a new package registry or try to replace npm.

## Why this split

The application model is C# and ASP.NET Core, so its core packages belong in
the .NET ecosystem. At the same time, the web ecosystem contains mature assets
and libraries that should remain available to a Weft application:

| Need | Preferred source | Examples |
| --- | --- | --- |
| Server feature or framework extension | NuGet | routes, DI, authentication integrations |
| Browser C# capability | NuGet | offline editor, local calculator |
| CSS framework or icon set | Optional npm-compatible source | Tailwind CSS, Bootstrap, Pico CSS |
| Optional JavaScript bridge | Optional npm-compatible source | Chart.js, Monaco, Leaflet |
| Application static asset | Local project/feature asset | feature CSS, images, fonts |

The user should not have to install Node to build a pure server-HTML Weft
application.

## Project modes

### Pure .NET mode

The project restores NuGet packages and publishes its own templates and static
assets. No Node installation or package-lock file is required.

### Interop mode

The project also restores frontend dependencies. Weft should recommend pnpm for
new projects because it is efficient and explicit, while respecting an existing
`package-lock.json` when a team already uses npm.

An interop project declares one authoritative frontend package manager and
commits its corresponding lockfile. Restore must fail when that lockfile is
missing, stale, or ambiguous; Weft must not guess between multiple lockfiles.

Node tooling runs only during development/build. The browser receives final,
content-hashed assets—not `node_modules`.

### Existing frontend mode

A team with an established npm pipeline can retain it. Weft owns its server
feature modules and declared asset integration without requiring the team to
rewrite its broader frontend workflow. The project still names one
authoritative lockfile for assets that Weft publishes.

## Asset manifest

The future build pipeline will collect trusted assets from feature packages,
application assets, and optional frontend packages into a deployment manifest.
The manifest should contain:

- logical asset and capability names;
- content-hashed URLs;
- dependency relationships and lazy-load groups;
- MIME type and integrity data;
- asset size and compressed-size budget data;
- provenance: local feature, NuGet package, or npm package.

The server uses the manifest to emit only assets needed by a route or a
requested capability. A browser must not download a package manager layout or
an application-wide JavaScript bundle merely because one feature uses npm.

## CSS framework policy

### Tailwind CSS

Tailwind is a build-time integration. Its content scanner must include feature
HTML templates and any supported generated markup. The Tailwind example will
prove this with a reproducible config and a locked dependency graph.

### Bootstrap

Bootstrap CSS may be included as a build asset. Bootstrap JavaScript is not a
global default: a feature declares it only if it uses a Bootstrap behavior
that truly requires it.

### Lightweight CSS frameworks

Pico CSS and similar CSS-first libraries should work without browser
JavaScript. These are valuable demonstrations of the HTML-first model.

## JavaScript bridges

Some browser libraries are useful and do not need a C# reimplementation. A
feature may declare a small typed bridge to a JavaScript library. The bridge
must be:

- explicit in the feature manifest;
- lazily loaded with the capability that needs it;
- version-pinned through the project lockfile;
- bounded to a documented DOM/API contract;
- unloadable or disposable where the browser/runtime supports it.

A JavaScript bridge is an interoperability boundary, not permission to put
application behavior in a global JavaScript application.

## Supply-chain rules

Before the integration is considered stable, the platform must support:

- committed and verified NuGet and frontend lockfiles;
- package provenance and version visibility in build output;
- integrity hashes for deployed assets;
- vulnerability/audit hooks supplied by the selected ecosystem tools;
- allow/deny policy hooks for organisations;
- package-size and transitive-dependency budget reporting.

## Deliberate deferrals

The following are not implemented by this document:

- a `weft add` command;
- a custom JavaScript package manager;
- runtime downloading of arbitrary npm packages from the browser;
- a promise that all npm packages can be used safely without a bridge.
