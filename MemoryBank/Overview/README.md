# Weft MemoryBank Overview

## Purpose

This folder contains durable project understanding distilled from detailed
feature investigations. It is the starting point for product and engineering
work; the FEAT folder remains the evidence and execution record.

Statements use these boundaries:

- **Current** — implemented in the repository and supported by source/tests.
- **Research conclusion** — supported by the dated FEAT-001 evidence snapshot.
- **Proposal** — a requirement or decision awaiting product-owner approval.
- **Hypothesis** — a claim that still needs implementation or reproduced data.

## Current project state

Weft is an experimental HTML-first platform for ASP.NET Core. Current Weft
implements generated feature manifests, explicit host registration,
deterministic endpoint mapping, route-manifest validation, and one server-only
HTML/form example. It does not yet implement a general renderer, enhanced
server actions, browser C#, a JavaScript bridge, an asset pipeline, a CLI, or a
production support contract.

FEAT-001 completed the planned investigation package and is ready for owner
review, but it is not product-complete. Requirement approval, public-document
changes, implementation FEAT creation, equivalent reference applications, and
comparative benchmarks remain unresolved.

## Overview documents

| Document | Durable topic |
| --- | --- |
| [Technical overview](technical-overview.md) | Current architecture, intended execution model, market thesis, and technical risks |
| [Competitive landscape](competitive-landscape-overview.md) | Blazor, Next.js, TanStack Start, Angular, and Weft comparison conclusions |
| [Product requirements and sequencing](product-requirements-and-sequencing-overview.md) | Proposed readiness baseline, non-goals, approval gates, and bounded implementation order |
| [Reference application and benchmarking](reference-application-and-benchmarking-overview.md) | Project Atlas workload, benchmark cohorts, admission gates, and known specification gaps |
| [Security, accessibility, and reliability](security-accessibility-and-reliability-overview.md) | Authority boundaries, secure defaults, diagnostics, accessibility, testing, and operations |
| [Developer experience, installation, and dependencies](developer-experience-installation-and-dependencies-overview.md) | CLI, bootstrap, local workflow, assets, package policy, supply chain, updates, and removal |
| [Browser interoperability and native shells](browser-interoperability-and-native-shells-overview.md) | Progressive enhancement, browser C#, JavaScript adapters, and hosted/static/sidecar shells |
| [FEAT-001 research recheck](feat-001-research-recheck-overview.md) | Independent double/triple-check findings, corrections, limitations, and closure conditions |

## Evidence source

The detailed evidence is in
[`FEAT-001-framework-comparison-and-weft-alternative-requirements`](../Features/03_IN_PROGRESS/FEAT-001-framework-comparison-and-weft-alternative-requirements/).
The principal artifacts are:

- `framework-comparison-report.md`;
- `praised-qualities-and-pains.md`;
- `reference-application-spec.md`;
- `benchmark-methodology.md`;
- `weft-alternative-requirements.md`;
- `weft-gap-and-decision-backlog.md`;
- `developer-errors-and-native-shell-integration.md`;
- `installation-and-bootstrap-strategy.md`; and
- `research-recheck-2026-07-20.md`.

The competitor evidence is a **2026-07-15 snapshot**. Patch-version drift was
observed during the 2026-07-20 recheck and must be refreshed before external
publication or a later architecture decision that depends on exact current
versions.

## Decision boundary

The Overview records conclusions and proposals; it does not authorize runtime
implementation. Before starting implementation, the product owner must approve
or revise the proposed requirement ranks, public-document changes, and the
scope and sequence of each follow-up FEAT.
