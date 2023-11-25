using Microsoft.Extensions.DependencyInjection;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

public class FooServiceProvider : IServiceProvider
{
    private readonly ServiceProvider _serviceProvider;

    public FooServiceProvider()
    {
        _serviceProvider = new ServiceCollection()
            .Configure<FooOptions>(options => options.Name = "Jane")
            .BuildServiceProvider();
    }

    public object? GetService(Type serviceType) => _serviceProvider.GetService(serviceType);
}
