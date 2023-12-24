# Raiqub Jab Modules - Microsoft.Extensions.Options

_Provides a Jab module for registering types from Microsoft.Extensions.Options library_

[![Build status](https://github.com/skarllot/jab-modules/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/skarllot/jab-modules/actions)
[![NuGet](https://buildstats.info/nuget/Raiqub.JabModules.MicrosoftExtensionsOptions)](https://www.nuget.org/packages/Raiqub.JabModules.MicrosoftExtensionsOptions/)
[![Code coverage](https://codecov.io/gh/skarllot/jab-modules/branch/main/graph/badge.svg)](https://codecov.io/gh/skarllot/jab-modules)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fskarllot%2Fjab-modules%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/skarllot/jab-modules/main)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://raw.githubusercontent.com/skarllot/Expressions/master/LICENSE)

## Release Notes
See [GitHub Releases](https://github.com/skarllot/jab-modules/releases) for release notes.

## Quick Example
```csharp
[ServiceProvider]
[Import(typeof(IOptionsModule))]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureMyConfig))]
internal partial class MyServiceProvider
{
    private static IConfigureOptions<MyConfigOptions> ConfigureMyConfig() =>
        IOptionsModule.Configure<MyConfigOptions>(options => options.Key1 = "Jane");
}

public class MyConfigOptions
{
    public string Key1 { get; set; }
    public int Key2 { get; set; }
    public int Key3 { get; set; }
}
```

## Documentation and Samples
Documentation, and samples, for using Raiqub Jab Modules can be found in the repository's [README](https://github.com/skarllot/jab-modules#readme).
