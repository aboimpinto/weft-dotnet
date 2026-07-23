# Weft Technical Overview

## Purpose of this document

This document describes Weft from a technical and architectural point of view.
It is working memory for product and engineering decisions, not a replacement
for the public project `README.md` and not a promise that planned functionality
already exists. Use the [Overview index](README.md) for the durable topic
summaries produced from FEAT-001.

## Executive summary

Weft is an experimental, HTML-first application platform for ASP.NET Core. Its
primary unit is a **vertical feature module** rather than a page component or a
separate frontend/backend layer.

A Weft feature is intended to own a coherent business capability:

```text
Orders feature
├── dependency-injection registration
├── server routes, authorization, and application services
├── server-rendered HTML templates
├── CSS and other assets
├── ordinary links and form fallbacks
├── optional enhanced server actions
└── optional browser-side C# capability
```

The server remains authoritative for security, validation, data access, and
business invariants. A useful HTML page should be available before any
application runtime starts in the browser. Browser-side code is added only when
the interaction requires it and its cost is justified.

The current repository implements the server-only foundation. Browser C#,
WebAssembly capability loading, enhanced fetch, a general asset pipeline, and
npm integration are roadmap items, not current features.

## The problem Weft is trying to solve

Many business applications are dominated by navigation, forms, tables,
validation, and server-side workflows. These interactions do not inherently
require a client-side application framework or a managed runtime in the
browser. At the same time, a smaller number of workflows may genuinely benefit
from local computation, offline operation, or long-lived interactive state.

Weft attempts to support both without making the most expensive execution mode
the default for the whole application:

1. Start with normal HTML and HTTP semantics.
2. Enhance a server operation when replacing part of a page materially improves
   the experience.
3. Load a browser-side C# capability only for a workflow that benefits from
   local execution enough to repay its payload, startup, and memory costs.

This is progressive enhancement expressed as a .NET feature contract and build
model.

## Product thesis and market gap

Weft should not claim that no C# web frameworks exist. Blazor, Uno Platform,
OpenSilver, DotVVM, Wisej.NET, WebSharper, Razor Pages, and ASP.NET Core MVC all
allow developers to use .NET for some or most of a web application.

The stronger and more accurate position is:

> The market contains C# web frameworks, but no mainstream platform is centred
> on the exact combination Weft proposes: HTML-first vertical .NET features,
> zero application JavaScript by default, optional capability-sized browser C#,
> and explicit access to JavaScript libraries when they are genuinely useful.

The current alternatives emphasise different models:

| Alternative | Primary model | Difference from the intended Weft model |
| --- | --- | --- |
| React and Angular ecosystems | JavaScript/TypeScript application architecture, component composition, and frontend package tooling | Mature modern web experience, but JavaScript/TypeScript and the Node toolchain normally become architectural foundations |
| Blazor | Razor component model with Static Server, Interactive Server, Interactive WebAssembly, and Interactive Auto render modes | The closest C# alternative; Weft instead wants feature-level execution placement, ordinary HTTP as the durable contract, and capability-level browser activation |
| Razor Pages and ASP.NET Core MVC | Server-rendered request/response applications | Can be completely JavaScript-free, but do not by themselves provide the proposed modern feature packaging and selectively local C# capability model |
| Uno Platform and OpenSilver | C#/XAML applications delivered to the browser through WebAssembly | Oriented toward cross-platform native, WinUI, WPF, or Silverlight-style UI rather than HTML-first business feature modules |
| DotVVM and Wisej.NET | C#-oriented developer models backed by client framework or real-time server infrastructure | Reduce developer-authored JavaScript, but still adopt a particular client/runtime architecture rather than zero-runtime HTML as the base contract |
| WebSharper | F#/C# source compiled into JavaScript for client execution | Lets .NET-language developers author browser behaviour, but JavaScript remains the generated client runtime target |

Weft is therefore not justified merely because it uses C#. It is justified if it
can occupy the space between traditional server-rendered ASP.NET Core and a
full client application framework.

The intended product statement is:

> Weft exists so .NET teams can build modern modular web applications in C#,
> HTML, and CSS—without adopting a JavaScript application architecture,
> without paying for browser-side .NET on every page, and without losing access
> to the JavaScript ecosystem when it is genuinely useful.

“React/Angular-style project” should describe the expected level of developer
experience and modularity, not an obligation to copy their internal rendering
models. Weft should aim to provide:

- reusable feature and UI composition;
- clear state, event, form, validation, and navigation contracts;
- capability isolation and code splitting;
- fast local development and hot reload;
- high-quality diagnostics, testing, browser debugging, and developer tools;
- packages that can be developed independently and composed into an
  application;
- a coherent production build with predictable assets and dependencies.

Weft does not need a React-compatible virtual DOM or an Angular-compatible
module system. It does need comparable productivity and predictability. Without
that development experience, a distinctive runtime architecture alone will not
be enough to create adoption.

## Current architecture

### Build-time feature discovery

A feature class is marked with `[WeftFeature]`, declares its routes and actions,
and implements `IWeftServerFeature`:

```csharp
[WeftFeature("tasks")]
[WeftRoute("/tasks", Name = "tasks.page")]
public sealed partial class TasksFeature : IWeftServerFeature
{
    public void RegisterServices(IServiceCollection services) { }

    public void MapEndpoints(IEndpointRouteBuilder endpoints) { }
}
```

`Weft.Generator` is a Roslyn source generator. It validates the feature shape
and emits a strongly typed `TasksFeature.Manifest` property. The generated
factory directly constructs the feature; it does not use runtime reflection to
dispatch requests.

### Explicit host trust

The application host selects the feature manifests that it trusts:

