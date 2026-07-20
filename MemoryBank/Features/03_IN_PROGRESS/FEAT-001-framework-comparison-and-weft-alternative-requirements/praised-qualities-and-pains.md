# FEAT-001 Praised Qualities and Pain Analysis

**Snapshot date:** 2026-07-15
**Evidence input:** `framework-comparison-report.md`

## Interpretation Boundary

This is not a popularity survey. “Praised quality” means a mechanism with a
clear developer/user benefit supported by primary documentation. “Pain” means
a documented limitation, necessary trade-off, or strongly supported inference
from an official architecture boundary. It does not mean that every team
experiences the problem. No forum anecdote is promoted to a conclusion.

Responses are proposals for Weft architecture: qualities use `Adopt`, `Adapt`,
`Interoperate`, `Defer`, or `Reject`; pains use `Avoid`, `Mitigate`, `Accept`,
or `Not Applicable`.

## Blazor

### Praised qualities

| ID | Quality and problem solved | Workload/team | Evidence; label; confidence | Proposed Weft response and rationale |
| --- | --- | --- | --- | --- |
| `BQ-01` | Multiple render modes let one .NET solution place interactivity on server or browser. | Mixed content/business apps | `EV-0001`; Fact; High | **Adapt** — preserve placement choice, but make HTML the explicit baseline and capabilities the opt-in unit. |
| `BQ-02` | C# and Razor share language, tooling and models across server and WASM. | .NET teams | `EV-0001`; Fact; High | **Adopt** — C#-native contracts are central to Weft. |
| `BQ-03` | ASP.NET Core authentication, authorization and antiforgery integrate with the component host. | Authenticated business apps | `EV-0003`; Fact; High | **Adopt** — build on ASP.NET Core rather than inventing a parallel security stack. |
| `BQ-04` | Static SSR and prerendering can deliver useful initial HTML. | SEO/content and resilient pages | `EV-0001`; Fact; High | **Adopt** — durable HTML must remain useful without an interactive runtime. |
| `BQ-05` | Supported JS interop permits ecosystem escape hatches. | Apps needing maps/editors/charts | `EV-0005`; Fact; High | **Adapt** — typed, lazy, disposable adapters with explicit DOM ownership. |

### Pains

| ID | Trigger and affected team | Consequence | Standard workaround and added cost | Severity / confidence / grade / classification | Weft response and rationale |
| --- | --- | --- | --- | --- | --- |
| `BP-01` | Choosing among Static, Server, WASM and Auto for one app. | Mode-specific lifecycle, security, state and deployment rules increase mental load. | Standardize a mode per area and document boundaries; loses flexibility or adds architecture governance. | High / High / A / Essential complexity | **Mitigate** — define three explicit action/capability levels and expose cost in manifests/tooling. |
| `BP-02` | Interactive Server at scale or unreliable networks. | Persistent connection and per-user circuit state affect scale and reconnect UX. | Scale-out/backplane, circuit persistence and reconnect handling; adds infrastructure and state design. | High / High / A / Implementation limitation | **Avoid** — enhanced server actions should be stateless HTTP, not a mandatory circuit. |
| `BP-03` | WASM/Auto browser activation. | .NET runtime/assemblies add first-capability download and browser memory. | Lazy assemblies, trimming/AOT and careful placement; adds build complexity and cannot erase runtime cost. | High / High / A / Essential complexity | **Mitigate** — load browser C# only for sustained local interactions, by capability. |
| `BP-04` | Authentication with client or Auto rendering. | Client checks are untrusted; secure data needs server/API enforcement in both execution locations. | Central server policies and authorized APIs; duplicates boundary handling. | High / High / A / Essential complexity | **Accept** — any browser technology has this boundary; generate explicit server authority contracts. |
| `BP-05` | JS component initialization during enhanced/static navigation. | Page scripts can miss reinitialization or leak DOM resources. | JS initializers and navigation event listeners; adds lifecycle protocol and disposal discipline. | Medium / High / A / Implementation limitation | **Mitigate** — make adapter lifecycle/ownership a first-class contract. |

## Next.js App Router

### Praised qualities

