# Phase 1 - Research Methodology and Evidence Contract

**Status:** COMPLETED
**Started:** -
**Completed:** 2026-07-15
**Duration:** -
**Work Type:** R&D / Documentation Spike
**Execution Mode:** Manual research in the active agent conversation
**Research Owner:** Paulo Aboim Pinto with the active agent
**Estimated Human Time:** 2h
**Estimated AI Time:** 1h

## Research Rationale

This phase establishes the evidence, versioning, comparability, and decision
rules that every later research phase must use.

## Historical Generation Record

- On 2026-07-15 Hepha generated and began this phase using development-task
  vocabulary. Its recorded work is retained as evidence, but remaining work is
  performed manually under the research method defined here.

## Objective

Create the canonical planning and evidence-control artifact that makes every later research phase comparable, traceable, and executable without future dependencies.

## Source Context Used

- `FeatureDescription.md`, including Evidence Policy, 24 dimensions, deliverables, acceptance criteria, and saved Deep-Dive decisions
- `FeatureTasks.md`, especially dependency ordering and phase policy
- EPIC-001 `EpicDescription.md`
- Current Weft overview, architecture, package policy, roadmap, source, example, and tests

## Task Details

1. Create `research-methodology-and-evidence-contract.md` with `## Scope And Phase-Dependency Summary` followed immediately by `## Research Phase Index`.
2. Give the index one row for each Phase 0–8 and exactly these columns: `Phase`, `Planning sections / heading references`, `Research obligations / observable boundaries`, and `Acceptance evidence / handoff`. Use semantic Markdown headings, not character ranges.
3. For each phase, name the exact report headings a researcher must read; name the observable contract boundary, or `Not applicable` where none exists; state the evidence and next consumer.
4. Add `## Evidence Taxonomy And Source Ledger`, `## Mandatory Platform Version Policy`, `## Matrix Coverage Rules`, `## Pain And Quality Analysis Rules`, `## Reference Workload Equivalence Rules`, `## Benchmark Comparability Gate`, `## Requirement Ranking Rules`, `## Decision And Approval Boundaries`, and `## FEAT And EPIC Acceptance Evidence Ledger`.
5. Define the canonical source-row fields: platform, dimension/claim, URL or repository, evaluated version/status, access date, evidence type/grade, confidence, conclusion label, scope limitation, and consumer deliverable.
6. Map every FEAT and EPIC criterion to one deliverable, phase, and evidence state. Mark reproduced measurements as deferred rather than fabricated.
7. Require later phases to read and update this report whenever new evidence changes a contract consumed by a future phase. If a prerequisite is unavailable, revisit this phase before beginning the consumer research.

## Phase Task Ledger

- [x] Create the durable `research-methodology-and-evidence-contract.md` handoff with the required scope/dependency summary and immediately following phase implementation index (Concrete Task 1).
- [x] Add all Phase 0–8 index rows with semantic headings, obligations/entry points, evidence, and handoffs (Concrete Tasks 2–3).
- [x] Add the required evidence, version, matrix, pain, workload, benchmark, ranking, approval, and acceptance-ledger sections (Concrete Task 4).
- [x] Define and preserve the canonical source-row field schema (Concrete Task 5).
- [x] Map every FEAT and EPIC criterion to phase, deliverable, and evidence state (Concrete Task 6).
- [x] State the consumer read/update rule and return-to-provider action for unavailable or changed prerequisites (Concrete Task 7).
- [x] Validation gate: complete `source-provenance-audit`, `decision-traceability-audit`, and `research-baseline-review`; record exact artifact paths.
- [x] Review follow-up: resolve schema/dependency findings before releasing the planning handoff to Phases 2–8.
- [x] Finalization: update this research ledger and record the manual handoff, then publish the canonical handoff.

## Concrete Task 1 Evidence

Created the canonical
`MemoryBank/Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/research-methodology-and-evidence-contract.md`.
Its `## Scope And Phase-Dependency Summary` records the research-only boundary,
Phase 0–8 producer/consumer dependency chain, high-level documentation contract,
explicit acceptance-artifact absences, cross-phase risks, future-consumer
expectations, and provider-return/update rule. `## Research Phase Index`
follows that summary immediately and has the four required columns. Its Phase
0–8 semantic navigation rows remain explicitly pending Concrete Tasks 2–3, so
no consumer phase can mistake this first increment for the released planning
contract. No runtime source, test, API, data, or UI behavior changed.

