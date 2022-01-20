using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Serilog;
using ConGo;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true)
    .Build();

var provider = new ServiceCollection()
    .AddTransient<IMain, Main>()
    .AddSingleton<IConfiguration>(configuration)
    .AddSingleton<Settings>(configuration.GetRequiredSection("Go").Get<Settings>())
    .AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger(), dispose: true))
    .BuildServiceProvider();

var version = Assembly.GetEntryAssembly()?
    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
        .InformationalVersion;

provider
    .GetRequiredService<ILogger<Program>>()
    .LogInformation("Running ConGo {version}", version);

provider
    .GetRequiredService<IMain>()
    .Run();
    