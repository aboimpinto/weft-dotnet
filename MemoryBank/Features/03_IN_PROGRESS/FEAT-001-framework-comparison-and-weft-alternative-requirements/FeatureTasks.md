# FEAT-001 Implementation Handoff — Framework Comparison And Weft Alternative Requirements

## Scope Summary

Create an evidence baseline—not new runtime code—for Blazor, Next.js App Router, TanStack Start and supporting TanStack packages, Angular, and Weft. Produce the six requested research deliverables, update the technical overview only with approved conclusions, and identify bounded follow-up FEAT candidates. The work must distinguish current Weft implementation from its target hypothesis and must not make performance, security, or competitive claims without comparable evidence.

## Linked EPIC And Acceptance Traceability

- Parent: `MemoryBank/Features/00_EPICS/EPIC-001-competitive-parity-and-differentiated-web-platform/EpicDescription.md`
- No `EpicAcceptanceTests.md` exists for EPIC-001. Consequently, there are no EPIC Gherkin scenarios to extract and no browser E2E artifacts are planned for this research/documentation FEAT.
- EPIC success criteria are traced through the deliverable and acceptance ledger in Phase 7. Any browser-visible reference implementation work is deferred to a future, evidence-gated FEAT rather than simulated with superficial UI tests here.
- Phase 0's 2026-07-15 repository check also found no related/follow-up FEAT or design artifact and no active `MemoryBank/LessonsLearned/` rule document. Phase 1 must preserve these as explicit absences and must not invent downstream acceptance or design coverage.
- Phase 0's `research-baseline-review` evidence is recorded in `Phases/phase-0-health-check.md` under `## Task 6 Research-Baseline Review`. It confirms cited current-Weft paths, target-only roadmap/architecture headings, required artifact absences, and Markdown cleanliness; it does not create executable acceptance coverage.
- Phase 0's review follow-up is recorded under `## Task 7 Review Follow-up And Phase 1 Handoff` in the same phase document. It assigns every documented absence and research-risk control to Phase 1 or its named later owner; the absence of an EPIC acceptance-test artifact remains explicit and does not create executable coverage.
- Phase 0 finalization is recorded under `## Task 8 Finalization And Phase 1 Handoff`. Its static `phase-0-finalization-audit` reconfirms the cited baseline paths, expected artifact absences, bootstrap-ledger boundary, and Markdown cleanliness; it hands the reviewed baseline to Phase 1 without creating executable acceptance coverage or altering Hepha-owned lifecycle state.

## Execution Routing Policy

The initial route for every numbered phase is **Implementation Agent** using **OpenAI Codex Terra (`gpt-5.6-terra`)**. This is a cross-platform, evidence-led documentation FEAT: no individual implementation stack specialist is a better owner than an agent able to preserve the shared research contract across all five platforms. C# repository knowledge is an input to current-Weft evidence, not a change to the phase owner.

A later developer may override a phase route only by appending an entry to that phase's `## Routing Decision History`; never replace the original entry. Each override entry must state the **previous route**, **selected route**, **decision maker**, **timestamp**, **reason**, and **expected impact**. The new route takes effect only for remaining unchecked ledger work and must preserve the phase dependencies and acceptance contract.

Before beginning any unchecked phase-ledger item, the worker must read `planning-analysis-report.md` and the completed prerequisite handoffs named in the phase's Source Context Used section. A consumer must respect the prior evidence schema, interfaces, fixtures, and test/evidence contracts; if a prerequisite or its contract is missing or changed, stop and return to the provider phase rather than inventing a replacement.

## Contracts And Deliverables

