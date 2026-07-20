# Phase 0 - Research Baseline

**Status:** COMPLETED
**Started:** -
**Completed:** -
**Duration:** -
**Work Type:** R&D / Documentation Spike
**Execution Mode:** Manual research in the active agent conversation
**Research Owner:** Paulo Aboim Pinto with the active agent
**Estimated Human Time:** 1h
**Estimated AI Time:** 30m

## Research Rationale

This baseline establishes what Weft implements now, what remains a target, which
research artifacts are missing, and which evidence rules the comparison needs.

## Historical Generation Record

- On 2026-07-15 Hepha generated this file and completed the baseline work using
  its development-task vocabulary. That route is historical and is not an
  instruction to continue this FEAT through Hepha.

## Objective

Establish a reproducible research baseline and confirm that FEAT-001 can begin without claiming unimplemented Weft behavior.

## Source Context Used

- `FeatureDescription.md`
- `FeatureTasks.md`
- EPIC-001 `EpicDescription.md`
- `README.md`, `docs/architecture.md`, `docs/package-ecosystem.md`, `docs/roadmap.md`
- `MemoryBank/Overview/technical-overview.md`
- Current `src/`, `examples/starter-html/`, and test projects

## Task Details

1. Inventory the current branch, solution layout, baseline documents, existing test coverage, and target feature folder.
2. Confirm no `EpicAcceptanceTests.md`, related FEAT, design artifact, or active LessonsLearned rule exists; record an explicit absence rather than assuming coverage.
3. List the seven required research outputs and verify their planned owners in `FeatureTasks.md`.
4. Create a baseline-fact register separating implemented server foundation facts from roadmap hypotheses; include source paths for every current-Weft assertion.
5. Record research risks: live official-source access, version drift, source-grade gaps, and the prohibition on incomparable benchmark conclusions.

## Task 1 Baseline Inventory

**Captured 2026-07-15.** The checked-out branch is
`feat/feat-001-feat-001-framework-comparison-and-weft-alternative-requireme`
at commit `9bc05ff` (`docs: add MIT license`), with `origin` configured for
`aboimpinto/weft-dotnet`. At inventory time, `MemoryBank/` and `logs/` are
untracked; this FEAT folder is therefore present locally but is not part of the
committed repository baseline. No production source change was made by this
health check.

| Inventory area | Baseline evidence |
| --- | --- |
| Solution and tooling | `Weft.sln` contains eight projects: `Weft.Abstractions`, `Weft.Server`, `Weft.Generator`, three test projects, and the `starter-html` feature and web projects. `global.json` pins SDK `10.0.301`; `Directory.Build.props` enables latest C#, nullable reference types, implicit usings, and deterministic builds; `Directory.Packages.props` centrally pins test and Roslyn packages. |
| Production layout | `src/Weft.Abstractions/` holds feature/route/action/execution metadata; `src/Weft.Generator/` holds `WeftFeatureManifestGenerator`; `src/Weft.Server/` holds explicit manifest registration and endpoint mapping. `examples/starter-html/` contains the runnable feature and web host; the other example directories are specifications/planned examples. |
| Baseline documents | Product and current-state inputs are `README.md`, `docs/architecture.md`, `docs/package-ecosystem.md`, `docs/roadmap.md`, `docs/examples.md`, and `MemoryBank/Overview/technical-overview.md`. They consistently describe a runnable server-only foundation and label enhanced actions, browser C#, asset pipeline/capability loading, and npm integration as planned rather than implemented. |
| Existing test coverage | `tests/Weft.Generator.Tests/WeftFeatureManifestGeneratorTests.cs` covers manifest generation and diagnostics `WFT001`/`WFT009`; `tests/Weft.Server.Tests/WeftEndpointRouteBuilderExtensionsTests.cs` covers rejection of route/manifest mismatch; `tests/Weft.Examples.StarterHtml.Tests/TasksPageTests.cs` covers HTML without scripts or a browser runtime, antiforgery rejection, post/redirect/get, and CSS serving without Node. The inventory found eight xUnit facts across those three projects. |
| Target feature folder | `MemoryBank/Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/` contains `FeatureDescription.md`, `FeatureTasks.md`, and phase documents `phase-0-research-baseline.md` through `phase-8-research-closure-and-follow-up.md`. `research-methodology-and-evidence-contract.md` and the seven research outputs do not yet exist; their production starts in later planned phases. |