| ID | Quality and problem solved | Workload/team | Evidence; label; confidence | Proposed Weft response and rationale |
| --- | --- | --- | --- | --- |
| `NQ-01` | Route folders colocate page, layout, loading, error and metadata conventions. | Product teams shipping route-oriented features | `EV-0008`; Fact; High | **Adapt** — feature folders/packages should own equivalent routes, states and metadata without coupling URL shape to disk shape. |
| `NQ-02` | Server Components default keeps server-only work and some dependencies out of client bundles. | Data-heavy React apps | `EV-0009`; Fact; High | **Adapt** — server HTML is Weft’s baseline; local code crosses only an explicit capability boundary. |
| `NQ-03` | Streaming/loading boundaries provide early useful UI. | Slow data and distributed backends | `EV-0010`; Fact; High | **Adopt** — define loading/error boundaries and later stream where ordinary HTML semantics remain clear. |
| `NQ-04` | Cache tagging and revalidation connect mutations to server-rendered data freshness. | Catalog/content/admin apps | `EV-0010`; Fact; High | **Adapt** — provide explicit invalidation contracts rather than hidden global cache behavior. |
| `NQ-05` | Mature React/npm ecosystem and deployment integrations reduce missing-component risk. | Teams needing broad third-party UI | `EV-0013`; Inference; High | **Interoperate** — bounded JS adapters are more credible than rebuilding the ecosystem. |
| `NQ-06` | Development overlay connects an error message to the relevant source code frame and stack while hiding low-value framework noise. | Developers diagnosing render/build/server failures | `EV-0045`; Fact; High | **Adapt** — present .NET exceptions through a Weft-aware Development overlay with C#/template source mapping and a strict Production boundary. |

### Pains

| ID | Trigger and affected team | Consequence | Standard workaround and added cost | Severity / confidence / grade / classification | Weft response and rationale |
| --- | --- | --- | --- | --- | --- |
| `NP-01` | Crossing Server/Client Component boundaries. | Directives, serialization and composition constraints make execution placement non-local. | Minimize client islands and define DTOs; adds architectural review and component reshaping. | High / High / A / Essential complexity | **Mitigate** — generated manifests show placement, payload and fallback explicitly. |
| `NP-02` | Combining dynamic data, Cache Components and revalidation. | Stale/fresh behavior can be difficult to reason about across tags, paths and scopes. | Central cache policy and observability; adds conventions and debugging tooling. | High / High / A / Changeable default | **Avoid** — no implicit cache; require named cache/invalidation policy. |
| `NP-03` | Frequent framework/React evolution and major upgrades. | Codemods and migration work consume team capacity; alpha/changed conventions can leak into apps. | Pin versions, run codemods, maintain upgrade tests; adds recurring migration budget. | Medium / High / A / Ecosystem/tooling consequence | **Mitigate** — longer compatibility windows, deprecation diagnostics and migration tooling. |
| `NP-04` | Normal development/install of a non-trivial app. | A project-local `node_modules` graph can be large in files/disk and executes a JavaScript toolchain. | pnpm stores/deduplication, caches, pruning and script policies; adds package-manager policy and still requires Node. | Medium / High / A / Ecosystem/tooling consequence | **Avoid** by default — pure .NET/direct assets must not require Node; **Accept** only in opt-in interop mode. |
| `NP-05` | Authentication/authorization across pages, route handlers and Server Actions. | Framework defenses do not replace authorization at every entry point. | Auth library, DAL/DTO layer and action checks; necessary extra structure. | High / High / A / Essential complexity | **Accept** — centralize generated policy metadata but never imply UI checks secure data. |

## TanStack Start Family

### Praised qualities

| ID | Quality and problem solved | Workload/team | Evidence; label; confidence | Proposed Weft response and rationale |
| --- | --- | --- | --- | --- |
| `TQ-01` | Router propagates types through paths, params, search state, loaders and navigation. | Large TypeScript apps and refactors | `EV-0015`,`EV-0016`; Fact; High | **Adopt** — generated typed routes/search/action contracts are a Must. |
| `TQ-02` | URL search state is validated, typed and shareable rather than ad-hoc strings. | Search/filter/table applications | `EV-0016`; Fact; High | **Adapt** — use typed C# codecs and server validation while preserving normal URLs. |
| `TQ-03` | Router loaders coordinate parallel preloading and SWR; Query adds rich server-state caching. | Data-intensive apps | `EV-0017`; Fact; High | **Adapt** — start with server loaders; add an optional coherent local cache only when needed. |
| `TQ-04` | Headless Table/Form preserve product markup and design-system ownership. | Custom business UI/design systems | `EV-0018`,`EV-0020`; Fact; High | **Adopt** — Weft primitives should not impose a visual component library. |
| `TQ-05` | Start targets multiple runtimes through standard fetch-shaped output and build adapters. | Vendor-portable deployments | `EV-0021`; Fact; Medium | **Adopt** — keep Weft on ordinary ASP.NET Core hosting and deterministic published output. |

### Pains

