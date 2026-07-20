# Weft Browser Interoperability and Native Shells Overview

## Execution-placement principle

Weft should use the least expensive execution location that satisfies the user
journey. Placement is explicit and measurable; an interaction does not become
browser C# merely because it looks interactive.

| Mode | Authority and transport | Browser cost | Status |
| --- | --- | --- | --- |
| HTML action | Server through ordinary navigation/form HTTP | HTML/CSS only | Narrow current baseline |
| Enhanced server action | Server through stateless fetch and declared region replacement | Small framework kernel | Proposed Must |
| Local C# capability | Browser for sustained local/offline computation; server still authorizes mutations | Lazy managed runtime and capability assets | Proposed Should/hypothesis |
| JavaScript adapter | Third-party browser library behind a typed boundary | Selected library and bridge | Proposed Must |

## Stateless enhancement

Enhanced actions should preserve the ordinary URL/method as the canonical
fallback. The contract must define:

- full-document versus fragment negotiation;
- authentication, authorization, antiforgery, validation, redirects, and typed
  failures;
- atomic region ownership/replacement;
- canonical URL and browser history;
- focus and live-region behavior;
- cancellation and stale-response ordering;
- failure fallback without partial DOM corruption; and
- no mandatory persistent per-user UI circuit.

## Browser C# capability

Browser C# is justified for repeated local interaction, offline work, complex
calculation, or another workload that repays activation cost. It is not the
normal implementation of navigation, forms, or simple server workflows.

A supported capability contract requires:

- a browser-safe API/reference profile enforced at compile time;
- versioned input/output DTOs and generated serialization;
- capability/user-journey chunking, shared-dependency planning, hashes, and
  cache policy;
- activation bytes, startup duration, retained memory, and disposal reporting;
- cancellation, errors, offline/pending state, and optional server fallback;
- no secrets or authoritative security decisions in browser code; and
- supported runtime/loader APIs rather than private Blazor/.NET internals.

WebAssembly may increase cold activation and browser memory. It can still be the
right engineering choice for sustained local behavior. No universal speed
conclusion follows from the technology alone.

## JavaScript interoperability

The product promise is:

> JavaScript-free by default; JavaScript-compatible by choice.

A pure route can send zero JavaScript bytes, but a future enhancement kernel,
browser .NET bootstrap, native WebView guest API, or selected library may
include JavaScript infrastructure even when application authors write C#.

Adapters should be typed, lazy, disposable, and least-privilege. They declare
DOM/API ownership, accept validated serializable data, receive no credentials
or raw trusted HTML, isolate failure, preserve semantic fallback, and remove
listeners/resources on disposal. Reusing a mature chart, map, editor, or payment
library is preferable to ideological reimplementation.

## Native shell landscape

| Shell | Current role | Important boundary |
| --- | --- | --- |
| Electron | Windows/macOS/Linux desktop | Bundled Chromium/Node; remote content must not receive broad Node/native access |
| Electrobun | Windows/macOS/Linux desktop | Bun/TypeScript plus WebView/CEF; no supported mobile application target today |
| Tauri 2 | Windows/macOS/Linux/Android/iOS | Primary cross-desktop/mobile reference; normally a static frontend host with Rust/native capabilities |
| Capacitor | Primarily iOS/Android web-native container | Mobile lifecycle/plugin reference with a JavaScript-facing guest API |

Bun's Android runtime build is a prerequisite that may help a future Electrobun
port; it does not supply an Android WebView host, packaging, lifecycle, bridge,
plugins, signing, debugging, updates, or support. Electrobun's mobile request
remained open in the 2026-07-20 recheck.

A product normally chooses one shell family that covers its target platforms.
The framework-neutral contract makes another adapter possible; it does not
justify maintaining several wrappers simultaneously.

## Native integration modes

### Hosted shell

A WebView loads a deployed HTTPS Weft server. This is closest to Current Weft
but usually requires connectivity. Origins, cookies, auth redirects, deep
links, navigation, external links, and native bridge capabilities must be
restricted and tested.

### Bundled static/client shell

The native package contains immutable HTML/CSS/assets and optional browser C#;
domain APIs remain remote or use an approved local service. This fits normal
Tauri/Capacitor hosting but requires a future static-shell publish profile.
Current Weft SSR cannot be bundled unchanged as this frontend.

### Desktop sidecar

A desktop shell starts a loopback-only packaged ASP.NET Core process and
coordinates authenticated readiness, random port, crash recovery, logging,
updates, and shutdown. This is not the proposed iOS/Android model.

## Framework-neutral shell contract

A future shell descriptor and generated bridge should define:

- profile-compatible output and relative content-hashed assets;
- start URL, allowed origins, routes/deep links, auth callbacks, and external
  link policy;
- versioned capabilities such as file selection, notifications, biometrics,
  secure storage, camera, and lifecycle events;
- origin/window/WebView allowlists and least-privilege permissions;
- validation, cancellation, timeout, errors, disposal, suspend/resume, and
  unsupported/fallback outcomes;
- safe area, viewport, touch, keyboard, back, focus, connectivity, background,
  memory pressure, and termination behavior;
- coordinated `dotnet watch` and shell development without unnecessary native
  rebuilds; and
- conformance for startup, recovery, navigation, auth, bridge denial, XSS
  containment, accessibility, production diagnostics, signing, integrity, and
  update compatibility.

## Recommended Spike boundary

Native-shell work should follow typed routes/actions, deterministic assets,
browser/JavaScript bridges, security, and deployment contracts. The original
single candidate covering Windows, Linux, Android, and an iOS pipeline is too
large for one first Spike.

Begin with one Tauri hosted or static prototype on one desktop OS and one native
capability. Prove the descriptor, origin/permission denial, deep link/auth,
lifecycle, Development/Production diagnostics, and build prerequisites. Expand
to the second desktop OS and Android in separately accepted phases. Treat iOS as
a separate Apple build/signing validation over the same contract.

## Detailed source

- [Developer errors and native shell integration](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/developer-errors-and-native-shell-integration.md)
- [Reference application capability and adapter boundaries](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/reference-application-spec.md)
