using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

public class FooServiceNamed(IOptionsSnapshot<FooOptions> options)
{
    public string Call() => $"Hello {options.Get("Foo").Name}";
}
