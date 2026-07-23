# FEAT-001 Research Methodology and Evidence Contract

This is the canonical cross-phase planning handoff for FEAT-001. It controls
how later research deliverables exchange evidence and acceptance information;
it is not evidence that any framework capability, reference implementation, or
benchmark result exists.

## Scope And Phase-Dependency Summary

FEAT-001 creates an evidence baseline for Blazor, Next.js App Router, TanStack
Start and its named supporting packages, Angular, and Weft. Weft must be
represented in two visibly separate states: repository-backed current evidence
and target hypotheses. The feature produces a capability matrix, a praised
quality and pain catalog, a framework-neutral reference-application
specification, a benchmark methodology, a ranked Weft requirements catalog, a
gap and decision backlog, and approved evidence-labelled updates to the Weft
technical overview. It does not implement runtime, API, data, UI, browser, or
reference-application behavior.

The work is ordered so that no consumer invents a missing provider contract:

| Producer | Durable handoff | Consumer dependency |
| --- | --- | --- |
| Phase 0 | Repository baseline, current-Weft fact/hypothesis boundary, required-artifact absences, and research risks in `Phases/phase-0-research-baseline.md` | Phase 1 uses this baseline to define the canonical planning contract; Phase 2 uses repository paths as current-Weft evidence inputs. |
| Phase 1 | This `research-methodology-and-evidence-contract.md` | Phases 2–8 must read their Research Phase Index row and every named planning heading before work begins. |
| Phase 2 | `framework-comparison-report.md` | Phases 3 and 6 consume capability evidence; Phases 7–8 audit its coverage and provenance. |
| Phase 3 | `praised-qualities-and-pains.md` | Phase 6 consumes controlled quality, pain, and preliminary response records; Phases 7–8 audit traceability. |
| Phase 4 | Base `reference-application-spec.md` workload, data, role, route, failure, security, and integration contracts | Phase 5 adds UI acceptance clauses; Phase 6 uses the frozen workload for measurement methodology. |
| Phase 5 | Completed UI, accessibility, observable-state, DOM-ownership, and browser-boundary clauses in `reference-application-spec.md` | Phase 6 uses equal browser observables and fixture boundaries for all platforms. |
| Phase 6 | `benchmark-methodology.md`, `weft-alternative-requirements.md`, and `weft-gap-and-decision-backlog.md` | Phase 7 audits requirements, decisions, deferrals, and approval boundaries. |
| Phase 7 | Completed FEAT/EPIC acceptance ledger, audited deliverables, approved technical-overview updates, and owned gaps | Phase 8 performs final consistency and manual-review-ready reconciliation. |
| Phase 8 | Final handoff summary and owner-decision list | Product owner review; no runtime implementation is authorized by implication. |

The cross-phase contracts are documentation contracts. Phase 1 owns the source
and conclusion schema, version policy, coverage rules, decision vocabularies,
comparability gate, acceptance ledger, and update rules. Phases 4–5 own the
future reference workload's data/API/UI/adapter observables, but public code
entry points remain not applicable in this research FEAT. There is no
`EpicAcceptanceTests.md`, related implementation FEAT, design artifact, or
active `MemoryBank/LessonsLearned/` rule document in the Phase 0 baseline;
later phases must preserve those absences and must not fabricate executable,
Gherkin, Playwright, security, performance, or browser evidence.

Reproduced cross-platform measurements are deferred until equivalent
implementations and pinned environments exist. Version drift, inaccessible or
insufficient official sources, current-versus-target Weft leakage, unequal
workloads, and unapproved public-document changes are cross-phase risks. A
consumer must stop and return to the owning provider phase when a prerequisite
is absent, incomplete, changed, or contradicted. Any phase that changes a
contract used later must update this report before dispatching its consumer.
The per-phase navigation, policy controls, canonical source-row schema, and
criterion-level acceptance map are established in this report. Consumer update
mechanics and the Phase 1 release gates remain later Phase 1 work.

## Research Phase Index

