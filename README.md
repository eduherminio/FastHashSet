# FastHashSet

FastHashSet is a replacement for the generic HashSet&lt;T>.  It is usually faster, has more predictable memory allocations, and uses C# 7.x ref returns and readonly ref params (in).

-----

[![GitHub Actions][githubactionslogo]][githubactionslink]
[![Nuget][nugetlogo]][nugetlink]

This repository is a fork of [Motvin/FastHashSet](https://github.com/Motvin/FastHashSet).

The original author explained the process of creating FastHashSet in [this codeproject article](https://www.codeproject.com/Articles/1280633/Creating-a-Faster-HashSet-for-NET).

I haven't made any significant source code changes *so far*, being making FashHashSet available via NuGet the main purpose of this fork *up to now*.

[githubactionslogo]: https://github.com/eduherminio/FastHashSet/workflows/CI/badge.svg
[githubactionslink]: https://github.com/eduherminio/FastHashSet/actions?query=workflow%3ACI
[nugetlogo]: https://img.shields.io/nuget/v/FastHashSet.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/FastHashSet
