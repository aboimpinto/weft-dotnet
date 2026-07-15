# EPIC-001: Competitive Parity And Differentiated Web Platform

| Field | Value |
| --- | --- |
| Epic ID | EPIC-001 |
| State | InProgress |
| Created | 2026-07-15 |
| Target Completion | TBD - define after framework investigation |
| Owner | Paulo Aboim Pinto |
| Priority | High |
| External Reference | `MemoryBank/Overview/technical-overview.md` |

## Executive Summary

Establish the evidence-backed product requirements that Weft must satisfy to be
considered a credible alternative for modern modular web applications. Compare
Blazor, Next.js, TanStack Start, Angular, and the current/target Weft model
side-by-side using a five-platform evidence matrix. Identify what developers
praise, what recurring pain each platform introduces, and which qualities Weft
should adopt, adapt, avoid, integrate, or deliberately reject.

This EPIC is not an exercise in declaring one universal framework winner. It
defines the class of application for which Weft intends to be the better
choice, the parity capabilities required to enter that market, and the
measurable differentiators required to justify a new platform.

## Problem Statement

Weft has a coherent HTML-first architectural thesis, but its current repository
implements only generated server feature registration and one HTML-only
example. The project does not yet have a complete, evidence-backed capability
contract comparable to the routing, rendering, forms, state, data, tooling,
testing, packaging, deployment, and ecosystem support available in established
platforms.

Without a disciplined comparison, Weft risks one of two failures:

1. reproducing avoidable complexity and pain already visible in established
   platforms; or
2. concentrating on architectural novelty while omitting ordinary capabilities
   developers require before they will consider switching.

The project needs a shared reference workload, comparison rubric, source
quality policy, requirements catalog, and benchmark methodology before large
new framework mechanisms are selected.

## Product Position To Validate

> Weft is the HTML-first, C#-native platform for modern modular web
> applications: JavaScript-free by default, JavaScript-compatible by choice,
> and explicit about the cost and placement of every interaction.

The investigation must test this position rather than assume it is correct.
Blazor is the closest C# competitor. Next.js, TanStack Start, and Angular are
reference platforms for developer experience, modularity, rendering, data
flows, tooling, and ecosystem expectations.

## Hepha Deep-Dive Decisions

| Topic | Decision | Application |
| --- | --- | --- |
| Research boundary | Five-platform evidence matrix | Compare Blazor, Next.js, TanStack Start, Angular, and current/target Weft using versioned official sources plus clearly graded external evidence. |
| Reference workload | Modular business application | Define an authenticated multi-module CRUD workflow with forms, data access, validation, accessibility, and progressive enhancement. |
| Requirements gate | Evidence and acceptance gate | Create follow-up FEAT candidates only for ranked requirements with user value, competitor evidence, pain decision, measurable acceptance condition, and roadmap destination. |

## Success Criteria

- [ ] A versioned, source-linked five-platform evidence matrix covers Blazor,
  Next.js, TanStack Start, Angular, and both current and target Weft.
- [ ] The comparison uses versioned official sources as its primary evidence
  and clearly grades external evidence.
- [ ] The comparison separates documented capability, praised quality,
  recurring pain, workaround, and Weft inference instead of mixing them into a
  single opinion score.
- [ ] A shared modular business application specification makes later
  prototypes and measurements comparable.
- [ ] The reference application includes authenticated multi-module CRUD
  workflows, forms, data access, validation, accessibility, and progressive
  enhancement.
- [ ] A benchmark methodology defines server, browser, dependency, build,
  developer-loop, accessibility, security, and operational measurements.
- [ ] A ranked Weft requirements catalog defines Must, Should, Could, and
  explicit Won't/Non-goal items.
- [ ] Every Must requirement includes a user value, competitor evidence, pain
  to avoid, measurable acceptance condition, and likely roadmap destination.
- [ ] Each competitor strength receives an Adopt, Adapt, Interoperate, Defer,
  or Reject decision with rationale.
- [ ] Each significant competitor pain receives an Avoid, Mitigate, Accept, or
  Not Applicable decision with rationale.
- [ ] Current Weft documents are checked for contradictions, unsupported
  claims, missing capabilities, and roadmap gaps.
- [ ] Follow-up FEAT candidates are prepared only for ranked requirements that
  satisfy the evidence and acceptance gate; implementation does not begin
  merely because an idea appears in the comparison.

## Features Breakdown

| Feature ID | Title | Status | Dependencies | Priority |
| --- | --- | --- | --- | --- |
| FEAT-001 | Framework Comparison And Weft Alternative Requirements | IN PROGRESS | None | P0 |

Further features will be created only after FEAT-001 identifies bounded,
evidence-backed work that passes the evidence and acceptance gate. Expected
categories include reference-application implementations, developer experience,
rendering/composition, typed actions, asset/dependency management, browser
capabilities, and production hardening.

## Guardrails

- Do not claim that established platforms lack capabilities their current
  official documentation demonstrates.
- Do not treat popularity as proof of architectural quality or unpopularity as
  proof of technical weakness.
- Do not compare synthetic benchmark numbers produced with different workloads,
  hardware, deployment topology, runtime versions, or cache state.
- Do not classify individual preference as framework pain without evidence and
  an identified affected use case.
- Do not copy React, Angular, Blazor, Next.js, or TanStack mechanisms without
  first identifying the user problem the mechanism solves.
- Do not promise literal zero JavaScript bytes for a browser-side .NET runtime
  that currently requires JavaScript bootstrap/host infrastructure.
- Do not create a new package registry merely to avoid `node_modules`.
- Preserve JavaScript interoperability as an explicit product strength.

## Risks And Mitigations

| Risk | Impact | Mitigation |
| --- | --- | --- |
| Comparison becomes subjective advocacy | Requirements lose credibility | Require source grades, reproducible observations, and confidence labels |
| Scope expands across every web framework | Research never converges | Keep five mandatory platforms and treat others as targeted references |
| Feature parity becomes framework imitation | Weft loses its architectural identity | Map every candidate to Weft principles and an explicit decision |
| Marketing claims precede evidence | Early trust is damaged | Label facts, observations, hypotheses, and predictions separately |
| Reference apps are not equivalent | Performance conclusions become invalid | Define one modular business workload and measurement protocol before implementation |
| Pain is ecosystem- or team-specific | Weft solves the wrong problem | Record trigger, affected users, workaround, severity, and confidence |
