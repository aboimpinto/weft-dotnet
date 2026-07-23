# FEAT-001: Framework Comparison And Weft Alternative Requirements

**Feature ID**: FEAT-001
**Parent Epic**: EPIC-001
**Status**: Manual Review Ready With Findings
**Priority**: P0
**Work Type**: R&D / Documentation Spike
**Execution Mode**: Manual investigation in the active agent conversation;
do not continue this item through Hepha's development workflow

## Summary

Research Blazor, Next.js, TanStack Start, Angular, and Weft using one evidence
rubric and one reference-application contract. Produce a side-by-side capability
matrix, a praised-quality and pain catalog, a benchmark plan, and a ranked list
of what Weft must provide to be considered a credible alternative while
avoiding unnecessary complexity inherited from those platforms.

## User Story

As the Weft product owner, I want an evidence-backed comparison of established
web platforms so that Weft adopts capabilities developers value, avoids known
pain where its architecture permits, and implements the complete baseline
needed for teams to consider it a real alternative.

## Why This Research Comes First

The current Weft server foundation is too early for a fair implementation-level
comparison. The next architectural work should not be selected from intuition
alone. This feature creates the decision framework and shared workload that
future spikes and implementation features will use.

The intended conclusion is not predetermined. The research may determine that
Blazor or another platform already solves a category well enough that Weft
should interoperate, reuse supported infrastructure, or declare the category a
non-goal.

## Manual Research Execution

Hepha generated the first Phase 0–8 skeleton before this work was reclassified.
The phase files have now been renamed and rewritten around these research
responsibilities:

| Research phase | Responsibility |
| --- | --- |
| Phase 0 — Research Baseline | Repository baseline, current-versus-target boundary, and research risks |
| Phase 1 — Research Methodology and Evidence Contract | Evidence schema, version policy, comparison contract, and acceptance traceability |
| Phase 2 — Framework Capability Profiles | Source acquisition and 24-dimension framework capability matrix |
| Phase 3 — Praised Qualities and Pain Analysis | Praised qualities, recurring pains, workarounds, and Weft responses |
| Phase 4 — Reference Application Contract | Framework-neutral reference business application contract |
| Phase 5 — Browser Experience and Accessibility Criteria | Browser-visible, accessibility, and visual acceptance contract for the reference app |
| Phase 6 — Weft Requirements and Decision Synthesis | Benchmark methodology, ranked Weft requirements, and gap/decision backlog |
| Phase 7 — Evidence Audit and Overview Update | Cross-document evidence, terminology, and acceptance audit |
| Phase 8 — Research Closure and Follow-up | Owner-ready synthesis, unresolved questions, and follow-up classification |

Any remaining Hepha task-state sections are explicitly marked as historical
records. From this decision onward, phase work and evidence are written
manually in this conversation. No development prompts, code implementation
phases, or automatic lifecycle continuation apply.

## Mandatory Platforms And Scope

### Blazor

Evaluate the current supported Blazor Web App model, including:

- Static Server rendering;
- Interactive Server and its circuit/state model;
- Interactive WebAssembly;
- Interactive Auto;
- enhanced navigation and form handling;
- Razor components and Razor Class Libraries;
- routing, forms, validation, authentication, authorization, and JS interop;
- build, publish, lazy loading, diagnostics, testing, and deployment.

Do not reduce Blazor to WebAssembly-only behaviour.

### Next.js

Evaluate the current stable App Router model, including:

- file-system routing, layouts, loading, and error boundaries;
- React Server and Client Components;
- Server Functions/Actions, mutations, streaming, caching, and revalidation;
- asset/image/font handling and code splitting;
- local development, diagnostics, testing, deployment adapters, and hosting
  assumptions;
- client dependency and hydration boundaries.

### TanStack

TanStack is a family of tools rather than one framework. Use **TanStack Start**
as the full-stack framework under comparison and assess Router, Query, Form,
Table, and relevant ecosystem packages as supporting capabilities. Record the
maturity/stability status of each evaluated package.