```csharp
builder.Services.AddWeft(TasksFeature.Manifest);

var app = builder.Build();
app.MapWeft();
```

Weft does not activate every assembly found in the deployment. `AddWeft(...)`
sorts selected features by stable feature ID, creates the feature modules,
checks for duplicate feature IDs and declared routes, and calls each feature's
service-registration method.

`MapWeft()` then calls the route-mapping method of each selected feature. It
compares the endpoints added by that feature with the generated route metadata.
A disagreement fails application startup instead of silently accepting an
incorrect manifest.

### Current packages

| Project | Current responsibility |
| --- | --- |
| `Weft.Abstractions` | Feature, route, action, and execution-mode contracts |
| `Weft.Generator` | Compile-time feature validation and manifest generation |
| `Weft.Server` | Explicit feature registration, duplicate checks, and deterministic endpoint mapping |
| `starter-html` | Runnable proof using embedded HTML/CSS, antiforgery, and normal post/redirect/get |

The template rendering and embedded asset mechanism in `starter-html` are
private to that example. They are not yet general Weft framework APIs.

## Planned execution modes

| Mode | Execution location | Browser requirement | Status |
| --- | --- | --- | --- |
| HTML action | ASP.NET Core server through ordinary navigation or form submission | HTML and CSS only | Implemented baseline |
| Enhanced server action | Server, with a small browser kernel performing fetch and explicit region replacement | Small generic enhancement script | Planned |
| Local C# capability | Browser for sustained local computation or offline behaviour | Lazy managed runtime and selected capability assets | Planned and still a technical hypothesis |

An action should use the least expensive mode that meets its requirements. A
button appearing in an interactive-looking area is not sufficient reason to
turn its behaviour into browser-side C#.

## What is the difference between Weft and Blazor?

Blazor is Microsoft's component-oriented web UI framework. Current Blazor Web
Apps can use static server-side rendering, interactive server rendering,
interactive WebAssembly rendering, and automatic selection between server and
WebAssembly interaction. Therefore, it would be inaccurate to describe all
Blazor applications as applications that immediately download WebAssembly.

Weft is exploring a different primary abstraction and set of constraints:

| Concern | Blazor | Weft direction |
| --- | --- | --- |
| Primary unit | UI component and component render tree | Vertical business feature module |
| Baseline interaction | Depends on the selected component render mode | Ordinary URLs, links, forms, and server HTML |
| Client interactivity | Interactive render mode applied to components/app boundaries | Explicit action placement; future local capability loaded for a user journey |
| DOM ownership | Interactive components participate in Blazor's rendering model | HTML is the durable contract; enhancements replace declared regions |
| Server interaction | Interactive Server uses a live server circuit; other modes use normal requests as designed by the app | Normal HTTP is the baseline; no persistent circuit is required by the model |
| Module registration | Application and component conventions | Generated manifest explicitly selected by the host |
| Browser C# | A supported central Blazor capability | A future optional capability, not the default application model |
| Asset objective | Determined by Blazor render modes and publishing model | Per-feature/capability assets with explicit payload budgets and provenance |

There is overlap. Blazor static SSR and enhanced navigation cover some problems
that Weft also wants to address. Blazor also supports lazy loading of assemblies.
Weft must therefore prove value through its feature packaging, explicit trust
model, execution-placement rules, fallback contract, and measurable
capability-level asset planning—not through a claim that Blazor cannot render
HTML on the server.

Weft is not currently a production alternative to Blazor. The repository has a
runnable server foundation, while the browser capability model remains future
work. A future implementation might reuse supported .NET runtime and
WebAssembly infrastructure, but it must not depend on unsupported runtime
internals or imply that it is simply Blazor with different terminology.

### How to answer: “We can already build this with Blazor”

The first answer is **yes**. Blazor proves that modern web applications can be
built with C#, HTML, and CSS. It supports reusable Razor components, Razor Class
Libraries, static server rendering, interactive server rendering, browser
WebAssembly, automatic render-mode selection, forms, enhanced navigation, and
JavaScript interoperability. If those capabilities and Blazor's component
model fit a project's requirements, Blazor is the mature choice today.

Weft should not argue that Blazor is incapable. It should argue that it makes a
different architectural choice:

> Blazor makes the Razor component and its render mode the central unit of web
> interactivity. Weft intends to make the vertical business feature and the
> execution placement of each action the central unit of application design.

The short public response can be:

> Yes, Blazor can build a modern application in C#. Weft is not based on the
> claim that Blazor cannot. Weft is for applications that want ordinary HTTP
> and server HTML to remain the default contract, with stateless enhancement or
> browser-side C# activated only for the particular feature capability that
> earns its cost. It also treats routes, services, authorization, templates,
> assets, fallback behaviour, and optional browser code as one explicitly
> trusted vertical feature package. If Weft cannot make that model materially
> simpler, smaller, and easier to measure than the equivalent Blazor
> application, developers should use Blazor.

#### Where the approaches overlap

Blazor already covers several ideas relevant to Weft:

- Static SSR can render Razor components as server HTML without interactive C#.
- Blazor forms can use traditional HTTP posts in static SSR.
- Enhanced navigation and form handling can fetch server-rendered responses and
  patch the DOM when the Blazor web script is present.
- Interactive Server avoids downloading the application as WebAssembly, while
  executing events over a live server circuit.
- Interactive WebAssembly and Auto allow C# execution in the browser.
- Razor Class Libraries can package components and static web assets.
- JavaScript interop allows reuse of browser APIs and third-party libraries.

These are substantial capabilities. Weft must never present them as absent.

#### What Weft intends to make different

