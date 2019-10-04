@echo off
cd %~dp0

:build
call dotnet restore
call dotnet build --no-restore
call dotnet test --no-build
call dotnet pack BerTlv\BerTlv.csproj --no-build -o ./NuGet
