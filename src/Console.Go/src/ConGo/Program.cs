using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using ConGo;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddAppSettings("appsettings.json")
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

provider
    .LogVersion()
    .GetRequiredService<IMain>()
    .Run();
