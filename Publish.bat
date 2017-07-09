@echo off
if not exist packages (
    md packages
)

for /R "packages" %%s in (*) do (
    del %%s
)

dotnet pack src/Cosmos.Abstractions -c Release -o ../../packages
dotnet pack src/Cosmos.Core -c Release -o ../../packages
dotnet pack src/Cosmos -c Release -o ../../packages
dotnet pack src/Cosmos.Extensions -c Release -o ../../packages
dotnet pack src/Cosmos.Extensions.Preconditions -c Release -o ../../packages
dotnet pack src/Cosmos.Extensions.DateTime -c Release -o ../../packages

for /R "packages" %%s in (*symbols.nupkg) do (
    del %%s
)

echo.
echo.

set /p key=input key:
set source=https://www.myget.org/F/alexinea/api/v2/package

for /R "packages" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
	echo.
)

pause