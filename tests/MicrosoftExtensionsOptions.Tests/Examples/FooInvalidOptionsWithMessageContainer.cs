using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Singleton<FooService>]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFoo))]
[Transient<IValidateOptions<FooOptions>>(Factory = nameof(ValidateFoo))]
public sealed partial class FooInvalidOptionsWithMessageContainer
{
    private static IConfigureOptions<FooOptions> ConfigureFoo() =>
        IOptionsModule.Configure<FooOptions>(options => options.Name = "Jane");

    private static IValidateOptions<FooOptions> ValidateFoo() =>
        IOptionsModule.Validate<FooOptions>(options => options.Name != "Jane", "Name is not Jane");
}
