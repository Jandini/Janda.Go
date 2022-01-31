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





### Resources

Go icon was downloaded from [Flaticon](https://www.flaticon.com/premium-icon/go_2813814?term=go&related_id=2813814).



