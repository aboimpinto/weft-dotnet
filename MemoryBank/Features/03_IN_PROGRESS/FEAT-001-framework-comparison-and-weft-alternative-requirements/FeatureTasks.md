# FEAT-001 Research Handoff — Framework Comparison And Weft Alternative Requirements

## Scope Summary

Create an evidence baseline—not new runtime code—for Blazor, Next.js App Router, TanStack Start and supporting TanStack packages, Angular, and Weft. Produce the requested core research deliverables and addenda, update the technical overview only with approved conclusions, and identify bounded follow-up FEAT candidates. The work must distinguish current Weft implementation from its target hypothesis and must not make performance, security, or competitive claims without comparable evidence.

## Manual R&D Execution Override

This work item is an R&D / Documentation Spike. Hepha generated this handoff and
the Phase 0–8 skeleton before the work type was corrected. Those files remain
useful as research containers and audit history, but Hepha must not continue
the feature or apply development-task prompts. Research is performed manually
in the active agent conversation and reported in the existing phase files and
named deliverables.

The phase names and files now describe research responsibilities directly, as
defined in `FeatureDescription.md` under `## Manual Research Execution`.
Remaining Hepha task-state fields are historical; they do not authorize runtime
code, automated test construction, or lifecycle movement.

## Linked EPIC And Acceptance Traceability

- Parent: `MemoryBank/Features/00_EPICS/EPIC-001-competitive-parity-and-differentiated-web-platform/EpicDescription.md`
- No `EpicAcceptanceTests.md` exists for EPIC-001. Consequently, there are no EPIC Gherkin scenarios to extract and no browser E2E artifacts are planned for this research/documentation FEAT.
- EPIC success criteria are traced through the deliverable and acceptance ledger in Phase 7. Any browser-visible reference implementation work is deferred to a future, evidence-gated FEAT rather than simulated with superficial UI tests here.
- Phase 0's 2026-07-15 repository check also found no related/follow-up FEAT or design artifact and no active `MemoryBank/LessonsLearned/` rule document. Phase 1 must preserve these as explicit absences and must not invent downstream acceptance or design coverage.
- Phase 0's `research-baseline-review` evidence is recorded in `Phases/phase-0-research-baseline.md` under `## Task 6 Research-Baseline Review`. It confirms cited current-Weft paths, target-only roadmap/architecture headings, required artifact absences, and Markdown cleanliness; it does not create executable acceptance coverage.
- Phase 0's review follow-up is recorded under `## Task 7 Review Follow-up And Phase 1 Handoff` in the same phase document. It assigns every documented absence and research-risk control to Phase 1 or its named later owner; the absence of an EPIC acceptance-test artifact remains explicit and does not create executable coverage.
- Phase 0 finalization is recorded under `## Task 8 Finalization And Phase 1 Handoff`. Its static `phase-0-finalization-audit` reconfirms the cited baseline paths, expected artifact absences, bootstrap-ledger boundary, and Markdown cleanliness; it hands the reviewed baseline to Phase 1 without creating executable acceptance coverage or altering Hepha-owned lifecycle state.
- Phase 1 Concrete Task 1 created the canonical `research-methodology-and-evidence-contract.md` with `## Scope And Phase-Dependency Summary` followed immediately by the required `## Research Phase Index`; Concrete Tasks 2–3 added all Phase 0–8 semantic navigation rows with exact planning headings, obligations, applicable entry-point/adapter boundaries, evidence, and consumer handoffs. Concrete Task 4 established the nine referenced policy sections with evidence/version, matrix, pain/quality, equivalent-workload, benchmark, ranking, approval, and acceptance-ledger controls. Concrete Task 5 added the canonical FEAT-wide `EV-####` source-row schema, controlled field vocabularies, source-grade mapping, confidence definitions, lifecycle/identity rules, exact consumer links, and schema-change return boundary. Concrete Task 6 populated the canonical acceptance map for the original 13 FEAT acceptance criteria and 12 EPIC success criteria, splitting two compound FEAT criteria into single-owner atomic obligations and explicitly deferring reproduced measurements to a future comparability-gated FEAT. Three owner-requested addenda later extended the live FEAT ledger through `FEAT-AC-16` without rewriting that historical Phase 1 event.

## Manual Research Execution Policy

The work is performed manually in the active conversation by Paulo Aboim Pinto
and the active agent. Each phase consumes the evidence and decisions recorded
by its predecessors. C# repository knowledge is an input to Current Weft
evidence; it does not turn this research into a development task.

Before beginning an unchecked phase-ledger item, the researcher reads
`research-methodology-and-evidence-contract.md` and the prerequisite handoffs named in the
phase's Source Context Used section. If a prerequisite or contract is missing
or changes, the affected earlier phase is corrected before its conclusions are
used.

