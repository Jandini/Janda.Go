using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CommandLine;
using Serilog;
using ConsoleGo;
using Microsoft.Extensions.Logging;

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
                        main.Run(options.Name);
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