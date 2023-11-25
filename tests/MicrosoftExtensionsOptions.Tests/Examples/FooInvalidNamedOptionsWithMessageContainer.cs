using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Scoped<FooServiceNamed>]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFoo))]
[Transient<IValidateOptions<FooOptions>>(Factory = nameof(ValidateFoo))]
public sealed partial class FooInvalidNamedOptionsWithMessageContainer
{
    private static IConfigureOptions<FooOptions> ConfigureFoo() =>
        IOptionsModule.Configure<FooOptions>("Foo", options => options.Name = "Jane");

    private static IValidateOptions<FooOptions> ValidateFoo() =>
        IOptionsModule.Validate<FooOptions>("Foo", options => options.Name != "Jane", "Name is not Jane");
}
