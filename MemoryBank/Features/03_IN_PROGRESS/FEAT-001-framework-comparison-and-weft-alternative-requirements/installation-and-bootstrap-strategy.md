# FEAT-001 Weft Installation and Bootstrap Strategy

**Revision:** IBS-1

**Snapshot date:** 2026-07-15

**State:** Proposed product contract; not implemented

**Decision scope:** Installation, project creation, restore, update, offline use,
and removal

## Executive Decision

Weft should offer the short first-run experience people expect from current web
frameworks without importing the Node application stack into a pure .NET
project.

The proposed model is:

1. the .NET SDK is the only mandatory platform prerequisite for pure Weft;
2. a verified `wget`/`Invoke-WebRequest` release download is the first bootstrap
   path while Weft is experimental;
3. a version-pinned repository-local .NET tool becomes the recommended team and
   CI path when `Weft.Cli` is published to NuGet;
4. a global .NET tool remains a convenience for individuals, not the source of
   a project's reproducibility;
5. project creation is one command and selects an explicit capability profile;
6. restore uses NuGet and a Weft lock/asset manifest with a shared cache;
7. Node, npm-compatible tools, Rust, Android Studio, and Xcode appear only when
   the selected application capability requires them; and
8. update and removal are explicit. There is no silent auto-update, background
   daemon, machine service, or mandatory administrator installation.

The desired user promise is:

> Install one small Weft tool, create a project in one command, and pay only for
> the toolchains the project explicitly selects.

## Installation Is Not One Operation

Framework documentation often uses *install* for several different actions.
Weft must name them separately so that a convenient command does not conceal
cost or authority.

| Layer | Purpose | Proposed Weft owner |
| --- | --- | --- |
| Platform prerequisite | Supplies compiler, runtime, and base build tools | Official .NET SDK installer/package manager |
| Weft bootstrap | Makes the Weft CLI available | Verified GitHub release initially; NuGet .NET tool when published |
| Project creation | Creates a new application from an explicit profile | `weft new` or installed `dotnet new` template |
| Existing-project adoption | Adds Weft packages/configuration without replacing the host | `weft add` with previewable changes |
| Dependency restore | Restores .NET packages, tools, and declared assets | `dotnet restore`, `dotnet tool restore`, and `weft restore` orchestration |
| Optional ecosystem setup | Enables npm assets, browser/native shells, or mobile targets | Explicit profile-specific prerequisites and `weft doctor` guidance |
| Update/migration | Changes an intentionally pinned version or contract | Explicit CLI command plus lock/manifest diff and diagnostics |
| Removal/cache cleanup | Removes project/global integration and optionally cached bytes | Package/tool uninstall plus separate cache garbage collection |

Installing Weft must not silently install every tool that Weft could possibly
integrate with.

## Official Platform Installation Comparison

This comparison concerns the default documented developer path, not every
supported installer or deployment target.

