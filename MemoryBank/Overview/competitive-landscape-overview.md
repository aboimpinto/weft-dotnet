# Weft Competitive Landscape Overview

## Scope and evidence boundary

FEAT-001 compared Blazor, Next.js App Router, TanStack Start and named supporting
packages, Angular, Current Weft, and the Target Weft Hypothesis across 24 common
dimensions. Capability claims were based primarily on official documentation
and Current Weft source at commit
`ca5bacedfa7241be6071b09ad44d8d62948c7426`.

This is a dated research conclusion, not a universal framework ranking. No
comparable cross-platform application or benchmark result exists yet.

## Executive conclusion

The market already has capable C# web frameworks. Weft is not justified by C#
alone and should not claim that Blazor cannot serve modern web applications.
Its opportunity is the narrower combination of:

- vertical business-feature packages as the primary ownership unit;
- useful server HTML and ordinary HTTP without a mandatory client runtime;
- stateless enhancement for common smooth interactions;
- browser C# activated only for a sustained-local capability that earns its
  download, startup, and memory cost;
- bounded JavaScript interoperability instead of ecosystem isolation; and
- explicit dependency, payload, fallback, and execution-placement reporting.

Weft must make this combination simpler, safer, and more measurable than
assembling equivalent conventions on ASP.NET Core or Blazor. Otherwise, teams
should use the established platform.

## Platform findings

### Blazor

Blazor is the decisive .NET comparator and the mature choice today. It supports
Static SSR, Interactive Server, Interactive WebAssembly, Interactive Auto,
Razor components and libraries, forms, security integration, enhanced
navigation, JavaScript interop, and established .NET hosting.

Weft should adopt C# contracts, ASP.NET Core security, useful initial HTML, and
supported interop. It should differentiate through vertical feature ownership,
stateless HTTP enhancement, explicit host trust, and capability-level browser
activation—not by pretending Blazor is WebAssembly-only.

### Next.js App Router

Next.js demonstrates a strong integrated baseline for route layouts and states,
server/client placement, streaming, cache invalidation, development feedback,
testing integrations, asset handling, and deployment workflows.

Weft should adapt the user outcomes—coherent route states, loading/error
boundaries, source-mapped diagnostics, and explicit invalidation—without
copying React component boundaries or making Node and a client application
architecture mandatory.

### TanStack Start family

TanStack's strongest lessons are typed routing and search state, composable
loaders and server-state tools, and headless ownership of markup and design.
Its trade-off is integration ownership across packages and maturity levels.

Weft should adopt generated typed routes and headless contracts while providing
a coherent default path. Optional cache or browser-state capabilities should be
an explicit escalation, not an overlapping collection of hidden state models.

### Angular

Angular provides a cohesive CLI, integrated components/DI/router/forms,
security guidance, release policy, and team-scale conventions. Its breadth,
multiple paradigms, client runtime, Node toolchain, and regular upgrade cadence
are real costs for teams and routes that need only server-owned HTML.

Weft should adopt cohesive tooling, secure defaults, and compatibility policy,
while using progressive disclosure: HTML and HTTP first, enhancement second,
and local browser capability only where justified.

### Current and target Weft

Current Weft proves a small server foundation only. Its strengths are explicit
generated manifests, host-selected trust, deterministic registration, route
metadata validation, and a normal antiforgery-protected HTML form path.

The target adds templates, typed routes/actions, enhanced actions, browser C#,
assets, JavaScript adapters, CLI tooling, security/accessibility contracts,
operations, and compatibility policy. These remain proposals or hypotheses
until implemented and tested.

## Cross-platform decisions

### Adopt or adapt

- durable HTML and ordinary URL/form semantics;
- typed routing, search state, actions, and validation;
- safe template/layout/error/loading composition;
- ASP.NET Core authentication, authorization, antiforgery, and diagnostics;
- cohesive scaffolding, hot feedback, and migration policy;
- explicit cache/invalidation behavior;
- headless ownership of product markup and visual design;
- bounded JavaScript adapters; and
- deterministic assets, deployment, and observability.

### Avoid or mitigate

- persistent server UI circuits as the default enhancement model;
- browser runtime cost on routes that do not need it;
- implicit caching and stale-state behavior;
- raw string template conventions;
- mandatory Node/npm for pure .NET projects;
- unbounded package or deployment adapter matrices;
- target behavior presented as current capability; and
- unsupported performance or security superiority claims.

### Explicit non-goals

- prohibiting all JavaScript;
- cloning the npm ecosystem or creating a JavaScript registry;
- owning an application visual design system;
- requiring browser .NET or a persistent circuit on every route; and
- claiming universal superiority over Blazor or Node platforms.

## Evidence limitations and refresh rule

The matrix is structurally complete, but the 2026-07-20 recheck found that some
source-ledger rows bundle more claims than their cited page directly supports.
Those rows need to be split or backed by more specific sources before external
publication.

The 2026-07-15 package snapshot was valid on that date. By 2026-07-20 Angular
had moved from 22.0.6 to 22.0.7 and `@tanstack/react-start` from 1.168.28 to
1.168.32. Patch drift does not by itself overturn the conclusions, but exact
versions and relevant behavior must be refreshed for a new snapshot.

## Adjacent topics not fully investigated

The 24-dimension rubric did not explicitly classify localization/RTL/time
zones, real-time push beyond Blazor circuits, file upload/download workflows,
background jobs/queues, multi-tenancy, or database migration strategy. Before
calling the alternative-readiness baseline complete, the owner should decide
whether each is:

1. required for the target business-application class;
2. inherited from ASP.NET Core/application infrastructure;
3. deferred to an optional package; or
4. an explicit non-goal.

## Detailed evidence

- [Framework comparison](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/framework-comparison-report.md)
- [Praised qualities and pains](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/praised-qualities-and-pains.md)
- [Research recheck](feat-001-research-recheck-overview.md)