This inventory is an input to Phase 1 only. Current-Weft capability claims must continue to cite source and tests directly; roadmap descriptions in the baseline documents are hypotheses, not implementation evidence.

## Task 2 Linked-Artifact And LessonsLearned Check

**Checked 2026-07-15.** The full repository search found no file named
`EpicAcceptanceTests.md`; EPIC-001 therefore provides success criteria but no
executable or Gherkin acceptance scenarios for this FEAT. This confirms the
existing traceability statement in `FeatureTasks.md`; Phase 7 remains the owner
of criteria-to-deliverable evidence, rather than inventing an acceptance test.

The only FEAT-001 references outside this feature folder are the parent
EPIC-001 feature-breakdown row and its statement that further features are
created only after FEAT-001 passes its evidence and acceptance gate. No related
or follow-up FEAT artifact exists, and no design artifact exists anywhere in
the repository. `MemoryBank/LessonsLearned/` exists but is empty, so there are
no active LessonsLearned rules or prior code-review prevention rules to apply.

| Required input | Presence | Evidence and Phase 1 handoff |
| --- | --- | --- |
| EPIC acceptance scenarios | Absent | Repository-wide exact-name search found no `EpicAcceptanceTests.md`. Do not create synthetic Gherkin or browser tests; Phase 1 records the absence in its acceptance ledger. |
| Related FEAT artifacts | Absent | `EpicDescription.md` names FEAT-001 as the sole EPIC feature and defers future features until this evidence gate. Phase 1 must not assume a downstream implementation consumer. |
| Design artifacts | Absent | Repository-wide design-artifact filename search returned no files. Phase 1 defines research/evidence contracts only; reference-application design is owned by Phases 4–5. |
| Active LessonsLearned rules | Absent | `MemoryBank/LessonsLearned/` contains no documents. If rules are added before a later phase starts, that worker must read and apply them before its work. |

## Task 3 Required-Output And Ownership Check

**Verified 2026-07-15.** `FeatureDescription.md` defines seven requested
outputs: six research documents plus an approved, evidence-labelled update to
`MemoryBank/Overview/technical-overview.md`. The canonical
`research-methodology-and-evidence-contract.md` is Phase 1's cross-phase contract and is not a
seventh substitute for the required output list. None of the seven output files
exists yet, which is expected before their producer phases begin.

| Required output | Direct producer and scope | Phase 1 ownership / required handoff | Consumer or completion check |
| --- | --- | --- | --- |
| `framework-comparison-report.md` | Phase 2 creates the 24-dimension, five-platform capability matrix with separate current- and target-Weft evidence. | Create the canonical evidence taxonomy, source-row schema, version/access-date policy, and matrix coverage rules before Phase 2 starts. | Phases 3 and 6 consume the matrix; Phase 7 audits coverage and provenance. |
| `praised-qualities-and-pains.md` | Phase 3 creates the controlled quality/pain catalog. | Define pain/quality record fields, conclusion labels, and decision boundaries before Phase 3 starts. | Phase 6 consumes decision inputs; Phase 7 audits traceability. |
| `reference-application-spec.md` | Phase 4 creates the framework-neutral workload; Phase 5 adds its UI and accessibility acceptance clauses. | Define reference-workload equivalence and handoff rules before Phase 4 starts. | Phases 5 and 6 consume the frozen workload; Phase 7 audits equivalence. |
| `benchmark-methodology.md` | Phase 6 creates the pinned-environment and comparability methodology. | Define the benchmark-comparability gate and deferred-measurement policy before Phase 6 starts. | Phase 7 audits comparability; Phase 8 performs final consistency review. |
| `weft-alternative-requirements.md` | Phase 6 creates the deduplicated Must/Should/Could/Won't catalog. | Define requirement-ranking fields and the evidence/acceptance gate before Phase 6 starts. | Phase 7 audits every requirement and bounded follow-up candidate. |
| `weft-gap-and-decision-backlog.md` | Phase 6 creates mechanism and pain decisions with owner-approval boundaries. | Define controlled decision vocabulary and approval boundaries before Phase 6 starts. | Phase 7 audits decision traceability and approval handling. |
| `MemoryBank/Overview/technical-overview.md` approved update | Phase 7 applies only approved, evidence-labelled conclusions. | Create the FEAT/EPIC acceptance ledger and public-document approval boundary; do not authorize a conclusion or public-document change. | Phase 8 confirms that no unsupported or unapproved claim remains. |

