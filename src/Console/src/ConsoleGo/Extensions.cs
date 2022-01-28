using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ConsoleGo
{
    internal static class Extensions
    {
        internal static IConfigurationBuilder AddAppSettingsJson(this IConfigurationBuilder builder, string name)
        {
            return builder
                .AddJsonStream(new EmbeddedFileProvider(Assembly.GetExecutingAssembly()).GetFileInfo(name).CreateReadStream())
                .AddJsonFile(name, true);
        }

        internal static IServiceProvider LogVersion(this IServiceProvider provider)
        {
            provider
                .GetRequiredService<ILogger<Program>>()
                .LogInformation("ConsoleGo {version}", Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);

            return provider;
        }


        internal static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton(configuration)
                .AddSingleton(configuration.GetRequiredSection("Go").Get<Settings>());
        }

        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IMain, Main>();
        }
    }
}
