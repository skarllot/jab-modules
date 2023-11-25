using Jab;
using Microsoft.Extensions.Options;

namespace Raiqub.JabModules.MicrosoftExtensionsOptions;

/// <summary>
/// Defines the registration for <see cref="IOptions{TOptions}"/>-related services.
/// </summary>
[ServiceProviderModule]
[Singleton(typeof(IOptions<>), typeof(OptionsManager<>))]
[Scoped(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>))]
[Singleton(typeof(IOptionsMonitor<>), typeof(OptionsMonitor<>))]
[Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>))]
[Singleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>))]
public interface IOptionsModule
{
    /// <summary>
    /// Registers an action used to configure a particular type of options once during startup.
    /// This is run before <see cref="PostConfigure{TOptions}(System.Action{TOptions})"/>.
    /// Updates to the configuration does not invoke the action again.
    /// </summary>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IConfigureOptions<TOptions> Configure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class =>
        Configure(Options.DefaultName, configureOptions);

    /// <summary>
    /// Registers an action used to configure a particular type of options once during startup.
    /// This is run before <see cref="PostConfigure{TOptions}(string,System.Action{TOptions})"/>.
    /// Updates to the configuration does not invoke the action again.
    /// </summary>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IConfigureOptions<TOptions> Configure<TOptions>(string? name, Action<TOptions> configureOptions)
        where TOptions : class =>
        new ConfigureNamedOptions<TOptions>(name, configureOptions);

    /// <summary>
    /// Registers an action used to configure all instances of a particular type of options.
    /// </summary>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IConfigureOptions<TOptions> ConfigureAll<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class =>
        Configure(name: null, configureOptions);

    /// <summary>
    /// Registers an action used to configure a particular type of options.
    /// These are run after <see cref="Configure{TOptions}(System.Action{TOptions})"/>.
    /// </summary>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IPostConfigureOptions<TOptions> PostConfigure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class =>
        PostConfigure(Options.DefaultName, configureOptions);

    /// <summary>
    /// Registers an action used to configure a particular type of options.
    /// These are run after <see cref="Configure{TOptions}(string,System.Action{TOptions})"/>.
    /// </summary>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IPostConfigureOptions<TOptions> PostConfigure<TOptions>(
        string? name,
        Action<TOptions> configureOptions)
        where TOptions : class =>
        new PostConfigureOptions<TOptions>(name, configureOptions);

    /// <summary>
    /// Registers an action used to post configure all instances of a particular type of options.
    /// Note: These are run after all <see cref="Configure{TOptions}(Action{TOptions})"/>.
    /// </summary>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The configuration to configure the <typeparamref name="TOptions"/> type.</returns>
    public static IPostConfigureOptions<TOptions> PostConfigureAll<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class =>
        PostConfigure(name: null, configureOptions);

    /// <summary>
    /// Register a validation action for an options type.
    /// </summary>
    /// <param name="validation">The validation function.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The validator used to validate the <typeparamref name="TOptions"/> type.</returns>
    public static IValidateOptions<TOptions> Validate<TOptions>(
        Func<TOptions, bool> validation)
        where TOptions : class =>
        new ValidateOptions<TOptions>(Options.DefaultName, validation, OptionsBuilderAccessor.DefaultValidationFailureMessage);

    /// <summary>
    /// Register a validation action for an options type.
    /// </summary>
    /// <param name="validation">The validation function.</param>
    /// <param name="failureMessage">The failure message to use when validation fails.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The validator used to validate the <typeparamref name="TOptions"/> type.</returns>
    public static IValidateOptions<TOptions> Validate<TOptions>(
        Func<TOptions, bool> validation,
        string failureMessage)
        where TOptions : class =>
        new ValidateOptions<TOptions>(Options.DefaultName, validation, failureMessage);

    /// <summary>
    /// Register a validation action for an options type.
    /// </summary>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="validation">The validation function.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The validator used to validate the <typeparamref name="TOptions"/> type.</returns>
    public static IValidateOptions<TOptions> Validate<TOptions>(
        string? name,
        Func<TOptions, bool> validation)
        where TOptions : class =>
        new ValidateOptions<TOptions>(name, validation, OptionsBuilderAccessor.DefaultValidationFailureMessage);

    /// <summary>
    /// Register a validation action for an options type.
    /// </summary>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="validation">The validation function.</param>
    /// <param name="failureMessage">The failure message to use when validation fails.</param>
    /// <typeparam name="TOptions">The options type to be configure.</typeparam>
    /// <returns>The validator used to validate the <typeparamref name="TOptions"/> type.</returns>
    public static IValidateOptions<TOptions> Validate<TOptions>(
        string? name,
        Func<TOptions, bool> validation,
        string failureMessage)
        where TOptions : class =>
        new ValidateOptions<TOptions>(name, validation, failureMessage);
}
