# Architecture

## Product boundary

Weft is an ASP.NET Core-oriented platform for HTML-first feature modules. The
server is the authority. The browser receives rendered HTML and only gains
additional behavior when a feature explicitly declares it.

The core unit is a vertical feature module, not a visual component:

```text
Orders feature
├── Server module
│   ├── DI registration
│   ├── routes and authorization
│   └── application/data services
├── Presentation
│   ├── HTML templates
│   ├── CSS/assets
│   └── ordinary form/link fallback
├── Optional enhancement
│   └── generic busy/fetch/replace-region behavior
└── Optional local capability
    ├── browser-safe C# code
    ├── generated typed endpoint client
    └── lazy capability asset group
```

## Current server foundation

The first implementation intentionally covers only the server-first base:

- `Weft.Abstractions` defines feature, route, and action metadata;
- `Weft.Generator` emits a `Manifest` property into each valid partial feature
  class;
- `Weft.Server` accepts only manifests explicitly selected by the host;
- `AddWeft(...)` rejects duplicate declared feature IDs, route metadata, and
  endpoint names before the application is built;
- `MapWeft()` invokes each selected module in deterministic feature-ID order.

The manifest factory is generated as a direct `new FeatureType()` call. There
is no runtime assembly scan and no reflection-based endpoint dispatch.

During mapping, Weft compares the feature's declared method, route, and endpoint
name metadata against the actual endpoints newly added by that feature. A
mismatch fails application startup rather than silently weakening duplicate-route
validation. In this first implementation, call `MapWeft()` before adding
host-owned endpoints so each feature's endpoint set can be isolated reliably.

The starter's template renderer and embedded CSS are intentionally
example-private. A general template language, transitive package asset
deployment, content hashes, and an asset manifest remain future work.

## Execution placement

An interaction has one declared placement. It must not accidentally become
browser C# merely because it appears in an interactive area of a page.

### 1. HTML action

The browser navigates or submits a form. The server validates, authorizes, and
returns a document or a fragment.

This is the default for workflows, saves, destructive actions, and
navigation. It has the strongest fallback and the smallest browser payload.

### 2. Enhanced server action

A small, framework-owned kernel can show busy state, issue a fetch request, and
replace an explicitly declared DOM region. Application behavior still lives in
the server module; the kernel must not become a general application JavaScript
runtime.

The contract must be explicit before this mode is implemented:

- the form or link method and URL remain the canonical non-enhanced behavior;
- full-document and fragment responses use explicit content negotiation;
- anti-forgery/CSRF rules apply to enhanced mutations exactly as they do to
  normal form submissions;
- authentication/login redirects, validation errors, and server failures have
  defined document/fragment behavior;
- replacement defines focus handling, history behavior, and accessible live
  updates where needed;
- requests are cancellable, and a cancelled response must not overwrite newer
  content.

### 3. Local C# capability

The intended future browser downloads a declared C# capability and, when
necessary, its managed runtime dependencies. This remains a prototype
hypothesis until Weft owns a supported loader. The mode is for cases where
execution must remain local or is repeated long enough to amortize the initial
cost: offline editing, complex calculation, rich sustained interaction, or a
long-running local workflow.

## Generated manifest

The current generator produces one manifest per feature class. It validates the
feature shape, its identifier, constructor convention, and its class-level
route/action metadata. The host explicitly passes the generated manifests it
trusts to `AddWeft(...)`.

The future platform should expand that into a broader manifest joining server
registration, templates, actions, assets, and browser dispatch.

Expected generated responsibilities:

- register trusted server modules and dependency injection services;
- map routes and detect duplicate feature IDs, routes, and action names;
- deploy templates and styles as private feature assets;
- map HTML actions to their execution mode;
- generate typed server-to-browser contracts and serialization contexts;
- produce content-hashed asset URLs and capability dependency groups;
- validate browser/server project references and invalid APIs;
- report initial, first-action, warm-cache, and retained-payload budgets.

The generator cannot infer arbitrary routes inside imperative `MapEndpoints`
code, but runtime validation makes the route declaration authoritative for the
currently mapped endpoint set. Deeper compile-time endpoint analysis is a later
generator milestone. Action metadata is descriptive in this slice; only the
ordinary `Html` execution mode exists today. Weft will not scan every DLL
found on a server.

## Rendering and DOM ownership

HTML is the durable UI contract. Weft should update explicitly declared regions
of the DOM rather than take ownership of the whole page with a virtual DOM.

This gives the application normal browser semantics:

- URLs and browser history remain ordinary;
- forms can post without enhancement;
- content is available before a capability loads;
- accessibility and copy/paste work on the base document;
- a failed client capability degrades to documented server behavior.

## Capability chunking

Chunk by user journey or capability, not one bundle per small visual component.
Good examples are:

- `orders-read`
- `orders-edit`
- `reporting-charting`
- `admin-import`

The build should identify shared dependencies, cache immutable content-hashed
assets, allow cautious idle prefetching, and flag a small capability that
accidentally imports an expensive dependency.

## Browser boundary

“Full .NET” belongs on the server. Browser projects need an enforced safe
profile. They cannot access server secrets, arbitrary file systems, processes,
databases, or privileged server APIs. The server remains responsible for
authorization and validation even when a browser capability has a typed
endpoint client.

## Explicit non-goals

- A C# syntax that browsers execute without compilation.
- Automatic conversion of arbitrary server .NET code into safe browser code.
- A framework-specific replacement for all JavaScript packages.
- A hidden RPC layer that makes authentication, validation, caching, errors,
  cancellation, and network cost invisible.
- A marketing claim that WebAssembly or managed memory makes browser tabs
  immune to memory pressure.
