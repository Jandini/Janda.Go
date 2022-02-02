# Janda.Go

[![.NET](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml)
[![NuGet](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml)

.NET template provides console application startup code with dependency injection, logging, configuration and more...


## Install

```bash
dotnet new -i Janda.Go
```



## Start

Create new application from **Console Go (C#)** template

```bash
dotnet new consolego 
```

or 

```bash
dotnet new consolego -n MyApp
```

The console main code is ready to "Run"

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
using MyApp;

try
{
    var provider = new ServiceCollection()
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
    finally
    {
        provider.GetRequiredService<ILoggerFactory>()
            .Dispose();
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

* .NET6 with https://aka.ms/new-console-template 
* Repository Layout
  * The `src` and `bin` folders 
  * Default `README.md` file 
  * Default `.gitignore` file
  * Default `launchSettings.json` file
* GitHub Actions
  * `Build` and `Test` workflow file for .NET6
* Dependency Injection
  * Main service with logging
* Logging
  * `Microsoft` or `Serilog` logging providers
  * Logger factory disposal
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





## Examples

### Simple Console

```
dotnet new -n Example
```

###### Example.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">
	<PropertyGroup>
		<OutputType>Exe</OutputType>
		<TargetFramework>net6.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>disable</Nullable>
		<BaseOutputPath>..\..\bin</BaseOutputPath>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
		<PackageReference Include="Microsoft.Extensions.Logging" Version="6.0.0" />
		<PackageReference Include="Microsoft.Extensions.Logging.Console" Version="6.0.0" />
	</ItemGroup>
</Project>
```



###### Program.cs

```c#
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Example;

var provider = new ServiceCollection()
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
finally
{
    provider.GetRequiredService<ILoggerFactory>()
        .Dispose();
}
```



###### IMain.cs

```c#
namespace Example
{
    internal interface IMain
    {
        void Run();
    }
}
```



###### Main.cs

```c#
using Microsoft.Extensions.Logging;

namespace Example
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;

        public Main(ILogger<Main> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Hello, World");            
            throw new NotImplementedException();
        }
    }
}
```





### Resources

Go icon was downloaded from [Flaticon](https://www.flaticon.com/premium-icon/go_2813814?term=go&related_id=2813814).