This ownership map matches the `## Contracts And Deliverables`, `## Task
Inventory By Phase`, and dependency-ordering tables in `FeatureTasks.md`.
Phase 1 owns the prerequisite planning contract for every output; the listed
producer phases own their creation or update. Phase 5 is deliberately recorded
as an addendum owner for the reference specification, not as a separate eighth
output.

**Verification.** `research-output-ownership-audit` statically verified seven
output rows, each direct producer, each Phase 1 handoff, and the expected
pre-producer absence of the six new output files. A no-index whitespace check
of this phase document found no whitespace errors.

## Task 4 Current-Weft Fact Versus Roadmap-Hypothesis Register

**Captured 2026-07-15.** This is the Phase 1 input boundary for Weft matrix
cells. `Fact` means the checked-out repository implements the behavior and the
listed source path is direct evidence; a listed test narrows or exercises that
fact. `Hypothesis` means an intended future behavior stated in a planning or
product document. It is not evidence of a current capability and must remain
outside `Current Weft` matrix cells until a later repository inventory proves
it.

| Classification | Claim | Repository evidence and source paths | Boundary for later research |
| --- | --- | --- | --- |
| Fact | Feature, route, and action metadata types exist; the only defined execution mode is `Html`. | `src/Weft.Abstractions/WeftFeatureAttribute.cs`, `src/Weft.Abstractions/WeftRouteAttribute.cs`, `src/Weft.Abstractions/WeftActionAttribute.cs`, `src/Weft.Abstractions/WeftActionDescriptor.cs`, and `src/Weft.Abstractions/WeftExecutionMode.cs`. | This establishes metadata and ordinary HTML placement only; it is not an enhanced-action or browser-capability implementation. |
| Fact | The generator produces a direct `Feature.Manifest` factory for valid partial server features and reports feature-shape diagnostics. | `src/Weft.Generator/WeftFeatureManifestGenerator.cs`; exercised by `tests/Weft.Generator.Tests/WeftFeatureManifestGeneratorTests.cs` (`Valid_feature_generates_a_direct_manifest_factory`, `Non_partial_feature_reports_a_clear_diagnostic`, and `Feature_without_a_parameterless_constructor_reports_a_clear_diagnostic`). | Record generated trusted registration as current; do not infer generalized template, asset, or browser-contract generation. |
| Fact | A host explicitly selects manifests through `AddWeft`; registration orders features by ID and rejects duplicate IDs, declared routes, and conflicting endpoint names. | `src/Weft.Server/WeftServiceCollectionExtensions.cs`; the host use is in `examples/starter-html/Weft.Examples.StarterHtml.Web/Program.cs`. | Treat explicit host trust and server registration as current, not automatic assembly discovery or a plugin sandbox. |
| Fact | `MapWeft()` maps registered feature endpoints once and rejects a feature whose actual endpoints do not equal its declared route metadata. | `src/Weft.Server/WeftEndpointRouteBuilderExtensions.cs` and `src/Weft.Server/WeftFeatureRegistry.cs`; exercised by `tests/Weft.Server.Tests/WeftEndpointRouteBuilderExtensionsTests.cs` (`MapWeft_rejects_routes_that_differ_from_the_manifest`). | Current validation is runtime route/HTTP-method/endpoint-name validation. It is not deeper compile-time analysis of imperative endpoint code. |
| Fact | The runnable starter implements a server-rendered task page, normal GET/POST form flow, antiforgery rejection, post/redirect/get, and feature-owned CSS served by its feature. | `examples/starter-html/Weft.Examples.StarterHtml.Feature/TasksFeature.cs`, `examples/starter-html/Weft.Examples.StarterHtml.Feature/TasksPage.cs`, `examples/starter-html/Weft.Examples.StarterHtml.Feature/TemplateAssets.cs`, `examples/starter-html/Weft.Examples.StarterHtml.Feature/UI/Tasks.html`, and `examples/starter-html/Weft.Examples.StarterHtml.Feature/UI/Tasks.css`; exercised by `tests/Weft.Examples.StarterHtml.Tests/TasksPageTests.cs` (`Get_tasks_returns_html_without_a_browser_runtime`, `Post_tasks_without_an_antiforgery_token_is_rejected`, `Post_tasks_with_an_antiforgery_token_uses_post_redirect_get`, and `Feature_owned_styles_are_served_without_node`). | This is evidence for one server-only example, not a reusable template system or general asset pipeline. |
| Fact | The starter page test asserts that `/tasks` contains no script tag, `_framework`, or `.wasm`; its feature CSS is embedded and served without Node. | `tests/Weft.Examples.StarterHtml.Tests/TasksPageTests.cs` and `examples/starter-html/Weft.Examples.StarterHtml.Feature/TemplateAssets.cs`. | Claim only the tested starter route's delivered HTML and CSS behavior. Do not generalize it to a product-wide payload, performance, or zero-JavaScript guarantee. |
| Hypothesis | Enhanced server actions will add framework-owned busy/fetch/replace-region behavior while preserving normal links and forms. | `docs/architecture.md` (`### 2. Enhanced server action`) and `docs/roadmap.md` (`## Phase 2 — Enhanced server actions`). | Phase 2 must not enter this as current capability; evidence requires implemented source and dedicated semantics, failure, and accessibility tests. |
| Hypothesis | Browser-safe C#, typed server/browser contracts, and browser dispatch will be added through a typed boundary. | `docs/architecture.md` (`### 3. Local C# capability`, `## Browser boundary`) and `docs/roadmap.md` (`## Phase 3 — Typed browser boundary`). | No `Weft.Browser` production project exists in the current inventory; treat this solely as a target hypothesis. |
| Hypothesis | A supported lazy browser-capability loader with content-hashed asset groups and activation diagnostics will be added. | `docs/architecture.md` (`## Capability chunking`) and `docs/roadmap.md` (`## Phase 4 — Supported lazy capability loading`). | No current capability loader, browser runtime, or comparable activation measurement exists; Phase 6 may define measurement only, not results. |
| Hypothesis | A general feature-asset manifest and optional npm-compatible restore/integration will add provenance, integrity, and size budgets. | `docs/package-ecosystem.md` (`## Asset manifest`, `## JavaScript bridges`) and `docs/roadmap.md` (`## Phase 5 — Asset pipeline and ecosystem integrations`). | The current example-private embedded CSS is not this system. Do not represent npm integration, content hashing, or asset integrity as implemented. |
| Hypothesis | Public-preview hardening will define browser support, security, test, benchmark, governance, versioning, and migration commitments. | `docs/roadmap.md` (`## Phase 6 — Hardening and public preview`). | These are future commitments and evaluation subjects, not a present support or performance claim. |