Evaluate:

- typed routing and URL/search state;
- loaders, prefetching, caching, invalidation, and mutations;
- SSR, streaming, server functions, server routes, and deployment output;
- framework composition versus integrated defaults;
- type safety, developer tooling, package/toolchain footprint, and operational
  maturity.

### Angular

Evaluate the current stable Angular platform, including:

- components, templates, signals/reactivity, and dependency injection;
- router, guards, data resolution, and lazy loading;
- forms and validation approaches;
- SSR, SSG, hydration, and client rendering;
- CLI, schematics, hot reload, DevTools, testing, build, and deployment;
- framework breadth, upgrade/migration posture, bundle/dependency costs, and
  team-scale conventions.

### Weft

Evaluate Weft twice:

1. **Current evidence** — only what the repository implements and tests today.
2. **Target hypothesis** — planned HTML actions, enhanced server actions,
   browser C# capabilities, assets, dependency policy, JavaScript bridges, and
   developer experience.

Never record a target hypothesis as an implemented capability.

### Supplemental References

Astro, HTMX, Phoenix LiveView, Laravel Livewire, SvelteKit, Remix/React Router,
Razor Pages/MVC, Uno Platform, OpenSilver, DotVVM, Wisej.NET, or WebSharper may
be used when they provide direct evidence for a specific design problem. They
must not expand the mandatory matrix unless the scope is explicitly revised.

## Evidence Policy

Every material entry must include a URL or repository reference, evaluated
version, access date, evidence type, and confidence.

Use this source order:

| Grade | Evidence |
| --- | --- |
| A | Official documentation, source code, specifications, release notes, or reproducible first-party benchmark |
| B | Maintainer issue/discussion, migration guide, security advisory, or documented design limitation |
| C | Reproducible independent benchmark, case study, postmortem, or widely corroborated technical analysis |
| D | Individual report, forum comment, or unverified anecdote; useful only as a lead |

Rules:

- Platform capabilities require Grade A evidence.
- A pain must identify its trigger, affected workload/team, consequence,
  available workaround, severity, and confidence.
- Grade D evidence cannot establish a requirement without corroboration.
- Separate framework pain from language, package ecosystem, hosting provider,
  application design, and team-practice pain.
- Record praised qualities with the same care as complaints; popularity alone
  is not evidence of why a mechanism works.
- Label each conclusion as Fact, Reproduced Observation, Inference,
  Hypothesis, or Prediction.

## Required Comparison Matrix

Compare every mandatory platform across the same dimensions:

1. Product boundary, target applications, and central mental model.
2. Project structure, modularity, ownership, and package boundaries.
3. Language model and server/client type sharing.
4. Rendering modes, streaming, hydration, and execution placement.
5. Components, templates, layouts, CSS isolation, and DOM ownership.
6. Routing, URL/search state, navigation, history, and route guards.
7. Data loading, caching, invalidation, mutations, and cancellation.
8. Forms, binding, validation, errors, antiforgery, and fallback behaviour.
9. Local/browser state, reactivity, concurrency, and optimistic updates.
10. Server endpoints, server actions/functions, transport, and serialization.
11. Authentication, authorization, secrets, and security defaults.
12. Accessibility, SEO, progressive enhancement, and failure behaviour.
13. Offline/local execution and progressive-web-app support.
14. JavaScript and third-party component interoperability.
15. Package management, lockfiles, supply chain, install scripts, and disk use.
16. CSS, images, fonts, static assets, bundling, and content hashing.
17. Lazy loading, code splitting, prefetch, and payload visibility.
18. CLI/scaffolding, local startup, hot reload, diagnostics, and DevTools.
19. Unit, component, integration, browser, and accessibility testing.
20. Build, publish, deployment targets, serverless/edge assumptions, and
    operational portability.
21. Logging, tracing, metrics, error reporting, and production diagnostics.
22. Versioning, migrations, compatibility, ecosystem maturity, and governance.
23. Team-scale maintainability, learning curve, and common failure modes.
24. Initial, first-interaction, warm-cache, memory, and connection costs.

