// Created with Janda.Go http://github.com/Jandini/Janda.Go
using Microsoft.Extensions.DependencyInjection;
#if (allFeatures)
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CommandLine;
#endif
using Serilog;
using ConsoleGo;

#if (allFeatures)
try
{
    Parser.Default.ParseArguments<Options.Say, Options.Go>(args)
        .WithParsed((parameters) =>
        {
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

            provider.LogVersion();

            try
            {
                var main = provider.GetRequiredService<IMain>();

                switch (parameters)
                {
                    case Options.Say:
                        main.Run();
                        break;

                    case Options.Go options:
                        main.Go(options.Name);
                        break;

                };
            }
            catch (Exception ex)
            {
                provider.GetService<ILogger<Program>>()?
                    .LogCritical(ex, ex.Message);
            }
        });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
#else
var provider = new ServiceCollection()
    .AddTransient<IMain, Main>()
    .AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger(), dispose: true))
    .BuildServiceProvider();

provider
    .GetRequiredService<IMain>()
    .Run();
#endif