**Phase 1 handoff.** Use the fact rows as initial `Current Weft` source-ledger
records with repository-source Grade A evidence and the hypothesis rows as
explicit target-only records. Re-audit each fact against the checked-out source
when Phase 2 begins; if source changes, update the later ledger rather than
silently carrying this snapshot forward.

## Task 5 Research-Risk Register

**Recorded 2026-07-15.** This register records health-check constraints, not
platform capability conclusions. Phase 1 must transfer these controls into the
canonical `research-methodology-and-evidence-contract.md`; Phases 2–8 must apply them to every
consumer artifact.

| Risk | Observed baseline evidence | Required control and Phase 1 handoff | Effect if unresolved |
| --- | --- | --- | --- |
| Live official-source access can be unavailable, redirected, dynamically rendered, or revised after collection. | On 2026-07-15, the primary official entry URLs for Blazor (`learn.microsoft.com`), Next.js (`nextjs.org`), TanStack Start (`tanstack.com`), and Angular (`angular.dev`) were retrievable. This confirms access at this health check only; it establishes no framework capability claim. | The source ledger must retain the exact URL/repository, access date, evaluated version/status, evidence type/grade, confidence, conclusion label, and scope limitation. Preserve a concise quotation or source-location note sufficient to re-find each material claim; if a source becomes inaccessible, record the gap rather than substituting an unverified summary. | A later reader cannot reproduce or distinguish the evidence snapshot; the affected matrix/pain/requirement entry remains a research gap. |
| Official documentation and package maturity drift; “current stable” is time-bound. | The Blazor primary URL explicitly targets `aspnetcore-10.0`; Next.js and Angular overview URLs are rolling documentation paths; the accessed TanStack Start `/v0` page identifies Start as `RC`. These labels may change independently of this repository. | For each platform and each evaluated TanStack supporting package, record the source-observed version or maturity status together with the access date. Do not infer a stable release from an unversioned URL, and do not revise an earlier conclusion without a new dated ledger row and an explicit supersession note. | A capability, support, or maturity claim may be incorrectly presented as contemporaneous or stable. |
| Evidence-grade boundaries can turn product positioning, roadmap intent, or anecdote into a capability/pain claim. | Current-Weft repository source and tests are direct implementation evidence; `README.md`, architecture, package-policy, roadmap, and technical-overview target statements are hypotheses. The feature Evidence Policy requires Grade A for platform capabilities and says Grade D is only a lead. | Phase 1 must define the canonical conclusion labels and source-row schema. Phase 2 accepts capability cells only with Grade A evidence; Phase 3 records pain triggers, affected workload/team, consequence, workaround and cost, severity, and confidence. Grade B–D material must retain its grade and limitation; Grade D cannot establish a requirement without corroboration. A Grade-A target document proves intent, never current implementation. | The comparison becomes advocacy or misstates planned Weft behavior as implemented behavior. |
| Cross-vendor benchmark conclusions are invalid without an equivalent workload and reproducible measurement conditions. | No reference application, frozen fixture set, benchmark methodology, or reproduced cross-platform measurements exists yet. EPIC-001 prohibits comparison across different workloads, hardware, deployment topology, runtime versions, or cache state; FeatureDescription also requires identical production configuration and database/network fixtures. | Phases 4–5 must freeze the shared workload, seeded data, roles, journeys, failure fixtures, security assumptions, visual acceptance, and interaction placement. Phase 6 must define pinned hardware/runtime/framework versions, production configuration, cold/warm states, collection method, and reporting schema before measurements. Until then, performance/security/competitive numbers remain absent or explicitly labelled `Hypothesis`; external numbers may inform a lead but cannot populate a side-by-side result. | Performance requirements or market claims would be incomparable and cannot be promoted to Must/Should evidence. |
| The local health-check and feature artifacts are untracked at the recorded repository baseline. | `git status --short --branch` on 2026-07-15 reports `?? MemoryBank/` and `?? logs/`; all seven later output paths and `research-methodology-and-evidence-contract.md` are absent before their planned producer phases. | Treat this phase document as local workflow evidence, not as proof that the committed baseline contains it. Before a later review/finalization claim, inspect the owning repository status and ensure the required artifacts are durable through the normal focused commit workflow; do not invent output evidence before its producer phase. | Reviewers or later phases could rely on local-only artifacts or claim a deliverable exists before it has been produced. |

