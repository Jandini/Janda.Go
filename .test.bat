@echo off
cd %temp%
call :run Hello1
call :run Hello2 -us
call :run Hello3 -al
call :run Hello4 -us -al
cd %~dp0
goto :eof

:run
echo dotnet new consolego -n %*
dotnet new consolego -n %*
cd %1
cd src
cd %1
dotnet run
if %errorlevel% neq 0 exit 1;
cd ..
cd ..
cd ..
rd /q /s %1
goto :eof
