# FEAT-001 Developer Errors and Native Shell Integration Addendum

**Revision:** DNS-1

**Snapshot date:** 2026-07-15

**Status:** Research proposal; no runtime or shell implementation is authorized

## Purpose

This addendum answers two product questions raised after the first FEAT-001
closure audit:

1. How should Weft provide a Next.js-like development error experience while
   using .NET exceptions and stack traces?
2. What framework contracts would make Weft applications integrate smoothly
   with Electron, Tauri, Electrobun, Capacitor, and similar native WebView
   shells?

The two topics share one principle: Weft should expose a stable, safe contract
and let development or native hosts adapt it. It should not make one shell or
one debugging transport part of every application.

## Development Error Experience

### Evidence and opportunity

Next.js displays a development-only error overlay. Its current documentation
describes full source-map debugging, and its recent overlay presents the error
message, relevant code frame, and call stack while de-emphasizing dependency
frames. ASP.NET Core already provides a Development-only exception page with a
stack trace and source file/line information when available, and recommends a
custom exception handler in Production.

Weft therefore does not need a new exception system. It needs a Weft-aware
presentation and source-mapping layer over .NET diagnostics.

### Proposed `Weft Development Error Contract`

In the `Development` environment, an unhandled render, route, action, template,
asset, or capability error should provide:

- exception type and message;
- correlation/trace identifier;
- the first relevant application frame, source file, and line;
- a short encoded C# or template code frame when source is locally available;
- the full stack trace with generated/framework/dependency frames collapsed by
  default but revealable;
- feature, route, action, template, and capability identifiers from generated
  manifests;
- no request body, cookie, authorization header, connection string, or other
  secret-bearing value by default, even in Development;
- copy-details and optional open-in-editor actions;
- separate views for compile/generator errors, full-page request errors,
  enhanced-action errors, and browser-capability failures; and
- automatic dismissal or refresh after a successful rebuild/request where the
  transport supports it.

This can be a full diagnostic response for normal navigation and a small
development-only overlay client for enhanced navigation. A JavaScript-free
production baseline does not prohibit tooling that exists only in local
Development builds.

Detailed browser diagnostics are enabled only by the trusted host environment
and are loopback/local-development oriented by default. A team that exposes a
development server to another device must opt in to that network boundary and
protect it; the overlay is not an unauthenticated remote diagnostics service.

### Source mapping needed from Weft

Ordinary .NET stack traces can already contain C# file and line information
when symbols are available. Weft must additionally preserve mappings from:

- generated endpoint/action code to the feature declaration;
- compiled HTML/template output to the original template file and span;
- generated browser-capability dispatch to the originating C# contract; and
- asset/manifest diagnostics to the declaring feature and project item.

Generators and template compilers should emit standard source locations or an
inspectable Weft mapping manifest. The overlay must never show only an opaque
generated `.g.cs` frame when a user-authored source location is known.

### Production boundary

In `Staging` and `Production`:

- the overlay, source endpoint, editor link, code frame, physical source path,
  and serialized stack trace are absent;
- full-page, partial-action, and API failures use the appropriate friendly
  error representation with a correlation identifier;
- detailed exceptions stay in controlled server logs/traces;
- error responses are not publicly cached;
- validation/business failures remain normal typed outcomes rather than
  exceptions; and
- CI tests inspect production responses and published assets for stack traces,
  source paths, secrets, and development endpoints.

The mode is determined by the trusted host environment and build/publish
configuration. A request query, cookie, or header must not be able to enable
development diagnostics in Production.

## Native Shell Landscape

The named tools do not have one common deployment boundary.

| Shell | Current target | Web content/runtime model | Consequence for Weft |
| --- | --- | --- | --- |
| Electron | Windows, macOS, Linux desktop | Bundles Chromium and Node.js; local or trusted remote content with a preload/context bridge | Desktop adapter only; Node/npm is necessarily part of the shell project even if the Weft application remains C#. |
| Electrobun | Windows, macOS, Linux desktop | TypeScript/Bun main process with system WebView or optional CEF, bundled `views://` assets, typed RPC | Desktop adapter today; requires a Bun/TypeScript shell layer and a generated or handwritten bridge. Bun now has an Android binary, but Electrobun does not yet provide an Android app target. |
| Tauri 2 | Windows, macOS, Linux, Android, iOS | Rust/native shell and system WebView; normally hosts bundled static HTML/CSS/JS/WASM; supports native plugins and capability permissions | Best current reference for desktop plus mobile, but Current Weft SSR cannot be bundled unchanged as its static frontend. |
| Capacitor 8 | Primarily iOS and Android, with web support | Native container for an existing modern web project with JavaScript-to-native plugin APIs | Strong mobile reference; a small generated JavaScript guest bridge remains necessary for native APIs. |

