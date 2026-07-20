# FEAT-001 Comparable Benchmark Methodology

**Method revision:** BM-1
**Workload:** Project Atlas RA-1
**Result status:** `METHODOLOGY_ONLY`

## Non-Result Statement

This document defines a reproducible benchmark; it contains no cross-platform
result. Current Weft does not implement the frozen workload and equivalent
implementations do not exist. Vendor numbers and unrelated samples may inform
hypotheses but cannot populate the result tables.

## Comparison Cohorts

Modes are not averaged into one framework score.

| Cohort | Required user outcome | Eligible modes |
| --- | --- | --- |
| `C-H` Durable HTML | `J-01`–`J-04` work with normal navigation/forms and useful initial HTML. | Weft HTML; Blazor Static SSR; server-rendered Next/Start/Angular configurations retaining the same fallback outcome. |
| `C-E` Enhanced server journey | `J-05` partial task update with identical URL, focus, failure and full-page fallback semantics. | Future Weft enhanced actions; comparable platform navigation/action modes. |
| `C-L` Sustained local capability | `J-06` board gives immediate local reorder/undo then server-authoritative save. | Future Weft browser C#; Blazor WASM/Auto; Next/Start/Angular client capability. |
| `C-S` Server interactivity | Same board events are server-mediated over a persistent connection. | Blazor Interactive Server and any explicitly equivalent implementation; never merged with `C-L`. |

If a platform cannot produce the cohort outcome, record `NOT_APPLICABLE` or a
functional failure. Do not silently change the workload.

## Pinned Environment Manifest

Every run commits `benchmark-environment.json` containing:

- repository commit and RA/BM revision;
- OS edition/build, kernel, architecture and power plan;
- physical/virtual host model, CPU model/count, RAM, storage and filesystem;
- isolation/container limits and noisy-neighbor controls;
- browser exact version, viewport, device scale and automation driver;
- .NET SDK/runtime, Node, npm/pnpm, Java, framework/package and database exact
  versions;
- all direct lockfile hashes and published-output manifest hashes;
- production configuration, rendering mode, minification/trimming/AOT,
  compression, TLS/reverse proxy and HTTP version;
- database engine/configuration, seed hash and connection pool;
- latency/bandwidth/loss profile between browser, app and database;
- cache state, service-worker state and CDN state;
- measurement tool versions and collection commands.

Minimum reference host is a dedicated x64 machine with fixed performance mode,
32 GiB RAM and SSD. The exact model—not this minimum—is the comparison fact.
Only one server implementation runs at a time. Background updates, indexing
and unrelated containers are disabled and documented.

## Build and Dependency Preparation

Each implementation starts from a clean worktree at its pinned commit. The
following are command shapes; the implementation repository records exact
paths/options:

```text
.NET: dotnet restore --locked-mode
      dotnet publish -c Release --no-restore -o <output>

npm:  npm ci --ignore-scripts (policy inspection run)
      npm ci (approved-script build run under committed allowScripts policy)
      npm run build
```

Alternative npm-compatible managers are permitted only as separately named
variants. A pnpm result is not labelled an npm result. Lockfiles are committed;
floating framework/package versions invalidate the run.

## Dependency Measurements

Measure before and after restore/install:

| ID | Metric | Required boundary |
| --- | --- | --- |
| `DM-01` | Clean checkout bytes/files | Exclude `.git`, build output and dependency caches. |
| `DM-02` | Project-local dependency bytes/files | Include `node_modules`, local stores/links and generated assets; .NET `obj` reported separately. |
| `DM-03` | Shared cache bytes/files delta | NuGet global packages/http cache or npm/pnpm cache/store; record warm baseline and added delta. |
| `DM-04` | Direct/transitive dependency count | Runtime and development graphs separately; include duplicate versions. |
| `DM-05` | Lockfile size/hash and graph provenance | Package, resolved source, integrity/signature/provenance state and license. |
| `DM-06` | Lifecycle/build scripts | Package, version, script phase, approval/denial and executed command hash. |
| `DM-07` | Cold restore/install | Empty relevant cache and no project-local tree. |
| `DM-08` | Warm restore/install | Populated shared cache, removed project-local tree. |
| `DM-09` | No-op restore/install | Existing valid project-local state/outputs. |
| `DM-10` | Published dependency footprint | Only files required to deploy/run; exclude package-manager layout unless runtime needs it. |

Disk usage reports logical and allocated bytes. File counts do not follow
symlinks twice. Global-cache “savings” are not free: total shared cache and run
delta are both visible.

## Developer-Loop Measurements

For every implementation record median, p90 and raw samples for:

1. cold development server start to first successful `/health/ready`;
2. warm start;
3. first page compile/load;
4. edit a server validation message to correct browser response;
5. edit CSS to corrected browser paint;
6. edit local board logic to corrected interaction;
7. syntax/type error to actionable diagnostic;
8. correction to recovered successful page.

File change time, compiler/bundler notification, server readiness and browser
paint are separate timestamps. Ten measured edits follow two warm-ups.

## Production Build Measurements

- delete prior outputs/intermediate caches for clean build;
- five clean builds per implementation, randomized order;
- five incremental no-change and one-file-change builds;
- record wall/CPU time, peak RSS, reads/writes and output file/byte counts;
- classify server executable, shared runtime, browser executable, JS, CSS,
  images/fonts, source maps and metadata separately;
