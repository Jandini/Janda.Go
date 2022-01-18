@echo off
:: Disable dotnet telemetry
set DOTNET_CLI_TELEMETRY_OPTOUT=1

:: Publish release as signle, executable, non self contained, ready to run file without debug files.
dotnet publish src -p:PublishSingleFile=true -r:win-x64 -p:PublishReadyToRun=true -c:Release --self-contained false -p:DebugType=None -nologo