| Platform | Base prerequisites | Typical first project | Where dependencies land | What is good | Cost or pain Weft should avoid |
| --- | --- | --- | --- | --- | --- |
| Blazor/.NET | .NET SDK, or Visual Studio plus ASP.NET workload | `dotnet new blazor -o MyApp` | NuGet's shared global package cache plus build intermediates | Cross-platform SDK, integrated templates, ordinary .NET restore, no Node requirement for a base app | SDK/workload/version choices and render modes still need clear guidance; global tooling alone does not pin a team's CLI |
| Next.js | Node.js 20.9+ and npm/pnpm/yarn/Bun | `pnpm create next-app@latest my-app --yes` | Project package graph/lockfile and normally `node_modules`, with manager-specific shared caches | Excellent one-command creation, useful defaults, immediate dev command | Creator runs latest unless pinned; pure projects still adopt Node/package-manager/script and local dependency-tree semantics |
| Angular | Supported Node.js plus npm/pnpm/yarn/Bun; Angular CLI | `ng new my-app`, after global CLI install in the official local-setup flow | Workspace lockfile and local Node dependency graph | Cohesive CLI, prompts, generators, workspace conventions, serve/build/test lifecycle | Global CLI/version drift, Node prerequisite, local dependency graph; official Windows npm-global guidance may require PowerShell execution-policy changes |
| TanStack Start | Node-compatible runtime/package manager | `npx @tanstack/cli create my-app` | Local npm-compatible dependency graph and lockfile | Composable starter, interactive/non-interactive modes, add-ons, existing-project additions | `npx` fetch/execution and `latest` conventions need deliberate pinning; selected add-ons widen the graph; CLI telemetry is on by default unless disabled |
| Tauri | OS build dependencies and Rust; Node only for a JS frontend; Android/iOS add their native toolchains | `create-tauri-app` through shell, PowerShell, npm-compatible manager, Deno, Bun, or Cargo | Cargo cache/target output and, for JS frontends, their package graph; native SDKs are machine-level | Many creator entry points, detects missing dependencies, supports adding to an existing frontend | The friendly creator does not remove Rust, C++/WebView, Android SDK/NDK, or Xcode requirements; direct remote-script execution is offered and must be treated cautiously |
| Proposed pure Weft | Supported .NET SDK only | `weft new app MyApp --profile html` | NuGet/shared Weft content cache, project lock/manifest, normal `obj`/`bin`; no `node_modules` | One command, C#/HTML/CSS baseline, reproducible project-local CLI, explicit profile cost | Requires Weft to build and maintain CLI, templates, release signing/provenance, restore, doctor, migration, and cache policy |

### What Weft should adopt

- Next.js/Angular/TanStack's discoverable one-command creation and good
  non-interactive CI path.
- Angular's cohesive workspace lifecycle and generators without requiring a
  global unpinned CLI.
- TanStack's add-on discovery and machine-readable CLI output.
- Blazor/.NET's SDK, templates, NuGet distribution, tool manifests, and shared
  package cache.
- Tauri's prerequisite diagnosis and explicit target-specific setup.

### What Weft should not inherit

- a mandatory Node installation or project-local JavaScript graph for a pure
  application;
- implicit execution of downloaded package lifecycle scripts;
- unpinned `latest` in team/CI instructions;
- a global CLI as the only supported workflow;
- a remote `wget|curl | sh` or PowerShell `... | iex` command as the canonical
  trust path;
- hidden installation of optional native/mobile toolchains; or
- silent telemetry or update behavior.

## Proposed Weft Distribution Model

### Stage A: verified release bootstrap

Before a stable NuGet tool exists, publish self-contained CLI archives for
supported .NET runtime identifiers in a versioned GitHub Release. Each release
contains:

- one archive per supported OS/architecture;
- a checksum manifest;
- a signed release/provenance statement;
- license and third-party notices;
- an SBOM;
- release notes and supported .NET/platform matrix; and
- a human-readable bootstrap script that installs only to a user-selected or
  user-local directory.

The commands below define the intended shape, not an available v0.1.0 release:

```bash
version=0.1.0
wget "https://github.com/aboimpinto/weft-dotnet/releases/download/v${version}/weft-linux-x64-v${version}.tar.gz"
wget "https://github.com/aboimpinto/weft-dotnet/releases/download/v${version}/SHA256SUMS"
sha256sum --check --ignore-missing SHA256SUMS
tar -xzf "weft-linux-x64-v${version}.tar.gz"
./weft install --user
```

PowerShell must have an equally supported path because `wget` is not a portable
Windows prerequisite and PowerShell aliases/versions differ:

```powershell
$Version = '0.1.0'
$BaseUri = "https://github.com/aboimpinto/weft-dotnet/releases/download/v$Version"
Invoke-WebRequest "$BaseUri/weft-win-x64-v$Version.zip" -OutFile "weft-win-x64-v$Version.zip"
Invoke-WebRequest "$BaseUri/SHA256SUMS" -OutFile 'SHA256SUMS'
Get-FileHash -Algorithm SHA256 "weft-win-x64-v$Version.zip"
# Compare the displayed value with the signed checksum manifest before extraction.
Expand-Archive "weft-win-x64-v$Version.zip" -DestinationPath '.\weft-bootstrap'
.\weft-bootstrap\weft.exe install --user
```