| Area | Contract |
| --- | --- |
| Evidence | Each material claim records URL/repository, evaluated version or maturity status, access date, evidence grade, confidence, and conclusion type (`Fact`, `Reproduced Observation`, `Inference`, `Hypothesis`, or `Prediction`). Grade A is required for platform capabilities. |
| Planning handoff | Phase 1 creates `planning-analysis-report.md` as the durable cross-phase planning handoff. Immediately after `## Scope And Phase-Dependency Summary`, it contains `## Phase Implementation Index`: one row per Phase 0–8 using semantic heading references, implementation obligations/public entry points, and acceptance evidence/handoffs. |
| Matrix | `framework-comparison-report.md` covers all 24 required dimensions for every mandatory platform, and has separate current-Weft and target-Weft columns/sections. |
| Pain decisions | `praised-qualities-and-pains.md` records trigger, affected workload/team, consequence, workaround and its cost, severity, confidence, source grade, and Weft response for at least five material qualities and pains per platform. |
| Shared workload | `reference-application-spec.md` fixes seeded data, roles, journeys, failure fixtures, security assumptions, visual acceptance, and interaction placement so later implementations remain comparable. |
| Measurement | `benchmark-methodology.md` defines pinned environment, cold/warm states, production configuration, fixtures, collection method, reporting schema, and comparability exclusions. It does not publish cross-vendor numbers as results. |
| Requirements | `weft-alternative-requirements.md` is a deduplicated Must/Should/Could/Won't catalog. Every Must has user value, evidence, avoided pain, measurable acceptance, and likely roadmap destination; performance items require the comparable-benchmark gate. |
| Decisions | `weft-gap-and-decision-backlog.md` maps competitor mechanisms to Adopt/Adapt/Interoperate/Defer/Reject and pains to Avoid/Mitigate/Accept/Not Applicable, with an owner-approval boundary for public-document changes. |
| Documentation | `MemoryBank/Overview/technical-overview.md` receives only approved, evidence-labelled conclusions; proposed public architecture, package-policy, or roadmap edits remain listed for owner approval. |

## Task Inventory By Phase

| Phase | Status | Tasks | Primary handoff |
| --- | --- | --- | --- |
| 0 — Health Check | COMPLETED | Confirm repository baseline, required source documents, deliverable paths, source-access constraints, and absence of EPIC acceptance scenarios. | Baseline inventory and research risks for Phase 1. |
| 1 — Planning Analysis | PENDING | Create `planning-analysis-report.md`; establish taxonomy, source ledger, version/access-date policy, decision rules, phase index, and acceptance ledger. | Canonical research contract consumed by Phases 2–8. |
| 2 — Data Layer | PENDING | Gather Grade-A capability evidence and populate the 24-dimension five-platform matrix; record version/maturity and current-versus-target Weft distinction. | Auditable `framework-comparison-report.md`. |
| 3 — Business Logic | PENDING | Analyse praised qualities, pains, triggers, workarounds, and Weft response; test each inference against evidence policy. | `praised-qualities-and-pains.md` and decision inputs. |
| 4 — Presentation Logic | PENDING | Specify the equivalent modular business application, data/role model, journeys, loading/error states, fallback, accessibility, security, and integration boundary. | `reference-application-spec.md`. |
| 5 — User Interface | PENDING | Define the visual/interaction acceptance portion of the reference application, including semantic HTML, keyboard/focus, responsive expectations, partial-update and sustained-local-interaction observables. | UI and browser-acceptance clauses in the reference specification. |
| 6 — Integration | PENDING | Define reproducible benchmark methodology; synthesize evidence into ranked requirements and explicit competitor/pain decisions. | `benchmark-methodology.md`, `weft-alternative-requirements.md`, and `weft-gap-and-decision-backlog.md`. |
| 7 — Testing Polish | PENDING | Audit all deliverables against every FEAT and EPIC criterion, repair traceability/evidence gaps, update technical overview with approved conclusions, and bound follow-up FEAT candidates. | Acceptance evidence ledger and review-ready documentation set. |
| 8 — Final Checkpoint | PENDING | Perform final consistency, provenance, terminology, comparability, and owner-approval review; publish the final handoff state. | Manual-review-ready FEAT evidence. |

## Implementation Timing Summary