Verification passed without retries. A focused `python3 - <<'PY'` assertion
audit checked the canonical filename, required heading order and index columns,
checked bootstrap item, FeatureTasks trace, recovery lesson, legacy-filename
absence, unchanged LessonsLearned and `EpicAcceptanceTests.md` absences, and
trailing whitespace across all three touched documents; it printed
`planning-handoff-final-check: PASS` and
`heading order, index columns, task trace, expected absences, and whitespace: PASS`.
`git diff --check` passed with no output. These are documentation checks only;
the Phase 1 validation gate remains pending.

## Concrete Tasks 2–3 Evidence

Added one semantic navigation row for every Phase 0–8 to the canonical
`research-methodology-and-evidence-contract.md` `## Research Phase Index`. Each row names
exact planning headings, the phase-specific obligations and public-entry-point
or adapter applicability, its required audit/evidence, and its next consumer or
provider-return handoff. The rows preserve this FEAT's documentation-only
boundary while requiring future executable browser validators to exercise
public browser routes/actions and adapter boundaries rather than helper-only
coverage. They also keep consumer Phases 2–8 blocked until the referenced Phase
1 policy sections exist and the Phase 1 completion gate passes.

`FeatureTasks.md` now traces this incremental handoff without claiming that the
remaining Phase 1 schemas are complete. The selected checkbox and its Hepha
task-state row remain `IN_PROGRESS` for deterministic completion after this
worker handoff; no Hepha-owned status, FeatureTasks status cell, or quality-gate
decision was edited.

Focused documentation verification accounted for both attempts. Attempt 1 ran
the inline `phase-index-contract-audit` but stopped at an incorrect verifier
assertion that tested whether the summary text itself began with a heading;
`git diff --check` was therefore not reached. Attempt 2 corrected only that
audit assertion and passed: it printed `phase-index-contract-audit: PASS` and
`9 ordered rows, exact semantic headings, obligations/public boundaries,
evidence/handoffs, resume state, and whitespace: PASS`; the subsequently
chained `git diff --check` also passed with no output. Neither attempt ran a
build or executable test. Per-command elapsed time was not emitted; both local
attempts completed within the same validation window of less than one minute.
A final post-evidence focused rerun also passed, printing
`phase-index-contract-audit-final: PASS`; its chained `git diff --check` passed
with no output and the measured wall-clock duration was 21 ms. The broader
Phase 1 validation-gate audits remain pending their selected ledger item.

## Concrete Task 4 Evidence

Established all nine policy headings referenced by the Phase Implementation
Index in canonical `research-methodology-and-evidence-contract.md`: `Evidence Taxonomy And Source
Ledger`, `Mandatory Platform Version Policy`, `Matrix Coverage Rules`, `Pain
And Quality Analysis Rules`, `Reference Workload Equivalence Rules`, `Benchmark
Comparability Gate`, `Requirement Ranking Rules`, `Decision And Approval
Boundaries`, and `FEAT And EPIC Acceptance Evidence Ledger`.

The policies fix source grades and conclusion labels, per-platform version and
TanStack maturity treatment, 24-dimension coverage states, quality/pain schemas
and controlled response vocabularies, frozen framework-neutral workload
obligations, the like-for-like benchmark admission gate and deferred result
state, MoSCoW ranking/evidence rules, product-owner approval boundaries, and the
acceptance-ledger state vocabulary/template. They preserve Current Weft versus
Target Weft Hypothesis separation and explicitly defer reproduced measurements
rather than fabricating results. The report also marks the exact source-row
template, complete FEAT/EPIC criterion population, consumer return mechanics,
and broad Phase 1 audits as later unchecked ledger work; no later task was
preemptively claimed complete. `FeatureTasks.md` traces this incremental handoff
and continues to block Phases 2–8 until the remaining Phase 1 gates pass.

