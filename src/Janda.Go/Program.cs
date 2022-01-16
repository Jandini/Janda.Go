using Janda.Go;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

new ServiceCollection()
    .AddTransient<IMain, Main>()
    .AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: $"{{Message,-{Console.WindowWidth - 18}:lj}} {{Timestamp:HH:mm:ss}} [ {{Level:u4}} ]{{NewLine}}{{Exception}}")
            .CreateLogger(), dispose: true))
    .BuildServiceProvider()
    .GetRequiredService<IMain>()
    .Run();
