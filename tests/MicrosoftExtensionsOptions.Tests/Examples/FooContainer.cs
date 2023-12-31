﻿using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions.Tests.Examples;

[ServiceProvider]
[Import<IOptionsModule>]
[Singleton<FooService>]
[Transient<IConfigureOptions<FooOptions>>(Factory = nameof(ConfigureFoo))]
[Transient<IPostConfigureOptions<FooOptions>>(Factory = nameof(PostConfigureFoo))]
[Transient<IValidateOptions<FooOptions>>(Factory = nameof(ValidateFoo))]
public sealed partial class FooContainer
{
    private static IConfigureOptions<FooOptions> ConfigureFoo() =>
        IOptionsModule.Configure<FooOptions>(options => options.Name = "Jane");

    private static IPostConfigureOptions<FooOptions> PostConfigureFoo() =>
        IOptionsModule.PostConfigure<FooOptions>(options => options.Name += " Doe");

    private static IValidateOptions<FooOptions> ValidateFoo() =>
        IOptionsModule.Validate<FooOptions>(options => options.Name == "Jane Doe");
}
