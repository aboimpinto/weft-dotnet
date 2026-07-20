# FEAT-001 Weft Alternative Requirements

**Catalog revision:** WR-1
**Decision status:** Proposed for product-owner approval

## Ranking Principles

`Must` means necessary before Weft can credibly invite normal teams to evaluate
it for the target application class. `Should` is important differentiation or
scale support that may follow the first coherent baseline. `Could` is valuable
but not required to prove the thesis. `Won't/Non-goal` protects the product
boundary.

No competitive performance threshold is ranked Must or Should because BM-1 has
no `COMPARABLE_REPRODUCED` result. Instrumentation may be required without
claiming a winning number.

## Must Requirements

### `WR-M01` Complete vertical feature package contract

- **User value:** A team can add, remove, test and publish one business feature
  without scattering ownership across host startup, unrelated route tables and
  global asset configuration.
- **Evidence / pain:** `EV-0008`, `EV-0014`, `EV-0023`, `WQ-01`, `WP-01`.
- **Architecture rationale:** Extend generated explicit manifests rather than
  runtime scanning or implicit global discovery.
- **Current gap:** Manifest covers feature identity/routes/actions but not the
  full templates/assets/auth/capability/test contract.
- **Measurable acceptance:** A packaged sample feature owns services, routes,
  policy metadata, actions, templates, CSS/assets and tests; host opt-in is one
  explicit registration; removing it leaves no route/asset/service residue;
  manifest mismatch fails build/startup with an actionable diagnostic.
- **Roadmap:** Expand Phase 1 foundation, prerequisite to Phases 2–5.
- **Dependencies / owner:** Generator, server registry, package format; Weft
  architecture owner.
- **Rank rationale:** Foundational product unit; without it Weft is only a thin
  endpoint-registration experiment.

### `WR-M02` Safe HTML template, layout and composition model

- **User value:** Developers author normal HTML/CSS with reusable layouts,
  fragments, loading/error/not-found states and IDE/build feedback without raw
  unsafe string replacement.
- **Evidence / pain:** `EV-0001`, `EV-0008`, `EV-0020`, `WP-02`.
- **Architecture rationale:** HTML remains the durable output; encoding is safe
  by default and raw HTML requires an explicit reviewed type.
- **Current gap:** Starter embeds an HTML string and performs manual token
  replacement.
- **Measurable acceptance:** Compile-time diagnostics cover missing templates,
  invalid slots and unsafe raw insertion; values are encoded by default;
  nested layouts, fragments, metadata and error/not-found states render in an
  integration sample; feature styles do not collide accidentally.
- **Roadmap:** New implementation FEAT before enhanced actions.
- **Dependencies / owner:** `WR-M01`, renderer decision, generator; UI/template
  architecture owner.
- **Rank rationale:** Required for maintainable application UI and security.

### `WR-M03` Typed routing and URL/search state

- **User value:** Links, parameters, filters, pagination and navigation survive
  refactors and normal browser history without handwritten string parsing.
- **Evidence / pain:** `TQ-01`, `TQ-02`, `EV-0008`, `EV-0024`, `WP-01`.
- **Architecture rationale:** Generate small C# route codecs from explicit
  feature declarations; validate user-controlled input on the server.
- **Current gap:** Route metadata is checked, but route construction/query
  parsing/navigation contracts are untyped.
- **Measurable acceptance:** Compile-time generated links for RA-1 routes;
  typed route/query binding with validation/canonicalization; reload/back/
  forward preserve `J-01`; duplicate/ambiguous routes fail diagnostics.
- **Roadmap:** Foundation expansion before Phase 2.
- **Dependencies / owner:** `WR-M01`; generator/server owners.
- **Rank rationale:** Baseline parity and a high-value TanStack lesson.

### `WR-M04` Typed server actions and authoritative forms

- **User value:** CRUD forms have one explicit C# authority for binding,
  validation, authorization, antiforgery, cancellation, concurrency,
  idempotency and error outcomes.
- **Evidence / pain:** `BQ-03`, `NQ-04`, `EV-0019`, `AQ-04`, `BP-04`, `NP-05`.
- **Architecture rationale:** Ordinary HTTP endpoint behavior is the source of
  truth; enhancement reuses the contract.
- **Current gap:** One handwritten sample form exists; there is no reusable
  action/form contract.
- **Measurable acceptance:** `J-03` and `J-04` pass through normal HTTP;
  generated action contract exposes validation/error DTOs and cancellation;
  unauthorized, CSRF, stale and duplicate submissions mutate nothing.