Focused documentation verification accounted for both initial attempts.
Attempt 1 ran the inline `phase-1-concrete-task-4-audit` but stopped before
`git diff --check` because its verifier expected the five conclusion labels on
one physical line while the valid prose wraps them across lines. No artifact
failure was found. Attempt 2 corrected only that assertion and passed, printing
`phase-1-concrete-task-4-audit: PASS` and `9 ordered policy sections, required
controls, deferred task boundaries, resume state, trace, and whitespace: PASS`;
the subsequently chained `git diff --check` passed with no output. The shell
did not emit per-attempt elapsed time; both completed in the same local
validation window of less than one minute. A final post-evidence rerun of the
same focused audit passed with `phase-1-concrete-task-4-audit-final: PASS`, and
its chained `git diff --check` passed with no output; the verifier measured
less than one second for the complete final command. Total validation wall-clock from Attempt 1
through the final rerun, including the evidence edit, was less than two minutes.
No build, executable test, Cargo command, or browser check is applicable to
this documentation-only task. The selected checkbox and Hepha
task-state row remain `IN_PROGRESS` for Hepha's deterministic completion update
after the worker handoff; no reserved lifecycle or quality-gate decision field
was edited.

## Concrete Task 5 Evidence

Defined `### Canonical Source-Row Schema` in the canonical
`research-methodology-and-evidence-contract.md`. Every evidence-producing deliverable must now use
one exact twelve-column `## Source Ledger` schema. It includes every required
claim-provenance field—platform, dimension/claim, URL or repository, evaluated
version/status, access date, evidence type/grade, confidence, conclusion label,
scope limitation, and consumer deliverable—plus immutable `EV-####` identity
and explicit `ACTIVE`/`STALE`/`SUPERSEDED` lifecycle state.

The schema fixes platform/state names, atomic-claim and locator requirements,
version/access-date forms, Grade A–D evidence-type pairs, High/Medium/Low
confidence meanings, the five conclusion labels, mode/scope limitations, and
exact consumer links. Preservation rules prohibit local field changes, ID
reuse, silent material edits, stale source support, fabricated source-gap rows,
and Current Weft/Target Weft leakage. Material changes create a new ID and
retain the old row; schema extensions return to Phase 1 before adoption.
`FeatureTasks.md` traces this increment while keeping the acceptance map,
consumer-return rule, and completion gates pending. No production code, API,
data, UI, executable test, or browser behavior changed. The selected checkbox
and Hepha task-state row remain `IN_PROGRESS` for Hepha's deterministic update
after this worker returns.

Focused documentation verification has two accounted attempts before the final
post-evidence rerun. Attempt 1 ran `canonical-source-row-schema-audit` and
stopped before `git diff --check` because the pre-existing phase file lacked a
final newline. After restoring the newline and recording the prevention lesson,
Attempt 2 passed the audit with `canonical-source-row-schema-audit: PASS` and
`12 required fields, controlled vocabularies, identity/lifecycle rules,
consumer trace, resume state, and whitespace: PASS`; its chained
`git diff --check` passed with no output. Attempt 2's shell elapsed value is not
valid evidence because this environment does not implement `date +%s%3N` as a
millisecond timestamp. The final rerun uses Python millisecond timing and the
schema artifact modification time as a conservative start bound; its exact
result and total validation window are recorded by the worker handoff. No
build, .NET test, Cargo command, or browser check is applicable.

## Concrete Task 6 Evidence

Populated the canonical `## FEAT And EPIC Acceptance Evidence Ledger` in
`research-methodology-and-evidence-contract.md` with traceability for all 13 original FEAT acceptance
criteria and all 12 EPIC-001 success criteria. Compound FEAT criteria 6 and 12
are split into suffixed atomic obligations so every row has exactly one primary
deliverable and owning phase without losing either source checkbox. Each row
records its initial evidence state, exact expected evidence or present gap, and
a named owner/follow-up condition. The mapping preserves separate FEAT and EPIC
rows even when one future artifact can satisfy both checklists.

All unproduced research deliverables remain honestly `NOT_STARTED`.
`FEAT-AC-10` alone records reproduced cross-platform measurements as `DEFERRED`
because equivalent implementations and pinned execution environments do not
exist; it names a future approved reference-implementation/benchmark FEAT and
the complete `COMPARABLE_REPRODUCED` gate rather than fabricating results. The
ledger also preserves the known absence of `EpicAcceptanceTests.md`, executable
browser coverage, and related FEATs. No production code, executable test, API,
data, UI, or browser behavior changed. The selected checkbox and Hepha task row
remain `IN_PROGRESS` for Hepha's deterministic completion update after this
worker returns; Concrete Task 7 and all release gates remain unchecked.

