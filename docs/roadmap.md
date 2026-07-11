# Roadmap

This is a technical sequence, not a release-date commitment. Each stage must
leave the HTML-first path usable and measurable.

## Phase 0 — Foundation and reference criteria

Current focus:

- capture the product boundary and package policy;
- preserve the experimental status of existing ideas;
- define the example and payload-measurement contracts;
- choose the final public name, repository slug, license, and support policy.

## Phase 1 — Generated feature manifest

Build the source-generated core that replaces manual module lists, string
dispatch, and reflection-based routing.

Success means:

- explicit trusted feature registration;
- generated route and DI catalog;
- duplicate feature/route/action diagnostics;
- deployment list for feature templates and styles;
- generated action-to-execution-mode map.

## Phase 2 — Server HTML and enhanced server actions

Deliver the two modes that do not require browser .NET:

- server-rendered page/fragment composition;
- normal links and forms as the baseline;
- optional generic busy/fetch/replace-region enhancement;
- CSRF, validation, authorization, errors, cancellation, and navigation
  semantics documented and tested.

The `starter-html` example becomes runnable here.

## Phase 3 — Typed browser boundary

Introduce browser-safe feature projects and generated typed contracts:

- supported browser project profile;
- compile-time server/browser reference validation;
- source-generated JSON serialization;
- cancellation and error contracts;
- typed browser dispatch without reflection.

## Phase 4 — Supported lazy capability loading

Replace prototype-only mechanisms with a supported loader and a capability
graph:

- content-hashed capability asset groups;
- shared runtime/dependency accounting;
- cold and warm activation diagnostics;
- cautious prefetch policy;
- runtime memory and disposal observability.

The `lazy-capability-lab` example becomes runnable here.

## Phase 5 — Asset pipeline and ecosystem integrations

Add optional npm-compatible integration, first for CSS and then for declared
JavaScript bridges:

- NuGet feature asset discovery;
- pnpm/npm lockfile-aware asset restore;
- Tailwind template content discovery;
- Bootstrap and Pico CSS reference examples;
- asset provenance, integrity, and size budgets.

## Phase 6 — Hardening and public preview

Before promising compatibility:

- browser support matrix;
- security review and threat model;
- test matrix for fallback, accessibility, caching, and failures;
- benchmark methodology and reproducible results;
- public license, governance, package versioning, and migration policy.
