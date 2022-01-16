using Janda.Go;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true)
    .Build();

new ServiceCollection()
    .AddTransient<IMain, Main>()
    .AddSingleton<IConfiguration>(configuration)
    .AddSingleton<Settings>(configuration.GetRequiredSection("Go").Get<Settings>())
    .AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger(), dispose: true))
    .BuildServiceProvider()
    .GetRequiredService<IMain>()
    .Run();
    