## Contracts And Deliverables

| Area | Contract |
| --- | --- |
| Evidence | Each material claim records URL/repository, evaluated version or maturity status, access date, evidence grade, confidence, and conclusion type (`Fact`, `Reproduced Observation`, `Inference`, `Hypothesis`, or `Prediction`). Grade A is required for platform capabilities. |
| Planning handoff | Phase 1 creates `research-methodology-and-evidence-contract.md` as the durable cross-phase planning handoff. Immediately after `## Scope And Phase-Dependency Summary`, it contains `## Research Phase Index`: one row per Phase 0–8 using semantic heading references, research obligations/observable boundaries, and acceptance evidence/handoffs. |
| Matrix | `framework-comparison-report.md` covers all 24 required dimensions for every mandatory platform, and has separate current-Weft and target-Weft columns/sections. |
| Pain decisions | `praised-qualities-and-pains.md` records trigger, affected workload/team, consequence, workaround and its cost, severity, confidence, source grade, and Weft response for at least five material qualities and pains per platform. |
| Shared workload | `reference-application-spec.md` fixes seeded data, roles, journeys, failure fixtures, security assumptions, visual acceptance, and interaction placement so later implementations remain comparable. |
| Measurement | `benchmark-methodology.md` defines pinned environment, cold/warm states, production configuration, fixtures, collection method, reporting schema, and comparability exclusions. It does not publish cross-vendor numbers as results. |
| Requirements | `weft-alternative-requirements.md` is a deduplicated Must/Should/Could/Won't catalog. Every Must has user value, evidence, avoided pain, measurable acceptance, and likely roadmap destination; performance items require the comparable-benchmark gate. |
| Decisions | `weft-gap-and-decision-backlog.md` maps competitor mechanisms to Adopt/Adapt/Interoperate/Defer/Reject and pains to Avoid/Mitigate/Accept/Not Applicable, with an owner-approval boundary for public-document changes. |
| Documentation | `MemoryBank/Overview/technical-overview.md` receives only approved, evidence-labelled conclusions; proposed public architecture, package-policy, or roadmap edits remain listed for owner approval. |
| Research addendum | `developer-errors-and-native-shell-integration.md` defines Development/Production error presentation and framework-neutral desktop/mobile WebView shell modes, bridge, lifecycle, security, and conformance boundaries. |
| Installation addendum | `installation-and-bootstrap-strategy.md` compares official installation flows and specifies the proposed verified bootstrap, pinned local .NET tool, profile/prerequisite, locked/offline restore, update, security, cache, and removal lifecycle. |

## Task Inventory By Phase

| Phase | Status | Tasks | Primary handoff |
| --- | --- | --- | --- |
| 0 — Research Baseline | COMPLETED | Confirm repository facts, deliverable paths, source-access constraints, research risks, and the Current Weft versus Target Weft boundary. | Auditable baseline for the methodology. |
| 1 — Research Methodology and Evidence Contract | COMPLETED | Establish taxonomy, source ledger, version/access-date policy, comparability rules, decision vocabulary, and acceptance ledger. | Canonical research contract consumed by Phases 2–8. |
| 2 — Framework Capability Profiles | COMPLETED | Gather Grade-A capability evidence and populate the 24-dimension platform matrix, including maturity and Current/Target Weft separation. | Auditable `framework-comparison-report.md`. |
| 3 — Praised Qualities and Pain Analysis | COMPLETED | Analyse praised qualities, recurring pains, triggers, workarounds, costs, and possible Weft responses. | `praised-qualities-and-pains.md` and decision inputs. |
| 4 — Reference Application Contract | COMPLETED | Specify the equivalent modular business workload, roles, journeys, failures, security boundaries, and integration responsibilities. | Base `reference-application-spec.md`. |
| 5 — Browser Experience and Accessibility Criteria | COMPLETED | Add framework-neutral browser behaviour, accessibility, resilience, partial-update, and sustained-local-interaction criteria. | Observable browser criteria in the reference specification. |
| 6 — Weft Requirements and Decision Synthesis | COMPLETED | Define the benchmark method and synthesize evidence into ranked requirements and explicit competitor/pain decisions. | Methodology, requirements catalog, and gap/decision backlog. |
| 7 — Evidence Audit and Overview Update | COMPLETED | Audit provenance and traceability, repair evidence gaps, and update the technical overview with approved conclusions. | Audited documentation set and acceptance ledger. |
| 8 — Research Closure and Follow-up | MANUAL REVIEW READY | Reconcile conclusions, limitations, owner decisions, and properly classified follow-up work. | `research-audit-and-closure-report.md`. |