| Question | Blazor answer | Intended Weft answer |
| --- | --- | --- |
| What is the architectural unit? | A Razor component, page, component library, or application | A complete vertical business feature with generated registration |
| What happens for a normal save operation? | Depends on static or interactive render mode and component design | Ordinary antiforgery-protected HTTP form action by default |
| How is smooth server interaction added? | Blazor enhanced navigation/form handling or Interactive Server components | A small stateless fetch/replace kernel without creating a component circuit |
| When is browser C# loaded? | When a component/app adopts WebAssembly or Auto interactivity | When a declared local capability is activated and no cheaper mode meets the need |
| What is packaged together? | Razor Class Libraries package components and assets; applications add their own service/endpoint conventions | Manifest joins routes, DI, authorization metadata, actions, templates, assets, fallback, and optional capabilities |
| How is trust expressed? | Normal application references and framework conventions | Host explicitly selects generated feature manifests |
| How are costs exposed? | Publish output and framework tooling provide relevant build information | Capability graph reports initial, first-action, warm-cache, retained-memory, provenance, and dependency budgets |
| Is Node required? | Not inherently; depends on selected project tooling and assets | Explicitly absent in pure .NET and direct-asset modes |

Some differences are differences of enforced convention rather than theoretical
capability. A skilled team can create vertical modules, explicit service
registration, fallback forms, asset budgets, and disciplined render modes on
top of Blazor. Weft's opportunity is to make those properties the default,
generated, validated, packaged, and measurable instead of requiring every team
to establish them independently.

#### The decisive test

Weft needs to demonstrate better outcomes, not merely different terminology.
An equivalent reference application should establish whether Weft provides:

- less initial browser code for predominantly server-owned workflows;
- no persistent per-user circuit for stateless enhanced actions;
- later and smaller activation of browser-side C#;
- clearer vertical feature packaging and host trust;
- more explicit fallback, dependency, and payload contracts;
- comparable hot reload, debugging, testing, component composition, and
  developer productivity;
- simpler deployment and failure behaviour for the target class of business
  applications.

If those results do not materialise, Blazor already serves the C# web market and
there is no strong reason for Weft to exist. That is the correct competitive
standard for the project.

## Why build this on .NET when mature Node.js options exist?

Node.js, TypeScript, and their frontend frameworks are valid and often
excellent choices. Weft is not based on the claim that JavaScript or Node.js is
an improper web platform.

The .NET choice is valuable primarily for organisations already invested in:

- C# engineering skills;
- ASP.NET Core hosting, security, diagnostics, and dependency injection;
- NuGet libraries and existing domain/application code;
- .NET operational tooling and deployment practices;
- compile-time contracts and source generation.

For those teams, Weft aims to keep business features, server behaviour, typed
contracts, and optional local capabilities in a coherent .NET model. A pure
HTML Weft application should not require Node.js at all. If a team needs
Tailwind, Bootstrap assets, Chart.js, Monaco, or another JavaScript ecosystem
package, Node-compatible tooling can remain an optional build-time integration
rather than a mandatory application runtime.

Using .NET does not remove the web platform. Weft applications still need good
HTML, CSS, HTTP, accessibility, browser security, caching, and—where useful—an
explicit JavaScript bridge. It also does not justify rewriting mature npm
libraries in C#.

For a team already productive with Node.js and a modern frontend stack, Weft
may offer no compelling reason to migrate. Its strongest potential audience is
a .NET team that wants modular server-owned applications, dependable HTML
fallbacks, and selectively richer browser behaviour without adopting a
JavaScript-first application architecture.

## JavaScript policy: free by default, compatible by choice

“JavaScript-free” must be defined precisely because it can refer to source code,
build tooling, or bytes delivered to the browser.

Weft should target all of the following:

1. **Zero developer-authored JavaScript can be a complete application choice.**
   Application behaviour can be written in C#, HTML, and CSS.
2. **HTML-only routes can deliver zero JavaScript bytes.** The current starter
   already demonstrates this property.
3. **Node.js is not required for a pure .NET application.** A project that does
   not select npm assets or Node-based build tools should not install them.
4. **Framework infrastructure is accounted for honestly.** A future enhanced
   server action may require a small Weft browser kernel. A future .NET
   WebAssembly capability is likely to require generated JavaScript bootstrap
   infrastructure such as `dotnet.js` and browser-host interop even when the
   application developer writes no JavaScript.
5. **JavaScript libraries remain an explicit option.** A feature can select a
   typed, isolated bridge to a mature library instead of forcing a rewrite in
   C#.

Consequently, Weft should not promise that every rich application ships no
`.js` files under every execution mode. It can make two stronger, testable
promises:

> **JavaScript-free by default. JavaScript-compatible by choice.**

> **No JavaScript application stack is required.**

These promises allow a genuinely script-free HTML application while remaining
technically honest about browser runtimes and interoperability.

## Dependency strategy: avoid the project-local dependency warehouse

One motivation for Weft is avoiding the large project-local `node_modules`
tree common in Node-based templates. npm installs local packages under
`node_modules`; a modern frontend build can expand a substantial transitive
graph there even when the published application uses only a fraction of its
files.

The Weft goal should be broader than merely renaming or hiding that directory:

- pure .NET projects have no Node.js installation and no `node_modules`;
- packages and assets are stored once in shared caches outside the repository;
- every dependency is explicitly declared and reproducibly locked;
- downloaded content is verified by a cryptographic hash;
- source, version, license, integrity, and reason for inclusion are visible;
- dependency lifecycle scripts do not execute implicitly;
- only selected, processed runtime assets enter published output;
- build dependencies never become browser dependencies by accident;
- unused transitive files are not copied into each application workspace.

