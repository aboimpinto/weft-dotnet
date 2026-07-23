# FEAT-001 Weft Gap and Decision Backlog

**Backlog revision:** WD-1
**Status:** Research proposals; no implementation is authorized

## Decision Rule

Every Phase 3 quality receives one mechanism decision and every pain receives
one pain response. Decisions describe how Weft should respond to the user
problem, not instructions to copy framework internals.

## Competitor Mechanism Decisions

| Source | Mechanism | Decision | Architectural rationale | Requirement destination |
| --- | --- | --- | --- | --- |
| `BQ-01` | Multiple render modes | **Adapt** | Keep placement choice but use HTML/action/capability as explicit cost levels rather than component render modes. | `WR-M05`,`WR-M06`,`WR-S01` |
| `BQ-02` | C# across server/browser | **Adopt** | C#-native generated contracts are core; browser subset remains explicit. | `WR-M03`,`WR-M04`,`WR-S01` |
| `BQ-03` | ASP.NET Core security integration | **Adopt** | Reuse proven server enforcement and antiforgery. | `WR-M07` |
| `BQ-04` | Static SSR/useful HTML | **Adopt** | This is Weft’s durable baseline. | `WR-M02`,`WR-M05` |
| `BQ-05` | JavaScript interop | **Adapt** | Require typed lazy disposal and DOM ownership. | `WR-M11` |
| `NQ-01` | Route-colocated layouts/states/metadata | **Adapt** | Feature packages own these concerns without requiring URL=disk convention. | `WR-M01`,`WR-S03` |
| `NQ-02` | Server-first UI/client islands | **Adapt** | Server HTML first; opt into local C# or JS per declared capability. | `WR-M05`,`WR-S01` |
| `NQ-03` | Streaming/loading boundaries | **Defer** | Loading/error composition is required now; streaming follows a clear HTML protocol later. | `WR-S03` |
| `NQ-04` | Cache tagging/revalidation | **Adapt** | Use named explicit policy and invalidation; avoid implicit cache semantics. | `WR-S02` |
| `NQ-05` | React/npm ecosystem | **Interoperate** | Bounded bridges are credible; cloning ecosystem is not. | `WR-M11`,`WR-C04`,`WR-W05` |
| `NQ-06` | Development error overlay with code frame and stack | **Adapt** | Reuse .NET exceptions/symbols, add Weft source mapping and browser presentation, and make the Production exclusion testable. | `WR-M07`,`WR-M10` |
| `TQ-01` | End-to-end typed routing | **Adopt** | Strong fit for generation and C# refactoring. | `WR-M03` |
| `TQ-02` | Typed URL search state | **Adapt** | C# codecs plus server validation and ordinary URLs. | `WR-M03` |
| `TQ-03` | Router loaders plus Query cache | **Adapt** | Integrated server loaders first, optional local cache second. | `WR-S02` |
| `TQ-04` | Headless Form/Table | **Adopt** | Own behavior/contracts, not application visual design. | `WR-M02`,`WR-M04`,`WR-W07` |
| `TQ-05` | Portable fetch-shaped deployment | **Adopt** | ASP.NET Core already supplies a portable host; certify outputs rather than build provider magic. | `WR-M14` |
| `AQ-01` | Cohesive CLI | **Adopt** | A credible alternative requires scaffolding, diagnostics and repeatable workflow. | `WR-M10` |
| `AQ-02` | Integrated baseline platform | **Adapt** | Coherent defaults are valuable, but browser SPA runtime is not mandatory. | `WR-M01`–`WR-M10` |
| `AQ-03` | Rich router lifecycle | **Adapt** | Implement typed server policies and only required client navigation events. | `WR-M03`,`WR-M06` |
| `AQ-04` | Sanitization/XSRF defaults | **Adopt** | Safe encoding and server/client CSRF cooperation are release blockers. | `WR-M07` |
| `AQ-05` | Release/deprecation/migration policy | **Adopt** | Required for long-lived .NET teams and package trust. | `WR-M15` |
| `WQ-01` | Explicit trusted generated manifests | **Adopt** | Keep the current core and broaden its contract. | `WR-M01` |
| `WQ-02` | Declared/actual route validation | **Adopt** | Extend conformance to actions/templates/assets/capabilities. | `WR-M01`,`WR-M13` |
| `WQ-03` | Normal HTML/form behavior | **Adopt** | Non-negotiable for appropriate journeys. | `WR-M05`,`WR-M06` |
| `WQ-04` | Shared NuGet cache/no local package warehouse | **Adapt** | Add deterministic lock/provenance/license/asset policy and report global cost honestly. | `WR-M12` |
| `WQ-05` | JS compatible by choice | **Adopt** | Avoid ideological isolation while preserving the C# default. | `WR-M11` |