Focused documentation verification and its exact result are recorded in the
worker handoff after the post-evidence rerun.

## Historical Hepha Task State (Non-Authoritative)

| Task ID | Task | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- | --- |
| phase-1.phase-task-ledger.create-the-durable-planning-analysis-report-md-handoff-with-the-required | Create the durable research-methodology-and-evidence-contract.md handoff with the required scope/dependency summary and immediately following phase implementation index (Concrete Task 1). | COMPLETED | 2026-07-15T07:47:39.336Z | 2026-07-15T07:53:17.681Z | 5m 38s |
| phase-1.phase-task-ledger.add-all-phase-0-8-index-rows-with-semantic-headings-obligations-entry-po | Add all Phase 0–8 index rows with semantic headings, obligations/entry points, evidence, and handoffs (Concrete Tasks 2–3). | COMPLETED | 2026-07-15T11:24:16.595Z | 2026-07-15T12:59:53.271Z | 95m 37s |
| phase-1.phase-task-ledger.add-the-required-evidence-version-matrix-pain-workload-benchmark-ranking | Add the required evidence, version, matrix, pain, workload, benchmark, ranking, approval, and acceptance-ledger sections (Concrete Task 4). | COMPLETED | 2026-07-15T12:59:53.389Z | 2026-07-15T13:05:16.671Z | 5m 23s |
| phase-1.phase-task-ledger.define-and-preserve-the-canonical-source-row-field-schema-concrete-task- | Define and preserve the canonical source-row field schema (Concrete Task 5). | COMPLETED | 2026-07-15T13:05:16.759Z | 2026-07-15T13:12:34.931Z | 7m 18s |
| phase-1.phase-task-ledger.map-every-feat-and-epic-criterion-to-phase-deliverable-and-evidence-stat | Map every FEAT and EPIC criterion to phase, deliverable, and evidence state (Concrete Task 6). | IN_PROGRESS | 2026-07-15T13:12:35.038Z | - | - |
| phase-1.phase-task-ledger.state-the-consumer-read-update-rule-and-return-to-provider-action-for-un | State the consumer read/update rule and return-to-provider action for unavailable or changed prerequisites (Concrete Task 7). | NOT_STARTED | - | - | - |
| phase-1.phase-task-ledger.validation-gate-complete-source-provenance-audit-decision-traceability-a | Validation gate: complete source-provenance-audit, decision-traceability-audit, and research-baseline-review; record exact artifact paths. | NOT_STARTED | - | - | - |
| phase-1.phase-task-ledger.review-follow-up-resolve-schema-dependency-findings-before-releasing-the | Review follow-up: resolve schema/dependency findings before releasing the planning handoff to Phases 2–8. | NOT_STARTED | - | - | - |
| phase-1.phase-task-ledger.finalization-update-this-ledger-and-hepha-task-state-then-publish-the-ca | Finalization: update this ledger and Hepha task state, then publish the canonical handoff. | NOT_STARTED | - | - | - |

## Expected Research Artifacts And Contracts

- `research-methodology-and-evidence-contract.md` is the canonical planning artifact.
- Public code entry points: Not applicable; this phase defines research-document contracts only.
- Data/API/UI/integration contracts: evidence-row schema, decision vocabulary, reference-workload equivalence, and final acceptance ledger.

## Research Validation Intent

Use `source-provenance-audit` and `decision-traceability-audit` to validate the schema and `research-baseline-review` to validate current-Weft assertions.

## Required Evidence

A complete phase implementation index, source ledger template, acceptance ledger, and explicit dependency/approval rules in `research-methodology-and-evidence-contract.md`.

## Research Review Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | recorded | Canonical handoff: `research-methodology-and-evidence-contract.md`; execution trace: this phase file and `FeatureTasks.md`. |
| Tests | not applicable | Planning-analysis scope creates documentation contracts only and changes no executable behavior. |
| Gherkin/Playwright E2E | not applicable | Planning-analysis scope introduces no browser behavior; EPIC-001 has no Gherkin acceptance file. |
| Research review | passed | The source schema, version policy, consumer-return rule, comparison coverage, decision vocabulary, and acceptance map are present and were consumed by Phases 2–8. |