- **Roadmap:** Phase 2 enhanced server actions, preceded by form contract FEAT.
- **Dependencies / owner:** `WR-M02`, `WR-M03`, ASP.NET Core security; server
  actions owner.
- **Rank rationale:** Essential for the stated modular business-app target.

### `WR-M05` Zero-JavaScript durable baseline

- **User value:** Content, navigation and ordinary forms remain useful when
  script is disabled, blocked, slow or unnecessary; teams need no Node install
  for pure .NET mode.
- **Evidence / pain:** `WQ-03`, `BQ-04`, `NP-04`, `AP-05`, `EV-0037`.
- **Architecture rationale:** HTML/HTTP is the default execution mode, not a
  fallback added after an SPA.
- **Current gap:** Demonstrated narrowly but not specified or tested as a
  framework-wide contract.
- **Measurable acceptance:** RA-1 `J-01`–`J-04` pass with scripts disabled;
  published base routes include no Weft JS/WASM runtime; pure .NET restore,
  build and publish require no Node executable or `node_modules`.
- **Roadmap:** Preserve across every phase; conformance work before preview.
- **Dependencies / owner:** `WR-M02`–`WR-M04`; architecture and test owners.
- **Rank rationale:** Core differentiation.

### `WR-M06` Stateless enhanced navigation and partial actions

- **User value:** Common interactions avoid full reload while preserving URLs,
  history, focus, accessibility, cancellation and an ordinary HTTP fallback.
- **Evidence / pain:** `NQ-01`, `NQ-03`, `BQ-04`, `BP-02`, `J-05`.
- **Architecture rationale:** Use bounded fetch/region replacement over
  stateless HTTP rather than a mandatory persistent UI circuit.
- **Current gap:** Not implemented.
- **Measurable acceptance:** RA-1 `J-05`, `FX-02`, `FX-08` and script-disabled
  fallback pass; stale response cannot win; region applies atomically; no
  persistent per-user server UI state is required.
- **Roadmap:** Phase 2.
- **Dependencies / owner:** `WR-M03`–`WR-M05`, browser boundary; enhanced action
  owner.
- **Rank rationale:** Needed to meet modern UX expectations without abandoning
  the thesis.

### `WR-M07` Secure-by-default server and browser boundary

- **User value:** Feature authors receive safe encoding, antiforgery, cookie/
  header/redirect/upload/secret/rate-limit guidance and cannot mistake client
  checks for authorization.
- **Evidence / pain:** `EV-0003`, `EV-0011`, `EV-0019`, `EV-0027`, `WP-03`.
- **Architecture rationale:** Reuse ASP.NET Core enforcement, generate policy
  metadata, and threat-model every execution/adapter boundary.
- **Current gap:** Framework threat model, defaults and conformance tests are
  absent.
- **Measurable acceptance:** Published threat model covers templates, actions,
  assets, browser C# and JS; RA-1 `ATLAS-SEC` controls pass; unsafe raw HTML,
  open redirect, missing auth and secret-in-client fixtures fail; security
  advisories/dependency audit have an owner/process.
- **Roadmap:** Cross-cutting; hardening before public preview.
- **Dependencies / owner:** All public boundaries; security owner.
- **Rank rationale:** Release blocker, not a differentiator to defer.

### `WR-M08` Accessibility and resilient interaction contract

- **User value:** Keyboard and assistive-technology users receive equal
  navigation, validation, loading, error and enhanced-action outcomes.
- **Evidence / pain:** RA-1 browser criteria, `EV-0020`, `BQ-04`, `WQ-03`.
- **Architecture rationale:** Semantic HTML is generated/owned by applications;
  Weft owns enhancement focus/history/live-region rules and test support.
- **Current gap:** One accessible sample pattern, no framework contract.
- **Measurable acceptance:** RA-1 `ATLAS-A11Y` passes automated and manual
  checks for all required states; disabling/failing enhancement preserves the
  journey; scaffolds generate semantic examples without inaccessible custom
  widgets.
- **Roadmap:** Cross-cutting, with Phase 2 enhancement and preview hardening.
- **Dependencies / owner:** `WR-M02`, `WR-M04`, `WR-M06`; accessibility owner.
- **Rank rationale:** Baseline quality and legal/product risk.

### `WR-M09` Feature asset manifest and deterministic publish

