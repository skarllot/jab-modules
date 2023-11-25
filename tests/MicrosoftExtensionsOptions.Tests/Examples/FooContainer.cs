using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Singleton<FooService>]
[Singleton<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFoo))]
public partial class FooContainer
{
    private static IConfigureOptions<FooOptions> ConfigureFoo() =>
        IOptionsModule.Configure<FooOptions>(options => options.Name = "Jane");
}
