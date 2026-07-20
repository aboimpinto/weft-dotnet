# FEAT-001 Reference Application Specification

**Workload:** Project Atlas
**Specification revision:** RA-1
**Status:** Frozen research contract; not implemented by FEAT-001

## Purpose and Equivalence Rule

Project Atlas is a modular project/task application used to compare future
Blazor, Next.js, TanStack Start, Angular and Weft implementations. Equivalent
does not mean identical internal architecture. It means identical seeded data,
roles, authority boundaries, routes, user outcomes, failure fixtures and
observable acceptance criteria.

An implementation may use its platform’s preferred server/component/cache
model, but it may not omit a journey, preload data unavailable to competitors,
weaken validation/security/accessibility, or replace a server-authoritative
operation with a client-only simulation.

## Module and Domain Vocabulary

| Module | Entities and responsibility |
| --- | --- |
| `Identity` | Users, roles, sign-in/out, session and authorization policies. |
| `Projects` | Public project catalog, project detail, metadata and ownership. |
| `Tasks` | Task search, filtering, status/priority, assignments and mutations. |
| `Admin` | Protected project/task create/edit operations and audit trail. |
| `Insights` | Read-only activity summary and bounded third-party chart adapter. |

Core records:

- `Project(ProjectId, Slug, Name, Summary, Status, OwnerId, UpdatedAt,
  RowVersion)`
- `Task(TaskId, ProjectId, Title, Description, Status, Priority, AssigneeId,
  DueDate, Position, UpdatedAt, RowVersion)`
- `User(UserId, Email, DisplayName, Role)`
- `AuditEvent(AuditId, UserId, EntityType, EntityId, Action, OccurredAt)`

Controlled values:

- Project status: `Planning`, `Active`, `Paused`, `Completed`.
- Task status: `Backlog`, `Ready`, `InProgress`, `Review`, `Done`.
- Priority: `Low`, `Normal`, `High`, `Critical`.
- Roles: `Anonymous`, `Viewer`, `Editor`, `Administrator`.

The database is authoritative. Browser caches, optimistic views, local board
positions and chart state are disposable projections.

## Frozen Seed Data

The canonical fixture is generated from seed `atlas-ra1-20260715`:

| Record | Count | Required distribution |
| --- | ---: | --- |
| Projects | 120 | 12 Planning, 72 Active, 12 Paused, 24 Completed |
| Tasks | 6,000 | exactly 50 per project; all five statuses and four priorities represented |
| Users | 32 | 24 Viewers, 6 Editors, 2 Administrators |
| Audit events | 24,000 | deterministic timestamps within the prior 180 days |

Stable test identities:

| Identity | Role | Password fixture | Purpose |
| --- | --- | --- | --- |
| `viewer@atlas.test` | Viewer | supplied through benchmark secret store | Read protected pages; mutation denied. |
| `editor@atlas.test` | Editor | supplied through benchmark secret store | Create/edit tasks and projects. |
| `admin@atlas.test` | Administrator | supplied through benchmark secret store | All operations and audit page. |
| `disabled@atlas.test` | Editor, disabled | supplied through benchmark secret store | Authentication rejection fixture. |

No credential appears in a client bundle, repository, page source or benchmark
report. The benchmark harness injects secrets at runtime.

## Canonical Route and Feature Map

| ID | Method and route | Access | Outcome |
| --- | --- | --- | --- |
| `RT-01` | `GET /` | Public | Product introduction, project summary counts and link to catalog. |
| `RT-02` | `GET /projects` | Public | Paginated/searchable/filterable/sortable project list. |
| `RT-03` | `GET /projects/{slug}` | Public | Project metadata plus first task page; 404 for unknown slug. |
| `RT-04` | `GET /projects/{slug}/tasks` | Public | Task list/board entry with URL-owned query state. |
| `RT-05` | `GET /projects/{slug}/tasks/region` | Public | Server-owned partial region; ordinary full-page `RT-04` is fallback. |
| `RT-06` | `GET /sign-in?returnUrl=` | Anonymous | Sign-in form; validated same-origin/local return URL only. |
| `RT-07` | `POST /sign-in` | Anonymous | Authenticates, rotates session, redirects safely. |
| `RT-08` | `POST /sign-out` | Authenticated | Antiforgery-protected sign-out. |
| `RT-09` | `GET /admin/projects` | Editor/Admin | Protected project management list. |
| `RT-10` | `GET /admin/projects/new` | Editor/Admin | Create form. |
| `RT-11` | `POST /admin/projects` | Editor/Admin | Server-authoritative create and redirect. |
| `RT-12` | `GET /admin/projects/{id}/edit` | Editor/Admin | Edit form with row version. |
| `RT-13` | `POST /admin/projects/{id}` | Editor/Admin | Validated update with concurrency detection. |
| `RT-14` | `GET /admin/projects/{id}/board` | Editor/Admin | Enhanced/local board activation surface. |
| `RT-15` | `POST /admin/projects/{id}/tasks/reorder` | Editor/Admin | Atomic ordered task-position mutation. |
| `RT-16` | `GET /admin/audit` | Administrator | Paginated audit log; Editor receives 403. |
| `RT-17` | `GET /health/live` | Operations | Liveness only; no dependency details. |
| `RT-18` | `GET /health/ready` | Operations | Readiness with protected/internal detail. |