NuGet already provides part of the desired model. With `PackageReference`,
packages are restored to a global packages folder outside the project and can
be reused by multiple projects. NuGet can also lock the complete dependency
closure in `packages.lock.json`. Weft should build on those mechanisms for .NET
code rather than invent another .NET package manager.

This does not mean that Weft is dependency-free or that every Weft application
has fewer packages than every Node application. The useful distinction is a
smaller mandatory toolchain and dependency ecosystems that are proportional to
selected capabilities:

| Potential setup | Required ecosystems and likely project footprint |
| --- | --- |
| Pure Weft | .NET SDK plus NuGet; no Node, npm, or `node_modules`. |
| Weft with one direct CSS asset | .NET SDK, NuGet, and one immutable hash-verified asset; still no Node or `node_modules`. |
| Weft with JavaScript ecosystem integration | .NET SDK, NuGet, and one selected npm-compatible package manager/lockfile; `node_modules` may exist and a compatible Node runtime may be required by the chosen tooling. |
| Weft with Tauri | .NET SDK, NuGet, Rust, and native target tooling; Android and iOS add their platform-specific SDK/build/signing requirements. |

NuGet also has transitive packages, supply-chain risk, build targets, analyzers,
source generators, caches, intermediate output, and disk cost. Build-time
package code remains a trust boundary. The structural difference is that
`PackageReference` normally restores package contents into a shared global
directory rather than expanding the complete package graph into every
project's `node_modules`. Local `obj`, `bin`, generated, and publish output
still exist, and the shared cache still occupies disk.

The defensible promise is therefore not “Weft has no dependencies” or even
“Weft always has fewer dependencies.” It is:

> **Weft does not make a C# web application inherit the Node dependency
> ecosystem unless the application selects a capability that needs it.**

> **Dependencies are proportional to the capabilities selected by the
> application.**

### Installation and bootstrap strategy

Installing Weft itself and restoring an application's dependencies are
different trust and lifecycle operations. The proposed installation contract is
documented in
[FEAT-001 Weft Installation and Bootstrap Strategy](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/installation-and-bootstrap-strategy.md).

The intended pure-mode experience has one mandatory prerequisite: a supported
.NET SDK. While Weft is experimental, a versioned GitHub Release downloaded by
`wget` on Unix-like systems or `Invoke-WebRequest` on PowerShell is a sensible
bootstrap path. The archive and signed checksum/provenance manifest must be
downloaded and verified before the CLI is executed; piping a mutable remote
script directly into a shell is not the canonical trust path.

When `Weft.Cli` can be published reliably, a committed repository-local .NET
tool manifest should become the recommended team and CI installation:

```powershell
dotnet tool install --local Weft.Cli --version 0.1.0
dotnet tool restore
dotnet weft --version
```

The identifiers and version above describe the proposed command shape, not an
available package. A global tool may remain convenient for exploration, but it
must not be the only workflow because two projects need to use pinned Weft
versions side by side.

Project creation should then be one explicit command such as `weft new app
MyApp --profile html`. The pure `html` profile installs no Node runtime,
`package.json`, JavaScript lockfile, or `node_modules`. Optional browser C#,
JavaScript interop, Tauri, Android, and iOS profiles expose their additional
workloads and native SDKs through `weft doctor`; the creator must not silently
install every possible toolchain.

The complete lifecycle also requires locked restore, a dry-run for adding Weft
to an existing ASP.NET Core application, offline/mirror support, explicit
updates and migrations, cache inspection/garbage collection, and conservative
removal. No normal command should require administrator privileges, silently
auto-update, enable telemetry, run undeclared install scripts, or remove shared
SDKs and caches.

### Direct immutable asset retrieval

The `wget` idea is useful as a mental model for simple browser assets: if a
feature needs one known CSS or JavaScript distribution file, it should be
possible to declare and retrieve that file without installing an entire Node
application toolchain.

The product implementation should be cross-platform .NET tooling rather than a
hard dependency on the `wget` executable. A future declaration might contain:

```json
{
  "assets": [
    {
      "name": "pico-css",
      "version": "2.1.1",
      "source": "https://example.invalid/pico/2.1.1/pico.min.css",
      "sha256": "<required-content-hash>",
      "license": "MIT",
      "publishAs": "styles/pico.<content-hash>.css"
    }
  ]
}
```

This is a design example, not a committed schema or a real asset URL. Restore
would download the asset into a global content-addressed cache, verify its hash,
record its provenance, and publish it under a content-hashed name. CI restore
would fail if the content changed without a lock update.

A raw `wget <url>` command is not sufficient dependency management. By itself
it does not provide semantic version resolution, transitive dependency
resolution, a reproducible lock, license information, provenance policy, or an
application asset graph. Direct retrieval should therefore be limited to
immutable, independently consumable assets with required integrity metadata.
Dependencies must be restored during the build, never downloaded arbitrarily by
the production browser or server at runtime.

### Optional npm interoperability

Some packages cannot be represented as one downloadable browser file. Tailwind
build tooling, complex JavaScript libraries, bundler plugins, and packages with
transitive imports need a real npm-compatible resolver.

For those projects, Weft should preserve an explicit escape hatch:

- one package manager and one committed lockfile are selected;
- pnpm is preferred for new integrations because its content-addressable store
  shares package files across projects;
- restore happens in an isolated or disposable build workspace where feasible;
- package lifecycle scripts are denied by default or explicitly approved;
- the final asset manifest contains only the files produced for deployment;
- the application repository does not treat `node_modules` as source or as a
  deployment artifact.

pnpm still constructs a `node_modules` structure for Node-compatible resolution,
although its package files are linked from a shared content-addressable store.
Weft must therefore not promise that selecting arbitrary npm build tooling can
never create such a directory. The meaningful promise is that npm and
`node_modules` are absent unless the project explicitly selects npm ecosystem
functionality, and that neither is required at application runtime.

