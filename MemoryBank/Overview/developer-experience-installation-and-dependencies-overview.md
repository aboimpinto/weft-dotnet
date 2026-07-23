# Weft Developer Experience, Installation, and Dependencies Overview

## Product objective

A credible framework is more than a runtime design. A developer must be able to
install a pinned version, create or adopt a project, restore it reproducibly,
understand optional prerequisites, receive actionable feedback, publish a
deterministic result, update safely, and remove Weft without damaging unrelated
machine or project state.

All commands described here are proposals. No Weft CLI, bootstrap archive,
template package, shared asset cache, or migration tool currently exists.

## Installation model

Installation must distinguish:

1. platform prerequisite;
2. Weft CLI bootstrap;
3. project creation or existing-project adoption;
4. dependency restore;
5. optional ecosystem/native prerequisites;
6. update and migration; and
7. removal and cache cleanup.

For a pure HTML-first project, the supported .NET SDK should be the only
mandatory platform prerequisite.

### Proposed distribution stages

- **Experimental:** versioned GitHub release archives for Windows, Linux, and
  macOS; checksums, signed provenance, SBOM/notices, explicit download and
  verification, then user-local install.
- **Preview/team default:** a version-pinned repository-local `Weft.Cli` .NET
  tool with a committed tool manifest and a compatible template pack.
- **Individual convenience:** an optional global .NET tool, never the source of
  team/CI reproducibility.

A remote pipe-to-shell command is not the canonical trust path. The supported
flow is download, verify, optionally inspect, then execute. PowerShell and Unix
paths must have equal support.

## Proposed project workflow

A pure profile should provide one clear route from creation to development:

```text
weft new app MyApp --profile html
dotnet tool restore
weft doctor
weft restore --locked
weft dev
```

The generated project contains a pinned tool manifest, NuGet locks, Weft
manifest/lock data, safe Development/Production settings, and a record of the
selected profile. It contains no Node prerequisite, `package.json`, JavaScript
lockfile, or `node_modules` in pure mode.

Existing-project adoption and removal require `--dry-run`. Weft must show all
package, project, source, configuration, generated, and lock changes and fail on
ambiguity instead of guessing.

## Optional profiles and proportional cost

| Capability | Additional cost |
| --- | --- |
| `html` | .NET SDK and NuGet only |
| `enhanced` | Small versioned browser kernel when implemented; no Node required |
| `browser-csharp` | Supported browser .NET workload/runtime assets for declared capabilities |
| `js-interop` | Selected package manager/runtime only when the chosen asset needs resolution/build |
| native shell | Rust/OS/mobile/Apple toolchains required by the selected target |

`weft doctor` must explain each missing prerequisite before project mutation and
must not silently install privileged SDKs.

## Developer loop and diagnostics

The tooling should build on `dotnet new`, analyzers/source generators,
`dotnet watch`, standard symbols/source locations, and normal build/publish
rather than an opaque daemon.

Required outcomes include:

- one-command app and feature scaffolding with interactive and deterministic
  non-interactive forms;
- stable diagnostic IDs and actionable fixes for manifest, route, action,
  template, asset, lock, and profile failures;
- C#/HTML/CSS edit feedback and recovery;
- inspectable generated code and feature/capability/cost graph;
- source-mapped Development errors with a strict Production exclusion;
- machine-readable `doctor`, `info`, restore, build, and publish output; and
- side-by-side repositories using different pinned Weft versions.

## Dependency and asset policy

Weft is NuGet-first and npm-compatible. It does not eliminate dependencies.
Its defensible promise is that dependency ecosystems are proportional to
selected capabilities.

### Pure .NET

NuGet packages are restored to shared global caches, with local `obj`, `bin`,
and publish output still measured. Locked mode, provenance, vulnerability
review, build-time package trust, and cache governance remain necessary.

### Direct immutable assets

An independently consumable CSS/font/JavaScript asset may be restored directly
without npm only when its source, exact version/content hash, license,
provenance, reason, and publish name are locked. Restore uses a shared
content-addressed cache and fails closed on changed bytes. A raw URL download is
not dependency management.

### Optional npm-compatible integration

Complex packages may require an existing npm-compatible resolver/build tool.
The project chooses one manager and lockfile, records lifecycle-script policy,
and publishes only final declared assets. `node_modules` may exist in this
opt-in mode; Weft must not promise otherwise.

The current public recommendation to prefer pnpm is still pending owner review.
Selection criteria and reproduced measurements are stronger than an unsupported
universal default.

## Restore, CI, offline, and controlled networks

`weft restore` should orchestrate—not replace—local .NET tools, NuGet locked
restore, direct assets, and an explicitly selected optional package manager.
Required behavior includes:

- fail-closed lock/hash/source/signature/tool-template compatibility;
- no undeclared lifecycle scripts;
- exact-version, non-interactive, telemetry-free CI;
- offline mode that performs no network access and lists missing content;
- mirror/source mapping without changing locked hashes;
- cache import/export/prewarm and hit/download/rejection reports;
- separate project-local, shared-cache, and publish byte reporting; and
- SBOM/license/provenance output for published inputs.

## Updates, compatibility, and removal

Updates are explicit, never part of `dev`, `build`, or `publish`. Check and
dry-run show compatibility, lock, generated-code, and migration effects before
source rewriting.

Removal deletes only changes Weft can prove it owns. Uninstall never removes
application features, shared caches, .NET, Node, Rust, Android, Xcode, or other
shared prerequisites by assumption. Cache garbage collection and purge are
separate explicit operations.

## Open decisions

- final CLI/package/template identities and compatibility protocol;
- release signing/provenance mechanism and revocation process;
- direct-asset lock schema and mirror policy;
- supported npm managers and lifecycle-script enforcement;
- telemetry policy (the proposal is off by default/no silent enablement);
- cache ownership and garbage-collection safety; and
- support windows and migration guarantees before preview/1.0.

## Detailed source

- [Installation and bootstrap strategy](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/installation-and-bootstrap-strategy.md)
- [Package and asset requirements](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-alternative-requirements.md)
- [Benchmark dependency measurements](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/benchmark-methodology.md)
