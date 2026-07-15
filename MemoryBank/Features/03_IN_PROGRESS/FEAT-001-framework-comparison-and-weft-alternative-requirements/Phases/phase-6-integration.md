# Phase 6 - Integration

**Status:** PENDING
**Started:** -
**Completed:** -
**Duration:** -
**Primary Agent:** -
**Primary Model:** -
**Recommended Agent:** Implementation Agent
**Recommended Model:** OpenAI Codex Terra (`gpt-5.6-terra`)
**Estimated Human Time:** 6h
**Estimated AI Time:** 3h

## Routing Rationale

This is controlled synthesis of matrix, pain, workload, and benchmark evidence into requirements and decisions; no runtime integration is implemented. Implementation Agent using the default `gpt-5.6-terra` model best preserves traceability and the comparable-benchmark gate across those inputs.

## Routing Decision History

- `2026-07-15T07:14:33Z` — **Start-Feature Post-Process Agent** selected **Implementation Agent / OpenAI Codex Terra (`gpt-5.6-terra`)** as the initial route. Expected impact: a reproducible methodology and requirements catalog that does not fabricate performance conclusions.

Any later override must append, not replace, an entry containing previous route, selected route, decision maker, timestamp, reason, and expected impact.

## Objective

Integrate the capability, pain, and shared-workload evidence into a reproducible benchmark methodology, a ranked Weft requirement catalog, and explicit decision/gap backlog.

## Source Context Used

- `planning-analysis-report.md`: `## Benchmark Comparability Gate`, `## Requirement Ranking Rules`, and `## Decision And Approval Boundaries`
- `framework-comparison-report.md`
- `praised-qualities-and-pains.md`
- `reference-application-spec.md`, including UI observables
- `FeatureDescription.md`: benchmark plan, requirement hypotheses, deliverables, and acceptance criteria

## Task Details

1. Create `benchmark-methodology.md` defining pinned platform/runtime versions, hardware, production configuration, database/network fixtures, cold/warm state, sample counts, collection boundaries, and report schema.
2. Include all required dependency, development-loop, build/output, request/bytes, timing, server load, per-user state, browser memory, failure, accessibility, security, and operational measurements.
3. State comparability exclusions: unrelated vendor numbers cannot populate results; mismatched workload, hardware, topology, versions, or cache state are hypotheses only.
4. Create `weft-alternative-requirements.md`; deduplicate initial hypotheses and rank Must/Should/Could/Won't with user value, source evidence, avoided pain, measurable acceptance, status, and roadmap destination.
5. Enforce the saved Deep-Dive comparable-benchmark gate: performance requirements remain deferred/hypothesis until like-for-like measurements exist.
6. Create `weft-gap-and-decision-backlog.md`; map every competitor mechanism to Adopt/Adapt/Interoperate/Defer/Reject and significant pain to Avoid/Mitigate/Accept/Not Applicable, with rationale and owner-approved follow-up boundary.
7. Propose bounded follow-up FEAT candidates only for approved Must/Should items that meet the EPIC evidence and acceptance gate.

## Phase Task Ledger

- [ ] Read the Phase 1 planning handoff and Phase 2–5 evidence/contract handoffs before synthesis.
- [ ] Create the pinned-environment, fixture, state, collection, and reporting benchmark methodology (Concrete Task 1).
- [ ] Include all required measurement categories and boundaries (Concrete Task 2).
- [ ] State and enforce comparability exclusions (Concrete Task 3).
- [ ] Create the deduplicated, traceable Must/Should/Could/Won't requirements catalog (Concrete Task 4).
- [ ] Apply the comparable-benchmark gate to performance requirements (Concrete Task 5).
- [ ] Create the controlled mechanism/pain decision and gap backlog (Concrete Task 6).
- [ ] Propose only bounded, approval-gated follow-up FEAT candidates (Concrete Task 7).
- [ ] Validation gate: complete `benchmark-comparability-review` and `decision-traceability-audit`; record all three deliverable paths.
- [ ] Review follow-up: resolve missing upstream links, unbounded follow-ups, or benchmark-gate violations before Phase 7 audit.
- [ ] Finalization: update this ledger and Hepha task state, then hand off the synthesis package to Phase 7.

## Hepha Task State

| Ledger item | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- |
| Prerequisite handoff read | NOT_STARTED | - | - | - |
| Benchmark methodology | NOT_STARTED | - | - | - |
| Measurement categories | NOT_STARTED | - | - | - |
| Comparability exclusions | NOT_STARTED | - | - | - |
| Ranked requirements catalog | NOT_STARTED | - | - | - |
| Performance gate | NOT_STARTED | - | - | - |
| Decision and gap backlog | NOT_STARTED | - | - | - |
| Bounded follow-up candidates | NOT_STARTED | - | - | - |
| Validation gate | NOT_STARTED | - | - | - |
| Review follow-up | NOT_STARTED | - | - | - |
| Finalization | NOT_STARTED | - | - | - |

## Expected Files, Components, And Contracts

- `benchmark-methodology.md`
- `weft-alternative-requirements.md`
- `weft-gap-and-decision-backlog.md`
- Integration contract: shared workload feeds measurements; evidence/pain findings feed requirements; decisions feed only approved follow-ups.
- Public code entry points: Not applicable; no integration runtime is implemented.

## Verification Intent

Use `benchmark-comparability-review` and `decision-traceability-audit` to ensure every requirement and decision has valid upstream evidence and no performance conclusion bypasses the gate.

## Required Evidence

Complete methodology, ranked catalog, decision backlog, and traceability links to matrix, pain catalog, and reference specification.

## Quality Gate Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | missing | Implementation worker must list the methodology, requirement catalog, decision backlog, and planning artifact paths updated by this phase. |
| Tests | not applicable | Integration scope composes research documentation and does not change executable integration behavior. |
| Gherkin/Playwright E2E | not applicable | Integration scope defines future measurement and browser evidence but implements no browser behavior. |
| Code review | not applicable | Integration scope is documentation-only; comparability and decision-traceability audits are the required phase review. |

## Acceptance Criteria

- Benchmark methodology is reproducible and refuses incomparable measurements.
- Every Must requirement has user value, competitor evidence, avoided pain, measurable acceptance, and roadmap destination.
- All competitor mechanisms and significant pains receive explicit decisions.

## Completion Gate

No requirement lacks traceability, no performance requirement bypasses the comparable-benchmark gate, and every proposed follow-up is bounded.

## Blockers Or Assumptions

Comparable measurements are intentionally unavailable in the evidence-baseline milestone. Their absence requires deferral, not invented benchmarks.