**Phase 1 handoff.** Start by copying these controls—not framework conclusions—into
`research-methodology-and-evidence-contract.md`. Its source ledger, version policy, evidence
rules, and benchmark-comparability gate must keep each risk visible to the
producer phases. No risk is resolved merely because a URL was reachable during
this Phase 0 check.

## Task 6 Research-Baseline Review

**Reviewed 2026-07-15.** The review confirmed that every current-Weft claim in
this phase has a direct repository source or test path, while enhanced actions,
browser C#, and lazy capability loading remain target-only architecture or
roadmap hypotheses. It also reconfirmed the explicit absence of
`EpicAcceptanceTests.md`, `research-methodology-and-evidence-contract.md`, and all six
future-producer research documents; no missing input was silently treated as
coverage.

`research-baseline-review` used static repository predicates: existence checks
for every source, document, EPIC, and test path cited by Tasks 1 and 4; exact
heading checks for `WeftExecutionMode.Html`, `### 2. Enhanced server action`,
`## Browser boundary`, and `## Phase 4 — Supported lazy capability loading`;
repository-wide absence checks for `EpicAcceptanceTests.md`; expected absence
checks for the canonical planning artifact and six producer outputs; ledger
precondition checks; and trailing-whitespace checks on this phase file and
`FeatureTasks.md`.

