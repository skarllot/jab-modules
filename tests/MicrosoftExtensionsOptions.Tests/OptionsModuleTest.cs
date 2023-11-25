using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;
using Xunit;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests;

public class OptionsModuleTest
{
    [Fact]
    public void ShouldConfigureFoo()
    {
        using var container = new FooContainer();
        var fooService = container.GetRequiredService<FooService>();

        string result = fooService.Call();

        result.Should().Be("Hello Jane");
    }
}