## Pain Decisions

| Source | Pain | Response | Rationale / control | Destination |
| --- | --- | --- | --- | --- |
| `BP-01` | Blazor render-mode mental load | **Mitigate** | Three placement levels, generated cost graph and explicit fallback. | `WR-M05`,`WR-M06`,`WR-S01` |
| `BP-02` | Persistent server circuits | **Avoid** | Stateless HTTP is the default enhancement model. | `WR-W02`,`WR-M06` |
| `BP-03` | WASM runtime/download/memory | **Mitigate** | Capability-only lazy activation, budgets and disposal. | `WR-S01`,`WR-S06` |
| `BP-04` | Client authorization untrusted | **Accept** | Fundamental browser boundary; server authority remains mandatory. | `WR-M07` |
| `BP-05` | JS navigation lifecycle | **Mitigate** | Adapter lifecycle and DOM ownership in generated contract. | `WR-M11` |
| `NP-01` | Server/client component boundary complexity | **Mitigate** | Smaller explicit capability boundary and inspectable DTOs. | `WR-S01` |
| `NP-02` | Cache semantic complexity | **Avoid** | No implicit caching; named policy and invalidation only. | `WR-S02` |
| `NP-03` | Rapid major/migration work | **Mitigate** | Compatibility windows, diagnostics and migration fixtures. | `WR-M15` |
| `NP-04` | Project-local dependency/toolchain footprint | **Avoid** by default | Pure mode needs no Node/local JS graph; opt-in mode remains measured. | `WR-M12`,`WR-W01` |
| `NP-05` | Authorization at multiple entry points | **Accept** | Essential complexity; centralize policies and conformance rather than hide it. | `WR-M07`,`WR-M13` |
| `TP-01` | Multi-package integration choices | **Mitigate** | Coherent Weft baseline with replaceable explicit edges. | `WR-M01` |
| `TP-02` | Deep TypeScript type-check cost | **Avoid** | Incremental generated C# APIs with bounded public generic surface. | `WR-M03`,`WR-M10` |
| `TP-03` | Router cache insufficient for rich shared state | **Mitigate** | One documented escalation to optional local cache. | `WR-S02` |
| `TP-04` | Experimental RSC/alpha Devtools | **Not Applicable** | Weft does not need RSC protocol; inspectable manifest tooling can mature independently. | `WR-S04` |
| `TP-05` | Adapter/hosting maturity matrix | **Mitigate** | Certify small standard deployment profiles. | `WR-M14` |
| `AP-01` | Large Angular learning surface | **Avoid** | Progressive disclosure: HTML then enhancement then local capability. | `WR-M05`,`WR-M10` |
| `AP-02` | Multiple form paradigms | **Avoid** | One server action/form authority with optional feedback. | `WR-M04` |
| `AP-03` | Resolver-blocked navigation | **Mitigate** | Cancellable loading states and server-first response. | `WR-S03`,`WR-M06` |
| `AP-04` | Limited built-in offline service worker | **Accept** | Offline is domain/capability-specific, not core framework promise. | `WR-C01` |
| `AP-05` | Browser runtime/Node cost on simple pages | **Avoid** | Zero-runtime pure mode and per-capability activation. | `WR-M05`,`WR-S01` |
| `WP-01` | Current Weft capability gap | **Mitigate** | Complete approved Must baseline before public alternative claim. | `WR-M01`–`WR-M15` |
| `WP-02` | Raw embedded string templates | **Avoid** | Safe compiled/validated template composition. | `WR-M02` |
| `WP-03` | Sample mistaken for security framework | **Mitigate** | Threat model, defaults and security conformance. | `WR-M07`,`WR-M13` |
| `WP-04` | Unsupported superiority claims | **Avoid** | Evidence labels and BM-1 gate. | `WR-W06`,`WR-C05` |
| `WP-05` | Roadmap mistaken for current capability | **Avoid** | Current/Target status in manifests/docs and release evidence. | `WR-M15` |

## Current Weft Gap Map