## Praised Qualities And Pain Analysis

For every platform, collect:

- the capabilities developers repeatedly praise and the user problem they
  solve;
- the pains developers repeatedly encounter and the conditions that trigger
  them;
- whether the pain is essential complexity, an implementation limitation, a
  default that can be changed, or an ecosystem/tooling consequence;
- the standard workaround and the new cost introduced by that workaround;
- whether Weft should Adopt, Adapt, Interoperate, Defer, or Reject the praised
  mechanism;
- whether Weft should Avoid, Mitigate, Accept, or mark each pain Not Applicable.

Do not use a single numeric “winner” score. A decision matrix may use ratings
only when the rating definition and evidence are visible.

## Shared Reference Application Specification

Define, but do not yet implement in every framework, one inspectable business
application that exercises equivalent capabilities:

- public list, detail, search, filtering, sorting, and pagination;
- shared and nested layouts with metadata and error/not-found states;
- authenticated administration area with role-protected operations;
- create/edit form with server and client validation, antiforgery protection,
  validation errors, cancellation, and post-success navigation;
- data loading, mutation, cache invalidation, slow response, retry, and stale
  response handling;
- one smooth server-owned partial update;
- one sustained local interaction that can justify browser execution;
- one third-party JavaScript component integrated behind a bounded adapter;
- feature-owned CSS, image/font/static assets, and production hashing;
- unit, integration, browser, accessibility, and security-focused tests;
- deployment instructions and observable production health.

The specification must define the same seeded data, user journeys, failure
fixtures, security assumptions, and visual acceptance criteria for every
implementation.

## Benchmark And Measurement Plan

Define reproducible cold and warm measurements using pinned runtime/framework
versions, identical hardware, comparable production configuration, and the same
database/network fixtures.

At minimum measure:

- clean checkout size excluding VCS metadata;
- dependency cache size and project-local dependency footprint;
- dependency file count and direct/transitive dependency count;
- clean restore/install time and warm restore/install time;
- development server startup and first successful edit feedback;
- production build time and output size;
- initial request count, transferred/compressed bytes, and executable code;
- time to first byte, useful HTML, and interactive readiness;
- first and warm repeated action latency;
- server throughput, tail latency, CPU, and memory for defined workloads;
- per-user server connection/state cost where applicable;
- browser memory before and after rich capability activation;
- slow-network, offline, cancellation, and failed-asset behaviour;
- accessibility audit results and security-control verification.

Numbers from different vendors or unrelated benchmarks may inform hypotheses
but cannot populate the final side-by-side result.

## Initial Weft Requirement Hypotheses

The research must validate, refine, rank, or reject this initial list.

### Developer experience

- One-command project and feature scaffolding with no mandatory Node install.
- Fast local startup, C# and template hot reload, actionable compile/startup
  diagnostics, and browser debugging.
- A documented project structure that scales from one application to many
  independently packaged features.
- First-class IDE/editor completion, navigation, refactoring, and generated-code
  visibility.
- Upgrade, migration, compatibility, and deprecation tooling.

### Feature and UI composition

- A vertical feature contract joining DI, routes, authorization metadata,
  actions, templates, styles, assets, fallback, tests, and optional capabilities.
- Reusable layouts, templates, UI composition, error boundaries, loading states,
  metadata, and not-found handling.
- Clear DOM ownership rules and safe integration boundaries.
- Feature-local styles/assets without accidental global collisions.
- A reusable package model that works through NuGet.

### Routing, data, forms, and state

- Typed routing, route parameters, query/search state, nested layouts, and normal
  browser history.
- Typed server actions/endpoints with explicit serialization, cancellation,
  validation, authentication, authorization, and error contracts.
- Server data loading plus an optional coherent client cache/invalidation model
  where sustained local interaction requires it.
- Accessible forms with server-authoritative validation, antiforgery, field and
  summary errors, upload support, and normal HTTP fallback.
