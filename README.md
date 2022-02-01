# Janda.Go

[![.NET](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/build.yml)
[![NuGet](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml/badge.svg)](https://github.com/Jandini/Janda.Go/actions/workflows/nuget.yml)

.NET template to create console application including dependency injection, logging, configuration.



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



