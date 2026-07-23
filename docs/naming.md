# Naming status

## Working identity

- Product name: **Weft**
- Suggested repository slug: `weft-dotnet`
- Suggested short description: **HTML-first .NET feature modules with optional lazy browser C#.**

“Weft” expresses the desired architecture: server behavior, HTML, styles, and
optional local capabilities are woven into one feature.

## Package identity decision

An availability check on 2026-07-23 found that `Weft.Server` is already
published by the unrelated `StrangeDaysTech/weft` .NET CRDT project. Weft must
not publish under that package ID.

Experimental packages use the owner-qualified prefix:

- `AboimPinto.Weft.Abstractions`;
- `AboimPinto.Weft.Server`;
- `AboimPinto.Weft.Generator`;
- `AboimPinto.Weft.Templates` when the template package is implemented.

The qualified IDs avoid the known NuGet collision, but they are not a legal or
commercial clearance of the Weft product name.

## Before commercial use

Before using the name commercially, check:

1. GitHub repository and organisation naming;
2. remaining NuGet and close-name collisions;
3. relevant domains and social identifiers;
4. Swiss, EU, UK, US, and target-market trademark databases;
5. companies/products in adjacent developer-tool and web-platform categories.

If a different final brand is chosen, rename the directory and repository slug
before describing the project commercially. The architecture and public
positioning can remain the same.