### What “better than npm” should mean

Weft should not claim to replace the npm registry or universally outperform its
package manager. It should define “better” for the narrower Weft use case:

| Property | Weft target |
| --- | --- |
| Workspace size | No project-local dependency tree for pure .NET or direct-asset projects |
| Reuse | One global content-addressed cache across projects |
| Determinism | Committed lock data and immutable versions |
| Integrity | Required cryptographic hashes and fail-closed restore |
| Provenance | Source, version, license, and dependency reason in the build report |
| Execution safety | No undeclared install/build scripts |
| Deployment | Publish only route/capability assets, never a package-manager layout |
| Interoperability | Use npm-compatible tooling when a selected dependency genuinely requires it |

This extends the existing NuGet-first, npm-compatible policy. Adding direct URL
assets and a shared Weft asset cache would require a formal package/asset design
decision before implementation.

## Is Weft as fast as a Node.js project?

There is currently no evidence that supports a broad performance claim. Weft
has no published comparative benchmarks, and “a Node.js project” is not a
single performance target. Performance depends on the framework, workload,
database, caching, serialization, network topology, page design, assets, and
deployment configuration.

The current request path uses ASP.NET Core endpoint handlers. Weft's feature
selection, manifest validation, and service registration happen during
application startup. Its generated factories avoid assembly scanning and
reflection-based route dispatch. These choices are intended to keep framework
overhead predictable, but they are not a substitute for measurements.

Weft should eventually benchmark equivalent applications and report at least:

- server throughput and CPU use;
- median and tail response latency;
- time to first byte and time to useful content;
- initial transferred and compressed bytes;
- initial request count;
- first enhanced-action latency;
- cold and warm local-capability activation time;
- browser memory after capability activation;
- server memory and connection requirements;
- behaviour under slow networks and constrained devices.

An HTML-first Weft page may have a smaller initial browser payload than a
client-heavy application because it can ship only HTML and CSS. That does not
mean every Weft application will be faster than every Node.js application. The
defensible goal is predictable performance with measured budgets, not a
universal runtime victory claim.

## Does WebAssembly make a Weft application slower?

The current Weft implementation does not load or use WebAssembly. Its runnable
starter sends server-rendered HTML and CSS with no browser .NET runtime.

In the future local-capability mode, WebAssembly and the managed runtime can
make the **first activation of that capability** slower. The browser may need to
download, compile, and initialize runtime and application assets. It can also
increase browser memory usage. These costs are real and must not be hidden.

Weft's proposed response is architectural rather than rhetorical:

- do not load WebAssembly for navigation, ordinary forms, or simple server
  workflows;
- group browser code by meaningful capability or user journey instead of one
  file per button or visual component;
- share runtime and common dependencies across capabilities;
- use immutable, content-hashed assets so repeat visits benefit from caching;
- consider cautious prefetch only when user intent and network conditions make
  it reasonable;
- report cold, warm-cache, transferred-size, and retained-memory budgets;
- preserve a documented server fallback where the workflow permits one.

WebAssembly should only be selected when local execution provides enough value:
offline editing, repeated complex calculations, low-latency sustained
interaction, local processing of non-secret data, or a long-running workflow
that would otherwise require frequent network round trips.

WebAssembly can also increase development complexity through additional build,
debugging, deployment, and browser-boundary concerns. The future tooling must
make that boundary explicit and testable. If it cannot do so, a server action or
an existing JavaScript library may be the better engineering decision.

## Is Weft secure?

Weft cannot currently be described as production-secure. It is an experimental
framework with no released packages, formal threat model, independent security
review, supported-version policy, or production incident-response process. The
starter demonstrates a few sound practices, but a secure example is not the
same as a secure platform.

The present design has security-positive properties:

- **Explicit module trust.** The host selects generated feature manifests.
  Weft does not discover and activate every DLL in the deployment directory.
- **Server authority.** Authorization, validation, secrets, database access,
  and business invariants are intended to remain on the server.
- **No reflection-based request dispatch.** Generated factories and normal
  ASP.NET Core endpoints reduce dynamic behaviour that is difficult to audit.
- **Small default browser surface.** The current HTML-only path sends no
  application JavaScript, managed browser runtime, or WebAssembly.
- **Ordinary web protections.** The starter's mutation uses ASP.NET Core
  antiforgery validation, bounds its input, HTML-encodes submitted text, and
  applies post/redirect/get.
- **Manifest-to-endpoint validation.** Startup fails when a feature's declared
  routes do not match the routes it maps.

These properties help with particular risks, but none of them proves that an
application is secure. For example, explicit registration does not sandbox a
feature. Once trusted, a feature library runs as normal server code with the
permissions of the application process. Route metadata also does not currently
declare or verify an authorization policy.

Weft and applications built on it still require:

- supported runtime and package versions with timely security updates;
- HTTPS and correct proxy, cookie, header, and production-host configuration;
- authentication and authorization on every protected operation;
- server-side validation and enforcement of business invariants;
- contextual output encoding and protection against XSS;
- antiforgery protection for cookie-authenticated mutations;
- protection against injection, unsafe file access, SSRF, open redirects, and
  insecure deserialization where relevant;
- secure secret storage and least-privilege database/service credentials;
- dependency provenance, lockfiles, vulnerability monitoring, and controlled
  build pipelines;
- rate limiting, logging, alerting, recovery procedures, and security tests;
- an explicit threat model for enhanced actions, asset delivery, JavaScript
  bridges, and future browser capabilities.

The current example renderer performs manual placeholder replacement. It
HTML-encodes its present dynamic values, but that implementation must not be
treated as a general safe-template system. A future renderer needs clear
contextual-encoding rules for HTML text, attributes, URLs, CSS, and scripts.