Electron and Electrobun are not iOS/Android deployment solutions today. Tauri
and Capacitor are the relevant mobile references. Tauri's own frontend guidance
states that it acts conceptually as a static web host and does not natively
support server-rendered alternatives.

Bun 1.3.14 added first-party Android runtime builds in May 2026. That removes
one possible prerequisite for a future Electrobun Android port, but it is not
an Android application framework by itself. Electrobun would still need an
Android launcher/WebView host, Bun lifecycle integration, RPC bridge, Gradle
and APK/AAB generation, signing, permissions, plugins, device lifecycle,
debugging, and release/update support. Electrobun's official repository still
describes desktop applications, its platform table lists desktop operating
systems, and its mobile/Android requests remain open. Therefore the accurate
state is **promising new prerequisite, no supported Electrobun Android target
yet**.

### One shell family per application

The adapter contract is portable so a product can choose a shell; it is not a
recommendation to combine Electron, Electrobun, Tauri, and Capacitor in one
application. A normal Weft product selects one shell family that covers its
required platforms and maintains one bridge, lifecycle model, plugin set,
update mechanism, signing model, and conformance suite.

For a product requiring Windows/Linux desktop and Android today, Tauri is the
reference choice because it covers that set. Electron and Electrobun remain
alternative desktop-only providers for applications that do not require
mobile, or possible replacement candidates if their future platform coverage
matches the complete product requirement. Faster compilation alone does not
justify a second permanent shell implementation.

iOS always needs its Apple-specific Xcode, provisioning, signing, store, and CI
pipeline. Tauri can target iOS, so this operational separation does not require
a second Weft feature model or native bridge contract; a product may still
choose to handle its iOS application separately.

## Three Supported Integration Modes

Weft should specify modes explicitly instead of claiming that any web
application can be wrapped identically.

### Mode NS-1 — Hosted shell

The native WebView loads a deployed Weft application over HTTPS.

- Closest to Current Weft and preserves server rendering/actions.
- Requires network access for normal use unless a separately designed cache or
  offline capability exists.
- Authentication redirects, cookies, antiforgery, allowed origins, deep links,
  navigation, and external-browser transitions need shell-aware tests.
- Native API access must be origin-scoped and least-privileged. Electron remote
  content must not receive Node integration; Tauri remote API access requires
  explicit capability configuration.
- A compromised deployed page becomes more dangerous if the shell exposes an
  over-broad native bridge.

### Mode NS-2 — Bundled static/client shell

The shell packages immutable Weft HTML/CSS/assets and optional browser C#;
domain APIs remain remote or use an approved local data service.

- Fits Tauri/Capacitor's normal static frontend model and Electron/Electrobun
  bundled assets.
- Requires a future Weft static-shell publish profile, relative/base-path-safe
  assets, client-capable routing, an explicit remote API/auth contract, offline
  and update semantics, and capability-scoped browser execution.
- Current Weft does not implement this profile.

### Mode NS-3 — Desktop sidecar server

The desktop shell launches a packaged ASP.NET Core/Weft executable bound to a
random loopback port, waits for authenticated readiness, and loads it locally.

- Preserves server rendering while allowing a mostly local desktop app.
- Requires process lifecycle, one-time connection token, loopback-only binding,
  health/startup timeout, crash recovery, logging, coordinated update, signing,
  and clean shutdown contracts.
- This is a desktop pattern, not the proposed iOS/Android solution. Mobile
  platforms must not be assumed to permit a packaged long-running ASP.NET
  sidecar.

## Framework-Neutral `Weft Shell Contract`

Smooth integration requires the following Weft-owned contracts.

### Publish profiles

- `weft publish --profile hosted-shell`: emits server deployment plus a shell
  descriptor containing start URL, allowed origins, deep-link routes, asset
  policy, and required bridge capabilities.
- `weft publish --profile static-shell`: future static/client output with
  relative content-hashed assets and no server-only code in the bundle.
- `weft publish --profile desktop-sidecar`: self-contained desktop server
  output, lifecycle descriptor, health contract, and loopback security policy.
- Each profile fails when a feature requires a capability incompatible with the
  selected profile; no silent fallback changes application semantics.

### Typed native bridge

Feature manifests should declare native capabilities such as file selection,
notifications, biometrics, secure storage, camera, or deep-link events. A
generated C# interface should expose only approved operations. Shell adapters
translate that interface to Electron preload/contextBridge, Tauri commands and
permissions, Electrobun RPC, or Capacitor plugins.

