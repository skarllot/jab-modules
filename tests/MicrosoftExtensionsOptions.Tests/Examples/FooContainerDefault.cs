using Jab;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Singleton<FooService>]
public sealed partial class FooContainerDefault;
