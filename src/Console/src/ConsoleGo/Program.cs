// Created with Janda.Go http://github.com/Jandini/Janda.Go
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
#if (allFeatures)
using Microsoft.Extensions.Configuration;
using CommandLine;
#endif
#if (useSerilog || allFeatures)
using Serilog;
#endif
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
#else
try
{
    var provider = new ServiceCollection()
        .AddTransient<IMain, Main>()
#if (useSerilog)
        .AddLogging(builder => builder
            .AddSerilog(new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger(), dispose: true))
#else
        .AddLogging(builder => builder.AddConsole())
#endif
        .BuildServiceProvider();

    try
    {
        provider
            .GetRequiredService<IMain>()
            .Run();
    }
    catch (Exception ex)
    {
        provider.GetRequiredService<ILogger<Program>>()
            .LogCritical(ex, ex.Message);
    }
#if (!useSerilog)
    finally
    {
        provider.GetRequiredService<ILoggerFactory>()
            .Dispose();
    }
#endif
#endif
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}