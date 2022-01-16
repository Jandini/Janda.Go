using Janda.Go;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;


new ServiceCollection()
    .AddTransient<IMain, Main>()    
    .AddLogging(builder => builder        
        .AddSerilog(new LoggerConfiguration()       
            .ReadFrom.Configuration(
                new ConfigurationBuilder()                    
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .Build())
            .CreateLogger(), dispose: true))
    .BuildServiceProvider()
    .GetRequiredService<IMain>()
    .Run();