- Defined concurrency, stale-response, optimistic-update, retry, and duplicate
  submission behaviour.

### Execution and performance

- HTML-only routes that send no JavaScript and start no managed browser runtime.
- Optional stateless enhanced server actions with navigation, focus,
  accessibility, cancellation, and failure semantics.
- Supported browser-safe C# capabilities loaded by user journey rather than for
  the entire application.
- Route/capability code splitting, content hashes, shared dependency planning,
  cache policy, and cautious prefetch.
- Build-visible initial, first-action, warm-cache, retained-memory, request, and
  dependency budgets.

### JavaScript and dependency interoperability

- Typed, lazy, disposable JavaScript bridges with explicit DOM/API ownership.
- Pure .NET and direct-asset modes with no `node_modules`.
- Global content-addressed caches, deterministic locks, integrity verification,
  provenance, license reporting, and no undeclared install scripts.
- npm-compatible restoration only when selected assets genuinely require it;
  publish final assets rather than a package-manager layout.

### Security, accessibility, and reliability

- Secure-by-default encoding, antiforgery, headers, cookies, transport, secret,
  upload, redirect, and authorization guidance.
- A threat model covering server features, templates, enhanced actions, assets,
  browser C#, and JavaScript bridges.
- Accessibility-first HTML, focus/history/live-region behaviour, keyboard
  operation, and automated/manual verification guidance.
- Useful operation when enhancement or a local capability fails, where the
  workflow permits a fallback.
- Rate limiting, structured logging, traces, metrics, health checks, and
  production error diagnostics.

### Testing, build, and deployment

- Unit, generator, integration, browser, accessibility, security, fallback, and
  performance test support.
- Deterministic build/publish output with an inspectable feature/asset manifest.
- Straightforward container, reverse-proxy, cloud, and self-hosted deployment
  without binding the architecture to one vendor.
- Reproducible production configuration and diagnostics for cache, compression,
  assets, capabilities, and dependency provenance.

## Deliverables

Create the following in this feature folder during investigation:

1. `framework-comparison-report.md` — source-linked side-by-side matrix.
2. `praised-qualities-and-pains.md` — evidence, trigger, workaround, severity,
   confidence, and Weft response.
3. `reference-application-spec.md` — equivalent workload and journeys.
4. `benchmark-methodology.md` — environment, commands, metrics, and reporting
   format.
5. `weft-alternative-requirements.md` — ranked Must/Should/Could/Won't catalog
   with measurable acceptance conditions.
6. `weft-gap-and-decision-backlog.md` — current gaps, contradictions, Adopt/
   Adapt/Interoperate/Defer/Reject decisions, and proposed follow-up features.
7. Updates to `MemoryBank/Overview/technical-overview.md` reflecting approved
   conclusions and clearly separating evidence from prediction.
8. `developer-errors-and-native-shell-integration.md` — Development-only error
   overlay and production-safe failure contract; Electron, Tauri, Electrobun,
   Capacitor, and framework-neutral native WebView shell integration modes.
9. `installation-and-bootstrap-strategy.md` — official-platform installation
   comparison and proposed Weft bootstrap, local-tool, profile, restore,
   update, offline/mirror, security, and removal lifecycle.
10. `research-recheck-2026-07-20.md` plus `MemoryBank/Overview/README.md` and its
    linked topic documents — independent structural/semantic/source/code
    recheck and durable Overview handoff with findings and closure conditions.

## Acceptance Criteria

- [x] All five mandatory platform entries record evaluated version/status,
  access date, deployment mode, and primary official sources.
- [x] All 24 comparison dimensions contain evidence or an explicit “not
  applicable/not yet implemented” result for every mandatory platform.
- [x] Each platform has at least five material praised qualities and five
  material pains; weakly evidenced items are labelled rather than promoted to
  conclusions.
- [x] TanStack Start is compared as the framework and supporting TanStack
  packages are not misrepresented as one monolithic product.