URL-owned list state uses these canonical query fields:

`q`, `status`, `priority`, `owner`, `sort`, `direction`, and `page`.
Unknown fields are ignored, invalid controlled values produce a visible
validation message and canonicalized URL, `page` is 1-based, and page size is
fixed at 25. Sort defaults to `updatedAt desc`.

## Layout, Metadata and Navigation Contract

- Root HTML includes language, UTF-8, viewport, canonical URL, title and
  description.
- Public and Admin areas have different nested navigation but share product
  identity and account controls.
- Page title format is `{Page} · Project Atlas`; project details use
  `{Project name} · Project Atlas`.
- Normal links remain real anchors with meaningful `href`; back/forward and
  reload reproduce URL-owned state.
- Unknown public resources return real HTTP 404 with a useful HTML page.
- Unauthorized anonymous requests redirect to sign-in with validated return
  URL; authenticated-but-forbidden requests return 403 without disclosing data.
- Loading UI never replaces the page heading or removes navigation context.
- Uncaught route errors show a correlation ID and retry/navigation choices;
  production output never includes stack traces or secrets.

## Canonical User Journeys

### `J-01` Public discovery

1. Open `/projects` with an empty cache.
2. Search `migration`, filter `Active`, sort by name ascending and visit page 2.
3. Copy the URL, open it in a new browser context and observe identical state.
4. Open a project detail and return with browser Back; prior list state and
   focus/scroll restoration follow the browser criteria below.

### `J-02` Authentication and authorization

1. Request `/admin/projects` anonymously and sign in as Viewer.
2. Return to the requested URL, then receive the defined forbidden outcome.
3. Sign out through POST.
4. Sign in as Editor and reach the management list.
5. Directly request `/admin/audit`; receive 403 without audit data.

### `J-03` Create with validation

1. Editor opens the create form.
2. Submit empty/invalid values and receive field errors plus an error summary;
   entered non-secret values remain.
3. Correct values and submit once.
4. Server creates exactly one project and redirects to its edit/detail success
   destination with a visible confirmation.

### `J-04` Edit, cancel and concurrency

1. Two contexts open the same project edit form with identical `RowVersion`.
2. Context A saves successfully.
3. Context B saves stale data and receives a non-destructive conflict page/form
   showing current versus submitted values and reload/merge choices.
4. Cancel from a clean form navigates back without mutation; cancel from a
   dirty form requires confirmation without trapping keyboard users.

### `J-05` Partial task update

1. On a project task list, change status and priority filters.
2. With enhancement active, only the task region is fetched/replaced and the
   canonical URL/history is updated.
3. Heading, result count and live status are correct; focus remains at the
   initiating control unless validation/error requires an announced target.
4. With enhancement disabled or failed, the same form performs ordinary GET
   navigation and produces the same task set and URL.

### `J-06` Sustained local board interaction

1. Editor explicitly activates “Interactive board” on `RT-14`.
2. The implementation loads its local capability only then.
3. Reorder 20 tasks across columns, including keyboard operation, with local
   immediate feedback and a 10-step undo stack.
4. Save once to `RT-15`; server validates authorization, task set, row versions
   and positions atomically.
5. On conflict, retain the local proposal, show server changes and offer reload
   or reapply. Offline editing may remain local but cannot report server save.

This interaction justifies browser execution because every pointer/keyboard
move should not require a network round trip. It is the only workload that may
activate a managed browser runtime in the Weft implementation.