| Phase | Planning sections / heading references | Research obligations / observable boundaries | Acceptance evidence / handoff |
| --- | --- | --- | --- |
| Phase 0 — Research Baseline | Read `Scope And Phase-Dependency Summary`, `Evidence Taxonomy And Source Ledger`, and `Decision And Approval Boundaries` when reconciling the baseline. | Inventory repository facts, separate current-Weft evidence from target hypotheses, record required-artifact absences and research risks, and identify provider ownership. Public functions/adapters/entry points: Not applicable; this is a repository and documentation baseline. | Evidence: `Phases/phase-0-research-baseline.md` under `Task 1 Baseline Inventory` through `Task 8 Finalization And Phase 1 Handoff`, including `research-baseline-review` and `phase-0-finalization-audit`. Handoff: repository paths and risk/absence controls to Phase 1, and current-Weft source inputs to Phase 2. |
| Phase 1 — Research Methodology and Evidence Contract | Read `Scope And Phase-Dependency Summary`, `Research Phase Index`, `Evidence Taxonomy And Source Ledger`, `Mandatory Platform Version Policy`, `Matrix Coverage Rules`, `Pain And Quality Analysis Rules`, `Reference Workload Equivalence Rules`, `Benchmark Comparability Gate`, `Requirement Ranking Rules`, `Decision And Approval Boundaries`, and `FEAT And EPIC Acceptance Evidence Ledger`. | Define the canonical source/conclusion schema, version and coverage policies, workload/benchmark/ranking controls, decision vocabulary, acceptance mapping, and consumer update/return rules. Observable boundary: this planning document is the durable research contract. | Evidence: `source-provenance-audit`, `decision-traceability-audit`, and `research-baseline-review` recorded in `Phases/phase-1-research-methodology-and-evidence-contract.md`. Handoff: the completed canonical contract to every Phase 2–8 researcher; no consumer starts before every named heading exists and the Phase 1 completion gate passes. |
| Phase 2 — Framework Capability Profiles | Read `Evidence Taxonomy And Source Ledger`, `Mandatory Platform Version Policy`, and `Matrix Coverage Rules`. | Produce `framework-comparison-report.md`; cover all 24 dimensions for Blazor, Next.js App Router, TanStack Start and each named supporting package, Angular, Current Weft, and Target Weft Hypothesis with Grade-A capability evidence or an explicit unavailable/not-implemented state. Public functions/adapters/entry points: Not applicable; repository symbols are cited evidence, not change targets. | Evidence: completed canonical source rows plus `source-provenance-audit` and `matrix-coverage-audit`, including current/target Weft separation and per-package TanStack maturity. Handoff: capability facts and unresolved research flags to Phases 3 and 6, then audit inputs to Phases 7–8. |
| Phase 3 — Praised Qualities and Pain Analysis | Read `Evidence Taxonomy And Source Ledger`, `Pain And Quality Analysis Rules`, and `Decision And Approval Boundaries`. | Produce `praised-qualities-and-pains.md`; apply the common quality/pain schemas, cross-link Phase 2 matrix evidence, use only controlled mechanism and pain-response vocabularies, and retain unresolved claims as labelled leads rather than requirements. Public functions/adapters/entry points: Not applicable. | Evidence: per-platform coverage and `source-provenance-audit` plus `decision-traceability-audit`, with every pain's trigger, consequence, workaround/cost, severity, confidence, grade, classification, and rationale. Handoff: controlled quality, pain, and preliminary response records to Phase 6 and audit inputs to Phases 7–8. |
| Phase 4 — Reference Application Contract | Read `Matrix Coverage Rules`, `Pain And Quality Analysis Rules`, and `Reference Workload Equivalence Rules`. | Produce the base `reference-application-spec.md`; freeze domain vocabulary, seeded data, roles, route/action outcomes, layouts and states, admin validation/security flows, cache/failure fixtures, server-owned partial-update fallback, sustained-local interaction, JavaScript adapter boundary, assets, and operational signals. Observable boundary: the specification names future routes/actions, partial-update responses, local-capability activation, and the third-party adapter contract without implementing them. | Evidence: `reference-workload-review` proving equal data, roles, routes, outcomes, failures, authority boundaries, and fixtures without an implementation claim. Handoff: frozen workload and adapter observables to Phase 5 for browser criteria and to Phase 6 for methodology. |
| Phase 5 — Browser Experience and Accessibility Criteria | Read `Reference Workload Equivalence Rules` and `Benchmark Comparability Gate`. | Extend `reference-application-spec.md` with semantic HTML, visual/responsive, keyboard/focus/live-region, metadata, error, cancellation, fallback, partial-update, failed-asset, local-capability, DOM-ownership, disposal, and browser-memory observables. Observable boundary: later validators must exercise the specified browser routes/actions and adapter boundaries; helper-only checks cannot establish acceptance. | Evidence: `reference-workload-review` and `documentation-consistency-review` proving equal observable expectations across HTML-first, hydrated, and client-rendered approaches; Gherkin/Playwright remains explicitly not applicable until a later implementation FEAT. Handoff: frozen browser, accessibility, DOM, and adapter criteria to Phase 6. |
| Phase 6 — Weft Requirements and Decision Synthesis | Read `Evidence Taxonomy And Source Ledger`, `Reference Workload Equivalence Rules`, `Benchmark Comparability Gate`, `Requirement Ranking Rules`, and `Decision And Approval Boundaries`. | Produce `benchmark-methodology.md`, `weft-alternative-requirements.md`, and `weft-gap-and-decision-backlog.md`; pin environments and fixtures, reject incomparable results, rank deduplicated requirements, apply the performance gate, decide every competitor mechanism/significant pain, and bound approval-gated follow-up candidates. Public functions/adapters/entry points: Not applicable; no benchmark harness or runtime integration is implemented. | Evidence: `benchmark-comparability-review` and `decision-traceability-audit` linking methodology, requirements, and decisions to Phase 2–5 inputs; reproduced measurements remain deferred unless the full comparability gate is met. Handoff: complete synthesis package and visible approval/deferment boundaries to Phase 7. |
| Phase 7 — Evidence Audit and Overview Update | Read `Evidence Taxonomy And Source Ledger`, `Mandatory Platform Version Policy`, `Matrix Coverage Rules`, `Pain And Quality Analysis Rules`, `Reference Workload Equivalence Rules`, `Benchmark Comparability Gate`, `Requirement Ranking Rules`, `Decision And Approval Boundaries`, and `FEAT And EPIC Acceptance Evidence Ledger`. | Audit and repair all deliverables, complete every FEAT/EPIC ledger row, apply only approved evidence-labelled technical-overview changes, list unapproved public-document proposals, and verify bounded follow-up candidates. Public code validators/entry points: Not applicable because this FEAT changes documentation only; each contract is validated through its named research audit, while future executable validators must test their public surfaces rather than helpers. | Evidence: all named research audits, completed acceptance-ledger states with owner/follow-up for gaps, `documentation-consistency-review`, and `manual-review-ready`; exact repaired paths and approved overview diff are recorded. Handoff: audited package, unresolved owner decisions, and provider-return actions to Phase 8. |
| Phase 8 — Research Closure and Follow-up | Read `Scope And Phase-Dependency Summary`, `Research Phase Index`, `Benchmark Comparability Gate`, `Decision And Approval Boundaries`, and `FEAT And EPIC Acceptance Evidence Ledger`. | Reconcile deliverable inventory, terminology/provenance, acceptance states, dependencies, deferrals, approvals, current/target separation, anti-fabrication controls, and bounded next work; publish the owner-facing handoff without authorizing runtime work. Public functions/adapters/entry points: Not applicable. | Evidence: final `manual-review-ready`, `documentation-consistency-review`, and `source-provenance-audit`, plus owner/follow-up for every deferred or blocked item. Handoff: manual-review-ready evidence package and explicit owner-decision list to the product owner; unresolved mandatory evidence returns to its owning phase. |