The final PowerShell installer should verify the checksum/signature itself so a
developer does not have to compare text manually. The explicit comparison
above is retained to show the trust boundary before that installer exists.

### Why not `wget ... | sh`

Piping a URL directly to a shell is short, but it combines download and code
execution before the user or CI can verify the bytes. It also makes redirects,
mutable scripts, shell compatibility, proxies, and incident reconstruction
harder to reason about. Tauri's own prerequisite documentation advises users to
inspect remote scripts before executing them.

Weft may publish a convenience bootstrap script, but the supported security
flow is **download, verify, inspect when desired, then execute**. Versioned
artifact URLs must never silently redirect a version to different bytes.

### Stage B: NuGet-distributed local tool

When package identity and release automation are ready, the recommended
repository workflow becomes:

```powershell
dotnet tool install --local Weft.Cli --version 0.1.0
dotnet tool restore
dotnet weft --version
```

`.config/dotnet-tools.json` is committed. Every contributor and CI runner then
restores the version chosen by the project. On .NET 10, local tool installation
can create the manifest when needed; Weft documentation should still explain
where it is written and why it is committed.

For individual exploration, a global convenience path can exist:

```powershell
dotnet tool install --global Weft.Cli --version 0.1.0
weft --version
```

Global installation is not recommended for reproducible builds. The tool must
also work from a secure explicit tool path for hermetic CI environments.

### Template packaging decision

Prefer one public Weft CLI that owns profile discovery, `doctor`, existing-
project adoption, and migrations. It may invoke a version-matched template pack
internally. If templates are also exposed through the standard .NET template
engine, the explicit path is:

```powershell
dotnet new install Weft.Templates@0.1.0
dotnet new weft -n MyApp
```

The CLI package and template package must publish a compatibility pair. The
tool must refuse an incompatible combination with an actionable diagnostic;
it must not silently fetch `latest`.

## Proposed First-Project Experience

### Pure HTML-first application

```powershell
weft new app MyApp --profile html
Set-Location MyApp
dotnet tool restore
weft doctor
weft restore --locked
weft dev
```

The creator should perform the initial locked restore by default and print the
equivalent individual commands. `--no-restore` supports offline preparation and
specialized CI flows.

The generated project contains no `package.json`, JavaScript lockfile, or
`node_modules`. It does contain:

- the solution/project files;
- a pinned local tool manifest;
- NuGet lockfiles;
- a Weft project/capability manifest;
- a Weft asset lock if direct assets are selected;
- Development and Production configuration with safe error defaults; and
- a short generated `GETTING_STARTED.md` that reports exactly what was chosen.

### Add Weft to an existing ASP.NET Core application

```powershell
weft add --profile html --dry-run
weft add --profile html
weft doctor
weft restore --locked
```

`--dry-run` shows package, project, source, configuration, and lockfile changes.
The command must preserve existing application code and fail on ambiguous host
configuration rather than guessing.

### Explicit optional capabilities

Profiles are cumulative declarations, not marketing names:

| Profile/capability | Additional prerequisite | Project effect |
| --- | --- | --- |
| `html` | None beyond .NET SDK | Server HTML, CSS/assets, normal links/forms; no Node/browser .NET runtime |
| `enhanced` | None beyond .NET SDK | Adds the small versioned Weft browser kernel when implemented |
| `browser-csharp` | Supported .NET browser workload/runtime assets | Adds only declared lazy browser C# capabilities |
| `js-interop` | Selected Node/Bun/package manager only if the chosen library requires package resolution/build | Adds an explicit manager, lockfile, script policy, and final-asset boundary |
| `shell-tauri` | Rust and OS target tools; Android Studio/SDK/NDK for Android; Xcode on macOS for iOS | Adds a shell descriptor/project for the chosen target family, never silently |

