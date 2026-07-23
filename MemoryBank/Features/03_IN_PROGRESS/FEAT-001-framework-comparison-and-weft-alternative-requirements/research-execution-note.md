# FEAT-001 Research Execution Note

**Decision date:** 2026-07-15
**Work type:** R&D / Documentation Spike
**Execution owner:** Active agent conversation with Paulo Aboim Pinto
**Hepha continuation:** Not applicable

## Decision

FEAT-001 was initially sent through the current Hepha workflow, which supports
development tasks. Hepha created a feature branch, moved the work item to
`03_IN_PROGRESS`, completed Phase 0, and started Phase 1 planning. The owner then
clarified that research, documentation, and Spike work require a different
workflow and different prompts.

The useful investigation detail was preserved, but the phase files and their
cross-references were renamed to a research lifecycle. From this point:

- no Hepha continuation is used;
- no development implementation is inferred;
- phase names describe their actual research responsibility;
- results are written to existing Phase files or the named research
  deliverables;
- lifecycle/routing tables produced by Hepha remain historical records;
- follow-up work is explicitly classified as R&D, Documentation, Spike, or
  Development before a new workflow is selected.

## Current Handoff

- Phase 0 is a completed research baseline.
- Phase 1 contains substantial evidence-policy and acceptance-contract work.
- Phase 1 is manually reviewed and completed before Phase 2 evidence collection
  begins.
- Phase 2 begins the actual source-linked framework comparison.

## Future Process Requirement

The broader MemoryBank/Hepha process needs first-class work types with separate
recipes. At minimum it should distinguish:

1. Development
2. Defect investigation/fix
3. R&D / Spike
4. Documentation
5. Product/architecture decision

That workflow capability is outside Weft FEAT-001 and must be proposed in the
AgenticDevelopmentProcess repository if Paulo chooses to pursue it.