All nine navigation rows are present. They identify the exact planning headings,
phase obligations, applicable entry-point or adapter boundary, acceptance
evidence, and next consumer. The policy headings, canonical source-row schema, and criterion-by-criterion
acceptance mapping referenced by the index are established below. The consumer
update rule and Phase 1 validation gates remain owned by later Phase 1 ledger
items. Until those items pass, this index remains navigation for planning work
and is not released as a complete contract to Phases 2–8.

## Evidence Taxonomy And Source Ledger

Every material capability, quality, pain, requirement, decision, or comparison
conclusion must resolve to one or more stable evidence records. A citation is a
lead until its record identifies the exact claim it supports and the limits of
that support. Later deliverables reference evidence-record identifiers rather
than copying a source into unrelated claims.

Source grades are fixed by `FeatureDescription.md`:

| Grade | Permitted evidence | Use in this FEAT |
| --- | --- | --- |
| A | Official documentation, source, specification, release note, or reproducible first-party benchmark | Required to establish a platform capability. Repository source and tests are the authority for Current Weft. |
| B | Maintainer issue/discussion, migration guide, security advisory, or documented design limitation | May establish a maintained limitation or pain context; it does not replace Grade A capability evidence. |
| C | Reproducible independent benchmark, case study, postmortem, or widely corroborated technical analysis | May support observed consequences and external context when scope and method are recorded. |
| D | Individual report, forum comment, or unverified anecdote | Lead only; it cannot establish a capability or requirement without corroboration. |

Allowed conclusion labels are exactly `Fact`, `Reproduced Observation`,
`Inference`, `Hypothesis`, and `Prediction`. A fact must not overrun its source;
a reproduced observation requires a recorded method and result; an inference
must link its premises; and hypotheses or predictions must remain visibly
unverified. Confidence is recorded independently of grade so that an official
source with unclear applicability is not silently treated as high-confidence
proof.

Current Weft records cite implemented repository symbols, tests, or executable
examples. Target Weft records cite roadmap or architecture material and use a
hypothesis/prediction conclusion; they never satisfy a current-capability cell.
Supplemental frameworks may support a specific design question but cannot add
matrix columns without an approved scope revision.

### Canonical Source-Row Schema

Every producer deliverable that introduces evidence must contain a
`## Source Ledger` table using the following exact columns and order. This
planning report owns the schema; producer ledgers own the evidence rows. The
`Evidence ID` is the FEAT-wide join key used by matrix cells, quality/pain
records, workload clauses, benchmark inputs, requirements, decisions, and the
acceptance ledger. The template row below defines fields only and is not an
evidence claim.

| Evidence ID | Record state | Platform / state | Dimension / claim | URL or repository | Evaluated version / status | Access date | Evidence type / grade | Confidence | Conclusion label | Scope limitation | Consumer deliverable |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EV-####` | `ACTIVE` | `<controlled platform/state>` | `<dimension and one atomic claim>` | `<stable URL or commit-qualified repository locator>` | `<concrete version, release channel, maturity, or commit>` | `YYYY-MM-DD` | `<controlled evidence type> / Grade <A-D>` | `<High, Medium, or Low>` | `<Fact, Reproduced Observation, Inference, Hypothesis, or Prediction>` | `<applicable mode, conditions, and exclusions>` | `<exact artifact path, heading, and record/cell ID>` |

All twelve fields are required for an active evidence row:

| Field | Canonical rule |
| --- | --- |
| `Evidence ID` | Use a unique, immutable, monotonically allocated `EV-####` identifier across FEAT-001. Never recycle an identifier or assign a second claim to it. |
| `Record state` | Use exactly `ACTIVE`, `STALE`, or `SUPERSEDED`. Only `ACTIVE` may support a current conclusion. A non-active row remains in its producer ledger and identifies its replacement or refresh need in `Scope limitation`. |
| `Platform / state` | Use `Blazor`, `Next.js App Router`, `TanStack Start`, the exact supporting package name such as `TanStack Router`, `TanStack Query`, `TanStack Form`, or `TanStack Table`, `Angular`, `Current Weft`, or `Target Weft Hypothesis`. Prefix a targeted non-matrix source with `Supplemental —`; never use an undifferentiated `Weft` or `TanStack` value. |
| `Dimension / claim` | State one atomic material claim. Matrix evidence starts with the exact `D01`–`D24` dimension identifier; other records name the quality, pain, workload, benchmark, requirement, decision, or acceptance record they support. One source used for materially different claims receives one row per claim. |
| `URL or repository` | Store the canonical source URL with the most specific stable heading/anchor available, or a commit-qualified repository locator in `<commit>:<path>#<symbol-or-lines>` form. Current Weft uses repository source/test/example locators; Target Weft Hypothesis uses a commit-qualified document path and heading. A link to a home page alone is insufficient. |
| `Evaluated version / status` | Record the concrete framework/package version, release line and channel or maturity when relevant. Current Weft records the evaluated commit; target documents record their revision. Values such as `latest`, `current`, or `stable` without a concrete version/status are invalid. |
| `Access date` | Record the date on which the cited content and locator were inspected, in ISO `YYYY-MM-DD` form. This is independent of release or commit date. |
| `Evidence type / grade` | Record one controlled evidence type and its policy grade in `<type> / Grade <A-D>` form. The type-to-grade mapping below is fixed; capability claims require Grade A. |
| `Confidence` | Use exactly `High`, `Medium`, or `Low` according to the definitions below. Confidence measures claim applicability and corroboration, not source grade, and cannot upgrade weak evidence. |
| `Conclusion label` | Use exactly `Fact`, `Reproduced Observation`, `Inference`, `Hypothesis`, or `Prediction`. The label must match the claim, not merely the source type. |
| `Scope limitation` | State applicable rendering/deployment mode, package or feature boundary, workload/population, conditions, exclusions, and source ambiguity. Use `None identified for the cited version and mode` only after those boundaries have been checked; never leave the field blank. |
| `Consumer deliverable` | Name every exact consuming artifact path plus heading and record, requirement, decision, acceptance, or matrix-cell ID. Do not use `all deliverables` or an implicit cross-reference. |

