using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using ConGo;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddAppSettingsJson("appsettings.json")
    .Build();

var provider = new ServiceCollection()
    .AddServices()
    .AddConfiguration(configuration)
    .AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger(), dispose: true))
    .BuildServiceProvider();

provider
    .LogVersion()
    .GetRequiredService<IMain>()
    .Run();
