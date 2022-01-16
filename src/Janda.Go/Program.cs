using Janda.Go;
using Microsoft.Extensions.DependencyInjection;

new ServiceCollection()
    .AddTransient<IMain, Main>()
    .BuildServiceProvider()
    .GetRequiredService<IMain>()
    .Run();