| ID | Trigger and affected team | Consequence | Standard workaround and added cost | Severity / confidence / grade / classification | Weft response and rationale |
| --- | --- | --- | --- | --- | --- |
| `TP-01` | Selecting Start plus Router, Query, Form, Table and devtools. | More packages, versions and overlapping caches/state boundaries must be composed. | Establish a blessed stack and version policy; reduces flexibility and adds integration ownership. | High / High / A / Ecosystem/tooling consequence | **Mitigate** — integrated defaults with replaceable boundaries, not a mandatory bundle of every capability. |
| `TP-02` | Very large typed route trees or broad generic types. | TypeScript checking can slow and shared hooks can widen to expensive unions. | Narrow `from`/`to`, generated trees and precise types; adds type-performance discipline. | Medium / High / A / Implementation limitation | **Avoid** — generator output should keep public contracts small and incremental. |
| `TP-03` | Router cache used for shared/mutated data. | Coarse invalidation and no cache-level optimistic API become limiting. | Add TanStack Query; introduces a second cache model and dependency. | Medium / High / A / Product boundary | **Mitigate** — make the transition from server loader to optional client cache explicit. |
| `TP-04` | Depending on Start RSC or unified Devtools today. | Experimental/alpha APIs can change and increase upgrade risk. | Avoid those features or isolate adapters; sacrifices capabilities or adds abstraction. | High / High / A / Ecosystem/tooling consequence | **Defer/Accept** — do not copy immature protocols; interoperate only behind isolation. |
| `TP-05` | Deploying across Nitro/provider/build-tool paths. | Portability creates a matrix of adapters and maturity levels rather than zero configuration. | Choose and test one blessed target; adds target-specific CI. | Medium / Medium / A / Hosting-provider consequence | **Mitigate** — certify a small ASP.NET deployment matrix with conformance tests. |

## Angular

### Praised qualities

| ID | Quality and problem solved | Workload/team | Evidence; label; confidence | Proposed Weft response and rationale |
| --- | --- | --- | --- | --- |
| `AQ-01` | Cohesive CLI scaffolds, serves, tests, builds and maintains applications. | Enterprise teams needing consistent conventions | `EV-0029`; Fact; High | **Adopt** — Weft needs first-class project/feature scaffolding and diagnostics. |
| `AQ-02` | Integrated components, DI, router, forms and signals reduce basic library selection. | Large multi-team applications | `EV-0023`,`EV-0025`; Fact; High | **Adapt** — provide a coherent baseline without requiring a browser SPA runtime. |
| `AQ-03` | Route guards, resolvers, lazy loading and events cover rich navigation workflows. | Complex authenticated portals | `EV-0024`; Fact; High | **Adapt** — typed server policies plus optional client navigation observables. |
| `AQ-04` | Template sanitization, XSRF integration and security guidance provide strong defaults. | Security-sensitive browser apps | `EV-0027`; Fact; High | **Adopt** — secure encoding and antiforgery must be built in and visible. |
| `AQ-05` | Explicit release/support/deprecation policy and migration tools make change governable. | Long-lived enterprise apps | `EV-0023`; Fact; High | **Adopt** — publish compatibility/support policy before preview. |

### Pains

| ID | Trigger and affected team | Consequence | Standard workaround and added cost | Severity / confidence / grade / classification | Weft response and rationale |
| --- | --- | --- | --- | --- | --- |
| `AP-01` | Learning the full platform: templates, DI, signals, RxJS, router, forms and rendering. | Large conceptual surface before a developer is productive. | Team conventions/training and architecture layers; adds onboarding time. | High / High / A / Essential complexity | **Avoid** — progressive disclosure: HTML/HTTP first, optional capabilities later. |
| `AP-02` | Choosing template, reactive or signal forms across old/new code. | Multiple paradigms and maturity levels complicate standards/migrations. | Standardize one approach and migrate gradually; adds internal wrappers and transition cost. | Medium / High / A / Ecosystem/tooling consequence | **Avoid** — one server-authoritative form contract with optional client feedback. |
| `AP-03` | Resolver performs slow data work. | Navigation blocks and needs separate progress/error handling. | Keep resolvers small, cache and show router progress; shifts loading complexity. | Medium / High / A / Changeable default | **Mitigate** — server HTML/loading boundaries and cancellable enhanced navigation. |
| `AP-04` | Adding advanced offline behavior. | Built-in service worker is intentionally basic and security-fixes-only. | Use native/service-worker ecosystem tooling; adds custom JS and operational complexity. | Medium / High / A / Product boundary | **Accept** — offline is a capability-specific concern, not a framework-wide promise. |
| `AP-05` | Client-heavy app plus npm/CLI toolchain and regular majors. | Runtime/bundle/dependency and migration costs exist even for pages needing little interactivity. | SSR/hybrid/lazy loading, budgets and update tooling; adds build/deployment complexity. | High / High / A / Essential complexity | **Avoid** by default — no browser runtime or Node toolchain for HTML-only features. |