| Attempt | Result | Diagnosis and outcome |
| --- | --- | --- |
| 1 | Failed | The target-evidence predicate searched for `Enhanced server actions`, but the source heading is the singular `### 2. Enhanced server action`; this was an audit-query wording mismatch, not a missing source or changed product contract. |
| Retry 1 | Passed | The exact heading predicate was corrected. All cited inputs exist, the current/target distinction is evidenced, required absences remain explicit, the next ledger item remains this validation gate, and the reviewed Markdown is whitespace-clean. |
| Documentation verification 1 | Failed | The post-edit assertion searched for `research-baseline-review` before `Phase 0` in `FeatureTasks.md`; the durable traceability sentence has the correct reverse order. A diagnostic `printf` also used a leading-dash format string. Neither failure concerns a repository input or documentation claim. |
| Documentation verification retry 1 | Passed | The corrected traceability predicate and `%s` `printf` format confirmed the evidence section, FeatureTasks traceability link, expected absences, and whitespace cleanliness. |

**Validation outcome.** The research baseline is complete for the active gate.
The next unchecked review-follow-up task must transfer the documented absences
and risks to Phase 1 without creating substitute evidence. Hepha retains
ownership of lifecycle fields, task-state rows, and gate decisions.

## Task 7 Review Follow-up And Phase 1 Handoff

**Reviewed 2026-07-15.** No saved review report or finding ledger exists for
FEAT-001, so there is no reviewer finding to resolve. The follow-up instead
re-audited the Phase 0 source paths, documented absences, and Phase 1 producer
preconditions. All 22 cited current-Weft, source-document, test, and EPIC paths
remain present. `EpicAcceptanceTests.md` and the canonical
`research-methodology-and-evidence-contract.md` remain absent; neither absence is evidence of a
capability or acceptance test.

| Missing input or risk | Phase 0 disposition | Explicit Phase 1 handoff | Consumer boundary |
| --- | --- | --- | --- |
| Canonical planning artifact and its nine required control headings | Expected absence: Phase 1 has not created `research-methodology-and-evidence-contract.md` or its required headings yet. | Create the canonical file and all nine headings named in Phase 1 Concrete Task 4 before releasing any consumer. | Phases 2–8 must read the completed artifact; no phase may invent a replacement schema. |
| EPIC acceptance scenarios | Confirmed absent: no `EpicAcceptanceTests.md` exists. | Record this absence in `## FEAT And EPIC Acceptance Evidence Ledger`; map EPIC success criteria to research deliverables instead of inventing Gherkin, browser, or executable coverage. | Phase 7 owns criteria-to-deliverable evidence; any browser implementation remains a future evidence-gated FEAT. |
| Related/follow-up FEAT and design artifacts | Confirmed absent. | Preserve the absence and do not assume an implementation consumer or approved design. | Phases 4–5 own the framework-neutral reference workload and UI clauses; Phase 7 may propose only evidence-gated follow-up FEAT candidates. |
| Active LessonsLearned rules | Confirmed absent at this review. | Re-inspect `MemoryBank/LessonsLearned/` before starting Phase 1 and apply any rules added after this snapshot. | Later workers must repeat that pre-work check; absence does not authorize inventing rules or coverage. |
| Official-source access and version/maturity drift | Unresolved research risk; current URL reachability is only a dated access observation. | Establish the source ledger and version policy with exact URL/repository, source-observed version/status, access date, grade, confidence, conclusion label, scope limitation, and supersession handling. | Phases 2–3 use it for capabilities and pains; changed or inaccessible sources remain explicit gaps. |
| Evidence-grade and current-versus-target boundary | Unresolved control risk; repository facts remain distinct from roadmap hypotheses. | Define the evidence taxonomy and conclusion labels; accept Grade A for capabilities, retain lower grades and limitations, and carry target-Weft claims only as hypotheses. | Phase 2 keeps Current Weft and Target Weft separate; Phase 3 does not promote an anecdote into a pain decision. |
| Comparable benchmark evidence | Unresolved by design: no frozen workload, methodology, or reproduced cross-platform measurement exists. | Define reference-workload equivalence and the benchmark-comparability gate, including deferred-measurement handling. | Phases 4–5 freeze the workload; Phase 6 defines methodology. No performance, security, or competitive result is inferred beforehand. |
| Local-only workflow artifacts | `MemoryBank/` and `logs/` remain untracked in the current repository status; no commit was made in this documentation task. | Retain this as a durability risk and inspect the owning repository status before a later review or finalization claim. | A later phase must use the normal focused-commit workflow for required artifacts or withdraw any durability claim; no phase may treat local presence as committed-baseline evidence. |