Browser-side C# and WebAssembly must also be treated as public client code. They
cannot contain server secrets or be trusted to authorize an operation. A user
can inspect or modify browser requests regardless of whether the client was
written in C#, JavaScript, or another language. The server must validate every
security-sensitive request and enforce every invariant again.

## Is Weft more secure than Node.js?

Not inherently. A well-designed, maintained Node.js application can be more
secure than an immature or incorrectly configured Weft application. Conversely,
a carefully built ASP.NET Core application may be safer than a poorly
maintained Node.js application. The programming language and runtime influence
the available controls and likely mistakes, but they do not decide the result.

Weft may reduce attack surface in some deployments:

| Weft design choice | Potential security benefit | Important limitation |
| --- | --- | --- |
| HTML-only baseline | Less client application code and fewer browser dependencies to compromise | Server HTML can still contain XSS, unsafe links, or sensitive data |
| Node-optional pure .NET build | Removes the npm dependency graph when the application genuinely does not need it | NuGet, container, CI, OS, and other supply-chain risks remain |
| Explicit generated manifests | Makes feature activation deliberate and auditable | A selected feature is fully trusted code, not a sandboxed plugin |
| Server-owned business rules | Keeps secrets and authoritative decisions out of the browser | Developers must actually implement authorization and validation correctly |
| Normal ASP.NET Core endpoints | Reuses established framework security mechanisms | Those mechanisms require correct configuration and do not prevent application-logic flaws |
| Planned bounded asset manifest | Could expose provenance, integrity, and dependency budgets | The asset pipeline and integrity enforcement are not implemented yet |

Node.js has its own strengths: mature frameworks, security middleware,
well-understood deployment patterns, lockfiles, auditing tools, and a large
community that identifies and fixes vulnerabilities. Its npm ecosystem can
produce a large transitive dependency graph, but dependency count alone is not
a security verdict. Risk depends on which packages execute, their provenance,
maintenance, permissions, build scripts, and update process. A .NET application
can also be compromised through a malicious or vulnerable package.

The defensible security position for Weft is therefore:

> Weft intends to make a small browser surface, explicit feature trust, server
> authority, and dependency visibility architectural defaults. It does not
> claim that .NET or Weft is automatically more secure than Node.js.

Before any production-security claim, Weft should deliver and review at least:

1. a threat model covering server registration, enhanced actions, asset
   publication, capability loading, and JavaScript bridges;
2. an authorization contract that cannot be confused with route declaration;
3. contextual template encoding and content-security-policy guidance;
4. CSRF, XSS, authentication, authorization, cancellation, redirect, upload,
   and error-path tests;
5. package lock/provenance and asset-integrity support;
6. a supported-version and private vulnerability-reporting policy;
7. security review of the framework and representative applications;
8. documented deployment hardening for ASP.NET Core and reverse proxies.

## Aggressive product predictions

The following are hypotheses Weft should state confidently and then attempt to
prove with runnable applications, build reports, and benchmarks:

1. **Most business interactions do not need a persistent client runtime.** A
   large application can remain modern and responsive while most routes use
   server HTML and ordinary HTTP.
2. **JavaScript/TypeScript does not need to be the application language of the
   web for .NET teams.** C#, HTML, and CSS can cover the complete application,
   with JavaScript selected only at an interoperability boundary.
3. **A browser runtime should be a capability cost, not an application tax.**
   Lazy local C# can serve offline, computational, and sustained interactions
   without making every page a WebAssembly application.
4. **Vertical NuGet features can replace duplicated frontend/backend package
   structures.** One feature package can own routes, services, contracts,
   rendering, assets, tests, and optional local behaviour.
5. **The average Weft business application can have a smaller and more
   explainable dependency surface.** Pure .NET and direct-asset modes can avoid
   Node and `node_modules`, while build reports expose every deployed asset.
6. **Initial user experience can beat client-heavy defaults.** Useful HTML can
   arrive without waiting for hydration, a JavaScript application bundle, or a
   managed browser runtime. This must be measured per application, not treated
   as a universal benchmark result.
7. **Explicit execution placement can improve reliability and security in
   practice.** Developers can see which operations use HTTP, enhancement, local
   C#, or JavaScript bridges, and can test each failure boundary.
8. **One typed feature language is well suited to AI-assisted development.** An
   agent can reason across routes, contracts, validation, rendering, and tests
   without translating the same feature between separate C# and TypeScript
   architectures.
9. **JavaScript interoperability is a competitive advantage, not a failure of
   the C# vision.** Weft can reuse mature browser libraries without allowing
   them to dictate the structure of the entire application.

The project should distinguish predictions from current capabilities. The
server foundation exists today; the developer experience, asset system,
enhanced actions, and lazy browser capability model still have to earn these
claims.

## Why might people choose Weft?

If the project delivers its roadmap, likely reasons include:

1. **HTML-first reliability.** Core workflows remain normal pages, links, and
   forms instead of depending on a client runtime merely to become usable.
2. **Vertical feature packaging.** Routes, services, templates, styles, and
   optional capabilities can be developed and distributed as one business
   feature.
3. **Explicit trust and predictable startup.** Hosts choose generated feature
   manifests; deployed assemblies are not automatically activated.
4. **A C#-native workflow.** .NET teams can reuse their skills, NuGet ecosystem,
   domain types, and ASP.NET Core infrastructure.
5. **Optional Node tooling.** Projects that need only server HTML are not forced
   to install Node. Projects that need frontend packages can opt into a pinned
   npm-compatible build pipeline.
