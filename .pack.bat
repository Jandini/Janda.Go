@echo off
:: This script allows to build the package locally 
where dotnet-gitversion >nul
if %errorlevel% neq 0 dotnet tool install --global GitVersion.Tool --version 5.8.1 

for /f %%i in ('dotnet gitversion /showvariable SemVer') do set GIT_VERSION=%%i

nuget pack .nuspec -OutputDirectory bin/Release -NoDefaultExcludes -Version %GIT_VERSION%

echo Uninstalling current version...
dotnet new uninstall Janda.Go 2>nul
echo Installing Janda.Go.%GIT_VERSION%
dotnet new install bin/Release/Janda.Go.%GIT_VERSION%.nupkg
