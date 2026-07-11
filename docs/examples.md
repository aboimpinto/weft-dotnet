# Example suite

The example suite should prove design claims, not merely demonstrate different
CSS themes. Each example must remain small enough to inspect, include a normal
HTML fallback, and report what loads initially and on its first enhanced
interaction.

## Planned examples

| Example | Primary purpose | Required proof |
| --- | --- | --- |
| `starter-html` | Baseline HTML-first workflow | A usable server page with no Node build, no browser .NET runtime, normal forms, and an accessible fallback |
| `tailwind-orders` | Optional build-time asset integration | Tailwind sees feature templates during content scanning; published output contains the required CSS only |
| `bootstrap-admin` | Conventional business UI | Bootstrap CSS works with server forms; no Bootstrap JS is sent unless a declared behavior requires it |
| `pico-portal` | Low-tooling CSS-first UI | A polished small portal works with static CSS and ordinary HTML semantics |
| `lazy-capability-lab` | Browser-C# performance experiment | Initial page avoids managed runtime; one intentional capability demonstrates cold/warm payload, busy state, cancellation, and fallback |

## Acceptance rules for every runnable example

1. A fresh clone documents exactly which tools are optional and which are
   required.
2. The example has a `README` with run, test, and publish instructions.
3. The first route says whether it starts a managed browser runtime.
4. The application works through its ordinary HTML path if the enhancement or
   C# capability fails to load.
5. The published output is inspected for asset size, request count, and
   content hashes.
6. An optional frontend dependency is pinned with its package-manager
   lockfile; no dependency relies on a developer-global installation.

## What the examples must not hide

- a large global JavaScript bundle;
- an unpinned CDN dependency;
- a browser runtime that starts before a declared capability needs it;
- application logic embedded in an opaque generic JavaScript helper;
- a fallback that is only visually present but cannot actually submit or
  navigate.
