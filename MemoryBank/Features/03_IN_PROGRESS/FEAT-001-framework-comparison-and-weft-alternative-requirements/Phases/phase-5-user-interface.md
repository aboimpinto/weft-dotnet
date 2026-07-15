# Phase 5 - User Interface

**Status:** PENDING
**Started:** -
**Completed:** -
**Duration:** -
**Primary Agent:** -
**Primary Model:** -
**Recommended Agent:** Implementation Agent
**Recommended Model:** OpenAI Codex Terra (`gpt-5.6-terra`)
**Estimated Human Time:** 3h
**Estimated AI Time:** 1h

## Routing Rationale

The UI work is an inspectable, framework-neutral acceptance specification rather than an implemented frontend. Implementation Agent can preserve parity across HTML-first, hydrated, and client-rendered models; `gpt-5.6-terra` remains the FEAT default model.

## Routing Decision History

- `2026-07-15T07:14:33Z` — **Start-Feature Post-Process Agent** selected **Implementation Agent / OpenAI Codex Terra (`gpt-5.6-terra`)** as the initial route. Expected impact: testable accessibility and browser observables without creating framework-specific behavior or tests.

Any later override must append, not replace, an entry containing previous route, selected route, decision maker, timestamp, reason, and expected impact.

## Objective

Complete the reference application's inspectable UI and accessibility acceptance contract without building a UI or inventing framework-specific client behavior.

## Source Context Used

- `planning-analysis-report.md`: `## Reference Workload Equivalence Rules` and `## Benchmark Comparability Gate`
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

- [ ] Read the Phase 1 planning handoff and the Phase 4 reference workload before adding UI acceptance detail.
- [ ] Add semantic HTML, visual, responsive, keyboard/focus, live-region, metadata, error, and not-found clauses (Concrete Task 1).
- [ ] Define normal and failure-state observables from initial load through capability failure (Concrete Task 2).
- [ ] Define canonical DOM ownership and adapter boundaries (Concrete Task 3).
- [ ] Define sustained-local activation, offline/local behavior, recovery, disposal, and memory-measurement boundary (Concrete Task 4).
- [ ] Define future browser/accessibility/security evidence categories and fixture names without creating test/source files (Concrete Task 5).
- [ ] Verify equal UI expectations across rendering approaches (Concrete Task 6).
- [ ] Validation gate: complete `reference-workload-review` and `documentation-consistency-review`; record the updated specification path.
- [ ] Review follow-up: resolve parity or observability findings before Phase 6 consumes the frozen UI contract.
- [ ] Finalization: update this ledger and Hepha task state, then hand off UI observables to Phase 6.

## Hepha Task State

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

## Expected Files, Components, And Contracts

- Updated `reference-application-spec.md`
- UI contract: semantic landmarks, focus/history/live-region rules, visual states, responsive expectations, DOM ownership, and adapter boundary.
- Public code entry points: Not applicable; future implementations own their framework-specific entry points.

## Verification Intent

Use `reference-workload-review` and `documentation-consistency-review`; future UI implementation will require `ui-tests` and accessibility evidence through the public browser behavior, not helper-only coverage.

## Required Evidence

An inspectable UI acceptance section with all normal and failure states, plus an explicit future evidence plan for accessibility and browser behavior.

## Quality Gate Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | missing | Implementation worker must record the reference specification and planning artifact paths updated by the UI-contract work. |
| Tests | not applicable | UI-contract scope plans future acceptance tests but changes no executable UI. |
| Gherkin/Playwright E2E | not applicable | No browser UI is implemented in this research phase; future reference implementations must supply browser evidence. |
| Code review | not applicable | UI-contract scope is documentation-only; independent reference-workload review is required before Phase 6. |

## Acceptance Criteria

- Browser-visible normal, error, cancellation, fallback, and capability-failure behavior is observable and framework-neutral.
- Accessibility and DOM ownership rules are concrete enough to test in later implementations.
- No Gherkin/Playwright coverage is falsely claimed for unimplemented UI.

## Completion Gate

Phase 6 can use the frozen UI observables and local-interaction boundaries in the benchmark methodology.

## Blockers Or Assumptions

Assumes the reference application remains a specification. If implementation begins, create a separate evidence-gated FEAT with focused browser tests.