The controlled evidence-type/grade pairs are:

| Grade | Controlled evidence types |
| --- | --- |
| Grade A | `Official documentation`, `Source code`, `Specification`, `Release note`, `Reproducible first-party benchmark` |
| Grade B | `Maintainer issue/discussion`, `Migration guide`, `Security advisory`, `Documented design limitation` |
| Grade C | `Reproducible independent benchmark`, `Case study`, `Postmortem`, `Widely corroborated technical analysis` |
| Grade D | `Individual report`, `Forum comment`, `Unverified anecdote` |

Confidence is assigned consistently:

| Confidence | Meaning |
| --- | --- |
| `High` | The source directly supports the whole atomic claim for the recorded version, mode, and scope; repository claims resolve to the cited symbol/test/example. |
| `Medium` | The source supports the claim but applicability is conditional, indirect, mode-specific, or not independently corroborated; the limitation is explicit. |
| `Low` | Material applicability or corroboration remains uncertain. The row may be a lead or hypothesis but cannot establish a capability or requirement by itself. |

Schema preservation rules are mandatory. Allocate a separate row when one claim
needs multiple sources or one source supports materially different claims; a
consumer cites every applicable `Evidence ID`. A typo or locator-only correction
may retain the ID if claim identity, version, and scope do not change. A change
to the material claim, platform/state, evaluated version, source meaning, or
scope creates a new ID; retain the old row as `SUPERSEDED` and identify the new
ID. Version drift marks the old row `STALE` until a new active row is evaluated.
The same change must update all named consumers, so no active consumer points
only to a stale or superseded row.

No phase may rename, remove, reorder, or locally reinterpret these fields. A
needed schema extension returns to Phase 1 and updates this section before any
producer or consumer adopts it. `SOURCE_GAP` and `NOT_APPLICABLE` matrix states
must record their required gap or product-boundary rationale in the matrix; they
must not fabricate an evidence row or placeholder URL. The
`source-provenance-audit` rejects missing fields, uncontrolled values, duplicate
IDs, non-atomic claims, unqualified versions/locators, unsupported capability
grades, target/current leakage, and active consumers that resolve only to
non-active evidence.

## Mandatory Platform Version Policy

Each mandatory platform is evaluated at a named version or maturity status that
was current and supported on the source access date. `Current stable`, `latest`,
or an unversioned documentation URL is not a sufficient stored value by itself.
The evidence record must preserve the concrete version/status shown by the
source, the access date in ISO `YYYY-MM-DD` form, and any documentation-version
selector or release channel needed to interpret it.

- Blazor covers the supported Blazor Web App model and records the .NET/ASP.NET
  Core version for Static Server, Interactive Server, Interactive WebAssembly,
  and Interactive Auto claims; it is never reduced to WebAssembly alone.
- Next.js covers the stable App Router and records the Next.js version or stable
  release line plus deployment/runtime assumptions relevant to each claim.
- TanStack records TanStack Start separately from Router, Query, Form, Table,
  and every other cited supporting package. Each package gets its own version,
  release channel, and maturity/stability status; the family is not presented
  as one monolithic product.
- Angular records the stable Angular version and identifies when a capability
  depends on an optional package, rendering mode, or migration state.
- Current Weft records the repository commit and relevant file/symbol/test.
  Target Weft Hypothesis records the source-document revision or commit and
  remains separate from implemented evidence.

A later version drift check must mark a record stale when the source's supported
version, maturity, or relevant behavior changes. Stale records remain
historical evidence but cannot silently support the final matrix: the owning
phase must refresh them or record an explicit source gap and impact. Comparing
different platform release dates is permitted only as a versioned snapshot,
not as a claim about an unspecified present.

## Matrix Coverage Rules

`framework-comparison-report.md` must cover all 24 numbered dimensions from
`FeatureDescription.md` for Blazor, Next.js App Router, TanStack Start with its
named supporting packages, Angular, Current Weft, and Target Weft Hypothesis.
The two Weft states are separate visible columns or sections even though they
represent one mandatory platform.

Every platform/dimension intersection must contain:

1. an evidence-backed capability or limitation linked to canonical evidence;
2. the evaluated deployment/rendering mode when behavior varies by mode;
3. a conclusion label and confidence; and
4. one explicit coverage state: `EVIDENCED`, `NOT_APPLICABLE`,
   `NOT_YET_IMPLEMENTED`, or `SOURCE_GAP`.

`NOT_APPLICABLE` requires a product-boundary reason. `NOT_YET_IMPLEMENTED` is
valid for Current Weft only when repository evidence supports the absence and
must not be replaced by a target hypothesis. `SOURCE_GAP` identifies unfinished
research and cannot be interpreted as lack of platform capability. Capability
entries require Grade A evidence; lower-grade sources may annotate pain or
operational context but cannot fill the capability obligation.