## Weft (Current and Target)

### Praised qualities

| ID | Quality and problem solved | Workload/team | Evidence; label; confidence | Proposed response |
| --- | --- | --- | --- | --- |
| `WQ-01` | Host explicitly trusts feature manifests; generator avoids runtime assembly scanning. | Modular ASP.NET apps | `EV-0035`,`EV-0036`; Fact; High | **Adopt** — retain as core architecture. |
| `WQ-02` | Declared route metadata is checked against actual mapped endpoints. | Package authors/hosts | `EV-0036`; Fact; High | **Adopt** — extend contract validation to actions/assets/capabilities. |
| `WQ-03` | Starter journey works as HTML/CSS and normal POST without JavaScript. | Forms/content on constrained or failure paths | `EV-0037`,`EV-0038`; Fact; High | **Adopt** — preserve as non-negotiable baseline where workload permits. |
| `WQ-04` | NuGet/global cache means no mandatory project-local dependency warehouse. | .NET teams/CI | `EV-0006`,`EV-0039`; Fact; High | **Adapt** — add locks/provenance/assets while retaining shared-cache behavior. |
| `WQ-05` | Target explicitly allows bounded JS interop rather than ideological prohibition. | Real products needing ecosystem widgets | `EV-0044`; Hypothesis; High | **Adopt** — “JavaScript-free by default, compatible by choice.” |

### Pains

| ID | Trigger and affected team | Consequence | Standard workaround and added cost | Severity / confidence / grade / classification | Response and rationale |
| --- | --- | --- | --- | --- | --- |
| `WP-01` | Building anything beyond the starter’s server HTML/form path today. | Missing layouts/components/data contracts/assets/tooling makes Current Weft non-competitive. | Hand-build on ASP.NET Core or use Blazor/Node; bypasses Weft or duplicates framework work. | Critical / High / A / Implementation limitation | **Mitigate** — ranked Must baseline before public alternative claims. |
| `WP-02` | Authoring feature UI today. | Raw embedded string templates have weak tooling/composition and can become unsafe or unmaintainable at scale. | Custom renderer/template engine; creates incompatible feature patterns. | High / High / A / Implementation limitation | **Avoid** — select a compiled/validated HTML template contract with encoding by default. |
| `WP-03` | Trusting current examples as framework security proof. | One encoded/antiforgery sample does not establish headers, auth, upload, redirect, rate-limit or browser-boundary defaults. | Apply ASP.NET guidance manually; consistency depends on each team. | Critical / High / A / Implementation limitation | **Mitigate** — threat model, secure defaults and conformance suite before preview. |
| `WP-04` | Claiming faster/smaller/more secure than Node or Blazor now. | Unsupported marketing damages credibility and may guide bad architecture. | Qualify every claim and run equivalent benchmarks later; delays aggressive messaging. | High / High / A / Team practice | **Avoid** — enforce evidence labels and comparable-benchmark gate. |
| `WP-05` | Depending on target browser C#, enhanced actions, assets or JS bridges. | Roadmap intent can be mistaken for shipping capability. | Keep Current/Target documents separate; adds repeated qualification. | High / High / A / Team practice | **Avoid** — tooling/docs must generate explicit current capability status. |

## Cross-Platform Decisions Carried to Phase 6

- Preserve durable server HTML and normal HTTP fallback as Weft’s strongest
  differentiator, but never force fallback on interactions whose nature is
  genuinely local/offline.
- Adopt typed routing, route/search state, server-authoritative forms,
  loading/error boundaries, scaffolding, diagnostics and support policy.
- Adapt React/TanStack cache and client-island ideas into optional,
  capability-scoped C# boundaries with explicit cost and disposal.
- Interoperate with third-party JavaScript components; do not attempt to clone
  the npm UI ecosystem.
- Avoid persistent server circuits as Weft’s default enhancement model,
  implicit caches, mandatory Node installation, raw unsafe templates, and
  unsupported performance/security superiority claims.

## Phase 3 Audit Results

- `platform-count-audit`: **PASS** — five material qualities and five material
  pains are recorded for Blazor, Next.js, TanStack Start family, Angular, and
  Weft.
- `decision-traceability-audit`: **PASS** — each record links Phase 2 evidence
  and uses a controlled Weft response.
- `weak-evidence-audit`: **PASS** — no Grade-D anecdote is used; inference is
  labelled separately from source fact.
- `cause-classification-audit`: **PASS** — ecosystem, hosting, application and
  team-practice costs are not silently blamed on framework runtime code.