| Phase | Recommended Agent | Recommended Model | Estimated Human Time | Estimated AI Time | Routing Rationale |
| --- | --- | --- | --- | --- | --- |
| 0 — Health Check | Implementation Agent | `gpt-5.6-terra` | 1h | 30m | Cross-platform baseline and repository-fact inventory; no runtime implementation owner is required. |
| 1 — Planning Analysis | Implementation Agent | `gpt-5.6-terra` | 2h | 1h | Defines the shared evidence and dependency contract consumed by all research phases. |
| 2 — Data Layer | Implementation Agent | `gpt-5.6-terra` | 7h | 3h | Requires consistent official-source analysis across five platforms and current/target Weft separation. |
| 3 — Business Logic | Implementation Agent | `gpt-5.6-terra` | 6h | 3h | Requires disciplined cross-platform evidence interpretation rather than framework-specific coding. |
| 4 — Presentation Logic | Implementation Agent | `gpt-5.6-terra` | 4h | 2h | Defines framework-neutral workload contracts across server, browser, and integration boundaries. |
| 5 — User Interface | Implementation Agent | `gpt-5.6-terra` | 3h | 1h | Specifies comparable, framework-neutral browser and accessibility observables. |
| 6 — Integration | Implementation Agent | `gpt-5.6-terra` | 6h | 3h | Synthesizes evidence into controlled methodology, requirements, and decisions. |
| 7 — Testing Polish | Implementation Agent | `gpt-5.6-terra` | 4h | 2h | Performs cross-deliverable traceability and evidence audit without executable-code ownership. |
| 8 — Final Checkpoint | Implementation Agent | `gpt-5.6-terra` | 2h | 1h | Reconciles the completed research package and owner-facing limitations. |
| **Total** | — | — | **35h** | **16h** | Initial routing only; actual AI time is recorded later by Hepha from phase-worker timestamps. |

## Dependency Ordering And Bootstrap Analysis

| Required capability / contract | Consumer phase and task | Provider FEAT / phase / entry point | Must exist before | Availability at consumer start | Decision | Bootstrap retirement / evidence |
| --- | --- | --- | --- | --- | --- | --- |
| Repository baseline and current-Weft facts | Phase 1 taxonomy and Phase 2 Weft-current matrix | Existing README, `docs/architecture.md`, `docs/package-ecosystem.md`, `docs/roadmap.md`, `MemoryBank/Overview/technical-overview.md`, and source/tests | Phase 1 | Available | baseline | Phase 0 inventory cites the exact baseline documents and marks unsupported claims as hypotheses. |
| Source-quality, version, access-date, and conclusion-label rules | Phase 2 matrix and Phase 3 pain analysis | Phase 1 `planning-analysis-report.md` — `## Evidence Taxonomy And Source Ledger` | Phases 2–3 | Unavailable until Phase 1 completes | ordered earlier | Phase 1 records the canonical row schema and source ledger; later phases update it rather than creating incompatible formats. |
| Capability matrix facts | Phase 3 decisions and Phase 6 requirements ranking | Phase 2 `framework-comparison-report.md` — `## Capability Matrix` | Phases 3 and 6 | Unavailable until Phase 2 completes | ordered earlier | Matrix coverage audit shows all 24 dimensions × five platforms are evidence-backed or explicitly unavailable/not implemented. |
| Pain/quality analysis | Phase 6 Weft response and requirements prioritisation | Phase 3 `praised-qualities-and-pains.md` | Phase 6 | Unavailable until Phase 3 completes | ordered earlier | Each decision links back to a trigger, impact, workaround, grade, and confidence. |
| Equivalent workload and UI observables | Phase 6 benchmark plan and final performance conclusions | Phases 4–5 `reference-application-spec.md` | Phase 6 | Unavailable until Phases 4–5 complete | ordered earlier | Reference specification freezes fixtures and journeys; benchmark methodology names them and rejects non-equivalent measurements. |
| Comparable benchmark gate | Phase 6 performance ranking | Phase 6 `benchmark-methodology.md`; reproduced measurements are explicitly future work | Requirements ranking in Phase 6 | Methodology available in phase; measurements intentionally unavailable | defer | Performance requirements remain hypothesis/deferred unless a later comparable run supplies the methodology's evidence. No performance Must is promoted without that evidence. |
| Ranked decisions and approved conclusions | Phase 7 technical-overview update and follow-up FEAT candidates | Phase 6 requirements and decision backlog plus owner approval for public-document changes | Phase 7 | Requirements/backlog unavailable until Phase 6; owner approval may remain pending | ordered earlier | Phase 7 updates only approved conclusions; unapproved document changes are listed as proposals, not silently applied. |
| Acceptance-evidence ledger | Phase 8 completion decision | Phase 7 `## FEAT And EPIC Acceptance Evidence Ledger` in planning report or final audit | Phase 8 | Unavailable until Phase 7 completes | ordered earlier | Ledger marks each criterion evidenced, deferred with owner/follow-up, or blocked; Phase 8 cannot close unresolved required criteria. |