The matrix records deployment mode and does not merge materially different
modes into an averaged answer. Security, accessibility, failure behavior,
dependency footprint, and operational maturity remain first-class dimensions.
No total score or universal winner is produced. `matrix-coverage-audit` must
count exactly 24 dimensions across every required platform/state and reject
missing, duplicated, target-as-current, or unsupported cells.

## Pain And Quality Analysis Rules

`praised-qualities-and-pains.md` applies the same evidentiary discipline to
positive and negative observations. Each mandatory platform must have at least
five material qualities and five material pains, but weak evidence remains a
labelled lead rather than being promoted merely to meet the count.

A quality record identifies the mechanism, user problem solved, affected
workload/team, evidence and grade, conditions/limitations, confidence, and a
proposed Weft mechanism response: exactly `Adopt`, `Adapt`, `Interoperate`,
`Defer`, or `Reject`. Popularity is not evidence that a quality works.

A pain record identifies the trigger, affected workload/team, consequence,
standard workaround, cost introduced by that workaround, severity, confidence,
evidence and grade, classification, and a proposed Weft pain response: exactly
`Avoid`, `Mitigate`, `Accept`, or `Not Applicable`. Classification is one of
`Essential complexity`, `Implementation limitation`, `Changeable default`,
`Ecosystem/tooling consequence`, `Hosting-provider consequence`, `Application
design`, or `Team practice`; framework blame must not absorb another category.

Every proposed response includes architecture rationale and remains a research
decision pending the approval rules below. A single numeric winner score is
forbidden. Ratings may be used only when their definitions and supporting
evidence are visible. Phase 3 cross-links Phase 2 capability records and leaves
uncorroborated Grade-D items as research leads, not requirement inputs.

## Reference Workload Equivalence Rules

`reference-application-spec.md` defines one framework-neutral modular business
application; this FEAT specifies it but does not implement it. Equivalent means
identical business outcomes, authority boundaries, fixtures, and observable
acceptance conditions—not identical internal architecture.

The specification freezes, before benchmark methodology is consumed:

- domain vocabulary, seeded records, data volumes, stable identifiers, roles,
  credentials/test identities, authorization boundaries, and security
  assumptions;
- public list/detail/search/filter/sort/pagination journeys, shared and nested
  layouts, metadata, not-found, loading, and error outcomes;
- authenticated create/edit/admin journeys with server-authoritative
  validation, client feedback where applicable, antiforgery, cancellation,
  duplicate/stale/concurrent submission rules, and post-success navigation;
- cache invalidation, slow response, retry, stale-response, offline, failed
  asset, and partial-failure fixtures;
- one server-owned partial update with an ordinary navigation/form fallback,
  one sustained local interaction with a measurable reason for browser
  execution, and one third-party JavaScript component behind a bounded,
  disposable adapter with explicit API and DOM ownership;
- semantic HTML, keyboard, focus, live-region, responsive, metadata,
  accessibility, visual-state, asset/hash, deployment, logging, tracing,
  metrics, health, and production-diagnostic observables; and
- unit, integration, browser, accessibility, security, fallback, and future
  performance verification obligations.

The data, network, cache, failure, and security fixtures must be reusable by all
future implementations. Platform-specific adapters may translate the contract
but may not weaken outcomes. Once Phase 5 freezes browser observables, a change
that affects comparison must be versioned and returned to the workload-owning
phase before measurements proceed. This research FEAT has no executable public
validator; a future implementation FEAT must test public routes/actions and
adapter boundaries, and helper-only tests cannot establish those contracts.

## Benchmark Comparability Gate

`benchmark-methodology.md` defines measurements but does not create results.
A side-by-side number or performance conclusion is publishable only when every
compared implementation passes all of these conditions:

1. the same frozen workload revision, seeded data, user journeys, failures,
   security assumptions, and acceptance outcomes;
2. pinned framework/runtime/package versions, lockfiles, operating system,
   hardware or isolated host allocation, database, network profile, deployment
   topology, production configuration, compression, cache state, and warm-up;
3. equivalent release builds and declared rendering/hosting modes, with no
   platform-specific shortcut that changes the user-visible workload;
4. recorded commands, environment manifest, raw outputs, sample count,
   ordering/randomization, cold/warm definitions, variance/statistical method,
   tool versions, exclusions, failures, retries, and total validation window;
5. successful functional, accessibility, and security-control checks before
   performance samples are admitted; and
6. repeatable collection by another developer from the retained methodology
   and fixtures.

The methodology covers the required server, browser, dependency, build,
developer-loop, accessibility, security, and operational measures, including
checkout/cache/local footprint and file/graph counts; restore/install and edit
feedback; production build/output; requests, bytes, executable code, useful
HTML and readiness; cold/first/warm action behavior; throughput, tail latency,
CPU, memory, connection/state cost; browser memory; offline/cancellation/asset
failure; accessibility; and security controls.

Result states are `METHODOLOGY_ONLY`, `COMPARABLE_REPRODUCED`,
`CONTEXT_ONLY_EXTERNAL`, or `DEFERRED`. Vendor or unrelated benchmark numbers
may inform a hypothesis but are `CONTEXT_ONLY_EXTERNAL` and never populate the
final comparison. In this evidence-baseline FEAT, reproduced cross-platform
measurements are `DEFERRED` unless equivalent implementations and every gate
condition actually exist. A failed gate invalidates the comparison rather than
being waived by narrative.

## Requirement Ranking Rules