## Research Effort Estimate

| Phase | Research responsibility | Estimated Human Time | Estimated AI Time |
| --- | --- | --- | --- |
| 0 — Research Baseline | Repository facts and research boundary | 1h | 30m |
| 1 — Research Methodology and Evidence Contract | Shared evidence and decision contract | 2h | 1h |
| 2 — Framework Capability Profiles | Official-source platform research | 7h | 3h |
| 3 — Praised Qualities and Pain Analysis | Cross-platform interpretation | 6h | 3h |
| 4 — Reference Application Contract | Equivalent workload definition | 4h | 2h |
| 5 — Browser Experience and Accessibility Criteria | Observable browser criteria | 3h | 1h |
| 6 — Weft Requirements and Decision Synthesis | Methodology, ranking, and product decisions | 6h | 3h |
| 7 — Evidence Audit and Overview Update | Traceability and documentation audit | 4h | 2h |
| 8 — Research Closure and Follow-up | Owner-facing synthesis | 2h | 1h |
| **Total** | — | **35h** | **16h** |

## Dependency Ordering And Bootstrap Analysis

| Required capability / contract | Consumer phase and task | Provider FEAT / phase / entry point | Must exist before | Availability at consumer start | Decision | Bootstrap retirement / evidence |
| --- | --- | --- | --- | --- | --- | --- |
| Repository baseline and current-Weft facts | Phase 1 taxonomy and Phase 2 Weft-current matrix | Existing README, `docs/architecture.md`, `docs/package-ecosystem.md`, `docs/roadmap.md`, `MemoryBank/Overview/technical-overview.md`, and source/tests | Phase 1 | Available | baseline | Phase 0 inventory cites the exact baseline documents and marks unsupported claims as hypotheses. |
| Source-quality, version, access-date, and conclusion-label rules | Phase 2 matrix and Phase 3 pain analysis | Phase 1 `research-methodology-and-evidence-contract.md` — `## Evidence Taxonomy And Source Ledger` | Phases 2–3 | Unavailable until Phase 1 completes | ordered earlier | Phase 1 records the canonical row schema and source ledger; later phases update it rather than creating incompatible formats. |
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

This research uses evidence reviews rather than development verification commands:

- **research-baseline-review** — source inventory and current repository fact check.
- **source-provenance-audit** — URL/repository, version/status, access date, grade, confidence, and conclusion-label completeness.
- **matrix-coverage-audit** — 24 dimensions × mandatory platform coverage and Weft current/target separation.
- **decision-traceability-audit** — qualities, pains, requirements, and decisions link to evidence and architecture rationale.
- **reference-workload-review** — equivalence of data, fixtures, journeys, visual and security expectations.
- **benchmark-comparability-review** — pinned environments, cold/warm definitions, fixture parity, and no invalid cross-vendor result comparison.
- **documentation-consistency-review** — approved technical-overview changes, terminology, and public-claim boundaries.
- **manual-review-ready** — final owner-facing review package.

## Research Review Policy

Research cannot complete a phase until its sources, outputs, limitations, and
handoff are recorded. Each researcher replaces planned review rows with actual
paths and evidence. Automated tests and browser E2E are not required because
this FEAT produces research documents, not executable behaviour. Any later
implementation must be created as a separately classified Development FEAT.

### Manual Resume-Ledger Rule

The `## Phase Task Ledger` in each phase file is the manual resume ledger.
Checked entries remain complete unless later evidence invalidates them; the next
unchecked entry is the next research activity. Any Hepha state table is a
non-authoritative historical snapshot.

## Independent Recheck And Overview Handoff

The 2026-07-20 owner-requested double/triple-check is recorded in
`research-recheck-2026-07-20.md`. It independently audited structure,
traceability, source/version drift, Current Weft source, verification, and
cross-document semantics. Durable topic summaries now live under
`MemoryBank/Overview/README.md`.

The recheck preserves the manual phase-completion history but qualifies the
original unconditional audit result. FEAT-001 is
`MANUAL_REVIEW_READY_WITH_FINDINGS` until the source-ledger atomicity repair,
reference-workload wording/revision decision, adjacent-scope classification,
requirement approval, and bounded follow-up gate are resolved.

## Completion Conditions

FEAT-001 is ready for final owner review when all requested outputs exist, the
recheck findings and evidence limitations are visible, every mandatory
platform/dimension has an explicit evidence state, requirements and decisions
are traceable, performance statements honour the comparable-benchmark gate,
and no acceptance gap lacks an owner. Final acceptance/product completion
additionally requires resolution of the closure conditions in
`research-recheck-2026-07-20.md`.
