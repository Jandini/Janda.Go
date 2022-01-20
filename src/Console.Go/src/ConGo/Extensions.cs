using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ConGo
{
    internal static class Extensions
    {
        static readonly Assembly _assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();

        internal static IConfigurationBuilder AddAppSettings(this IConfigurationBuilder builder, string name)
        {
            return builder
                .AddJsonStream(new EmbeddedFileProvider(_assembly, typeof(Program).Namespace ?? _assembly.GetName().Name).GetFileInfo(name).CreateReadStream())
                .AddJsonFile(name, true);
        }

        internal static IServiceProvider LogVersion(this IServiceProvider provider)
        {
            provider
                .GetRequiredService<ILogger<Program>>()
                .LogInformation("ConGo {version}", _assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);

            return provider;
        }
    }
}