`weft-alternative-requirements.md` contains deduplicated requirement records
ranked exactly `Must`, `Should`, `Could`, or `Won't/Non-goal`. Ranking expresses
product necessity and evidence, not framework popularity or implementation
enthusiasm. Duplicate mechanisms are merged around the underlying user problem,
while materially different acceptance contracts remain separate.

Every requirement records a stable identifier, title, user value, linked
competitor/capability evidence, linked quality or pain and intended response,
Weft architecture rationale, current gap, measurable acceptance condition,
roadmap destination, dependencies, owner, and ranking rationale. Every `Must`
must have all of those fields and must satisfy the evidence-and-acceptance gate;
otherwise it remains a hypothesis, gap, or lower-ranked/deferred item.

A performance requirement cannot enter `Must` or `Should` from vendor numbers,
inference, or methodology alone. It requires `COMPARABLE_REPRODUCED` evidence
from the benchmark gate. Until then, the desired measurement may be retained as
a hypothesis or deferred research item without a competitive threshold.
Security and accessibility requirements are ranked as first-class capabilities
and are not deferred merely because they are non-performance concerns.

Only approved `Must` or `Should` records with bounded scope, measurable
acceptance, evidence, pain/quality decision, roadmap destination, and dependency
analysis may become follow-up FEAT candidates. `Could` and `Won't/Non-goal`
items remain visible for rationale and scope control; no ranking authorizes
runtime implementation by itself.

## Decision And Approval Boundaries

`weft-gap-and-decision-backlog.md` gives every competitor mechanism exactly one
proposed response—`Adopt`, `Adapt`, `Interoperate`, `Defer`, or `Reject`—and
every significant pain exactly one proposed response—`Avoid`, `Mitigate`,
`Accept`, or `Not Applicable`. Each record links evidence, affected user
problem, Weft principles, trade-offs, requirement/backlog destination, owner,
and rationale. `Copy it` is not a decision.

Researchers may collect evidence, propose responses, rank candidate
requirements, identify contradictions, and draft bounded follow-up candidates.
They may not, by implication:

- claim target Weft behavior as current behavior;
- authorize runtime/API/data/UI changes or start a follow-up implementation;
- publish incomparable performance, security, or competitive claims;
- change the mandatory platform scope;
- create a package registry or remove JavaScript interoperability; or
- silently change public architecture, package policy, roadmap, branding, or
  licensing commitments.

The product owner approves public-position changes, scope revisions, follow-up
FEAT creation, and any architecture/package-policy/roadmap proposal. Phase 7
may update `MemoryBank/Overview/technical-overview.md` only with an approval
record and evidence-labelled conclusion; unapproved changes remain proposals in
the backlog with owner and follow-up. A research decision and a requirement
rank are inputs to approval, not implementation authorization.

## FEAT And EPIC Acceptance Evidence Ledger

Phase 7 completes one ledger row for every FEAT acceptance criterion and every
EPIC-001 success criterion. There is no `EpicAcceptanceTests.md`, so there are
no EPIC Gherkin scenarios or browser tests to fabricate or map in this research
FEAT. Documentation audits and exact deliverable evidence are the applicable
acceptance mechanism; future executable coverage belongs to separately
approved implementation FEATs.

The ledger uses these evidence states: `NOT_STARTED`, `EVIDENCED`, `DEFERRED`,
`BLOCKED`, and `NOT_APPLICABLE`. `EVIDENCED` requires an exact artifact heading,
record identifier, or audit result. `DEFERRED` requires the reason, owner,
destination/follow-up, and condition that would permit completion. `BLOCKED`
requires the unresolved dependency and owner action. `NOT_APPLICABLE` requires
a scope-based rationale and cannot hide missing mandatory evidence. Reproduced
cross-platform measurements start as `DEFERRED`, never as fabricated evidence.

The canonical mapping below gives every FEAT acceptance criterion and every
EPIC-001 success criterion one primary owning deliverable, phase, and evidence
state. Compound FEAT criteria `FEAT-AC-06` and `FEAT-AC-12` are split into
suffixed atomic obligations so each row still has exactly one owner; the source
checkbox closes only when all of its suffixed rows are `EVIDENCED`. Duplicate
FEAT/EPIC intent remains as separate rows because both source checklists require
independent traceability, although one artifact may satisfy both.

