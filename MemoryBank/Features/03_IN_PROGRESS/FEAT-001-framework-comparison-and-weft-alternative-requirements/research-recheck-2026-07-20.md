# FEAT-001 Independent Research Recheck

**Recheck date:** 2026-07-20

**Recheck scope:** Structural audit, semantic cross-document review, official
source/version refresh, Current Weft source inspection, repository verification,
and durable Overview coverage

**Decision:** `MANUAL_REVIEW_READY_WITH_FINDINGS`

## Executive result

The investigation covered its declared FEAT scope broadly and produced every
named research deliverable. Its central product conclusions remain defensible:
Current Weft is a narrow server foundation; Blazor is the decisive .NET
comparator; Weft's opportunity is HTML-first vertical feature ownership with
stateless enhancement, optional browser C#, and bounded JavaScript interop; and
no competitive performance or security-superiority claim is currently
supported.

The earlier all-PASS closure was nevertheless too strong. The recheck found one
high-priority evidence-contract gap, one workload/acceptance overstatement,
several candidate-bounding problems, two internal wording/reference defects,
Current Weft hardening gaps, version drift after the snapshot, and adjacent
product topics that were never explicitly classified.

These findings do not require repeating the whole investigation. They require a
source-ledger hardening pass, owner decisions, and bounded follow-up planning
before external publication or implementation authorization.

## Recheck method

### Pass 1 — Structural and traceability audit

The recheck parsed every FEAT Markdown document and the technical Overview.
It verified:

- 24 unique matrix dimensions (`D01`–`D24`);
- 54 active evidence IDs referenced without undefined IDs;
- 51 quality/pain records: 26 qualities and 25 pains;
- 35 requirement records: 15 Must, 8 Should, 5 Could, and 7 Won't;
- 18 routes, 7 journeys, 12 failure fixtures, and 10 dependency metrics;
- no undefined requirement, quality/pain, route, journey, fixture, or metric ID;
- no broken relative Markdown links in the audited set; and
- clean patch formatting through `git diff --check` before the new Overview
  additions.

Result: **PASS for identifier and link structure**.

### Pass 2 — Semantic cross-document audit

The recheck compared Feature/EPIC criteria, the evidence contract, matrix,
quality/pain analysis, reference workload, benchmark method, requirements,
decisions, closure report, and Overview statements.

Result: **PASS with findings**; see F-01 through F-07.

### Pass 3 — Source and version refresh

Official framework documentation, npm registry metadata, and GitHub repository
state were rechecked. The 2026-07-15 exact package versions were valid for that
snapshot. By 2026-07-20:

- Next.js remained 16.2.10 and React 19.2.7;
- Angular core/CLI had moved from 22.0.6 to 22.0.7, published after the snapshot;
- `@tanstack/react-start` had moved from 1.168.28 to 1.168.32, published after
  the snapshot;
- the other recorded TanStack Router/Query/Form/Table/Devtools package versions
  remained current;
- TanStack Start documentation still described Start as Release Candidate and
  Server Components as experimental;
- Tauri documentation still described its normal frontend boundary as a static
  web host;
- Electrobun still described a desktop product and mobile issue 70 remained
  open; and
- Bun Android runtime availability did not supply an Electrobun mobile app
  lifecycle or packaging target.

Result: **Snapshot valid; refresh required before present-tense publication**.

### Pass 4 — Current Weft source audit

The recheck inspected generator, manifest, registry, endpoint validation,
starter rendering/actions, and tests at commit
`ca5bacedfa7241be6071b09ad44d8d62948c7426`.

Result: **Core Current Weft description confirmed with additional hardening
gaps**; see F-05.

### Pass 5 — Repository verification

The first `dotnet test` attempt failed because the host had exhausted its limit
of 128 inotify instances, not because assertions failed. The controlled rerun
used:

```text
DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet test Weft.sln --no-restore
```

Result: **PASS — 8 passed, 0 failed, 0 skipped**.

This confirms only the narrow repository baseline. It is not comparative,
security, accessibility, or performance evidence.

## Findings

### F-01 — Source-ledger atomicity and claim coverage

**Severity:** High before external publication

**Owner:** Phase 2 research/documentation owner

The methodology requires each evidence row to contain one atomic claim and an
exact consumer path/heading/record. Several active rows bundle many dimensions
or cite a page narrower than the claims assigned to it. Examples include:

- `EV-0001`, where a Blazor render-modes source is used across component,
  routing, assets, testing, operations, maturity, and team-cost claims; and
- `EV-0023`, where Angular's version-compatibility page is used for the broader
  product/component/DI model in addition to version facts.

Consumer fields such as “Matrix Blazor cells” are also less exact than the
canonical contract requires. The matrix can be directionally correct while the
provenance audit still fails its own schema.

**Required repair:** Split broad evidence records by atomic claim or add exact
official sources for the unsupported dimensions; record exact matrix/quality/
requirement consumers; rerun source-provenance audit. Do not publish the matrix
as fully contract-compliant before this repair.

### F-02 — Multi-module CRUD overstatement

**Severity:** High for acceptance wording, medium for the workload itself

**Owner:** Paulo Aboim Pinto as product owner; RA/BM documentation owner after
scope decision

