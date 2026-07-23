# Phase 6 - Weft Requirements and Decision Synthesis

**Status:** COMPLETED
**Started:** -
**Completed:** 2026-07-15
**Duration:** -
**Work Type:** R&D / Documentation Spike
**Execution Mode:** Manual research in the active agent conversation
**Research Owner:** Paulo Aboim Pinto with the active agent
**Estimated Human Time:** 6h
**Estimated AI Time:** 3h

## Research Rationale

This phase converts the capability, pain, and reference-workload evidence into
ranked Weft requirements, benchmark rules, and explicit product decisions.

## Historical Generation Record

- Hepha generated the original skeleton on 2026-07-15. The former development
  routing is historical; no runtime integration is part of this phase.

## Objective

Integrate the capability, pain, and shared-workload evidence into a reproducible benchmark methodology, a ranked Weft requirement catalog, and explicit decision/gap backlog.

## Source Context Used

- `research-methodology-and-evidence-contract.md`: `## Benchmark Comparability Gate`, `## Requirement Ranking Rules`, and `## Decision And Approval Boundaries`
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

- [x] Read the Phase 1 planning handoff and Phase 2–5 evidence/contract handoffs before synthesis.
- [x] Create the pinned-environment, fixture, state, collection, and reporting benchmark methodology (Concrete Task 1).
- [x] Include all required measurement categories and boundaries (Concrete Task 2).
- [x] State and enforce comparability exclusions (Concrete Task 3).
- [x] Create the deduplicated, traceable Must/Should/Could/Won't requirements catalog (Concrete Task 4).
- [x] Apply the comparable-benchmark gate to performance requirements (Concrete Task 5).
- [x] Create the controlled mechanism/pain decision and gap backlog (Concrete Task 6).
- [x] Propose only bounded, approval-gated follow-up FEAT candidates (Concrete Task 7).
- [x] Validation gate: complete `benchmark-comparability-review` and `decision-traceability-audit`; record all three deliverable paths.
- [x] Review follow-up: resolve missing upstream links, unbounded follow-ups, or benchmark-gate violations before Phase 7 audit.
- [x] Finalization: update this research ledger and record the manual handoff, then hand off the synthesis package to Phase 7.

## Historical Hepha Task State (Non-Authoritative)

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

## Expected Research Artifacts And Contracts

- `benchmark-methodology.md`
- `weft-alternative-requirements.md`
- `weft-gap-and-decision-backlog.md`
- `installation-and-bootstrap-strategy.md` (owner-requested synthesis addendum)
- Integration contract: shared workload feeds measurements; evidence/pain findings feed requirements; decisions feed only approved follow-ups.
- Public code entry points: Not applicable; no integration runtime is implemented.

## Research Validation Intent

Use `benchmark-comparability-review` and `decision-traceability-audit` to ensure every requirement and decision has valid upstream evidence and no performance conclusion bypasses the gate.

## Required Evidence

Complete methodology, ranked catalog, decision backlog, and traceability links to matrix, pain catalog, and reference specification.

## Research Review Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | recorded | `benchmark-methodology.md`, `weft-alternative-requirements.md`, `weft-gap-and-decision-backlog.md`, `installation-and-bootstrap-strategy.md`, and this phase ledger. |
| Tests | not applicable | Integration scope composes research documentation and does not change executable integration behavior. |
| Gherkin/Playwright E2E | not applicable | Integration scope defines future measurement and browser evidence but implements no browser behavior. |
| Research review | passed | The methodology's comparability review and both synthesis deliverables' traceability audits pass. |

## Manual Phase Completion Evidence

BM-1 pins cohorts, fixtures, cold/warm states, environment fields, measurement
categories, exclusions, sampling, and reporting while leaving results
`METHODOLOGY_ONLY`. WR-1 contains fifteen Must, eight Should, five Could, and
seven Won't/Non-goal proposals. WD-1 maps all 26 quality mechanisms and 25
pains, records the current gap, and proposes nine bounded but unauthorized
follow-up candidates. DNS-1 extends the synthesis with Development error and
native WebView shell contracts. IBS-1 adds the official installation comparison
and verified bootstrap/local-tool/restore/update/removal proposal, expanding
CAND-06 without authorizing implementation.

## Acceptance Criteria

- Benchmark methodology is reproducible and refuses incomparable measurements.
- Every Must requirement has user value, competitor evidence, avoided pain, measurable acceptance, and roadmap destination.
- All competitor mechanisms and significant pains receive explicit decisions.

## Completion Gate

No requirement lacks traceability, no performance requirement bypasses the comparable-benchmark gate, and every proposed follow-up is bounded.

## Blockers Or Assumptions

Comparable measurements are intentionally unavailable in the evidence-baseline milestone. Their absence requires deferral, not invented benchmarks.