### `J-07` Third-party chart adapter

1. Open project Insights and activate the activity chart.
2. A third-party JavaScript chart library renders inside its owned element.
3. The page provides an equivalent semantic data table and summary before and
   after chart activation.
4. Navigation/removal calls adapter disposal; repeated activation does not add
   duplicate listeners or retain obsolete chart data.

## Forms and Mutation Contract

Project create/edit fields and rules:

| Field | Rules |
| --- | --- |
| Name | Required; trimmed; 3–100 Unicode characters. |
| Slug | Required; lowercase ASCII letters/digits/hyphens; 3–80; unique. |
| Summary | Required; 20–1,000 characters; rendered as text, not trusted HTML. |
| Status | Required controlled value. |
| Owner | Required existing active user. |
| RowVersion | Required on edit; opaque and server-generated. |

All state-changing requests require server authentication/authorization,
antiforgery where cookie authentication makes it relevant, size/content limits,
server validation and audit. Client validation is optional feedback and never
authority. Duplicate submissions with the same idempotency key create at most
one record. A disabled submit control is UX, not the duplicate-submit defense.

Errors use stable codes (`VALIDATION_FAILED`, `FORBIDDEN`, `CONFLICT`,
`RATE_LIMITED`, `DEPENDENCY_UNAVAILABLE`, `UNEXPECTED`) and a correlation ID.
No serialized exception or database detail crosses the public boundary.

## Data, Cache and Consistency Contract

- Public list/detail may be cached, but cache policy and key must include all
  authority and query inputs.
- Successful project/task mutation invalidates every affected list, detail,
  board and insight projection before success is reported.
- Authenticated/role-specific HTML is private and must not enter a shared cache.
- Cancellation stops obsolete browser work and propagates to server/database
  where supported; an obsolete response cannot overwrite newer visible state.
- Optimistic state is allowed only for board order and must remain visually
  distinguishable until acknowledged.
- A retry is never automatic for a non-idempotent mutation unless the
  idempotency key makes it safe.

## Failure Fixtures

| ID | Fixture | Required observable outcome |
| --- | --- | --- |
| `FX-01` | 1,500 ms project-list delay | Existing layout/heading remain; loading status is announced once. |
| `FX-02` | 8,000 ms task delay | Cancel/retry controls work; stale response cannot replace newer query. |
| `FX-03` | Database unavailable | 503-style recoverable page/region with correlation ID; no stack/secret. |
| `FX-04` | First mutation returns transient 503 | User controls retry; duplicate record is not created. |
| `FX-05` | Stale `RowVersion` | Conflict outcome from `J-04`. |
| `FX-06` | Antiforgery missing/invalid | Mutation rejected; no state/audit success event. |
| `FX-07` | Expired session during edit | Reauthentication path preserves safe draft state, not credentials/token. |
| `FX-08` | Enhanced-region response invalid | Region is not partially corrupted; ordinary navigation fallback offered. |
| `FX-09` | Local capability asset unavailable | HTML task list remains usable; activation failure is announced. |
| `FX-10` | Chart script unavailable | Semantic table remains; chart failure does not affect navigation/content. |
| `FX-11` | Browser offline after board activation | Local reorder/undo works; save clearly remains pending/unsaved. |
| `FX-12` | Rate limit exceeded | 429 with retry guidance; no authorization or internal-limit leakage. |

## Server-Owned Partial Region

The task region has one canonical owner at a time. Before enhancement, the
server owns the full document. During enhanced filtering, the server response
owns `#task-results`; no local component may mutate children inside that region.
The response includes canonical URL, title/count metadata and a region version.
The client applies it atomically or not at all. An ordinary GET to `RT-04` is
the semantic fallback.

## Local C# Capability Boundary

The interactive board may own only `#interactive-board` after explicit user
activation. Its input is a versioned DTO containing the visible project and
tasks. Its output is a reorder command; it cannot access secrets, database
connections or server authorization state. Activation, transferred bytes,
startup duration and retained memory are measurable. Disposal removes event
handlers, timers, object references and capability-owned DOM.

## JavaScript Adapter Boundary

The chart adapter exposes only:

```text
mount(elementId, ActivitySeries, ChartOptions) -> ChartHandle
update(ChartHandle, ActivitySeries) -> void
dispose(ChartHandle) -> void
```

