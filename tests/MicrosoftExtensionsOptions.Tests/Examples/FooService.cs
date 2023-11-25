using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

public class FooService(IOptions<FooOptions> options)
{
    public string Call() => $"Hello {options.Value.Name}";
}
