// Created with Janda.Go http://github.com/Jandini/Janda.Go
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
#if (allFeatures)
using Microsoft.Extensions.Configuration;
#endif
using System;
#if (allFeatures)
using System.IO;
#endif
#if (useSerilog || allFeatures)
using Serilog;
#endif
#if (allFeatures)
using CommandLine;
#endif

namespace ConsoleGo
{
    class Program
    {
#if (allFeatures)
        static void Main(string[] args)
        {            
            try
            {
                Parser.Default.ParseArguments<Options.Say, Options.Go>(args)
                    .WithParsed((parameters) =>
                    {
                        var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddAppSettingsJson("appsettings.json")
                            .Build();

                        using var provider = new ServiceCollection()
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
        static void Main()
        {
            try
            {
                using var provider = new ServiceCollection()
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
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}