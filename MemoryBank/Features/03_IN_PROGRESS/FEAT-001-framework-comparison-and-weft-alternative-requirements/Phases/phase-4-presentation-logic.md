# Phase 4 - Presentation Logic

**Status:** PENDING
**Started:** -
**Completed:** -
**Duration:** -
**Primary Agent:** -
**Primary Model:** -
**Recommended Agent:** Implementation Agent
**Recommended Model:** OpenAI Codex Terra (`gpt-5.6-terra`)
**Estimated Human Time:** 4h
**Estimated AI Time:** 2h

## Routing Rationale

The phase defines a framework-neutral reference workload across server, browser, security, and integration boundaries; it does not implement a .NET component. Implementation Agent is therefore preferred for maintaining cross-platform contract equivalence, using the default `gpt-5.6-terra` model.

## Routing Decision History

- `2026-07-15T07:14:33Z` — **Start-Feature Post-Process Agent** selected **Implementation Agent / OpenAI Codex Terra (`gpt-5.6-terra`)** as the initial route. Expected impact: a complete observable workload without selecting a framework-specific implementation strategy.

Any later override must append, not replace, an entry containing previous route, selected route, decision maker, timestamp, reason, and expected impact.

## Objective

Specify the shared modular business application so later framework implementations and measurements exercise equivalent server, data, rendering, fallback, security, and integration responsibilities.

## Source Context Used

- `planning-analysis-report.md`: `## Reference Workload Equivalence Rules`
- `FeatureDescription.md`: Shared Reference Application Specification
- `framework-comparison-report.md` and `praised-qualities-and-pains.md`
- Current Weft architecture and package policy

## Task Details

1. Create `reference-application-spec.md` with domain vocabulary, seeded data, roles, authorization assumptions, and canonical route/feature map.
2. Define public list/detail/search/filter/sort/pagination; shared and nested layouts; metadata; loading/error/not-found states; and public versus protected boundaries.
3. Define authenticated role-protected administration create/edit workflow with server/client validation expectations, antiforgery, cancellation, errors, duplicate-submit and stale-response behavior, and post-success navigation.
4. Define data loading, mutation, cache invalidation, slow response, retry, and one server-owned partial update with canonical fallback semantics.
5. Define a sustained local interaction and a third-party JavaScript component behind bounded adapters; state which data remains server-authoritative and which browser state is disposable.
6. Define feature-owned CSS/assets, content-hash expectations, deployment health signals, test fixture parity, and failure fixtures without implementing them.

## Phase Task Ledger

- [ ] Read the Phase 1 planning handoff and prerequisite matrix/pain handoffs before defining the reference workload.
- [ ] Define domain vocabulary, seeded data, roles, authorization, and the route/feature map (Concrete Task 1).
- [ ] Define public routes, layouts, metadata, loading/error/not-found states, and public/protected boundaries (Concrete Task 2).
- [ ] Define the authenticated administration workflow, validation, antiforgery, failure, and navigation observables (Concrete Task 3).
- [ ] Define loading/mutation/cache/failure behavior and the server-owned partial-update fallback (Concrete Task 4).
- [ ] Define sustained-local interaction and third-party JavaScript adapter boundaries with server authority (Concrete Task 5).
- [ ] Define feature assets, deployment signals, fixture parity, and failure fixtures (Concrete Task 6).
- [ ] Validation gate: complete `reference-workload-review` and record the specification and planning-artifact evidence.
- [ ] Review follow-up: resolve ambiguous observable or fixture rules before Phase 5 adds UI acceptance clauses.
- [ ] Finalization: update this ledger and Hepha task state, then hand off the frozen workload contract to Phases 5–6.

## Hepha Task State

| Ledger item | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- |
| Prerequisite handoff read | NOT_STARTED | - | - | - |
| Domain, data, roles, and routes | NOT_STARTED | - | - | - |
| Public/protected route states | NOT_STARTED | - | - | - |
| Administration workflow | NOT_STARTED | - | - | - |
| Partial-update fallback | NOT_STARTED | - | - | - |
| Local interaction and adapter boundary | NOT_STARTED | - | - | - |
| Assets, signals, and fixtures | NOT_STARTED | - | - | - |
| Validation gate | NOT_STARTED | - | - | - |
| Review follow-up | NOT_STARTED | - | - | - |
| Finalization | NOT_STARTED | - | - | - |

## Expected Files, Components, And Contracts

- `reference-application-spec.md`
- Data contract: seeded entities, fixtures, role permissions, error fixtures, and comparable API/action outcomes.
- UI/API/integration contract: route map, fallback action behavior, partial-update response boundary, local-capability boundary, and JavaScript adapter ownership.
- Public code entry points: Not applicable; this is a specification phase.

## Verification Intent

Use `reference-workload-review` to confirm that each platform can be measured against the same routes, data, roles, failures, and observable outcomes.

## Required Evidence

A self-contained specification that an independent implementer can use without inventing requirements.

## Quality Gate Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | missing | Implementation worker must record the reference specification and planning artifact paths updated in this phase. |
| Tests | not applicable | Presentation-specification scope defines future tests but changes no executable behavior. |
| Gherkin/Playwright E2E | not applicable | This phase plans future browser evidence and does not implement browser behavior. |
| Code review | not applicable | Presentation-specification scope is documentation-only; reference-workload review provides the phase review. |

## Acceptance Criteria

- Seed data, journeys, roles, failure fixtures, security assumptions, and visual acceptance are fixed across implementations.
- Server-authoritative and browser-local boundaries are explicit.
- The specification includes all required public/admin, form, partial-update, sustained-local, bridge, asset, and operational scenarios.

## Completion Gate

The specification is detailed enough for independent implementation and feeds Phase 5 without relying on unstated UI assumptions.

## Blockers Or Assumptions

The phase must not select a specific framework implementation strategy; it defines observable workload, not the winner.