The bridge contract requires:

- explicit capability and platform support declarations;
- versioned serializable request/response/event schemas;
- allowlisted origins/windows/webviews and least-privilege permissions;
- input validation on both sides of the trust boundary;
- cancellation, timeout, error mapping, disposal, and suspend/resume behavior;
- no raw general-purpose IPC, filesystem, shell, or command-execution handle;
- a browser fallback or explicit unsupported outcome; and
- generated adapter code that is inspectable and independently testable.

The application author can remain in C#, but native WebView APIs generally
cross a JavaScript guest boundary. “C# application code only” is credible;
“literally no JavaScript exists inside every native shell” is not.

### Navigation, identity, and lifecycle

The shell contract must standardize:

- ordinary URLs, base paths, custom schemes, universal/app links, and validated
  deep-link-to-route translation;
- system-browser authentication and secure callback handling rather than
  embedding client secrets;
- server-authoritative authorization after every callback/deep link;
- safe-area insets, viewport, touch, virtual keyboard, hardware/system back,
  focus restoration, and accessible native prompts;
- connectivity changes, offline state, background/suspend, resume, memory
  pressure, and process termination;
- external-link allowlists and download/file handoff; and
- shell/app update compatibility so a new server or frontend cannot silently
  call an incompatible native bridge.

### Development loop

A shell adapter is not smooth unless local development is coordinated:

- one command starts `dotnet watch` and the selected shell runner;
- a machine-readable readiness endpoint supplies the actual development URL;
- physical mobile devices can reach the development host through an explicit,
  TLS-capable configuration rather than a hard-coded `localhost` assumption;
- C# source changes refresh/reload without rebuilding native projects when the
  native contract did not change;
- native contract changes produce a clear rebuild-required diagnostic; and
- Weft's development error overlay works inside the WebView without exposing
  it in signed production packages.

### Conformance matrix

Each official adapter should run the same fixtures for:

- cold start, readiness, refresh, shutdown, crash and recovery;
- navigation, back, deep link, auth callback, external link and offline start;
- every declared native capability's allow/deny/unsupported behavior;
- XSS-to-native-bridge containment and origin/permission denial;
- Development overlay presence and Production diagnostic absence;
- accessibility, safe area, keyboard/touch, background/resume, and rotation;
- signed release output, immutable asset integrity, and update compatibility;
  and
- supported OS/WebView/runtime versions.

## Product Decision

Native-shell compatibility should be a `Should`, not an immediate `Must`, for
the first credible web-platform baseline. The architecture must avoid blocking
it now: typed routes/actions, deterministic assets, an explicit browser bridge,
portable deployment, and security boundaries are prerequisites.

The first integration Spike should prove one coherent Tauri application across
Windows/Linux desktop and Android using the same Weft shell descriptor, typed
bridge, navigation/auth rules, and conformance fixtures. The Android build and
signing pipeline remains platform-specific. An iOS validation can be a
separate Apple pipeline over the same contract.

Electron or Electrobun should be evaluated as alternative shell providers, not
added beside Tauri in the same product merely to reduce desktop build time.
Creating such an adapter is justified only for a desktop-only product or a
deliberate whole-product shell migration.

It should not promise offline mobile operation until the static/client profile
and domain synchronization model exist.

## Official Sources

- [Next.js debugging and error overlay](https://nextjs.org/docs/app/guides/debugging)
- [Next.js 15.2 error overlay design](https://nextjs.org/blog/next-15-2)
- [ASP.NET Core error handling](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-10.0)
- [Electron platform boundary](https://www.electronjs.org/docs/latest/)
- [Electron security guidance](https://www.electronjs.org/docs/latest/tutorial/security)
- [Tauri platform overview](https://v2.tauri.app/)
- [Tauri frontend/static-host boundary](https://v2.tauri.app/start/frontend/)
- [Tauri capabilities](https://v2.tauri.app/security/capabilities/)
- [Tauri deep linking](https://v2.tauri.app/plugin/deep-linking/)
- [Electrobun documentation](https://blackboard.sh/electrobun/docs/)
- [Electrobun compatibility](https://blackboard.sh/electrobun/docs/guides/compatability/)
- [Electrobun mobile-build request](https://github.com/blackboardsh/electrobun/issues/70)
- [Bun 1.3.14 Android runtime builds](https://bun.com/blog/bun-v1.3.14#freebsd-and-android-support)
- [Capacitor documentation](https://capacitorjs.com/docs)