6. **Progressive cost.** Applications pay for enhanced interaction or a managed
   browser runtime only when a declared workflow needs it.
7. **Testable performance discipline.** Payload, caching, request count,
   activation latency, and memory are intended to become build-visible
   constraints rather than assumptions.
8. **Graceful behaviour.** Ordinary HTTP semantics improve accessibility,
   navigation, failure handling, and operation on unreliable networks.

## Who should not choose it yet?

Weft is experimental and has no production support commitment. It should not be
selected today when a project requires a mature ecosystem, stable packages,
documented browser compatibility, a security review, and predictable migration
support.

It may also be the wrong direction for:

- a team already successful with a Node.js/TypeScript architecture and no
  significant .NET requirement;
- an application whose entire experience requires rich client interaction from
  first paint;
- a simple ASP.NET Core application that does not benefit from packaged vertical
  features;
- a workflow better served by an established JavaScript component or library;
- a project unwilling to measure and justify the browser-runtime cost.

## Competitive research synthesis (FEAT-001, 2026-07-15)

The FEAT-001 investigation compared Blazor on .NET 10, Next.js 16.2.10 with
React 19.2.7, Angular 22.0.6, the individually versioned TanStack Start,
Router, Query, Form, Table, and Devtools packages, and Weft at commit
`ca5bacedfa7241be6071b09ad44d8d62948c7426`. The comparison uses official
technical sources for capability claims and keeps **Current Weft** separate
from **Target Weft Hypothesis**.

The defensible market statement is narrower and stronger than “there are no
C# web frameworks.” Blazor, Razor Pages/MVC, DotVVM, Uno Platform,
OpenSilver, Wisej.NET, and WebSharper all occupy adjacent territory. What is
not occupied by a mainstream platform is Weft's proposed combination:
vertical feature packages; C#, HTML, and CSS as the normal application
languages; useful HTML without a mandatory client runtime; stateless
enhancement; browser C# paid for only by sustained-local capabilities; and a
bounded JavaScript escape hatch rather than JavaScript as the application
foundation.

The research supports these conclusions:

- Blazor is the closest mainstream .NET alternative, but its component/render-
  mode model and interactive server/WebAssembly runtimes solve a different
  composition problem. Weft must demonstrate value through feature packaging,
  HTML-first behavior, stateless enhancement, and explicit capability cost—not
  through the fact that it uses C#.
- Next.js, Angular, and the TanStack family establish a demanding baseline for
  routing, forms, data loading, failure composition, tooling, testing,
  deployment, and developer feedback. Avoiding TypeScript is not sufficient;
  Weft must provide coherent C# equivalents for the relevant outcomes.
- No evidence collected in FEAT-001 proves that Weft is faster than Node.js,
  Blazor, or any named framework. Performance claims remain hypotheses until
  equivalent reference implementations pass the pinned benchmark method.
- WebAssembly is a cost, not an automatic verdict. It can slow cold activation
  and increase download and memory use; it can also be justified for sustained
  local interaction. Weft's proposed default therefore remains server HTML and
  stateless actions, with browser C# activated only for declared capabilities.
- Weft is not inherently more secure than Node.js. Its smaller default browser
  dependency surface and ASP.NET Core integration can reduce some exposure,
  while template encoding, authentication, authorization, antiforgery,
  dependency integrity, JavaScript adapters, deployment, and application logic
  still require explicit controls and conformance tests.
- Avoiding a project-local `node_modules` tree is a legitimate pure-mode goal,
  but it does not eliminate dependency risk or disk use. NuGet uses a shared
  global package cache; deterministic locks, hashes, provenance, licenses,
  lifecycle-script policy, published-output inspection, and cache accounting
  remain necessary. A future `wget`-style direct asset source must be immutable
  and integrity-checked, not an untracked download shortcut.

The proposed alternative-readiness baseline is recorded as fifteen `Must`, eight
`Should`, five `Could`, and seven `Won't/Non-goal` requirements. The Must set
covers vertical feature contracts, safe HTML composition, typed routes,
authoritative forms/actions, zero-runtime baselines, stateless enhancement,
security, accessibility, assets, CLI workflow, JavaScript adapters, dependency
integrity, testing, operations, and compatibility policy. These ranks remain
research proposals until product-owner approval; they do not authorize
implementation or public capability claims.

### Development error overlay

Next.js demonstrates an important developer-experience quality: in development,
an error can be shown in the browser with its message, relevant source code
frame, and useful stack frames. .NET already supplies exceptions, stack traces,
symbols, source file/line information, and the ASP.NET Core Developer Exception
Page. Weft should adapt these foundations rather than invent another exception
model.

The proposed Weft overlay maps generated routes, actions, templates, and
browser capabilities back to user-authored C# or HTML source. In Development it
shows the exception, relevant code frame, mapped file/line, collapsed stack,
feature context, and trace identifier. In Production the overlay, source code,
physical paths, editor links, and serialized stack are absent; users receive a
friendly full-page, partial-action, or API error with a correlation identifier,
while controlled server logs retain the detail. A request must never be able to
turn Development diagnostics on in Production.

### Desktop and mobile shell integration

Electron and Electrobun are desktop shells for Windows, macOS, and Linux; they
are not current iOS/Android deployment options. Tauri 2 supports those desktop
systems plus Android and iOS. Capacitor is a mobile-oriented native runtime for
web applications. Tauri's documented frontend model is a static web host and
does not natively host SSR, which means Current Weft cannot simply be bundled
unchanged as a fully local Tauri mobile application.

Bun 1.3.14 now provides a first-party Android runtime build, which makes a
future Electrobun Android port more plausible. It does not make Electrobun an
Android application framework today: its official targets remain desktop and
its open mobile work still needs the Android WebView host, lifecycle/RPC
integration, Gradle packaging, signing, permissions, plugins, debugging, and
release support.

