# Janda.Go

[![.NET](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml)
[![NuGet](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml)

.NET template provides console application startup code with dependency injection, logging, configuration and more...


## Install

To install this template use `dotnet` command. It will automatically download template nuget package from https://www.nuget.org/packages/Janda.Go/

```bash
dotnet new -i Janda.Go
```



## Start

Once the template is installed you can create new application from **Console Go (C#)** template. 

```bash
dotnet new consolego 
```

or 

```bash
dotnet new consolego -n MyApp
```

The console main code is ready to "Run" with dependency injection and logging.

```c#
public void Run()
{
    _logger.LogInformation("Hello, World");
    _logger.LogWarning("No implementation");
    throw new NotImplementedException("Fix it");
}
```	

![image](https://user-images.githubusercontent.com/19593367/152032611-382ae24e-23f2-4117-ae6b-cdf358ac3e00.png)

The `Program.cs` code is going to look like this

```C#
// Created with Janda.Go http://github.com/Jandini/Janda.Go
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Hello1;

try
{
    using var provider = new ServiceCollection()
        .AddTransient<IMain, Main>()
        .AddLogging(builder => builder.AddConsole())
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
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

### Serilog

If you like Serilog the same as I do use `--useSerilog` or `-us` option

```
dotnet new consolego -n MyApp -us
```

![image](https://user-images.githubusercontent.com/19593367/152033659-27d21c1a-293e-4e97-8282-2747f07f804f.png)




## Help

More information about **Console Go** template 

```
dotnet new consolego -h  
```





## Features

* .NET6
* Repository Layout
  * The `src` and `bin` folders 
  * Default `README.md` file 
  * Default `.gitignore` file
  * Default `launchSettings.json` file
* GitHub Actions
  * `Build` and `Test` workflow file for .NET6
* Dependency Injection
  * Main service with logging
  * Service provider disposal
* Logging
  * `Microsoft` or `Serilog` log providers  
  * Unhandled exceptions logging
  * Version logging
  * Dynamic logger
* Configuration
  * Embedded `appsettings.json`  file
  * Override embedded `appsettings.json` with the file
  * Settings binding
  * Configuration and settings injection
* Command line parser
  * Verbs and options parser








### Resources

Go icon was downloaded from [Flaticon](https://www.flaticon.com/premium-icon/go_2813814?term=go&related_id=2813814).