The adapter owns only descendants of `#activity-chart-canvas`. Weft/the host
owns the surrounding heading, summary, table, activation and error UI. The
adapter receives no bearer token, cookie value, user secret or raw HTML. Data
is validated/serialized by the server boundary. Disposal is mandatory on
replacement/navigation.

## Browser, Visual and Accessibility Criteria

### Semantic and keyboard contract

- One `main`, one page `h1`, ordered headings, labelled landmarks and a skip
  link are present.
- Real tables use captions/headers; sortable headers expose state in text and
  `aria-sort`; board columns use an accessible list/reorder pattern.
- Every action is keyboard reachable with visible focus. No keyboard trap is
  permitted in dialogs, board or chart controls.
- Validation summary links focus to fields; errors are associated by
  `aria-describedby`; color is never the only signal.
- Status/live regions announce loading completion, result count, save success,
  conflict and activation failure without repeated chatter.

### Focus, history and enhancement

- Full navigation focuses the page heading unless browser Back restores the
  prior document position/focus.
- Partial filtering keeps focus on the initiating control and announces the
  updated count.
- Create success moves to the destination heading and announces confirmation.
- Validation failure focuses the summary; conflict focuses the conflict
  heading; unexpected errors focus the error heading.
- Every filter change produces a canonical history entry only when the user
  commits it; transient typing may replace the current entry after debounce.

### Responsive and visual states

The reference visual language is framework-neutral. At 320 CSS px there is no
horizontal page scroll; wide data tables may use an explicitly labelled
scrolling container. At 768 and 1280 px layouts use available space without
changing information or authorization. Required inspectable states are:

`initial`, `loading`, `empty`, `filtered-empty`, `validation-error`,
`save-success`, `conflict`, `forbidden`, `not-found`, `dependency-error`,
`offline-local-unsaved`, `enhancement-failed`, and `adapter-failed`.

## Asset and Production Contract

- Each module owns its CSS/images/fonts and declares them in an inspectable
  manifest.
- Published immutable assets use content hashes and long-lived cache headers;
  HTML/manifests use revalidation appropriate to deployment.
- No implementation may fetch production code from an unpinned CDN at runtime.
- Font fallback prevents invisible text; failed non-essential images preserve
  meaningful alternative text/layout.
- The published output records direct/transitive dependencies, integrity,
  licenses and build/runtime assets.

## Observability Contract

Every request records trace/correlation ID, route ID, outcome, duration and
safe feature identity. Mutations additionally record user identity reference,
entity/action, validation/conflict outcome and audit ID without recording form
secrets. Metrics include request/error/rate-limit counts, latency histograms,
cache hit/miss, active server connections/state where applicable, partial
update failures, local-capability activation failures and adapter failures.

## Future Verification Catalog

| Evidence ID | Category | Public boundary |
| --- | --- | --- |
| `ATLAS-UNIT` | Domain, validation, URL codecs, cache keys, reducers | Pure public contracts. |
| `ATLAS-INT` | Routes, auth, antiforgery, persistence, concurrency, idempotency | `RT-01`–`RT-18`. |
| `ATLAS-BROWSER` | Journeys, history, focus, failure and enhancement fallback | `J-01`–`J-07`, `FX-01`–`FX-12`. |
| `ATLAS-A11Y` | Automated rules plus keyboard/screen-reader review | All routes and inspectable states. |
| `ATLAS-SEC` | Authz bypass, CSRF, XSS, redirect, upload/size, secrets, headers, rate limit | All public/mutation boundaries. |
| `ATLAS-PERF` | Phase 6 methodology after functional gates pass | Frozen RA-1 workload only. |

No Gherkin, Playwright or implementation source is created in this research
FEAT. These IDs define future evidence obligations.

## Reference Workload Review

- Seed, identities, routes, outcomes, failures and authority boundaries:
  **PASS**.
- Public list/detail/search/filter/sort/pagination and protected CRUD:
  **PASS**.
- Server partial update with ordinary HTTP fallback: **PASS**.
- Sustained local interaction with explicit activation/disposal: **PASS**.
- Bounded JavaScript adapter with semantic fallback: **PASS**.
- Security, accessibility, assets, observability and future test boundaries:
  **PASS**.
- Equal expectations across HTML-first, hydrated and client-rendered
  implementations: **PASS**; no platform-specific acceptance waiver exists.
