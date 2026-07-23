# Releasing NuGet packages

Weft publishes experimental packages through
`.github/workflows/publish-nuget.yml` using NuGet.org Trusted Publishing. No
long-lived NuGet API key is stored in GitHub.

## Package IDs

- `WeftDotNet.Abstractions`
- `WeftDotNet.Server`
- `WeftDotNet.Generator`

The owner-qualified prefix avoids the unrelated `Weft.Server` package already
published on NuGet.org. See [naming.md](naming.md).

## Release safeguards

- A manual workflow run builds, tests, packs, validates, and uploads temporary
  artifacts, but never publishes.
- Only a `Weft-v<SemVer>` tag can publish, matching the workspace's project-qualified release-tag convention.
- The tagged commit must be contained in `origin/master`.
- The `release` GitHub environment must match the NuGet.org trusted-publishing
  policy.
- GitHub obtains a short-lived NuGet credential through OIDC.
- Package IDs and versions are inspected before publication.
- A fresh package-only consumer is restored and built without source project
  references.
- GitHub Actions dependencies are pinned to commit SHAs.
- Published packages and symbol packages are attached to a GitHub Release with
  `SHA256SUMS`.

## Rehearse a release

Run **Publish NuGet packages** manually in GitHub Actions and provide a version
such as `0.1.0-alpha.1`. The publish job is deliberately skipped. Download and
inspect the resulting `nuget-<version>` artifact.

## Publish a release

From an updated, clean `master` checkout:

```bash
git tag -a Weft-v0.1.0-alpha.1 -m "Weft 0.1.0-alpha.1"
git push origin Weft-v0.1.0-alpha.1
```

The tag starts the pipeline. It runs the complete solution tests, creates the
three aligned package versions, proves package-only consumption, publishes to
NuGet.org, and creates the matching GitHub Release.

NuGet package versions are immutable. If a release fails after one or more
packages have been accepted by NuGet.org, fix the release process and use a new
version rather than trying to replace package bytes.

## Template package

`WeftDotNet.Templates` will join the same release set after the template
package and generated-project matrix are implemented. The CD workflow must not
claim or publish an empty placeholder package.
