# Raiqub Jab Modules
_Provides modules for registration of types from popular libraries using Jab_

[![Build status](https://github.com/skarllot/jab-modules/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/skarllot/jab-modules/actions)
[![OpenSSF Scorecard](https://api.securityscorecards.dev/projects/github.com/skarllot/jab-modules/badge)](https://securityscorecards.dev/viewer/?uri=github.com/skarllot/jab-modules)
[![Code coverage](https://codecov.io/gh/skarllot/jab-modules/branch/main/graph/badge.svg)](https://codecov.io/gh/skarllot/jab-modules)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fskarllot%2Fjab-modules%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/skarllot/jab-modules/main)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://raw.githubusercontent.com/skarllot/Expressions/master/LICENSE)

[🏃 Quickstart](#quickstart) &nbsp; | &nbsp; [📗 Guide](#guide) &nbsp; | &nbsp; [🔄 Migration](#migration-guide)

<hr />

## Features
* Provides [Jab] modules for registering popular .NET libraries
* Modules provides registration methods similar to the ones from original library

## NuGet Packages
* [![NuGet](https://buildstats.info/nuget/Raiqub.JabModules.MicrosoftExtensionsOptions)](https://www.nuget.org/packages/Raiqub.JabModules.MicrosoftExtensionsOptions/) **Raiqub.JabModules.MicrosoftExtensionsOptions**: provides a Jab module for registering types from Microsoft.Extensions.Options library.

## Prerequisites
Before you begin, you'll need the following:

* .NET Core 6.0 or greater installed on your machine
* An IDE such as Visual Studio, Visual Studio Code, or JetBrains Rider

## Quickstart
On a project defining a service provider using [Jab], add a NuGet package from `Raiqub.JabModules`:

```xml
<ItemGroup>
    <PackageReference Include="Jab" Version="0.10.1" />
    <PackageReference Include="Raiqub.JabModules.MicrosoftExtensionsOptions" Version="1.0.0" />
</ItemGroup>
```

Then add the provided module to the container:

```csharp
[ServiceProvider]
[Import(typeof(IOptionsModule))]
internal partial class MyServiceProvider
```

## Guide

### Microsoft.Extensions.Options
The NuGet package `Raiqub.JabModules.MicrosoftExtensionsOptions` provides a Jab module for registering types from [Microsoft.Extensions.Options](https://www.nuget.org/packages/Microsoft.Extensions.Options) library.

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

## Contributing

If something is not working for you or if you think that the source file
should change, feel free to create an issue or Pull Request.
I will be happy to discuss and potentially integrate your ideas!

## License

This library is licensed under the [MIT License](./LICENSE).

[Jab]:https://github.com/pakrym/jab
