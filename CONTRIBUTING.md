# Contributing to Weft

Weft is currently an experimental architecture repository. Design discussion is
welcome, but code contributions are deferred until the repository has a public
license and contribution terms.

When implementation starts, before proposing a new feature first describe where
it executes and why:

1. Can ordinary HTML and a server route solve the interaction?
2. If the page needs in-place behavior, can the generic enhanced-server-action
   mode solve it?
3. If browser C# is proposed, does local execution repay the runtime and
   capability payload cost?

## Contribution principles

- Keep the server authoritative for authorization, secrets, database access,
  and business invariants.
- Keep normal forms, links, and accessible HTML meaningful without client code.
- Prefer capability-sized lazy chunks over per-component WebAssembly files.
- Do not rely on unsupported runtime internals as a product API.
- Treat payload size, request count, cold-start latency, retained memory, and
  cancellation behavior as testable design concerns.
- Keep Node/npm integrations optional and isolated behind a documented asset
  pipeline.

## When implementation starts

Every new framework mechanism should include:

- a small end-to-end example;
- fallback behavior;
- a browser/server boundary test where relevant;
- an asset/payload report or budget;
- documentation that says whether the API is experimental or stable.

Do not add a “working” example that silently depends on an undeclared global
JavaScript bundle, an unpinned package, or a local-only toolchain.