| Criterion ID / title | Source | Owning deliverable | Owning phase | Evidence state | Exact evidence or gap | Owner / follow-up |
| --- | --- | --- | --- | --- | --- | --- |
| `FEAT-AC-01` — Platform version/status, access date, deployment mode, and official sources | FEAT acceptance criterion 1 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | `Evaluated Platform Register`, `Source Ledger`, and passing `Source Provenance Audit`. | Phase 7 audit complete; revisit on version refresh. |
| `FEAT-AC-02` — All 24 dimensions have evidence or explicit coverage state | FEAT acceptance criterion 2 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | `Capability Matrix` contains `D01`–`D24` for all six platform/state columns; `Matrix Coverage Audit`: PASS. | Phase 7 audit complete. |
| `FEAT-AC-03` — At least five material qualities and pains per platform, with weak evidence labelled | FEAT acceptance criterion 3 | `praised-qualities-and-pains.md` | Phase 3 | `EVIDENCED` | Five `BQ/NQ/TQ/AQ/WQ` and five `BP/NP/TP/AP/WP` records per platform; `Phase 3 Audit Results`: PASS. | Phase 7 audit complete. |
| `FEAT-AC-04` — TanStack Start and supporting packages represented accurately | FEAT acceptance criterion 4 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | `Evaluated Platform Register` separately records Start, Router, Query, Form, Table, and Devtools versions/maturity, including the docs/package-status inconsistency. | Recheck on snapshot refresh. |
| `FEAT-AC-05` — Current Weft separated from Target Weft Hypothesis | FEAT acceptance criterion 5 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | Separate `Current Weft` and `Target Weft Hypothesis` columns plus leakage check in `Phase 2 Audit Results`. | Phase 7 audit complete. |
| `FEAT-AC-06a` — Reference application is implementation-ready without invented requirements | FEAT acceptance criterion 6, reference-workload obligation | `reference-application-spec.md` | Phase 5 | `EVIDENCED` | RA-1 defines fixed data, routes `RT-01`–`RT-18`, journeys `J-01`–`J-07`, failures `FX-01`–`FX-12`, UI/browser/security/asset/operations contracts; `Reference Workload Review`: PASS. | Future implementers must use revision RA-1 unchanged. |
| `FEAT-AC-06b` — Benchmark plan is implementation-ready without invented requirements | FEAT acceptance criterion 6, benchmark obligation | `benchmark-methodology.md` | Phase 6 | `EVIDENCED` | BM-1 defines cohorts, environment, fixtures, cold/warm states, commands, metrics, order, raw-artifact reporting, and exclusions; `Benchmark Comparability Review`: PASS. | Future approved benchmark FEAT executes BM-1. |
| `FEAT-AC-07` — Requirements are ranked, deduplicated, and fully mapped | FEAT acceptance criterion 7 | `weft-alternative-requirements.md` | Phase 6 | `EVIDENCED` | WR-1 contains 15 Must, 8 Should, 5 Could, and 7 Won't records; `Traceability Audit`: PASS. Ranks remain proposals pending owner approval. | Product owner decides ranks before implementation sequencing. |
| `FEAT-AC-08` — Every competitor mechanism has an explicit reasoned Weft decision | FEAT acceptance criterion 8 | `weft-gap-and-decision-backlog.md` | Phase 6 | `EVIDENCED` | `Competitor Mechanism Decisions` maps all 26 qualities with rationale and destinations; `Decision Traceability Audit`: PASS. | Product owner decides proposal adoption. |
| `FEAT-AC-09` — Dependency analysis covers local/cache/graph/lock/script/provenance/license/publish concerns | FEAT acceptance criterion 9 | `benchmark-methodology.md` | Phase 6 | `EVIDENCED` | `Dependency Measurements` defines `DM-01`–`DM-10`, covering local/global disk, cache, graph, locks, lifecycle scripts, provenance, licenses, and publish output. | Future BM-1 execution supplies values. |
| `FEAT-AC-10` — Performance conclusions are reproduced comparably or remain hypotheses | FEAT acceptance criterion 10 | `benchmark-methodology.md` | Phase 6 | `DEFERRED` | Comparable reproduced measurements are intentionally absent because equivalent implementations and pinned execution environments do not exist. Only `METHODOLOGY_ONLY`, `CONTEXT_ONLY_EXTERNAL`, or visibly labelled hypotheses are allowed until the full gate yields `COMPARABLE_REPRODUCED`. | Future approved reference-implementation/benchmark FEAT; Phase 6 defines the gate and Phase 7 verifies no fabricated result or threshold. |
| `FEAT-AC-11` — Security and accessibility are first-class platform capabilities | FEAT acceptance criterion 11 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | Matrix `D11` and `D12`, relevant testing/tooling coverage in `D18`–`D19`, official-source ledger rows, RA-1 browser/security clauses, and `WR-M07`/`WR-M08` treat both as admission capabilities. | Phase 7 audit complete; source atomicity must be hardened per the 2026-07-20 recheck. |
| `FEAT-AC-12a` — Technical overview contains approved evidence-labelled conclusions | FEAT acceptance criterion 12, technical-overview obligation | `MemoryBank/Overview/technical-overview.md` | Phase 7 | `EVIDENCED` | Owner requested continuing Overview updates in this conversation; `Competitive research synthesis (FEAT-001, 2026-07-15)` distinguishes facts, hypotheses, and proposals. | Product owner reviews final wording. |
| `FEAT-AC-12b` — Proposed public architecture/package/roadmap changes are listed for approval | FEAT acceptance criterion 12, proposal-list obligation | `weft-gap-and-decision-backlog.md` | Phase 6 | `EVIDENCED` | `Documentation Audit and Proposed Changes` lists nine path-specific proposals, evidence, rationale, and `Pending owner` state; no public file was silently changed. | Product owner accepts/rejects each proposal. |
| `FEAT-AC-13` — Follow-up FEAT candidates are bounded and traceable to approved Must/Should requirements | FEAT acceptance criterion 13 | `weft-gap-and-decision-backlog.md` | Phase 7 | `DEFERRED` | `Proposed Follow-up FEAT Candidates` contains nine bounded candidates linked to proposed requirements, acceptance and dependencies, but WR-1 ranks are not yet owner-approved; no FEAT folders were created. | Paulo Aboim Pinto approves/revises WR-1 and sequencing before candidate creation. |
| `FEAT-AC-14` — Development errors map to useful source context without Production disclosure | FEAT acceptance criterion 14 | `developer-errors-and-native-shell-integration.md` | Phase 6 addendum | `EVIDENCED` | `Development Error Experience` defines overlay/source mapping and trusted-environment Production exclusion; `WR-M10` has measurable Development and Production acceptance. | Product owner approves CAND-06 implementation scope. |
| `FEAT-AC-15` — Native-shell research distinguishes targets, modes, bridge security and current limitations | FEAT acceptance criterion 15 | `developer-errors-and-native-shell-integration.md` | Phase 6 addendum | `EVIDENCED` | `Native Shell Landscape`, `Three Supported Integration Modes`, and `Framework-Neutral Weft Shell Contract` use `EV-0047`–`EV-0052`; `WR-S07` and CAND-09 preserve the approval boundary. | Product owner approves/revises WR-S07 and CAND-09. |
| `FEAT-AC-16` — Installation comparison and Weft lifecycle distinguish bootstrap, creation and dependency restore | FEAT acceptance criterion 16 | `installation-and-bootstrap-strategy.md` | Phase 6 addendum | `EVIDENCED` | IBS-1 compares official Blazor/.NET, Next.js, Angular, TanStack and Tauri flows using `EV-0053`–`EV-0059`, then defines verified `wget`/PowerShell bootstrap, pinned local .NET tool, pure/optional profiles, locked/offline restore, update, security, cache and removal contracts without claiming implementation. | Product owner approves/revises `WR-M10`, `WR-S08`, and expanded CAND-06. |
| `EPIC-SC-01` — Versioned source-linked five-platform matrix, including current/target Weft | EPIC success criterion 1 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | `Evaluated Platform Register`, `Capability Matrix`, `Source Ledger`, and both Phase 2 audits pass. | Refresh on new comparison snapshot. |
| `EPIC-SC-02` — Official sources are primary and external evidence is graded | EPIC success criterion 2 | `framework-comparison-report.md` | Phase 2 | `EVIDENCED` | All capability ledger entries are Grade A official docs/repository/local source; `Source Provenance Audit`: PASS. | Phase 7 audit complete. |
| `EPIC-SC-03` — Capability, quality, pain, workaround, and inference remain separate | EPIC success criterion 3 | `praised-qualities-and-pains.md` | Phase 3 | `EVIDENCED` | Common quality/pain schemas preserve evidence, consequence, workaround and inference fields; `Phase 3 Audit Results`: PASS. | Phase 7 audit complete. |
| `EPIC-SC-04` — Shared modular business specification enables comparable prototypes and measurements | EPIC success criterion 4 | `reference-application-spec.md` | Phase 5 | `EVIDENCED` | RA-1 frozen fixture, route, journey, failure, observable, capability and adapter contracts; `Reference Workload Review`: PASS. | Future implementations cite RA-1. |
| `EPIC-SC-05` — Reference workload includes authenticated multi-module CRUD, forms, data, validation, accessibility, and progressive enhancement | EPIC success criterion 5 | `reference-application-spec.md` | Phase 5 | `EVIDENCED` | `Module and Domain Vocabulary`, `Canonical User Journeys`, `Forms and Mutation Contract`, and `Browser, Visual and Accessibility Criteria` cover the complete obligation. | Phase 7 completeness audit passed. |
| `EPIC-SC-06` — Benchmark methodology covers all required measurement areas | EPIC success criterion 6 | `benchmark-methodology.md` | Phase 6 | `EVIDENCED` | BM-1 covers dependency, developer-loop, build, browser/network, server, functional, accessibility, security, and reporting sections; comparability review passes. | Future benchmark FEAT executes method. |
| `EPIC-SC-07` — Ranked requirements catalog includes Must/Should/Could/Won't | EPIC success criterion 7 | `weft-alternative-requirements.md` | Phase 6 | `EVIDENCED` | WR-1 uses all four ranks and passes `Traceability Audit`. | Product owner decides proposed ranks. |
| `EPIC-SC-08` — Every Must has value, evidence, avoided pain, acceptance, and roadmap destination | EPIC success criterion 8 | `weft-alternative-requirements.md` | Phase 6 | `EVIDENCED` | All `WR-M01`–`WR-M15` include the required fields; no unsupported performance threshold enters Must/Should. | Phase 7 field audit passed. |
| `EPIC-SC-09` — Every competitor strength has a reasoned mechanism response | EPIC success criterion 9 | `weft-gap-and-decision-backlog.md` | Phase 6 | `EVIDENCED` | All 26 quality mechanisms have one controlled response, rationale, and requirement destination; audit passes. | Product owner decides proposals. |
| `EPIC-SC-10` — Every significant pain has a reasoned pain response | EPIC success criterion 10 | `weft-gap-and-decision-backlog.md` | Phase 6 | `EVIDENCED` | All 25 pains have one controlled response, control/rationale, and destination; audit passes. | Product owner decides proposals. |
| `EPIC-SC-11` — Current Weft documents are checked for contradictions, claims, gaps, and missing capabilities | EPIC success criterion 11 | `weft-gap-and-decision-backlog.md` | Phase 6 | `EVIDENCED` | `Current Weft Gap Map` and `Documentation Audit and Proposed Changes` distinguish current gaps, corrections, proposals, and approval state. | Owner decides nine public-document proposals. |
| `EPIC-SC-12` — Follow-up candidates pass the ranked evidence-and-acceptance gate before implementation | EPIC success criterion 12 | `weft-gap-and-decision-backlog.md` | Phase 7 | `DEFERRED` | Nine candidates are bounded, linked, dependency-ordered, and explicitly unauthorized, but approval-gate passage awaits owner approval of WR-1 ranks. | Paulo Aboim Pinto approves requirements/sequencing before implementation FEAT creation. |

Phase 7 updated each row from its initial state only with exact evidence or an
owned gap; it did not treat the planning map as proof of delivery. Phase 8 did
not declare the package manual-review-ready until no mandatory row was
`NOT_STARTED`, no `BLOCKED`/`DEFERRED` state was unowned, and no row overstated
its evidence.
`FEAT-AC-10` may remain `DEFERRED` for this evidence-baseline milestone because
its future owner and full comparability condition are explicit; the deferment
forbids a reproduced performance conclusion rather than waiving the criterion.
The consumer update and provider-return mechanics remain active for future
snapshot refreshes.
