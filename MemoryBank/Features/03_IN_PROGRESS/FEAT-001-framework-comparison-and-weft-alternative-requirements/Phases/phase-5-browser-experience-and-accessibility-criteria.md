# Phase 5 - Browser Experience and Accessibility Criteria

**Status:** COMPLETED
**Started:** -
**Completed:** 2026-07-15
**Duration:** -
**Work Type:** R&D / Documentation Spike
**Execution Mode:** Manual research in the active agent conversation
**Research Owner:** Paulo Aboim Pinto with the active agent
**Estimated Human Time:** 3h
**Estimated AI Time:** 1h

## Research Rationale

This phase defines observable browser, accessibility, resilience, and
interaction criteria for the shared reference workload. It does not implement
a user interface.

## Historical Generation Record

- Hepha generated the original skeleton on 2026-07-15. The former development
  routing is historical and does not turn this phase into UI implementation.

## Objective

Complete the reference application's inspectable UI and accessibility acceptance contract without building a UI or inventing framework-specific client behavior.

## Source Context Used

- `research-methodology-and-evidence-contract.md`: `## Reference Workload Equivalence Rules` and `## Benchmark Comparability Gate`
- `reference-application-spec.md`: route, role, failure, partial-update, and local-interaction sections
- `FeatureDescription.md`: shared reference application and accessibility requirements
- Weft architecture: HTML durability, explicit regions, and browser boundary

## Task Details

1. Add precise semantic-HTML, visual hierarchy, responsive, keyboard, focus, live-region, metadata, error, and not-found acceptance clauses to `reference-application-spec.md`.
2. Define observable initial-page, validation-error, save-success, cancellation, slow-response, retry, stale-response, partial-update, failed-asset, and enhanced/local-capability failure states.
3. Define the canonical DOM ownership and adapter boundaries for the server-owned partial update and third-party JavaScript component.
4. Define the sustained local interaction's activation cue, offline/local behavior, loading indicator, failure recovery, disposal expectation, and browser-memory measurement boundary.
5. Define future browser/accessibility/security evidence categories and fixture naming. Do not create Gherkin, Playwright, or source files in refinement.
6. Verify that the UI contract remains comparable across HTML-first, hydrated, and client-rendered approaches and that no framework gets weaker acceptance expectations.

## Phase Task Ledger

- [x] Read the Phase 1 planning handoff and the Phase 4 reference workload before adding UI acceptance detail.
- [x] Add semantic HTML, visual, responsive, keyboard/focus, live-region, metadata, error, and not-found clauses (Concrete Task 1).
- [x] Define normal and failure-state observables from initial load through capability failure (Concrete Task 2).
- [x] Define canonical DOM ownership and adapter boundaries (Concrete Task 3).
- [x] Define sustained-local activation, offline/local behavior, recovery, disposal, and memory-measurement boundary (Concrete Task 4).
- [x] Define future browser/accessibility/security evidence categories and fixture names without creating test/source files (Concrete Task 5).
- [x] Verify equal UI expectations across rendering approaches (Concrete Task 6).
- [x] Validation gate: complete `reference-workload-review` and `documentation-consistency-review`; record the updated specification path.
- [x] Review follow-up: resolve parity or observability findings before Phase 6 consumes the frozen UI contract.
- [x] Finalization: update this research ledger and record the manual handoff, then hand off UI observables to Phase 6.

## Historical Hepha Task State (Non-Authoritative)

| Ledger item | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- |
| Prerequisite handoff read | NOT_STARTED | - | - | - |
| Semantic and accessibility clauses | NOT_STARTED | - | - | - |
| Normal and failure observables | NOT_STARTED | - | - | - |
| DOM and adapter boundaries | NOT_STARTED | - | - | - |
| Sustained-local interaction boundary | NOT_STARTED | - | - | - |
| Future evidence plan | NOT_STARTED | - | - | - |
| Cross-rendering parity check | NOT_STARTED | - | - | - |
| Validation gate | NOT_STARTED | - | - | - |
| Review follow-up | NOT_STARTED | - | - | - |
| Finalization | NOT_STARTED | - | - | - |

## Expected Research Artifacts And Contracts

- Updated `reference-application-spec.md`
- UI contract: semantic landmarks, focus/history/live-region rules, visual states, responsive expectations, DOM ownership, and adapter boundary.
- Public code entry points: Not applicable; future implementations own their framework-specific entry points.

## Research Validation Intent

Use `reference-workload-review` and `documentation-consistency-review`; future UI implementation will require `ui-tests` and accessibility evidence through the public browser behavior, not helper-only coverage.

## Required Evidence

An inspectable UI acceptance section with all normal and failure states, plus an explicit future evidence plan for accessibility and browser behavior.

## Research Review Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | recorded | Browser/accessibility clauses in `reference-application-spec.md` and this phase ledger. |
| Tests | not applicable | UI-contract scope plans future acceptance tests but changes no executable UI. |
| Gherkin/Playwright E2E | not applicable | No browser UI is implemented in this research phase; future reference implementations must supply browser evidence. |
| Research review | passed | The specification's parity, accessibility, DOM-ownership, and failure-state clauses pass the reference-workload review. |

## Manual Phase Completion Evidence

The frozen RA-1 contract defines semantic landmarks, responsive behavior,
keyboard/focus/history rules, live announcements, error/loading/not-found
states, canonical server and capability DOM ownership, activation failure,
recovery/disposal, and future public-browser evidence categories. It claims no
Playwright, accessibility, or browser execution result because no reference
implementation was built in this FEAT.

## Acceptance Criteria

- Browser-visible normal, error, cancellation, fallback, and capability-failure behavior is observable and framework-neutral.
- Accessibility and DOM ownership rules are concrete enough to test in later implementations.
- No Gherkin/Playwright coverage is falsely claimed for unimplemented UI.

## Completion Gate

Phase 6 can use the frozen UI observables and local-interaction boundaries in the benchmark methodology.

## Blockers Or Assumptions

Assumes the reference application remains a specification. If implementation begins, create a separate evidence-gated FEAT with focused browser tests.
