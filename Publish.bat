@echo off
if not exist nuget_pub (
    md nuget_pub
)

for /R "nuget_pub" %%s in (*) do (
    del %%s
)

::core
dotnet pack src/Cosmos.Logging -c Release -o nuget_pub

::extensions
dotnet pack src/Cosmos.Logging.Extensions.Microsoft -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.NodaTime -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.EntityFramework -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.EntityFrameworkCore -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.FreeSql -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.NHibernate -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.SqlSugar -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.PostgreSql -c Release -o nuget_pub

::runs on
dotnet pack src/Cosmos.Logging.RunsOn.AspNet -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.AspNet.WithAutofac -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.AspNetCore -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.Console -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.NancyFX -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.NancyFX.WithAutofac -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.RunsOn.ZKWeb -c Release -o nuget_pub

::configuration
dotnet pack src/Cosmos.Logging.Configuration.Xml -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Configuration.Json -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Configuration.Yaml -c Release -o nuget_pub

::sinks
dotnet pack src/Cosmos.Logging.Sinks.Console -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.File -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.Exceptionless -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.Log4Net -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.NLog -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.AliyunSls -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.JdCloud -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.TencentCloudCls -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Sinks.TomatoLog -c Release -o nuget_pub

::enrichers
dotnet pack src/Cosmos.Logging.Extensions.Exceptions -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.EntityFramework -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.MySql -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.MySqlConnector -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.Oracle -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.PostgreSql -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.Sqlite -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Extensions.Exceptions.SqlServer -c Release -o nuget_pub

::renderers
dotnet pack src/Cosmos.Logging.Renderers.Environment -c Release -o nuget_pub
dotnet pack src/Cosmos.Logging.Renderers.Process -c Release -o nuget_pub

for /R "nuget_pub" %%s in (*symbols.nupkg) do (
    del %%s
)

echo.
echo.

set /p key=input key:
@set source=https://www.myget.org/F/alexinea/api/v2/package
set source=https://api.nuget.org/v3/index.json

for /R "nuget_pub" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
	echo.
)

pause