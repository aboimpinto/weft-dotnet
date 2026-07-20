# FEAT-001 Research Recheck Overview

## Decision

The investigation is **manual-review-ready with findings**. It covered the
planned scope and its central conclusions remain defensible, but the previous
unqualified all-PASS closure should not be used as evidence that every source
row, acceptance statement, or follow-up candidate is complete.

## What was independently checked

The 2026-07-20 recheck used five passes:

1. identifier, count, and Markdown-link audit;
2. semantic cross-document review against FEAT/EPIC criteria;
3. official documentation, npm registry, and GitHub source/version refresh;
4. Current Weft generator/server/example/test source inspection; and
5. repository test execution.

Structural results were strong: 24 matrix dimensions, 54 evidence IDs, 26
qualities, 25 pains, 35 requirements, 18 routes, 7 journeys, 12 failures, and 10
dependency metrics all resolve without undefined identifiers. No broken
relative links were found in the audited research set.

All eight repository tests passed with polling file watching enabled. The
normal first run was blocked by the host's exhausted inotify-instance limit,
not by assertion failures.

## Material findings

| Finding | Impact | Required action |
| --- | --- | --- |
| Several source rows bundle non-atomic claims or cite a page narrower than all dimensions assigned to it. | The matrix is structurally complete but does not fully pass its own provenance contract. | Split rows/add exact official sources and exact consumers before external publication. |
| RA-1 does not implement full multi-module CRUD in its specification. | EPIC/closure wording is broader than the actual project create/edit plus task read/reorder workload. | Revise wording or create RA-2 with task create/edit and archive/delete behavior. |
| Follow-up themes are unapproved; CLI/release and native-shell candidates are oversized; benchmark candidate is Could-only. | The unchecked follow-up acceptance item is genuinely unresolved. | Approve ranks, split themes, and create only bounded Must/Should FEATs. |
| Current Weft has unrecorded hardening gaps in endpoint-name uniqueness, descriptor immutability, action-mode validation, and negative test breadth. | Foundation work should precede larger rendering/browser mechanisms. | Create a small manifest/foundation-hardening FEAT first. |
| Localization, real-time push, file transfer, background work, multi-tenancy, and data migration were not explicitly classified. | “Complete baseline” remains ambiguous around adjacent business-platform concerns. | Classify each as requirement, optional package, inherited concern, deferment, or non-goal. |
| Angular and TanStack Start patch versions advanced after the 15 July snapshot. | Snapshot remains historically valid but is not a present-tense version register. | Refresh exact versions and affected evidence before publication. |

## Corrections applied

- The technical Overview now records **eight** Should requirements, not seven.
- The acceptance ledger now points to `D11`/`D12` for the primary security and
  accessibility matrix evidence instead of `D18`/`D19`.
- Durable topic Overview documents now cover the competitive landscape,
  requirements/sequencing, reference workload/benchmarking, security/
  accessibility/reliability, installation/dependencies, and browser/native
  boundaries.

## What remains valid

- Current Weft is a narrow server-only foundation, not a production framework.
- Blazor is the closest and most important C# comparator.
- Weft's meaningful thesis is HTML-first vertical feature ownership with
  stateless enhancement, optional capability-sized browser C#, and bounded
  JavaScript interop.
- Avoiding mandatory Node in pure mode is legitimate; claiming no dependencies
  or no supply-chain risk is not.
- No current evidence supports universal speed, memory, or security superiority.
- Project Atlas and BM-1 are useful future contracts once their scope decision
  and implementation appendices are resolved.
- Runtime implementation remains unauthorized until owner approval and bounded
  FEAT creation.

## Closure conditions

Before FEAT-001 can be treated as fully accepted rather than review-ready:

1. harden the source ledger against its atomic-claim contract;
2. resolve the RA-1 CRUD wording/revision decision;
3. classify omitted adjacent topics;
4. approve or revise requirement ranks and public-document proposals;
5. split and approve bounded follow-up FEATs; and
6. refresh exact versions for any external publication.

## Full recheck record

See [research-recheck-2026-07-20.md](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/research-recheck-2026-07-20.md).