`weft doctor --profile <name>` reports missing prerequisites before modifying a
project. It may print official installation links and commands, but must not
install privileged platform SDKs without a separate explicit user action.

## Potential Dependency Setups

Weft does not eliminate dependencies. Its target advantage is a smaller
mandatory toolchain and a dependency footprint proportional to the capabilities
the application selects.

### Pure Weft

```text
.NET SDK + NuGet
No Node, npm, or node_modules
```

The application uses Weft/.NET packages, C#, HTML, CSS, and its own static
assets. NuGet lockfiles and the shared NuGet cache remain part of the dependency
model.

### Weft with one direct CSS asset

```text
.NET SDK + NuGet + one verified asset
Still no Node or node_modules
```

The asset is an independently consumable immutable file declared with its
source, exact content hash, version, license, provenance, and publish name. A
Weft restore implementation retrieves it into a shared content-addressed cache
and fails if the locked bytes do not match. No asset installation script runs.

### Weft with JavaScript ecosystem integration

```text
.NET SDK + NuGet + selected npm-compatible package manager
node_modules may now exist
```

The project explicitly selects npm, pnpm, Yarn, Bun, or another supported
manager, commits the corresponding lockfile, and declares its script policy.
Some managers reuse a shared store, but Node-compatible resolution may still
create a project-level `node_modules` structure. Weft publishes only the final
declared assets; it does not publish `node_modules` as part of the application.
The selected library or build tool may also require a compatible Node runtime,
even when the package manager itself is not Node.

### Weft with Tauri

```text
.NET SDK + NuGet + Rust and native target tooling
```

Desktop development adds Rust and operating-system build/WebView dependencies.
Android adds Android Studio, SDK, NDK, Java and Rust Android targets. iOS adds
the macOS/Xcode/Apple signing pipeline. A JavaScript frontend integration may
add an npm-compatible manager too, but it is not implied by pure Weft.

### NuGet is still a dependency ecosystem

NuGet is not dependency-free. A NuGet graph can include transitive packages,
supply-chain and namespace risks, build targets, analyzers, source generators,
shared caches, intermediate output, and significant disk usage. Build-time
package code can affect compilation, so removing npm does not remove the need
for source trust, locking, provenance, vulnerability review, and policy.

The principal structural difference is that `PackageReference` normally
restores packages into a shared global package directory rather than expanding
every package into each project's `node_modules`. Projects still create local
`obj`, `bin`, generated, and published output, and the global cache still
consumes disk even though it is outside the repository.

The defensible product statement is therefore:

> Weft does not eliminate dependencies. It prevents a C# web application from
> automatically inheriting the Node dependency ecosystem when it does not need
> it.

Or, as a shorter engineering principle:

> Dependencies are proportional to the capabilities selected by the
> application.

## Restore and Dependency Contract

`weft restore` is an orchestrator, not a new universal registry. In pure mode
it performs or validates:

1. `dotnet tool restore` for the pinned Weft CLI and repository tools;
2. `dotnet restore --locked-mode` for .NET dependencies;
3. direct immutable asset retrieval declared by URL, exact content hash,
   license, provenance, and publish name;
4. reuse of a user-level content-addressed cache outside the project;
5. generated SBOM/license/provenance information for publish inputs; and
6. failure on lock drift, hash mismatch, undeclared source, or ambiguous
   package-manager state.

This is where the *wget idea* also applies to application assets. Weft's .NET
implementation may use `HttpClient`; the product contract is the transparent
retrieval of a known immutable file, not dependence on the `wget` executable.

Direct assets execute no installation scripts. Optional npm mode delegates
resolution to one explicitly selected existing manager and committed lockfile.
It records which lifecycle scripts, if any, were approved. Only final declared
assets enter Weft publish output.

## Version, Channel, and Update Policy