## Assumptions And Boundaries

- This FEAT is a documentation and research handoff. It does not implement framework source, reference applications, browser assets, or E2E files.
- Official live documentation must be accessed during implementation; repository documents establish current-Weft facts but do not substitute for competitor evidence.
- “Current stable” means the version/status recorded on the source access date, not an unversioned framework label.
- The saved Deep-Dive decision selects an **evidence baseline** first; reproduced implementations and measurements are deferred.
- No phase may promote a prediction into a fact, or a target-Weft hypothesis into a current capability.

## Verification Evidence Policy

Implementation workers select project commands through the project verification profile. This handoff uses evidence labels rather than commands:

- **research-baseline-review** — source inventory and current repository fact check.
- **source-provenance-audit** — URL/repository, version/status, access date, grade, confidence, and conclusion-label completeness.
- **matrix-coverage-audit** — 24 dimensions × mandatory platform coverage and Weft current/target separation.
- **decision-traceability-audit** — qualities, pains, requirements, and decisions link to evidence and architecture rationale.
- **reference-workload-review** — equivalence of data, fixtures, journeys, visual and security expectations.
- **benchmark-comparability-review** — pinned environments, cold/warm definitions, fixture parity, and no invalid cross-vendor result comparison.
- **documentation-consistency-review** — approved technical-overview changes, terminology, and public-claim boundaries.
- **manual-review-ready** — final owner-facing review package.

## Phase Quality-Gate Policy

Implementation cannot complete a phase until every gate is satisfied, not applicable, or explicitly waived with a phase-specific justification. Each worker must replace the planned Quality Gate Evidence rows in its phase file with actual paths and evidence. Research-only phases may mark automated tests, browser E2E, and code review not applicable only with the phase-specific reason recorded in that file. If a phase changes executable repository code or browser-visible behavior, it must instead supply affected-tests/static-analysis and, where applicable, Gherkin/Playwright evidence plus a persisted code-review report. A zero-test selection is not passing evidence.

### Resume-Ledger Rule

The `## Phase Task Ledger` in each phase Markdown file is the bootstrap resume ledger. Existing checked (`[x]`) entries are completed and must not be rerun unless a later changed file, failed verification, or review-finding decision explicitly invalidates them. The next unchecked entry is the next executable work item. Hepha mirrors this state to SQLite and the phase's `## Hepha Task State` table using `NOT_STARTED`, `IN_PROGRESS`, `COMPLETED`, or `SKIPPED` plus Started, Completed, and Duration fields.

## Completion Conditions

FEAT-001 is ready for final owner review only when all seven requested outputs exist and are internally consistent; every mandatory platform/dimension has the required evidence state; all requirements and competitor/pain decisions are traceable; all performance statements honour the comparable-benchmark gate; and the final acceptance ledger has no unowned gaps.
