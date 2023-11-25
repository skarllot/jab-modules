using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests;

public class OptionsModuleTest
{
    [Fact]
    public void ShouldConfigureFoo()
    {
        using var container = new FooContainer();
        var fooService = container.GetRequiredService<FooService>();

        string result = fooService.Call();

        result.Should().Be("Hello Jane Doe");
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

    [Fact]
    public void ShouldThrowInvalidOptionsWithMessageFoo()
    {
        using var container = new FooInvalidOptionsWithMessageContainer();
        var fooService = container.GetRequiredService<FooService>();

        Action call = () => fooService.Call();

        call.Should().ThrowExactly<OptionsValidationException>().Where(e => e.Message == "Name is not Jane");
    }

    [Fact]
    public void ShouldThrowInvalidNamedOptionsWithMessageFoo()
    {
        using var container = new FooInvalidNamedOptionsWithMessageContainer();
        using var scope = container.CreateScope();
        var fooService = scope.GetRequiredService<FooServiceNamed>();

        Action call = () => fooService.Call();

        call.Should().ThrowExactly<OptionsValidationException>().Where(e => e.Message == "Name is not Jane");
    }

    [Fact]
    public void ShouldConfigureFooWithName()
    {
        using var container = new FooNamedContainer();
        using var scope = container.CreateScope();
        var fooService = scope.GetRequiredService<FooServiceNamed>();

        string result = fooService.Call();

        result.Should().Be("Hello Jane Doe");
    }
}