- Channels are explicit: `stable`, `preview`, and later `nightly` if needed.
- Team/CI examples always include an exact version or committed tool manifest.
- `weft update --check` is read-only and reports CLI/template/runtime/manifest
  compatibility.
- `weft update --version <version> --dry-run` shows package, lock, generated-
  code, and migration effects.
- An update never runs automatically during `dev`, `build`, or `publish`.
- Side-by-side projects use their local tool versions without fighting over a
  global installation.
- Breaking migrations require diagnostics and an inspectable diff; source
  rewriting requires explicit confirmation.

## CI, Offline, Mirror, and Cache Behavior

The install story is incomplete unless it works outside a developer laptop.

### CI baseline

```powershell
dotnet tool restore
weft doctor --ci
weft restore --locked
weft build --configuration Release
```

CI must be non-interactive, telemetry-free, exact-versioned, and fail closed.
Credentials come from the platform's normal secret/source configuration and
must never be written into a Weft lockfile or diagnostic bundle.

### Offline and controlled networks

Weft should support:

- `weft restore --offline`, which performs no network access and names every
  missing hash/package;
- cache export/import or documented cache prewarming for air-gapped builds;
- NuGet source configuration and organization-approved asset mirrors;
- source-to-mirror mapping without changing the locked content hash; and
- a restore report distinguishing cache hits, downloads, and rejected items.

### Disk behavior

Avoiding `node_modules` does not mean dependencies consume no disk. Weft must
report project-local intermediates, shared NuGet/Weft cache use, and published
bytes separately. `weft cache gc` removes unreferenced content; `weft cache
purge` is an explicit stronger action and must never run as part of uninstall.

## Removal Contract

| Action | Proposed behavior |
| --- | --- |
| Remove global CLI | `dotnet tool uninstall --global Weft.Cli` |
| Remove local CLI declaration | `dotnet tool uninstall Weft.Cli`; manifest change is committed |
| Remove from application | `weft remove --dry-run`, then explicit `weft remove`; only files/edits owned and recorded by Weft are eligible |
| Remove cached bytes | Separate `weft cache gc` or explicit `weft cache purge` |
| Remove .NET/native prerequisites | Never automatic; those installations may be shared by other projects |

Uninstall must not delete application features, shared caches, the .NET SDK,
Node, Rust, or native SDKs by assumption.

## Security and Privacy Requirements

The installer and restore pipeline form a code-execution boundary. A credible
Weft release requires all of the following:

- TLS plus immutable versioned artifact URLs;
- checksum verification before first execution;
- signed release manifest/provenance and published verification instructions;
- fail-closed behavior on signature, hash, lock, or source mismatch;
- no root/administrator requirement for the normal CLI path;
- no default write outside user-local tool/cache/config locations and the
  explicitly selected project;
- no hidden lifecycle-script execution;
- no remote code fetch during application runtime;
- no silent auto-update, background service, shell-profile edit, or telemetry;
- redacted diagnostics and no credentials in manifests, locks, logs, or SBOM;
- explicit allow/deny source and package policies for organizations; and
- revocation/security-advisory procedure for compromised releases.

This does not make Weft categorically more secure than Node platforms. It gives
Weft a smaller default toolchain and a stricter opportunity: pure mode can
exclude Node, npm lifecycle scripts, and a JavaScript dependency graph. Weft is
only safer in practice if its own CLI, NuGet graph, direct-asset retrieval,
templates, generators, and release process satisfy and continuously test this
contract.

## Required CLI Surface

The names remain proposals, but the responsibilities are product requirements:

| Command | Required responsibility |
| --- | --- |
| `weft new app` / `weft new feature` | Pinned, profile-aware, interactive and non-interactive scaffolding |
| `weft add` / `weft remove` | Previewable adoption/removal in existing applications |
| `weft doctor` | SDK, CLI/template/runtime, optional-toolchain, source, and platform diagnostics |
| `weft restore` | Locked tool/NuGet/direct-asset/optional-manager orchestration and report |
| `weft dev` | Transparent wrapper over `dotnet watch` plus Weft diagnostics; no opaque daemon |
| `weft build` / `weft publish` | Deterministic manifest, assets, provenance, budgets, and production-safe configuration |
| `weft update` | Read-only check, dry-run, explicit update, compatibility and migration path |
| `weft cache` | Inspect, verify, garbage collect, export/import, and explicitly purge shared cache |
| `weft info --json` | Machine-readable version, profile, dependency, capability, and support data |

Every wrapper prints the underlying operations at normal or verbose diagnostic
levels so developers can understand and reproduce the lifecycle without Weft.

## Acceptance Checklist

The installation design is implementation-ready only when a follow-up FEAT
proves:

- [ ] supported Windows, Linux, and macOS bootstrap artifacts install without
  administrator/root privileges;
- [ ] every artifact is verified before execution and tampering fails closed;
- [ ] local-tool restore reproduces the exact CLI version on a clean machine;
- [ ] a pure `html` project is created and run with the .NET SDK only;
- [ ] the pure project contains no Node prerequisite, `package.json`, npm lock,
  `node_modules`, or hidden JavaScript dependency restore;
- [ ] `doctor` names each missing optional prerequisite and why it is needed;
- [ ] interactive and non-interactive creation produce equivalent locked
  projects for the same options;
- [ ] locked restore succeeds online, from a warm cache, and from an approved
  mirror, and fails offline with an exact missing-input list;
- [ ] hash, lock, source, signature, and tool/template mismatch fixtures fail
  with stable diagnostic IDs;
- [ ] two repositories use different local Weft versions side by side;
- [ ] update dry-run and removal dry-run show complete, correct changes;
- [ ] uninstall does not remove the project, shared prerequisites, or cache;
- [ ] CI performs no prompts, telemetry, auto-update, or unapproved scripts;
- [ ] Windows PowerShell and Unix instructions are equally maintained; and
- [ ] docs distinguish installing Weft from restoring application assets.

## Rollout Recommendation

1. **Experimental bootstrap:** versioned GitHub archives, checksums, provenance,
   `wget` and PowerShell download instructions, `weft doctor`, and pure HTML
   project creation.
2. **Preview distribution:** signed `Weft.Cli` local/global .NET tool and a
   compatible template pack, locked pure restore, CI/offline fixtures.
3. **Asset lifecycle:** direct immutable assets, shared cache, SBOM/license
   reporting, mirror and policy support.
4. **Optional ecosystems:** explicit npm-compatible adapter and later Tauri
   target diagnostics without changing the pure-mode prerequisite contract.
5. **Stable lifecycle:** support matrix, migration/update guarantees, release
   revocation, side-by-side and removal conformance.

The first implementation should remain intentionally narrow: download a
verified CLI, create and run the current HTML-first starter shape, diagnose the
.NET SDK, and explain every file/change. Optional package and native-shell
automation can follow after the trust and versioning foundation is proven.

## Official Sources

- [.NET local tools and committed tool manifests](https://learn.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use)
- [`dotnet tool install` local, global, version, and path modes](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install)
- [`dotnet new install` template packages](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-install)
- [ASP.NET Core Blazor tooling and templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0)
- [Next.js installation and `create-next-app`](https://nextjs.org/docs/app/getting-started/installation)
- [Angular local setup and CLI installation](https://angular.dev/tools/cli/setup-local)
- [TanStack CLI quick start](https://tanstack.com/cli/latest/docs/quick-start)
- [TanStack Start build-from-scratch dependencies](https://tanstack.com/start/latest/docs/framework/react/build-from-scratch)
- [Tauri prerequisites](https://v2.tauri.app/start/prerequisites/)
- [Tauri project creation paths](https://v2.tauri.app/start/create-project/)

These sources establish competitor and host-tool behavior. All `Weft.Cli`,
template, command, archive, signature, cache, and profile behavior above remains
a proposal until implemented and verified.
