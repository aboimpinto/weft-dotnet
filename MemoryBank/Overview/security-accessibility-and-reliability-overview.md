# Weft Security, Accessibility, and Reliability Overview

## Position

Security and accessibility are release admission requirements, not optional
differentiators. Weft is experimental and cannot currently be called
production-secure, production-accessible, or operationally mature.

Current design choices can reduce particular risks, but neither C# nor a small
browser surface proves a secure outcome. A maintained Node or Blazor
application can be safer than an immature Weft application.

## Current evidence

Current Weft provides:

- explicit host selection of generated feature manifests;
- no runtime assembly scan or reflection-based request dispatch;
- startup validation of declared versus mapped route metadata;
- server authority through ordinary ASP.NET Core endpoints;
- one example with antiforgery validation, bounded input, encoded text, and
  post/redirect/get; and
- HTML/CSS output without an application script or browser .NET runtime.

These are narrow facts. The example is not a general renderer, threat model,
authorization contract, header policy, upload policy, rate-limit policy, or
security certification.

The recheck also found current contract-hardening gaps:

- endpoint-name duplicate validation permits the same endpoint name when the
  route pattern is also the same, even though named endpoints should be
  unambiguous;
- descriptor and registry properties are described as immutable while exposing
  caller-supplied list instances that can be backed by mutable arrays;
- generated action mode values are emitted without validating that the enum
  value is supported; and
- the eight current tests provide only narrow generator, route mismatch, and
  starter behavior coverage.

These belong in the first foundation-hardening FEAT.

## Required security contract

Before public preview, Weft needs:

1. a threat model for feature registration, templates, forms/actions, assets,
   enhancement, browser C#, JavaScript adapters, installation, and shell
   bridges;
2. contextual encoding by default, with explicit reviewed raw-content types;
3. server-authoritative authentication, authorization, validation, concurrency,
   and business invariants;
4. antiforgery, cookie, header, redirect, upload, request-size, secret, transport,
   proxy, and rate-limit guidance/defaults;
5. deterministic dependencies, integrity, provenance, vulnerability response,
   and release revocation;
6. no secrets or trusted authorization decisions in browser C#/JavaScript;
7. typed, least-privilege, origin-scoped interop and native bridges;
8. safe error representations and non-public caching; and
9. public-boundary conformance tests for bypass, CSRF, XSS, redirect, injection,
   disclosure, duplicate submission, and failure paths.

Explicitly selecting a feature is trust, not sandboxing. Once registered, the
feature executes with the application process's authority.

## Development and production errors

Development diagnostics should adapt .NET exceptions, symbols, and ASP.NET
Core error handling into a Weft-aware overlay. It should map generated routes,
actions, templates, assets, and capability dispatch back to user-authored C# or
HTML and show a useful code frame, collapsed stack, feature context, and trace
ID.

Even in Development, secrets, cookies, authorization headers, connection
strings, and arbitrary request bodies are excluded by default. Remote access to
local diagnostics requires an explicit protected boundary.

In Staging and Production:

- no overlay, source endpoint, editor link, code frame, physical path, or
  serialized stack is published;
- full-page, partial, and API failures return typed friendly outcomes with a
  correlation ID;
- detailed exceptions remain in controlled logs/traces; and
- no request parameter, cookie, or header can enable Development diagnostics.

## Accessibility contract

Weft should own the semantics introduced by its framework mechanisms while
leaving application visual design to the product. Required behavior includes:

- semantic HTML, labelled landmarks, ordered headings, and real links/forms;
- keyboard reachability, visible focus, no traps, and accessible dialogs/reorder;
- linked validation summary and field errors;
- announced loading, result, save, conflict, and failure outcomes without
  repeated chatter;
- defined focus and history behavior for full and partial navigation;
- semantic fallback when enhancement, local capability, chart, or asset fails;
- responsive layouts without information/authorization changes; and
- automated checks plus keyboard and screen-reader review.

A headless framework contract must not imply that arbitrary application markup
is automatically accessible.

## Reliability and operations

The production contract should use ordinary .NET facilities with Weft semantic
identifiers:

- structured logs and traces for feature, route, action, asset, capability, and
  safe outcome;
- request/error/rate-limit/cache/partial/capability/adapter metrics;
- liveness and readiness with protected detail;
- cancellation and stale-response propagation;
- idempotent retries and explicit non-idempotent retry rules;
- deterministic publish manifests and configuration;
- reverse-proxy, TLS, container, self-host, graceful shutdown, and recovery
  tests; and
- compatibility and incident-response ownership.

## Verification state

On 2026-07-20, `DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet test Weft.sln
--no-restore` passed all 8 repository tests. The polling override was necessary
because the host had exhausted its inotify-instance limit. This verifies the
current narrow baseline only; it is not FEAT-001 competitor, security,
accessibility, or performance evidence.

## Detailed source

- [Developer diagnostics and native shells](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/developer-errors-and-native-shell-integration.md)
- [Project Atlas security/accessibility contract](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/reference-application-spec.md)
- [Requirements `WR-M07`, `WR-M08`, `WR-M13`, and `WR-M14`](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/weft-alternative-requirements.md)