RA-1 defines project create/edit and task read/filter/reorder. It has no
project/task archive/delete journey and no ordinary task create/edit journey.
Therefore EPIC/closure wording that says the workload proves complete
“authenticated multi-module CRUD” is too broad.

**Required decision:** Either revise the criterion to “authenticated
multi-module business workflows” or create RA-2 with ordinary task create/edit
and reversible archive/delete behavior, then update BM-1 and future
implementations.

### F-03 — Follow-up candidate gate and boundedness

**Severity:** Medium; implementation remains correctly unauthorized

**Owner:** Paulo Aboim Pinto for ranks/sequence; future FEAT authors for bounded
scope

The unchecked/deferred follow-up criterion is correct. Nine themes exist, but
they have not passed the owner-approval gate. In addition:

- `CAND-06` combines bootstrap release engineering, CLI/templates, install/
  update/remove, offline/mirror behavior, diagnostics overlay, compatibility,
  migration, and policy work; it is too broad for one FEAT.
- `CAND-09` combines a shell contract plus Windows, Linux, Android, auth/deep
  links, lifecycle, permissions, failures, and iOS pipeline treatment; the first
  Spike should be smaller.
- `CAND-08` is linked to `WR-C05` (Could), while the candidate gate permits only
  approved Must/Should requirements. It should remain deferred benchmark
  research rather than be counted as a gate-passing candidate.

**Required repair:** Approve/revise ranks, split oversized themes, and create
only separately bounded FEATs with one primary contract and public-boundary
acceptance.

### F-04 — Internal count and acceptance-reference defects

**Severity:** Low

**Owner:** Recheck author; resolved in this documentation pass

- The technical Overview said seven Should requirements; WR-1 has eight.
- `FEAT-AC-11` cited matrix `D18`/`D19` as primary security/accessibility
  dimensions. The correct dimensions are `D11`/`D12`; `D19` is testing.

**Resolution:** Corrected during this recheck.

### F-05 — Current Weft contract-hardening gaps

**Severity:** Medium before extending the foundation

**Owner:** Future manifest/foundation FEAT owner after product approval

The source confirms the documented core, but the investigation did not record
all visible hardening gaps:

1. duplicate endpoint names are rejected only when the patterns differ; the
   same name/pattern can survive across distinct method declarations;
2. descriptors/registries are called immutable while retaining caller-supplied
   list instances that may be backed by mutable arrays;
3. action mode values are emitted as integers without validating supported enum
   values; and
4. the eight tests are narrow and do not cover duplicate feature/route/name
   registration, repeated `AddWeft`/`MapWeft`, mutable descriptor inputs,
   unsupported action modes, or the broader negative route matrix.

**Required follow-up:** Put these items first in manifest/foundation hardening;
do not hide them inside template or browser work.

### F-06 — Adjacent topics were not classified

**Severity:** Medium for product-boundary completeness

**Owner:** Paulo Aboim Pinto as product owner

The 24 dimensions are broad, but they do not explicitly decide:

- localization, RTL, culture/time-zone formatting, and localized validation;
- real-time server push/WebSockets outside the persistent-circuit comparison;
- file upload/download/streaming and scanning;
- background work, queues, scheduling, and out-of-request workflows;
- multi-tenancy and tenant-aware routing/cache/auth/assets; and
- database schema migration/transaction guidance.

These do not all have to become framework features. Leaving them unclassified,
however, makes “complete baseline” ambiguous.

**Required decision:** Mark each as Must/Should/package/inherited
ASP.NET/application concern/non-goal before approving alternative readiness.

### F-07 — Version and source refresh lifecycle

**Severity:** Informational now; high before claiming a current comparison

**Owner:** Phase 2 research/documentation owner for each publication snapshot

The snapshot's patch versions were valid on 2026-07-15, but two had advanced by
2026-07-20. This demonstrates that the version policy needs an operational
refresh procedure rather than only prose.

**Required repair:** Add a repeatable snapshot-refresh checklist that queries
exact package/release status, records changed official behavior, marks stale
rows, allocates replacement evidence IDs where material claim identity changes,
and updates consumers.

## Durable Overview documents created

The investigation is now summarized in:

- `MemoryBank/Overview/README.md`;
- `competitive-landscape-overview.md`;
- `product-requirements-and-sequencing-overview.md`;
- `reference-application-and-benchmarking-overview.md`;
- `security-accessibility-and-reliability-overview.md`;
- `developer-experience-installation-and-dependencies-overview.md`;
- `browser-interoperability-and-native-shells-overview.md`; and
- `feat-001-research-recheck-overview.md`.

These documents distinguish Current, research conclusion, proposal, and
hypothesis. They link to the FEAT evidence rather than duplicating its full
ledgers.

## Final disposition

FEAT-001 remains **manual-review-ready as an investigation**, with explicit
findings. It should not be marked completed/product-approved, used to authorize
runtime work, or published as a fully contract-compliant evidence comparison
until:

1. F-01 provenance hardening is complete;
2. the owner resolves F-02 and F-06 scope decisions;
3. requirements and public-document proposals are approved or revised;
4. candidate themes are split and approved under the Must/Should gate; and
5. exact versions are refreshed for the intended publication date.
