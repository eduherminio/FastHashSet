# FastHashSet

FastHashSet is a replacement for the generic HashSet&lt;T>.  It is usually faster, has more predictable memory allocations, and uses C# 7.x ref returns and readonly ref params (in).

-----

[![GitHub Actions][githubactionslogo]][githubactionslink]
[![Nuget][nugetlogo]][nugetlink]

This repository is a fork of [Motvin/FastHashSet](https://github.com/Motvin/FastHashSet).

The original author explained the process of creating FastHashSet in [this codeproject article](https://www.codeproject.com/Articles/1280633/Creating-a-Faster-HashSet-for-NET).

I haven't made any significant source code changes, being making FashHashSet available via NuGet the main purpose of this fork.

## Update

⚠️ Remember that this piece of software is served 'as is', and the author doesn't guarantee it to be faster than `System.Collections.Generic.HashSet` or to work in all scenarios.

I've detected some [issues](https://github.com/eduherminio/FastHashSet/issues) while trying to use FastHashSet from a .NET 5 project, so don't consider it production-ready myself.

[githubactionslogo]: https://github.com/eduherminio/FastHashSet/workflows/CI/badge.svg
[githubactionslink]: https://github.com/eduherminio/FastHashSet/actions?query=workflow%3ACI
[nugetlogo]: https://img.shields.io/nuget/v/FastHashSet.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/FastHashSet