- retain build logs and content hashes.

Framework/runtime files supplied by the host are declared; they are neither
hidden nor double-counted as application transfer.

## Browser and Network Measurements

Use a new browser profile for cold and the same controlled profile for warm.
Disable extensions. Service workers are absent except the explicit PWA variant.
Collect HAR, trace and memory artifacts for:

- `J-01` cold `/projects` load;
- first filtered list action;
- warm repeated filter;
- `J-03` invalid then valid create;
- `J-05` enhanced partial update and failed-enhancement fallback;
- `J-06` capability activation, 20 reorders, save and disposal;
- `J-07` chart activation/update/disposal.

Metrics:

- request count, transferred/compressed/uncompressed bytes by type;
- executable JS/WASM/.NET assembly bytes and parsed/compiled code;
- DNS/connect/TLS/TTFB, first byte, first useful HTML, FCP/LCP and interactive
  readiness defined by journey-specific probe;
- first/warm action input-to-visible-result and server acknowledgement;
- main-thread long tasks and cumulative layout shift;
- browser process/private memory before load, after base page, after capability,
  after ten actions and after disposal/GC opportunity;
- behavior under Fast 4G, Slow 4G, 150 ms RTT/1% loss and offline fixtures.

“Interactive readiness” is not a generic framework event. For each journey it
is the first instant its required control successfully completes a scripted
functional probe.

## Server Measurements

Use a closed-loop correctness run and an open-loop saturation run. The workload
mix is fixed:

- 45% public project list/detail;
- 25% task list/filter;
- 15% authenticated reads;
- 10% validated mutation;
- 5% conflict/error fixture.

Run 1, 10, 50, 100 and 250 concurrent users for 3 minutes after a 60-second
warm-up, with three randomized repetitions. Report throughput, p50/p90/p95/p99
and max latency, errors/timeouts, CPU, RSS/working set, allocations/GC, sockets,
database queries/pool and cache hits. Persistent-mode variants additionally
report per-connection memory, reconnect success/time and state after server
restart.

Raw samples, not only aggregates, are retained. Confidence intervals and
outliers use a method selected before results are viewed.

## Functional Admission Gates

Performance samples are rejected unless the implementation first passes:

- route/journey outcome checks for RA-1;
- seeded-data checksum and response-content equivalence;
- authentication/authorization/antiforgery/concurrency/idempotency controls;
- automated accessibility scan plus keyboard/focus assertions;
- HTML/fallback behavior required by its cohort;
- no production stack traces/secrets and correct cache privacy;
- absence of benchmark-only shortcuts or precomputed data unavailable to
  competitors.

## Accessibility and Security Measurements

Accessibility reports automated rule count/severity per state, keyboard journey
completion, focus-order/focus-restoration results, name/role/value checks,
contrast and one manual screen-reader pass on `J-01`, `J-03`, `J-05`, `J-06`.

Security verification reports pass/fail and evidence for server authorization,
CSRF, output encoding/XSS probes, safe redirect, session rotation/cookies,
secrets, CSP/security headers, rate limiting, input/size limits, dependency
audit/signatures/provenance and production error leakage. This is control
verification, not a declaration that a framework is “secure.”

## Cold, Warm and Failure Definitions

- `cold-cache`: relevant package/browser/server/app caches cleared and host
  rebooted or equivalently reset; exact reset logged.
- `warm-cache`: one unmeasured complete journey followed by stable cache state.
- `cold-server`: new process with database ready and no application memory
  cache.
- `warm-server`: warm-up completed with steady JIT/runtime/cache state.
- Failures use `FX-01`–`FX-12` exactly; injecting a different delay/error is a
  separate experiment.

## Sample Order and Reporting

Randomize implementation order per repetition. At least 30 browser samples for
timing distributions and three server-load repetitions per level are required.
Report every failure/exclusion and never replace a failed sample silently.

Result table template:

| Run ID | Cohort/mode | Commit/versions | Environment hash | State | Metric | Unit | n | Median | p90/p95/p99 | Variance/CI | Functional gate | Artifact |
| --- | --- | --- | --- | --- | --- | --- | ---: | ---: | --- | --- | --- | --- |
| `<id>` | `<C-H etc.>` | `<pins>` | `<sha256>` | `<cold/warm>` | `<metric>` | `<unit>` | 0 | — | — | — | `<pass/fail>` | `<raw path>` |

## Comparability Exclusions

Reject or label `CONTEXT_ONLY_EXTERNAL` when workload revision, data, hardware,
runtime topology, rendering cohort, security behavior, compression, cache state
or functional outcome differs. Do not compare vendor benchmark claims with
these future results. Do not compare Blazor Server circuit memory with a
stateless HTTP mode as if they implement the same placement model.

## Benchmark Comparability Review

- Pinned environment, workload, modes and fixture requirements: **PASS**.
- Dependency local/cache/graph/lock/script/provenance/license/publish coverage:
  **PASS**.
- Developer, build, browser, server, accessibility, security and operations
  coverage: **PASS**.
- Raw-data, sample, ordering and exclusion policy: **PASS**.
- Reproduced cross-platform result: **DEFERRED** to an approved implementation
  and benchmark FEAT; none is claimed here.
