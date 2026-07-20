# Weft Product Requirements and Sequencing Overview

## Status

FEAT-001 proposes a readiness baseline of 15 Must, 8 Should, 5 Could, and 7
Won't/Non-goal requirements. These ranks are research proposals awaiting
product-owner approval. They do not authorize implementation.

## Proposed Must baseline

The Must requirements form one coherent evaluation baseline:

| Area | Required outcome | WR-1 records |
| --- | --- | --- |
| Feature ownership | One explicitly trusted package owns services, routes, policy metadata, actions, templates, assets, tests, fallback, and optional capabilities. | `WR-M01` |
| HTML composition | Safe encoded templates, layouts, fragments, metadata, loading/error/not-found states, and feature-local styling. | `WR-M02` |
| Navigation | Typed routes, parameters, query/search state, canonical URLs, and browser history. | `WR-M03` |
| Forms/actions | Server-authoritative binding, validation, authorization, antiforgery, cancellation, concurrency, idempotency, and typed errors. | `WR-M04` |
| Durable baseline | Script-disabled navigation and ordinary forms remain useful; pure mode needs no Node toolchain. | `WR-M05` |
| Enhancement | Stateless partial navigation/actions preserve fallback, URL/history, focus, accessibility, cancellation, and stale-response safety. | `WR-M06` |
| Security | Threat model, safe defaults, server authority, dependency policy, production-safe errors, and conformance tests. | `WR-M07` |
| Accessibility | Semantic HTML plus keyboard, focus, live-region, validation, loading, and failure contracts. | `WR-M08` |
| Assets | Feature-owned, hashed, cacheable, deterministic, inspectable production assets. | `WR-M09` |
| Developer experience | Pinned CLI, scaffolding, diagnostics, source mapping, hot feedback, `doctor`, update/removal, and offline/CI behavior. | `WR-M10` |
| JavaScript interop | Typed, lazy, least-privilege adapters with DOM ownership, failure fallback, and disposal. | `WR-M11` |
| Supply chain | Locked NuGet/assets, shared cache, integrity, provenance, license/SBOM, and explicit optional npm policy. | `WR-M12` |
| Testing | Generator, integration, browser, accessibility, security, fallback, and public-boundary conformance support. | `WR-M13` |
| Operations | Portable ASP.NET Core deployment, health, logging, traces, metrics, manifest visibility, and safe failure diagnosis. | `WR-M14` |
| Compatibility | Version, support, deprecation, migration, browser/tool matrix, and security-reporting policy. | `WR-M15` |

A public claim that Weft is a credible alternative should wait until the
approved Must baseline exists and representative applications prove it.

## Proposed Should capabilities

The Should set adds differentiation or later portability:

- lazy browser-safe C# for sustained-local interaction (`WR-S01`);
- an optional coherent local server-state cache (`WR-S02`);
- reusable loading/error/metadata boundaries (`WR-S03`);
- IDE navigation, refactoring, and manifest visualization (`WR-S04`);
- immutable direct-asset retrieval without npm (`WR-S05`);
- feature/capability budget reporting (`WR-S06`);
- a framework-neutral native WebView shell contract (`WR-S07`); and
- verified portable bootstrap and controlled-network installation (`WR-S08`).

## Could capabilities

Offline/PWA packaging, an npm restoration adapter, optimistic mutation helpers,
a maintained adapter catalog, and comparable benchmark execution remain Could
items. Benchmark execution becomes necessary before making competitive
performance claims, even though it is not required to build the first
functional baseline.

## Non-goals

Weft should not require Node, persistent server UI circuits, or browser .NET for
every route. It should not prohibit JavaScript, clone npm, own product visual
design, or make universal performance/security claims.

## Recommended implementation sequence

The original candidate list is useful as a theme map but is not yet safely
bounded. In particular, CLI/bootstrap/diagnostics and cross-platform native
shell work are too large for one implementation FEAT each. A safer sequence is:

1. **Manifest contract hardening** — immutable descriptors, duplicate endpoint
   names, action-mode validation, full route/action tests, and generated source
   diagnostics.
2. **Typed routes and feature ownership** — expand the manifest and prove
   package add/remove isolation.
3. **Safe HTML composition** — templates, encoding, layouts, metadata, loading,
   error, and not-found states.
4. **Authoritative forms/actions** — validation, auth, antiforgery, cancellation,
   concurrency, idempotency, and typed errors over ordinary HTTP.
5. **Stateless enhancement and accessibility** — partial replacement, fallback,
   history, focus, live regions, cancellation, and stale-response rules.
6. **Security and conformance foundation** — threat model, secure defaults,
   public-boundary fixtures, and production disclosure tests.
7. **Feature assets and deterministic publish** — ownership, collision checks,
   hashing, cache rules, and manifest output.
8. **Dependency integrity and direct assets** — locked restore, provenance,
   licenses/SBOM, shared cache, mirror/offline policy.
9. **Bounded JavaScript adapter** — one reference chart integration with
   ownership, failure, and disposal evidence.
10. **Browser C# capability Spike** — one board interaction, supported runtime
    APIs, activation cost, fallback, and disposal; do not commit to a platform
    architecture before the Spike passes.
11. **CLI and local project workflow** — local tool, templates, pure profile,
    `doctor`, deterministic restore, and side-by-side versions.
12. **Development diagnostics** — source-mapped template/generated errors and a
    strict Production exclusion contract.
13. **Release lifecycle** — signed bootstrap, update/migration/removal,
    compatibility/support, offline/mirror, and revocation.
14. **Operations/deployment conformance** — self-host, container, reverse proxy,
    health, telemetry, and deterministic release output.
15. **Native shell Spike** — begin with one host/OS slice, then add desktop and
    Android/iOS validation as separately costed phases.
16. **Equivalent implementations and benchmark execution** — only after the
    selected cohorts pass functional, accessibility, and security admission.

Each FEAT should have one primary contract, public-boundary acceptance, explicit
dependencies, and a size that can be reviewed independently.

## Approval decisions required

Before creating follow-up FEAT folders, the owner should:

1. approve or revise each Must/Should rank;
2. classify the adjacent omitted topics listed in the competitive overview;
3. decide whether Project Atlas needs an RA-2 revision for complete multi-module
   CRUD and other baseline workloads;
4. approve or reject the nine proposed public-document changes;
5. approve the implementation sequence and split oversized candidates; and
6. select the first evidence-producing slice.

`CAND-08` should be treated as deferred research/benchmark work, not as a
candidate that has passed the Must/Should gate, because its only direct
requirement is `WR-C05`.

## Detailed source

- [Requirements catalog](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-alternative-requirements.md)
- [Gap, decisions, and candidate backlog](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-gap-and-decision-backlog.md)
