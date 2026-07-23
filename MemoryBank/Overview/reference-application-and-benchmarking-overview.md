# Weft Reference Application and Benchmarking Overview

## Purpose

Project Atlas (`RA-1`) is the frozen workload for future framework
implementations. Benchmark Method `BM-1` defines how equivalent implementations
may be measured. FEAT-001 specified both; it implemented neither.

## Project Atlas contract

Atlas is a project/task business application with Identity, Projects, Tasks,
Admin, and Insights modules. Its fixed fixture contains 120 projects, 6,000
tasks, 32 users, and 24,000 audit events generated from a stable seed.

The contract defines:

- 18 routes covering public catalog/detail/task views, authentication, protected
  project administration, board reorder, audit access, and health;
- four roles and stable benchmark identities;
- seven canonical journeys;
- twelve injected failure fixtures;
- canonical query/search/filter/sort/page state;
- server-authoritative validation, authorization, antiforgery, concurrency,
  idempotency, and audit behavior;
- one stateless server-owned partial update with full-navigation fallback;
- one sustained-local board interaction;
- one bounded third-party chart adapter with a semantic table fallback;
- keyboard, focus, live-region, responsive, visual-state, and metadata rules;
- deterministic asset, observability, security, and production-error contracts;
  and
- future unit, integration, browser, accessibility, security, and performance
  evidence obligations.

Equivalent implementations may use their framework's normal internals, but
they must produce the same data, authority boundaries, outcomes, failures, and
observable behavior.

## Execution-placement probes

Atlas deliberately includes three different interaction classes:

1. **Durable HTTP** — discovery, authentication, create, and edit work through
   normal navigation and forms.
2. **Stateless enhancement** — filtering replaces one server-owned region while
   preserving URL/history/focus and ordinary GET fallback.
3. **Sustained local execution** — board reorder provides immediate repeated
   interaction and undo before one server-authoritative save.

The chart is a separate interoperability probe. It tests JavaScript integration,
DOM ownership, semantic fallback, failure isolation, and disposal rather than
application-language purity.

## Benchmark cohorts

BM-1 keeps unlike execution modes separate:

| Cohort | Outcome |
| --- | --- |
| `C-H` | Durable HTML journeys through normal navigation/forms |
| `C-E` | Equivalent enhanced server partial update |
| `C-L` | Sustained local board interaction with authoritative save |
| `C-S` | Server-mediated persistent-connection board interaction |

A framework receives `NOT_APPLICABLE` or a functional failure when it cannot
meet a cohort. Results are never averaged into one framework score.

## Measurements

BM-1 covers:

- clean checkout, local intermediates/dependencies, shared-cache delta,
  dependency graph, locks, scripts, provenance, licenses, and publish output;
- cold/warm/no-op restore and install;
- development startup, first compile, C#/template/CSS/local-logic edit feedback,
  error diagnostics, and recovery;
- clean/incremental production builds, CPU, memory, I/O, and output classes;
- requests, bytes, executable code, network timing, useful HTML, journey-specific
  readiness, actions, long tasks, layout shift, and browser memory;
- server throughput, tail latency, CPU, memory, allocations, database/cache use,
  connections, reconnection, and restart behavior;
- slow networks, loss, offline, failed assets, cancellation, and stale responses;
- accessibility and security-control verification; and
- raw artifacts, randomization, repetitions, confidence reporting, failures, and
  exclusions.

## Admission and publication rules

No performance sample is admitted until the implementation passes functional,
seed-equivalence, security, accessibility, fallback, and cache-privacy checks.
The environment, versions, lockfiles, hardware, topology, network, production
configuration, cache state, tools, commands, and raw output must be pinned and
retained.

Vendor benchmarks and unrelated samples are context only. No current evidence
supports saying that Weft is faster, smaller, or more memory-efficient than
Blazor, Next.js, TanStack Start, Angular, or Node applications generally.

## Recheck findings

RA-1 is detailed enough for the journeys it defines, but one prior summary
claim is too broad: it does not demonstrate complete **multi-module CRUD**.
Projects have create/edit; tasks have read/filter/reorder; neither module has a
delete/archive journey, and ordinary task create/edit is absent.

Before implementations begin, choose one of these explicit resolutions:

- revise the EPIC wording to “authenticated multi-module business workflows”;
  or
- create `RA-2` with ordinary task create/edit and a reversible archive/delete
  journey, then update BM-1 and all implementations to that revision.

Additional decisions are needed for localization/RTL/time zones, file
upload/download, real-time push, background jobs, and multi-tenancy. They should
enter the reference workload only if they are baseline requirements; otherwise,
record them as inherited infrastructure, optional profiles, or non-goals.

The benchmark method also needs an execution appendix before use: concrete
harness/tool choices, database container/image, deterministic seed generator,
clock/time-zone controls, environment sanitization, artifact directory schema,
and statistical procedure must be committed by the future benchmark FEAT.

## Detailed source

- [Project Atlas RA-1](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/reference-application-spec.md)
- [Benchmark Method BM-1](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/benchmark-methodology.md)