| Gap | Current evidence | Required response | Rank |
| --- | --- | --- | --- |
| General renderer/layout/template safety absent | `EV-0037`,`WP-02` | `WR-M02` | Must |
| Full feature manifest/asset ownership absent | `EV-0035`,`EV-0036` | `WR-M01`,`WR-M09` | Must |
| Typed route/search/action/form contracts absent | `EV-0036`,`EV-0037` | `WR-M03`,`WR-M04` | Must |
| Enhanced server actions absent | `EV-0037` | `WR-M06` | Must |
| Browser-safe C# loader/dispatch absent | `EV-0037` | `WR-S01` | Should |
| JavaScript adapter boundary absent | `EV-0037` | `WR-M11` | Must |
| Dependency/asset lock/provenance pipeline absent | `EV-0039` | `WR-M12` | Must |
| Security threat model/default/conformance absent | `EV-0038` | `WR-M07`,`WR-M13` | Must |
| Accessibility interaction contract absent | `EV-0037` | `WR-M08` | Must |
| Weft CLI/scaffolding/diagnostic workflow incomplete | `EV-0035` | `WR-M10` | Must |
| Weft has no published bootstrap, pinned CLI/template compatibility, prerequisite diagnosis, update/removal, offline/mirror, or side-by-side-version contract | `EV-0053`–`EV-0059` | `WR-M10`,`WR-S08` | Must core / Should portable bootstrap |
| Weft-aware Development error overlay and generated/template source mapping absent | `EV-0045`,`EV-0046` | `WR-M10` | Must |
| Production semantic observability/deployment contract absent | `EV-0039` | `WR-M14` | Must |
| Native WebView shell profiles, lifecycle, bridge and conformance contract absent | `EV-0047`–`EV-0052` | `WR-S07` | Should |
| Compatibility/support/migration policy absent | `EV-0035` | `WR-M15` | Must |
| Comparable cross-platform performance evidence absent | BM-1 | `WR-C05` | Could / deferred |

## Documentation Audit and Proposed Changes

No silent edits are made to public `docs/` files in FEAT-001. These proposals
require owner approval:

| Proposal | Affected document | Evidence and reason | Approval state |
| --- | --- | --- | --- |
| Replace “recommend pnpm” with selection criteria and measured variants unless/until a benchmark supports one default. | `docs/package-ecosystem.md` — Interop mode | `EV-0032`, BM-1; efficiency depends on graph/workflow and is not reproduced here. | Pending owner |
| Add direct immutable asset retrieval as a supported future source beside NuGet/npm, with hash/license/provenance rules. | `docs/package-ecosystem.md` — source table/asset manifest | `WR-S05`; fulfills the owner’s `wget`-style goal without bypassing integrity. | Pending owner |
| Add explicit secure template contract and server-authoritative form policy. | `docs/architecture.md` — Rendering/DOM ownership | `WP-02`,`WR-M02`,`WR-M04`,`WR-M07`. | Pending owner |
| Add statelessness as a requirement for enhanced server actions and state that persistent circuits are not the default. | `docs/architecture.md` — Enhanced server action | `BP-02`,`WR-M06`,`WR-W02`. | Pending owner |
| Add the approved Must baseline and split implementation work into bounded FEATs before claiming alternative readiness. | `docs/roadmap.md` | WR-1; current roadmap omits renderer/templates/routing/forms/CLI as explicit gates. | Pending owner |
| Add version/support/migration policy milestone before public preview. | `docs/roadmap.md` Phase 0/6 | `WR-M15`. | Pending owner |
| Add a Development-only source-mapped error overlay milestone and an explicit Production diagnostic-disclosure gate. | `docs/roadmap.md` Phase 0/6 | `NQ-06`,`EV-0045`,`EV-0046`,`WR-M07`,`WR-M10`. | Pending owner |
| Add native-shell integration as a later Spike with one chosen shell family per application and hosted/static/desktop-sidecar modes rather than simultaneous wrappers or implied direct SSR mobile packaging. | `docs/roadmap.md` after asset/browser-boundary work | `EV-0047`–`EV-0052`,`WR-S07`; Tauri is the reference for Windows/Linux/Android coverage, iOS has a separate Apple pipeline, and Electron/Electrobun remain alternative desktop providers rather than companions in the same product. | Pending owner |
| Add the installation lifecycle: .NET-only pure prerequisite, verified release bootstrap, pinned local .NET tool, profile-aware `doctor`, locked/offline restore, explicit update/removal, and the distinction between installing Weft and retrieving application assets. | `docs/package-ecosystem.md` and `docs/roadmap.md` tooling/release milestones | `EV-0053`–`EV-0059`,`WR-M10`,`WR-M12`,`WR-S05`,`WR-S08`; specified in `installation-and-bootstrap-strategy.md`. | Pending owner |