Weft's portability contract must not become a multi-wrapper recommendation. A
normal product chooses one shell family that covers its required platforms and
maintains one bridge, lifecycle model, plugin set, updater, and conformance
suite. For Windows/Linux desktop plus Android, Tauri is the current reference.
Electron and Electrobun are alternative providers for desktop-only products or
future whole-product migrations, not additional wrappers used beside Tauri to
save CI compilation time. iOS retains its separate Apple build, provisioning,
signing, and store pipeline, while it can still consume the same Weft shell
contract.

Weft should define three explicit shell modes:

1. **Hosted shell:** a WebView loads a deployed HTTPS Weft server. This is
   closest to Current Weft but normally requires connectivity and a highly
   restricted origin-scoped native bridge.
2. **Bundled static/client shell:** immutable Weft HTML/CSS/assets and optional
   browser C# are packaged in the native app while APIs remain remote. This
   fits Tauri/Capacitor but requires a future static-shell publish profile.
3. **Desktop sidecar:** Electron, Electrobun, or Tauri launches a loopback-only
   packaged ASP.NET Core process and coordinates readiness, security, updates,
   logs, and shutdown. This must not be presented as the iOS/Android design.

Smooth integration requires profile-aware publishing; relative hashed assets;
typed routes and deep links; system-browser authentication callbacks; a
versioned least-privilege native bridge; back/safe-area/keyboard/touch and
suspend/resume/offline contracts; coordinated `dotnet watch` plus shell
development; and desktop/mobile conformance tests. Application authors may
remain in C#, but native WebView APIs normally cross a small JavaScript guest
boundary owned by the generated shell adapter. Therefore the accurate promise
is C# application code with bounded generated interoperability, not literal
absence of JavaScript inside every native container.

The complete evidence and execution contracts are in:

- [Framework comparison](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/framework-comparison-report.md)
- [Praised qualities and pains](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/praised-qualities-and-pains.md)
- [Reference application specification](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/reference-application-spec.md)
- [Benchmark methodology](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/benchmark-methodology.md)
- [Weft alternative requirements](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-alternative-requirements.md)
- [Gap and decision backlog](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-gap-and-decision-backlog.md)
- [Developer errors and native shell integration](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/developer-errors-and-native-shell-integration.md)
- [Installation and bootstrap strategy](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/installation-and-bootstrap-strategy.md)
- [Independent research recheck](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/research-recheck-2026-07-20.md)

## Technical risks and open questions

The server foundation demonstrates that generated, explicitly trusted feature
registration is practical. The largest risks remain ahead:

- whether capability-level browser C# can be loaded through supported runtime
  APIs with acceptable cold-start cost;
- how capability dependencies are shared without creating a hidden global
  bundle;
- how authentication, antiforgery, validation, redirects, cancellation,
  history, focus, and accessibility work for enhanced server actions;
- how feature templates and assets are discovered transitively from NuGet
  packages;
- how browser-safe C# references and APIs are enforced at compile time;
- how versioning and compatibility work across feature, server, generator, and
  asset packages;
- whether real applications demonstrate enough benefit over ASP.NET Core,
  Blazor, HTMX-style enhancement, and established Node.js frameworks.

These questions require prototypes, reproducible examples, and benchmarks. They
must not be resolved only through positioning language.

## Current validation status

At the time this document was created, the repository provides:

- a .NET 10 solution;
- generated trusted feature manifests;
- compile-time diagnostics for supported feature declarations;
- runtime validation of declared versus mapped feature routes;
- deterministic explicit feature registration;
- one runnable HTML-only task example;
- antiforgery-protected form submission using post/redirect/get;
- tests confirming the initial page contains no script, `.wasm`, or Blazor
  `_framework` resource.

It does not yet provide browser C#, enhanced server actions, a reusable template
system, an asset manifest, Node integration, public packages, comparative
benchmarks, or production support.

## Related project documents

- [Public project overview](../../README.md)
- [Architecture](../../docs/architecture.md)
- [Roadmap](../../docs/roadmap.md)
- [Package ecosystem](../../docs/package-ecosystem.md)
- [Example contract](../../docs/examples.md)
- [ASP.NET Core security documentation](https://learn.microsoft.com/aspnet/core/security/?view=aspnetcore-10.0)
- [Blazor render modes](https://learn.microsoft.com/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0)
- [Blazor navigation and enhanced form handling](https://learn.microsoft.com/aspnet/core/blazor/fundamentals/navigation?view=aspnetcore-10.0)
- [Blazor WebAssembly lazy assembly loading](https://learn.microsoft.com/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-10.0)
- [.NET WebAssembly JavaScript interop](https://learn.microsoft.com/aspnet/core/client-side/dotnet-interop/?view=aspnetcore-10.0)
- [Uno Platform](https://platform.uno/docs/articles/intro.html)
- [OpenSilver](https://doc.opensilver.net/documentation/general/overview.html)
- [DotVVM](https://www.dotvvm.com/docs/tutorials/introduction/latest)
- [Wisej.NET](https://docs.wisej.com/docs)
- [WebSharper](https://developers.websharper.com/)
- [npm folder layout](https://docs.npmjs.com/files/folders/)
- [pnpm content-addressable store](https://pnpm.io/motivation)
- [NuGet global packages and caches](https://learn.microsoft.com/nuget/consume-packages/managing-the-global-packages-and-cache-folders)
- [NuGet lock files](https://learn.microsoft.com/nuget/consume-packages/package-references-in-project-files#locking-dependencies)
- [Node.js security best practices](https://nodejs.org/en/learn/getting-started/security-best-practices)