**Verification.** The first `phase-1 planning-precondition audit` treated the
nine Phase 1-produced headings as if they had to exist before Phase 1 and
therefore failed. It was corrected to report their expected pre-producer
absence without changing any project input. The corrected audit confirmed all
22 cited source paths, the two documented absences, and no trailing whitespace
in this phase file, `FeatureTasks.md`, or the Phase 1 document. This resolves
Phase 0's handoff obligation; it does not resolve or fabricate Phase 1's
research evidence.

## Task 8 Finalization And Phase 1 Handoff

**Finalization audit 2026-07-15.** `phase-0-finalization-audit` rechecked the
14 representative source, test, document, and EPIC paths that anchor the Phase
0 fact/hypothesis boundary. All were present. It also confirmed the expected
absence of `EpicAcceptanceTests.md` and the Phase 1-owned
`research-methodology-and-evidence-contract.md`, exactly seven already-completed bootstrap ledger
items, the single Hepha-owned finalization item, and a whitespace-clean
repository diff (`git diff --check`). The repository still reports untracked
`MemoryBank/` and `logs/`; this remains the documented durability risk and is
not represented as committed-baseline evidence.

**Phase 1 handoff.** The reviewed baseline is ready for Phase 1 to consume.
Phase 1 must use Tasks 2–5 and 7 as its input record, re-inspect
`MemoryBank/LessonsLearned/`, and create the canonical
`research-methodology-and-evidence-contract.md` before releasing a consumer phase. It must carry
forward the explicit artifact absences, current-versus-target Weft distinction,
source/version controls, and no-incomparable-benchmark rule. No new runtime,
acceptance-test, or public-document claim was introduced by this finalization.

The finalization checkbox and its `## Historical Hepha Task State (Non-Authoritative)` row intentionally
remain Hepha-owned until the orchestrator records this worker result.

## Phase Task Ledger

- [x] Inventory the branch, solution layout, baseline documents, existing tests, and target feature folder (Concrete Task 1).
- [x] Record the explicit presence or absence of EPIC acceptance scenarios, related FEAT/design artifacts, and LessonsLearned rules (Concrete Task 2).
- [x] Verify the seven required research outputs and their Phase 1 ownership (Concrete Task 3).
- [x] Build the current-Weft fact versus roadmap-hypothesis register with source paths (Concrete Task 4).
- [x] Record source-access, version-drift, evidence-grade, and benchmark-comparability risks (Concrete Task 5).
- [x] Validation gate: complete `research-baseline-review` and record its evidence in Quality Gate Evidence.
- [x] Review follow-up: resolve or explicitly hand off every missing input/risk to Phase 1; do not invent evidence.
- [x] Finalization: update this ledger and Hepha task state, then hand the reviewed baseline to Phase 1.

## Historical Hepha Task State (Non-Authoritative)