README status language already distinguishes current versus future behavior and
needs no factual correction. Its architecture diagram is future build output;
the surrounding text should continue to label it as intended, not current.

## Proposed Follow-up FEAT Candidates

Candidates are deliberately not created as feature folders. Product-owner
approval of linked requirements and sequencing is required first.

| Candidate | Linked requirements | Bounded scope and acceptance | Dependencies | State |
| --- | --- | --- | --- | --- |
| `CAND-01 Feature package and safe HTML composition` | `WR-M01`,`WR-M02`,`WR-M03`,`WR-S03` | Extend manifest; implement safe template/layout/metadata/error states and typed routes; prove packaged RA-1 public slice. | Architecture choice for template model | Proposed, approval required |
| `CAND-02 Authoritative forms and stateless enhancement` | `WR-M04`,`WR-M05`,`WR-M06`,`WR-M08` | Implement RA-1 create/edit and partial filter with normal fallback, focus/history/cancellation/concurrency/idempotency. | `CAND-01` | Proposed, approval required |
| `CAND-03 Security and conformance foundation` | `WR-M07`,`WR-M13` | Threat model, secure defaults, public-boundary integration/security/accessibility fixtures. | Can begin with CAND-01 contracts | Proposed, approval required |
| `CAND-04 Assets and dependency provenance` | `WR-M09`,`WR-M12`,`WR-S05` | Hashed feature assets, locked direct assets, NuGet/global cache reporting, optional npm policy, SBOM/license output. | Manifest/package format | Proposed, approval required |
| `CAND-05 Browser C# and JS capability boundary` | `WR-M11`,`WR-S01`,`WR-S06` | Implement only RA-1 board capability and chart adapter with activation/cost/failure/disposal evidence. | CAND-01–04 public/security/asset contracts | Proposed, approval required |
| `CAND-06 CLI, bootstrap, diagnostics and lifecycle policy` | `WR-M07`,`WR-M10`,`WR-M12`,`WR-M15`,`WR-S04`,`WR-S08` | Verified Windows/Linux/macOS bootstrap artifacts; pinned local .NET tool and compatible templates; pure profile creation; add/remove/update dry-runs; `doctor`; locked/offline/mirror restore; side-by-side versions; stable diagnostics; manifest visualization; Development-only C#/template error overlay; Production disclosure tests; compatibility/support and one migration fixture. | Public contract inventory, release signing/provenance, package identity and source-mapping design | Proposed, approval required |
| `CAND-07 Operations and deployment conformance` | `WR-M14` | Self-host/container/reverse-proxy profiles, health/log/trace/metric semantics and deterministic publish checks. | Runtime contracts/assets | Proposed, approval required |
| `CAND-08 Comparable implementations and benchmark` | `WR-C05` | Implement approved RA-1 cohorts and execute BM-1; publish raw artifacts or no competitive result. | All functional candidates needed by chosen cohorts | Deferred; not Must/Should |
| `CAND-09 Native shell integration Spike` | `WR-M03`,`WR-M07`,`WR-M09`,`WR-M11`,`WR-M14`,`WR-S07` | Define shell descriptor/typed bridge; prove one Tauri application on Windows/Linux desktop and Android, including deep link/auth/lifecycle/permission/failure and production-disclosure fixtures. Record iOS as a separate Apple build/signing pipeline over the same contract. Evaluate Electron/Electrobun only as alternative-provider or migration Spikes, not simultaneous product dependencies. | CAND-01–05 assets, routes, security and browser bridge; CAND-06 dev overlay | Proposed, approval required |

## Decision Traceability Audit

- 26 quality mechanisms each have one Adopt/Adapt/Interoperate/Defer/Reject
  decision: **PASS**.
- 25 pains each have one Avoid/Mitigate/Accept/Not Applicable response:
  **PASS**.
- Every decision names architecture rationale and requirement destination:
  **PASS**.
- Public-document proposals are visible and pending rather than silently
  applied: **PASS**.
- Follow-up candidates are bounded, linked to WR-1 and explicitly unauthorized:
  **PASS**.