- [x] Current Weft capability is visibly separated from target Weft hypothesis.
- [x] The reference application and benchmark plan are detailed enough for
  separate agents or developers to create equivalent implementations without
  inventing different requirements.
- [x] Requirements are ranked Must/Should/Could/Won't, deduplicated, and mapped
  to evidence, avoided pain, measurable acceptance, and roadmap phase.
- [x] Every competitor mechanism receives an explicit Weft decision; “copy it”
  without architectural rationale is not accepted.
- [x] Dependency analysis includes project-local disk use, cache reuse,
  lockfiles, transitive graph, lifecycle scripts, provenance, license, and
  published output—not only `node_modules` size.
- [x] Performance conclusions use comparable reproduced measurements or remain
  labelled hypotheses.
- [x] Security and accessibility are evaluated as first-class platform
  capabilities, not deferred footnotes.
- [x] The technical overview is updated and any proposed changes to public
  architecture, package policy, or roadmap documents are listed for owner
  approval.
- [ ] Follow-up FEAT candidates are bounded and traceable to approved Must or
  Should requirements.
- [x] The developer-error contract maps .NET/generated/template failures to
  useful Development source context while proving that Production output does
  not expose stack traces, source paths, code frames, editor links, or secrets.
- [x] Native-shell research distinguishes desktop-only and mobile-capable
  tools, server-hosted/static/sidecar modes, native bridge security, lifecycle,
  and the current limitation that Weft SSR is not directly bundleable as a
  local mobile frontend.
- [x] Installation research distinguishes framework bootstrap from project
  creation and dependency restore, compares official platform flows, and
  specifies a verified `wget`/PowerShell bootstrap plus pinned local .NET tool,
  pure-mode prerequisite, optional-profile, CI/offline, update, and removal
  contract without presenting proposed commands as implemented.

## Out Of Scope

- Implementing the full reference application in all frameworks.
- Implementing new Weft runtime, rendering, asset, CLI, or browser capability
  mechanisms.
- Publishing competitive performance or security claims before reproducible
  evidence exists.
- Replacing NuGet or creating a new JavaScript package registry.
- Expanding the mandatory matrix to every web framework encountered.
- Selecting a final public brand or commercial licensing model.

## Initial Primary Sources

- [Blazor fundamentals](https://learn.microsoft.com/aspnet/core/blazor/fundamentals/?view=aspnetcore-10.0)
- [Blazor render modes](https://learn.microsoft.com/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0)
- [Next.js App Router](https://nextjs.org/docs/app)
- [Next.js Server and Client Components](https://nextjs.org/docs/app/getting-started/server-and-client-components)
- [TanStack Start](https://tanstack.com/start/v0)
- [Angular overview](https://angular.dev/overview)
- [Angular routing](https://angular.dev/guide/routing)
- [Angular forms](https://angular.dev/guide/forms)
- [Weft technical overview](../../../Overview/technical-overview.md)
- [Weft architecture](../../../../docs/architecture.md)
- [Weft roadmap](../../../../docs/roadmap.md)
- [Weft package ecosystem](../../../../docs/package-ecosystem.md)

## Historical Hepha Research Decisions

Recorded: 2026-07-15T07:05:46.181Z

Hepha applied these saved Deep-Dive answers directly because the full-document model rewrite did not finish.
Fallback reason: Source document is 18260 characters; deterministic update is used above 12000 characters.

### Research delivery scope

Question: What is the first research milestone before requirements are ranked?

Decision: **Evidence baseline** - Complete official-source matrix and current-Weft evidence first; defer reproduced implementations and measurements.

### Weft product boundary

Question: How should the research treat capabilities that existing platforms already provide well?

Decision: **Decision by evidence** - For each mechanism, explicitly choose Adopt, Adapt, Interoperate, Defer, or Reject based on evidence and Weft architecture.

### Benchmark commitment

Question: What level of reproduced measurement is required before performance requirements enter the Must/Should backlog?

Decision: **Comparable benchmark gate** - Rank performance requirements only after reproducible, like-for-like measurements using the shared workload and pinned environments.