- **User value:** CSS, images, fonts and optional code are owned by features,
  hashed, cacheable, inspectable and reproducibly published.
- **Evidence / pain:** `EV-0008`, `EV-0021`, `EV-0029`, `EV-0044`, `WP-01`.
- **Architecture rationale:** Extend the generated manifest and standard .NET
  static web asset/publish mechanisms; do not expose package-manager layout.
- **Current gap:** One hand-mapped embedded CSS endpoint; no general pipeline.
- **Measurable acceptance:** RA-1 modules publish content-hashed immutable
  assets; manifest maps source/owner/hash/cache/license; collision/undeclared
  asset fails; repeated locked build produces identical manifest/output hashes.
- **Roadmap:** Phase 5, but basic assets required before a credible preview.
- **Dependencies / owner:** `WR-M01`, renderer, build/publish owner.
- **Rank rationale:** Every real web app needs a safe production asset path.

### `WR-M10` First-class CLI, diagnostics and developer loop

- **User value:** A developer creates an app/feature, sees generator errors,
  runs/tests it and makes C#/HTML/CSS edits with actionable feedback.
- **Evidence / pain:** `AQ-01`, `NQ-01`, `NQ-06`, `EV-0007`, `EV-0045`,
  `EV-0046`, `EV-0053`–`EV-0059`, `WP-01`.
- **Architecture rationale:** Build on `dotnet new`, analyzers/generators and
  `dotnet watch`; avoid a parallel opaque build daemon.
- **Current gap:** No Weft distribution/bootstrap, templates/CLI, profile-aware
  prerequisite diagnosis, locked orchestration, update/removal lifecycle,
  HTML/CSS hot-reload guarantee, or Weft-aware browser error overlay/source
  mapping.
- **Measurable acceptance:** a pinned repository-local .NET tool is restored
  exactly on clean Windows/Linux/macOS environments; documented one-command
  pure-mode app/feature scaffolds require only a supported .NET SDK and create
  no Node graph; `doctor` explains every optional prerequisite; add/update/
  remove support dry-run; two repositories run different CLI versions side by
  side; offline and non-interactive CI behavior is deterministic. Invalid
  manifest/template/action/install/lock examples produce stable diagnostic IDs
  and fixes; RA-1 edit scenarios are automated; generated code is inspectable. In
  Development, server/render/action/capability failures show exception,
  relevant C# or template code frame, mapped file/line, collapsed stack and
  trace ID. Production output contains no overlay, source path, code frame,
  editor endpoint or serialized stack and instead returns the correct friendly
  full-page/partial/API error plus trace ID.
- **Roadmap:** Foundation/tooling before preview.
- **Dependencies / owner:** `WR-M01`–`WR-M04`; tooling owner.
- **Rank rationale:** Capability without usable workflow is not an alternative.

### `WR-M11` Bounded JavaScript interoperability

- **User value:** Teams can use mature charts, maps, editors and payment widgets
  without surrendering the app architecture to JavaScript.
- **Evidence / pain:** `BQ-05`, `NQ-05`, `EV-0020`, `BP-05`, RA-1 `J-07`.
- **Architecture rationale:** Typed adapter, lazy activation, explicit DOM/API
  ownership and mandatory disposal; semantic server-owned fallback.
- **Current gap:** Not implemented.
- **Measurable acceptance:** RA-1 chart adapter mounts/updates/disposes through a
  generated typed contract; no secret/raw HTML crosses; failure retains table;
  repeated activation shows no duplicate handlers/retained stale instance.
- **Roadmap:** Phase 3 browser boundary, before ecosystem preview.
- **Dependencies / owner:** `WR-M07`–`WR-M09`; interop owner.
- **Rank rationale:** Required for practical adoption; “no JavaScript ever” is
  not credible.

### `WR-M12` Dependency locks, shared cache, integrity and provenance

- **User value:** Restores are deterministic and auditable without mandatory
  project-local dependency duplication or undeclared install scripts.
- **Evidence / pain:** `EV-0006`, `EV-0032`, `EV-0053`–`EV-0056`, `NP-04`,
  `TP-01`, `WQ-04`.
- **Architecture rationale:** NuGet locked mode for .NET; content-addressed
  shared cache and immutable direct assets; optional npm adapter under explicit
  policy rather than a new package registry.
- **Current gap:** NuGet defaults exist, but Weft has no unified asset lock,
  license/provenance report or npm opt-in contract.
