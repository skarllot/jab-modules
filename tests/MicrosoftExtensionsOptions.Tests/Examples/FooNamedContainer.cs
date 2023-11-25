using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Scoped<FooServiceNamed>]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFoo))]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureIgnored))]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFooNamed))]
[Transient<IPostConfigureOptions<FooOptions>>(Factory = nameof(PostConfigureFoo))]
[Transient<IPostConfigureOptions<FooOptions>>(Factory = nameof(PostConfigureFooNamed))]
[Transient<IValidateOptions<FooOptions>>(Factory = nameof(ValidateFoo))]
public sealed partial class FooNamedContainer
{
    private static IConfigureOptions<FooOptions> ConfigureFoo() =>
        IOptionsModule.ConfigureAll<FooOptions>(options => options.Name = "J");

    private static IConfigureOptions<FooOptions> ConfigureIgnored() =>
        IOptionsModule.Configure<FooOptions>("Other", options => options.Name += "ohn");

    private static IConfigureOptions<FooOptions> ConfigureFooNamed() =>
        IOptionsModule.Configure<FooOptions>("Foo", options => options.Name += "ane");

    private static IPostConfigureOptions<FooOptions> PostConfigureFoo() =>
        IOptionsModule.PostConfigureAll<FooOptions>(options => options.Name += " ");

    private static IPostConfigureOptions<FooOptions> PostConfigureFooNamed() =>
        IOptionsModule.PostConfigure<FooOptions>("Foo", options => options.Name += "Doe");

    private static IValidateOptions<FooOptions> ValidateFoo() =>
        IOptionsModule.Validate<FooOptions>("Foo", options => options.Name == "Jane Doe");
}
