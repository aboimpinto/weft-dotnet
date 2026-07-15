# Phase 3 - Business Logic

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

This evidence-interpretation phase compares platform qualities and pains without promoting preferences to facts. It needs a cross-platform research owner who can enforce the Phase 1/2 contracts, so Implementation Agent with the default `gpt-5.6-terra` route is appropriate.

## Routing Decision History

- `2026-07-15T07:14:33Z` — **Start-Feature Post-Process Agent** selected **Implementation Agent / OpenAI Codex Terra (`gpt-5.6-terra`)** as the initial route. Expected impact: traceable pain analysis that distinguishes framework, ecosystem, hosting, application, and team causes.

Any later override must append, not replace, an entry containing previous route, selected route, decision maker, timestamp, reason, and expected impact.

## Objective

Turn the Phase 2 capability baseline into disciplined praised-quality and pain analysis without mistaking preference, ecosystem effects, or architecture hypotheses for framework facts.

## Source Context Used

- `planning-analysis-report.md`: `## Pain And Quality Analysis Rules` and `## Decision And Approval Boundaries`
- `framework-comparison-report.md`: `## Capability Matrix`
- `FeatureDescription.md`: Praised Qualities And Pain Analysis and Evidence Policy
- EPIC-001 guardrails and risks

## Task Details

1. Create `praised-qualities-and-pains.md` with separate platform sections and a common evidence schema.
2. Record at least five material praised qualities and five material pains per mandatory platform.
3. For each quality identify user problem solved, evidence, affected workload, and the preliminary Weft mechanism response: Adopt, Adapt, Interoperate, Defer, or Reject.
4. For each pain record trigger, affected workload/team, consequence, workaround, workaround cost, severity, confidence, evidence grade, and classification (essential complexity, implementation limitation, configurable default, or ecosystem/tooling consequence).
5. Assign the Weft pain response: Avoid, Mitigate, Accept, or Not Applicable, with architectural rationale.
6. Cross-link every finding to the capability matrix and label all inference/hypothesis/prediction states; preserve unresolved findings for Phase 6 rather than creating a premature requirement.

## Phase Task Ledger

- [ ] Read the Phase 1 planning handoff and Phase 2 matrix, then create the common-schema platform catalog (Concrete Task 1).
- [ ] Record the required material praised qualities and pains for each platform, or an evidenced scope limitation (Concrete Task 2).
- [ ] Capture quality evidence, affected workload, and preliminary Weft mechanism response (Concrete Task 3).
- [ ] Capture each pain's trigger, consequence, workaround/cost, severity, confidence, grade, and classification (Concrete Task 4).
- [ ] Assign the controlled Weft pain response with architectural rationale (Concrete Task 5).
- [ ] Cross-link matrix evidence, label conclusion states, and preserve unresolved findings for Phase 6 (Concrete Task 6).
- [ ] Validation gate: complete `source-provenance-audit` and `decision-traceability-audit`; record exact catalog and source paths.
- [ ] Review follow-up: resolve unsupported or Grade-D-only claims by evidence, limitation, or explicit lead status before requirement synthesis.
- [ ] Finalization: update this ledger and Hepha task state, then hand off controlled decision inputs to Phase 6.

## Hepha Task State

| Ledger item | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- |
| Common-schema catalog | NOT_STARTED | - | - | - |
| Per-platform coverage | NOT_STARTED | - | - | - |
| Quality records | NOT_STARTED | - | - | - |
| Pain records | NOT_STARTED | - | - | - |
| Pain-response decisions | NOT_STARTED | - | - | - |
| Cross-links and deferred findings | NOT_STARTED | - | - | - |
| Validation gate | NOT_STARTED | - | - | - |
| Review follow-up | NOT_STARTED | - | - | - |
| Finalization | NOT_STARTED | - | - | - |

## Expected Files, Components, And Contracts

- `praised-qualities-and-pains.md`
- Decision contract: controlled mechanism and pain-response vocabulary with traceable rationale.
- Public code entry points: Not applicable.

## Verification Intent

Use `source-provenance-audit` and `decision-traceability-audit` to check that every pain has a real trigger and workaround rather than an unverified complaint.

## Required Evidence

Platform-by-platform catalog with the minimum quality/pain coverage, evidence fields, classifications, and Weft response decision.

## Quality Gate Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | missing | Implementation worker must list the pain catalog and linked matrix/planning artifact paths updated by this phase. |
| Tests | not applicable | Business-analysis scope changes research documentation only, not executable business behavior. |
| Gherkin/Playwright E2E | not applicable | Business-analysis scope does not implement browser behavior or the reference application. |
| Code review | not applicable | Business-analysis scope is documentation-only; decision traceability audit is the phase review evidence. |

## Acceptance Criteria

- Each platform has five material praised qualities and five material pains or a clearly evidenced scope limitation.
- Every pain identifies trigger, consequence, workaround, workaround cost, severity, and confidence.
- Framework, language, hosting, application design, and team-practice causes are kept distinct.

## Completion Gate

All decisions have matrix/source links and no pain is promoted solely from Grade-D anecdote.

## Blockers Or Assumptions

Recurring pain claims require corroboration. If only anecdotal evidence is available, retain it as a labelled lead rather than a requirement source.