- **Measurable acceptance:** locked restore fails on drift; direct assets record
  URL/version/hash/license/provenance and reuse shared cache; pure mode creates
  no `node_modules`; opted-in npm mode records manager/lock/scripts and publishes
  final assets only; SBOM/license report covers published output.
- **Roadmap:** Phase 5.
- **Dependencies / owner:** Asset pipeline and package policy; supply-chain
  owner.
- **Rank rationale:** Directly addresses a core product promise without making
  false claims about npm.

### `WR-M13` Multi-layer conformance testing support

- **User value:** Package authors prove generator, route/action, HTML fallback,
  enhancement, accessibility and security behavior using public boundaries.
- **Evidence / pain:** `EV-0012`, `EV-0029`, `EV-0040`, `WP-03`.
- **Architecture rationale:** Provide test hosts/fixtures and framework
  assertions; remain compatible with xUnit/browser tools.
- **Current gap:** Eight narrow tests; no browser/accessibility/security/
  fallback conformance kit.
- **Measurable acceptance:** documented unit/generator/integration/browser/
  accessibility/security fixtures execute RA-1 public contracts; helper-only
  tests cannot satisfy route/action conformance; sample packages run in CI.
- **Roadmap:** Every implementation FEAT; full suite by Phase 6 hardening.
- **Dependencies / owner:** All contracts; test owner.
- **Rank rationale:** Required to keep explicit contracts true over upgrades.

### `WR-M14` Operational visibility and portable deployment

- **User value:** Teams publish to ordinary ASP.NET Core/container/reverse proxy
  environments and can diagnose feature/action/asset/capability failures.
- **Evidence / pain:** `EV-0012`, `EV-0021`, `EV-0029`, RA-1 observability.
- **Architecture rationale:** Use standard .NET logging, metrics, tracing,
  health and publish output with Weft semantic tags; avoid provider lock-in.
- **Current gap:** Only inherited ASP.NET behavior; no Weft semantic signals or
  deployment contract.
- **Measurable acceptance:** container and self-host reference deployments pass
  readiness/shutdown/proxy/TLS tests; logs/traces/metrics identify safe feature,
  route, action and capability outcome; published manifest and config are
  inspectable; no provider is required.
- **Roadmap:** Phase 6 hardening.
- **Dependencies / owner:** Server/assets/capability contracts; operations owner.
- **Rank rationale:** A development demo is not a production alternative.

### `WR-M15` Compatibility, migration and support policy

- **User value:** Long-lived teams can predict breaking changes, upgrade
  packages and understand supported .NET/browser/tool versions.
- **Evidence / pain:** `AQ-05`, `EV-0007`, `NP-03`, `AP-05`, `EV-0023`.
- **Architecture rationale:** Semantic packages, diagnostic deprecations,
  compatibility tests and explicit support windows.
- **Current gap:** Experimental repository has no published policy.
- **Measurable acceptance:** versioning/support document defines preview/1.0
  guarantees; one migration fixture proves diagnostics/codemod or documented
  steps; compatibility matrix is CI-verified; security reporting path exists.
- **Roadmap:** Define before public preview; enforce continuously.
- **Dependencies / owner:** Package/public API inventory; product owner.
- **Rank rationale:** Necessary for enterprise evaluation and ecosystem trust.

## Should Requirements

