# Phase 2 - Framework Capability Profiles

**Status:** COMPLETED
**Started:** -
**Completed:** 2026-07-15
**Duration:** -
**Work Type:** R&D / Documentation Spike
**Execution Mode:** Manual research in the active agent conversation
**Research Owner:** Paulo Aboim Pinto with the active agent
**Estimated Human Time:** 7h
**Estimated AI Time:** 3h

## Research Rationale

The comparison needs consistent, versioned, official-source profiles for every
platform, with a strict boundary between Current Weft and Target Weft.

## Historical Generation Record

- Hepha generated the original skeleton on 2026-07-15. The former agent/model
  route is historical; the phase is now a manual framework-research activity.

## Objective

Build the auditable capability-data baseline: the 24-dimension comparison matrix for all mandatory platforms.

## Source Context Used

- `research-methodology-and-evidence-contract.md`: `## Evidence Taxonomy And Source Ledger`, `## Mandatory Platform Version Policy`, and `## Matrix Coverage Rules`
- `FeatureDescription.md`: Mandatory Platforms, Evidence Policy, and Required Comparison Matrix
- Current Weft repository evidence identified in Phase 0

## Task Details

1. Collect Grade-A official-source evidence for Blazor, Next.js App Router, TanStack Start plus named supporting packages, Angular, and Weft.
2. Record evaluated version/status and access date for every platform; record TanStack package maturity individually.
3. Populate all 24 dimensions with an evidence-backed capability, limitation, or explicit not-applicable/not-yet-implemented result.
4. Create `framework-comparison-report.md` with visible `Current Weft` and `Target Weft Hypothesis` separation; target claims must never populate current capability cells.
5. Link each material matrix entry to its source-ledger record and label its conclusion type and confidence.
6. Flag capability evidence that requires a later pain, workload, or benchmark decision rather than inferring a winner.

## Phase Task Ledger

- [x] Read the Phase 1 planning handoff and collect Grade-A official capability evidence for every mandatory platform (Concrete Task 1).
- [x] Record version/status, access date, and individual TanStack package maturity (Concrete Task 2).
- [x] Populate all 24 dimensions with evidence-backed or explicitly unavailable/not-implemented results (Concrete Task 3).
- [x] Create `framework-comparison-report.md` with visibly separate Current Weft and Target Weft Hypothesis sections (Concrete Task 4).
- [x] Link every material matrix entry to the canonical ledger and label conclusion type and confidence (Concrete Task 5).
- [x] Flag findings that must remain inputs to later pain, workload, or benchmark decisions (Concrete Task 6).
- [x] Validation gate: complete `source-provenance-audit` and `matrix-coverage-audit`; record exact report and ledger paths.
- [x] Review follow-up: resolve missing Grade-A fields or preserve them as explicit research gaps before Phase 3 or 6 consumes the matrix.
- [x] Finalization: update this research ledger and record the manual handoff, then hand off the auditable matrix.

## Historical Hepha Task State (Non-Authoritative)

| Ledger item | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- |
| Official-source collection | NOT_STARTED | - | - | - |
| Version and maturity record | NOT_STARTED | - | - | - |
| Twenty-four-dimension matrix | NOT_STARTED | - | - | - |
| Current/target Weft report separation | NOT_STARTED | - | - | - |
| Ledger links and labels | NOT_STARTED | - | - | - |
| Deferred-decision flags | NOT_STARTED | - | - | - |
| Validation gate | NOT_STARTED | - | - | - |
| Review follow-up | NOT_STARTED | - | - | - |
| Finalization | NOT_STARTED | - | - | - |

## Expected Research Artifacts And Contracts

- `framework-comparison-report.md`
- Data contract: one canonical matrix row/cell schema from the planning artifact.
- Public code entry points: Not applicable; repository source is evidence, not a change target.

## Research Validation Intent

Use `source-provenance-audit` and `matrix-coverage-audit`; verify exact 24-dimension coverage and target/current Weft separation.

## Required Evidence

Versioned official-source ledger and a complete five-platform matrix with explicit evidence state for each required dimension.

## Research Review Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | recorded | `framework-comparison-report.md` and this phase ledger. |
| Tests | not applicable | Evidence-matrix scope changes research documentation only, not executable behavior. |
| Gherkin/Playwright E2E | not applicable | Evidence-matrix scope introduces no browser behavior and does not implement the reference application. |
| Research review | passed | The report's `Source Provenance Audit` and `Matrix Coverage Audit` both pass. |

## Manual Phase Completion Evidence

`framework-comparison-report.md` records the 2026-07-15 version snapshot,
distinct TanStack package maturity, 24 complete dimension rows, separate
Current and Target Weft columns, and canonical `EV-####` official-source rows.
Unsupported competitive performance and security-superiority conclusions are
explicitly rejected rather than inferred.

## Acceptance Criteria

- All five mandatory platform entries include version/status, access date, deployment mode, and primary official sources.
- Every required dimension has evidence or an explicit unavailable state for every platform.
- TanStack Start and its supporting packages are not represented as one monolith.

## Completion Gate

No unlabelled inference, missing source field, or current/target Weft conflation remains in the matrix.

## Blockers Or Assumptions

A missing Grade-A source blocks a capability conclusion. It may be recorded as an open research gap but not asserted as fact.