| Task ID | Task | State | Started | Completed | Duration |
| --- | --- | --- | --- | --- | --- |
| phase-0.phase-task-ledger.inventory-the-branch-solution-layout-baseline-documents-existing-tests-a | Inventory the branch, solution layout, baseline documents, existing tests, and target feature folder (Concrete Task 1). | COMPLETED | 2026-07-15T07:22:09.077Z | 2026-07-15T07:24:40.244Z | 2m 31s |
| phase-0.phase-task-ledger.record-the-explicit-presence-or-absence-of-epic-acceptance-scenarios-rel | Record the explicit presence or absence of EPIC acceptance scenarios, related FEAT/design artifacts, and LessonsLearned rules (Concrete Task 2). | COMPLETED | 2026-07-15T07:24:40.300Z | 2026-07-15T07:26:24.151Z | 1m 44s |
| phase-0.phase-task-ledger.verify-the-seven-required-research-outputs-and-their-phase-1-ownership-c | Verify the seven required research outputs and their Phase 1 ownership (Concrete Task 3). | COMPLETED | 2026-07-15T07:26:24.208Z | 2026-07-15T07:29:11.921Z | 2m 48s |
| phase-0.phase-task-ledger.build-the-current-weft-fact-versus-roadmap-hypothesis-register-with-sour | Build the current-Weft fact versus roadmap-hypothesis register with source paths (Concrete Task 4). | COMPLETED | 2026-07-15T07:29:11.970Z | 2026-07-15T07:32:00.874Z | 2m 49s |
| phase-0.phase-task-ledger.record-source-access-version-drift-evidence-grade-and-benchmark-comparab | Record source-access, version-drift, evidence-grade, and benchmark-comparability risks (Concrete Task 5). | COMPLETED | 2026-07-15T07:32:00.925Z | 2026-07-15T07:34:25.335Z | 2m 24s |
| phase-0.phase-task-ledger.validation-gate-complete-research-baseline-review-and-record-its-evidenc | Validation gate: complete research-baseline-review and record its evidence in Quality Gate Evidence. | COMPLETED | 2026-07-15T07:34:25.401Z | 2026-07-15T07:39:02.783Z | 4m 37s |
| phase-0.phase-task-ledger.review-follow-up-resolve-or-explicitly-hand-off-every-missing-input-risk | Review follow-up: resolve or explicitly hand off every missing input/risk to Phase 1; do not invent evidence. | COMPLETED | 2026-07-15T07:39:02.853Z | 2026-07-15T07:41:43.432Z | 2m 41s |
| phase-0.phase-task-ledger.finalization-update-this-ledger-and-hepha-task-state-then-hand-the-revie | Finalization: update this ledger and Hepha task state, then hand the reviewed baseline to Phase 1. | COMPLETED | 2026-07-15T07:41:43.520Z | 2026-07-15T07:44:28.348Z | 2m 45s |

## Expected Research Artifacts And Contracts

- Phase-local baseline/risk notes or equivalent entries in `research-methodology-and-evidence-contract.md` once Phase 1 begins.
- No public runtime, data, API, UI, or integration contract changes.

## Research Validation Intent

Use `research-baseline-review` to ensure current-Weft evidence comes from the repository and that no missing linked artifact is silently ignored.

## Required Evidence

Baseline inventory, source-document list, deliverable inventory, and explicit absence/presence record for EPIC acceptance scenarios and design artifacts.

## Research Review Evidence

| Gate | Decision | Evidence / Justification |
| --- | --- | --- |
| Changed files | not applicable | Health-check scope only; no production file changed. `Phases/phase-0-research-baseline.md` records the completed `research-baseline-review` and finalization narrative; `FeatureTasks.md` records its Phase 0 traceability link. |
| Tests | not applicable | No executable behavior changed. `research-baseline-review` Retry 1 passed as a static source/provenance, expected-absence, ledger-precondition, and whitespace audit; `phase-0-finalization-audit` also passed for cited baseline paths, expected absences, ledger boundary, and `git diff --check`. |
| Gherkin/Playwright E2E | not applicable | Health-check scope only; no browser behavior is introduced and EPIC-001 has no `EpicAcceptanceTests.md`. |
| Code review | not applicable | Health-check scope only; no code or executable documentation contract is changed. |

## Acceptance Criteria

- Current Weft facts and roadmap hypotheses are explicitly distinguishable.
- Required inputs and absences are documented.
- Phase 1 has a complete list of deliverables and research risks.

## Completion Gate

Baseline inventory is reviewed and the Phase 1 planning artifact has a confirmed input set.

## Blockers Or Assumptions

Assumes the repository baseline remains accessible. Stop and report if required current-Weft source or parent EPIC evidence becomes unreadable.

## Recovery Note

**2026-07-15 workflow recovery.** The failed continuation was a lifecycle reconciliation conflict: the final worker returned its Phase 0 handoff while its final task remained intentionally Hepha-owned, then deterministic reconciliation correctly recorded all eight checked ledger items and this phase as `COMPLETED`. The FeatureTasks phase-summary row is aligned to that settled state. Do not rerun Phase 0; begin Phase 1 from its first unchecked ledger task.

## Historical Hepha Phase State (Non-Authoritative)

- **Status:** COMPLETED
- **Completed At:** 2026-07-15T07:44:28.359Z
- **Completion Provenance:** Deterministic phase-state reconciliation from checked phase-document tasks and settled Quality Gate Evidence; worker final prose was not used.

## Historical Hepha State Reconciliation Audit

- 2026-07-15T07:44:28.359Z | Phase 0 promoted to COMPLETED | checked phase-document tasks and settled quality gates verified.
