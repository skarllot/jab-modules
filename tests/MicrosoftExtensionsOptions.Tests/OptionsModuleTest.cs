using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

    [Fact]
    public void ShouldDefaultOptionsFoo()
    {
        using var container = new FooContainerDefault();
        var fooService = container.GetRequiredService<FooService>();

        string result = fooService.Call();

        result.Should().Be("Hello John");
    }

    [Fact]
    public void ShouldThrowInvalidOptionsFoo()
    {
        using var container = new FooInvalidOptionsContainer();
        var fooService = container.GetRequiredService<FooService>();

        Action call = () => fooService.Call();

        call.Should().ThrowExactly<OptionsValidationException>();
    }
}