## Manual Phase Completion Evidence

The canonical contract contains the exact source-row schema, all FEAT and EPIC
criterion mappings, and the consumer update/provider-return rule. The Phase 0
baseline was rechecked before evidence collection; every produced report uses
the controlled evidence labels and preserves Current Weft versus Target Weft.
The final acceptance-state reconciliation is owned by Phase 7 because evidence
states could only be completed after Phases 2–6 produced their artifacts.

## Acceptance Criteria

- The canonical report has the required immediately-following phase index and all nine numbered phase rows.
- Every later phase has explicit headings, obligations/entry point, evidence, and handoff.
- Source, conclusion, benchmark, and approval policies prevent unsupported claims.

## Completion Gate

The planning artifact is complete and supplies every prerequisite identified in `FeatureTasks.md`; otherwise consumer phases must not start.

## Blockers Or Assumptions

Assumes live research implementation can access official sources. A missing official source for a claimed capability is a blocker for that claim, not permission to lower its evidence grade.

## LessonsLearned

- **Failure:** The prior workflow attempted to reconcile Phase 0 after its work was already complete while `FeatureTasks.md` still carried stale phase state.
- **Cause:** Hepha-owned completion reconciliation and the bootstrap ledger were temporarily inconsistent, and the configured Pi command pointed to a stale nvm path.
- **Fix:** Recovery aligned the Phase 0 handoff, selected `/usr/local/bin/pi`, committed the durable pre-Phase-1 artifacts, and directed this worker to the first unchecked Phase 1 task.
- **Prevention:** Resume strictly from checked phase ledgers and the orchestrator-selected task, never rerun a reconciled phase, and leave Hepha-owned lifecycle/task-state fields unchanged during worker evidence updates.
- **Failure:** The first focused Research Phase Index audit stopped before `git diff --check` on a verifier assertion unrelated to the document content.
- **Cause:** The assertion sliced from the summary heading and then incorrectly expected that slice not to begin with a heading.
- **Fix:** Validate the ordered top-level heading list directly, then rerun the complete focused audit before recording evidence.
- **Prevention:** Keep structural assertions aligned with the exact Markdown range they inspect and distinguish verifier defects from artifact defects in attempt evidence.
- **Failure:** The first canonical source-row schema audit stopped before `git diff --check` because this phase document lacked a final newline.
- **Cause:** The pre-existing Phase 1 evidence file ended directly after its last LessonsLearned bullet, and the focused audit correctly enforced Markdown file termination.
- **Fix:** Restore the final newline, rerun the complete focused audit, and account for both attempts in Concrete Task 5 evidence.
- **Prevention:** Keep final-newline and trailing-whitespace assertions in every documentation-focused audit so formatting drift is repaired before handoff.
- **Failure:** Attempt 2's elapsed reporter emitted a large non-millisecond value even though the focused audit returned promptly.
- **Cause:** This environment expands `date +%s%3N` as epoch seconds plus an unsupported width token/full nanoseconds rather than epoch milliseconds.
- **Fix:** Discard that elapsed value and use Python `time.time_ns() // 1_000_000` for the final command and conservative total-window calculation.
- **Prevention:** Use Python monotonic or epoch-millisecond timing for validation evidence instead of assuming shell `date` supports fractional-width formats.
- **Failure:** Concrete Task 6 verification Attempt 1 stopped before `git diff --check` on a case-sensitive verifier assertion for the future benchmark FEAT phrase.
- **Cause:** The audit expected lowercase `future` while the valid table cell begins the sentence with `Future`.
- **Fix:** Compare that assertion against normalized lowercase content, then rerun the complete focused audit.
- **Prevention:** Normalize case when an audit checks prose presence rather than a controlled case-sensitive token.
- **Failure:** Concrete Task 6 verification Attempt 2 stopped before `git diff --check` because the phase document again lacked a final newline after the evidence insertion.
- **Cause:** The targeted insertion preserved the existing final byte state and did not automatically restore the file terminator.
- **Fix:** Restore the final newline explicitly before rerunning the complete focused audit.
- **Prevention:** Check final bytes immediately after editing a previously affected Markdown evidence file, while retaining final-newline enforcement in the handoff audit.