| ID | Requirement | Evidence/pain and value | Measurable acceptance | Roadmap |
| --- | --- | --- | --- | --- |
| `WR-S01` | Lazy browser-safe C# capability | `BQ-01`,`BP-03`,`J-06`; permits sustained local interactions without app-wide runtime. | Only RA-1 board activation loads runtime/capability; inputs/outputs typed; failure leaves HTML list; disposal/memory observable. | Phases 3–4 |
| `WR-S02` | Optional coherent local server-state cache | `TQ-03`,`TP-03`; avoids every feature inventing stale/invalidation behavior. | Named keys/freshness/invalidation/cancellation; no cache in base route; RA-1 mutation invalidates every projection. | After Phase 3 |
| `WR-S03` | Reusable loading/error/metadata boundaries | `NQ-01`,`NQ-03`; consistent UX and SEO. | RA-1 layouts/states/metadata compose per feature and preserve HTTP status. | Template phase |
| `WR-S04` | IDE navigation/refactoring and manifest visualization | `TQ-01`,`AQ-01`; lowers generated-contract learning cost. | Go-to definition/references for generated routes/actions and an inspectable feature/cost graph. | Tooling |
| `WR-S05` | Approved direct immutable asset retrieval | `WR-M12`; small CSS/font/JS assets should not require npm. | HTTPS allowlist, exact hash, license/provenance, offline cache reuse and locked failure on mismatch. | Phase 5 |
| `WR-S06` | Feature/capability budget reporting without competitive thresholds | D24/BM-1; makes cost placement visible while results remain deferred. | Build report lists initial and activated bytes/files/dependencies plus retained-memory measurement hook; no “faster than” claim. | Phase 4–5 |
| `WR-S07` | Framework-neutral native WebView shell contract | `EV-0047`–`EV-0052`; lets a C# application choose one shell family that covers its target platforms without confusing adapter portability with simultaneous multi-shell maintenance. | Publish descriptors define hosted-shell, future static-shell, and desktop-sidecar compatibility; one Tauri project proves Windows/Linux desktop plus Android through the same typed least-privilege bridge, deep links/auth, lifecycle, fallback, dev loop, and Production diagnostic isolation. iOS may use a separate Apple pipeline over the same contract. | After assets/browser bridge; dedicated Spike |
| `WR-S08` | Verified portable bootstrap and controlled-network installation | `EV-0053`–`EV-0059`; supports initial adoption before/alongside NuGet tool distribution without copying remote-script execution patterns blindly. | Versioned user-local Windows/Linux/macOS archives publish checksum, signature/provenance, SBOM and notices; `wget` and PowerShell flows verify before execution; tampering fails closed; exact-version CI, approved mirrors, cache prewarm/export and offline missing-input reports are tested; no normal install needs administrator rights, silently updates, enables telemetry, or removes shared prerequisites/cache. | Tooling/release foundation before preview |

## Could Requirements

| ID | Requirement | Rationale / acceptance boundary |
| --- | --- | --- |
| `WR-C01` | PWA/offline package | Capability-specific manifest/service-worker/local data guidance; no blanket offline promise. |
| `WR-C02` | Opt-in npm restoration adapter | Uses an existing manager/lock/script policy and publishes final assets; never mandatory in pure mode. |
| `WR-C03` | Optimistic mutation toolkit | Only after idempotency/concurrency contracts; visibly pending and rollback/reconcile tested. |
| `WR-C04` | Certified third-party adapter catalog | Small set of maintained typed bridges with ownership/disposal/security tests. |
| `WR-C05` | Comparable benchmark execution | Future FEAT implements RA-1 in approved modes and runs BM-1; only then may competitive thresholds be ranked. |

## Won't / Non-goals

| ID | Non-goal | Reason |
| --- | --- | --- |
| `WR-W01` | Mandatory Node/npm or `node_modules` for pure .NET projects | Contradicts core value; opt-in interop remains supported. |
| `WR-W02` | Mandatory persistent server UI circuit | Changes stateless scale/failure model; may be a future optional experiment, not default. |
| `WR-W03` | Mandatory browser .NET runtime for every route | HTML-only journeys should not pay local-runtime cost. |
| `WR-W04` | Prohibition of all JavaScript | Would exclude practical ecosystem integrations and create needless reimplementation. |
| `WR-W05` | New JavaScript package registry or complete npm UI ecosystem clone | Outside competence/scope; use direct assets or existing ecosystem adapters. |
| `WR-W06` | Universal claim that Weft is faster or more secure than Node/Blazor | Architecture can reduce default surface/cost, but superiority requires workload-specific reproduced evidence. |
| `WR-W07` | Framework-owned visual design system | Weft should own contracts/semantics, not application brand or all widgets. |

## Traceability Audit

- All 15 Must records include user value, evidence/pain, architecture rationale,
  current gap, measurable acceptance, roadmap, dependencies/owner and ranking
  rationale: **PASS**.
- Ranks use Must/Should/Could/Won't and duplicate hypotheses are consolidated:
  **PASS**.
- Competitive performance thresholds remain outside Must/Should pending
  `COMPARABLE_REPRODUCED` BM-1 evidence: **PASS**.
- Security and accessibility are first-class Must requirements: **PASS**.
- Native-shell support is a traceable Should with explicit desktop/mobile and
  SSR/static limitations rather than a portability promise: **PASS**.
- Installation is split between a Must-level reproducible local-tool lifecycle
  and a Should-level verified portable bootstrap; neither treats `wget` as a
  package manager or permits unverified pipe-to-shell execution: **PASS**.
