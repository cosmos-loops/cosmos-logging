# COSMOSLOOPS/Cosmos.Logging

Logging component for .NET Core with nice APIs for developers to use. Cosmos.Logging is support for structured logging message in several kinds of .NET applications.

This repository belongs to [COSMOS LOOPS PROGRAMME](https://github.com/cosmos-loops/).

## Nuget Packages

| Package Name                                                                                                                                         | Version                                                                                          | Downloads                                                                                         |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------- |
| [Cosmos.Logging](https://www.nuget.org/packages/Cosmos.Logging/)                                                                                     | ![](https://img.shields.io/nuget/v/Cosmos.Logging.svg)                                           | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.svg)                                           |
| [Cosmos.Logging.RunsOn.AspNet](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNet/)                                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.AspNet.svg)                             | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.AspNet.svg)                             |
| [Cosmos.Logging.RunsOn.AspNet.WithAutofac](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNet.WithAutofac/)                                 | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.AspNet.WithAutofac.svg)                 | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.AspNet.WithAutofac.svg)                 |
| [Cosmos.Logging.RunsOn.AspNetCore](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNetCore/)                                                 | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.AspNetCore.svg)                         | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.AspNetCore.svg)                         |
| [Cosmos.Logging.RunsOn.Console](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.Console/)                                                       | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.Console.svg)                            | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.Console.svg)                            |
| [Cosmos.Logging.RunsOn.NancyFX](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.NancyFX/)                                                       | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.NancyFX.svg)                            | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.NancyFX.svg)                            |
| [Cosmos.Logging.RunsOn.NancyFX.WithAutofac](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.NancyFX.WithAutofac/)                               | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.NancyFX.WithAutofac.svg)                | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.NancyFX.WithAutofac.svg)                |
| [Cosmos.Logging.RunsOn.ZkWeb](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.ZkWeb/)                                                           | ![](https://img.shields.io/nuget/v/Cosmos.Logging.RunsOn.ZkWeb.svg)                              | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.RunsOn.ZkWeb.svg)                              |
| [Cosmos.Logging.Extensions.Microsoft](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Microsoft/)                                           | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Microsoft.svg)                      | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Microsoft.svg)                      |
| [Cosmos.Logging.Extensions.EntityFramework](https://www.nuget.org/packages/Cosmos.Logging.Extensions.EntityFramework/)                               | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.EntityFramework.svg)                | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.EntityFramework.svg)                |
| [Cosmos.Logging.Extensions.EntityFrameworkCore](https://www.nuget.org/packages/Cosmos.Logging.Extensions.EntityFrameworkCore/)                       | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.EntityFrameworkCore.svg)            | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.EntityFrameworkCore.svg)            |
| [Cosmos.Logging.Extensions.NHibernate](https://www.nuget.org/packages/Cosmos.Logging.Extensions.NHibernate/)                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.NHibernate.svg)                     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.NHibernate.svg)                     |
| [Cosmos.Logging.Extensions.FreeSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.FreeSql/)                                               | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.FreeSql.svg)                        | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.FreeSql.svg)                        |
| [Cosmos.Logging.Extensions.SqlSugar](https://www.nuget.org/packages/Cosmos.Logging.Extensions.SqlSugar/)                                             | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.SqlSugar.svg)                       | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.SqlSugar.svg)                       |
| [Cosmos.Logging.Extensions.PostgreSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.PostgreSql/)                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.PostgreSql.svg)                     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.PostgreSql.svg)                     |
| [Cosmos.Logging.Extensions.Exceptions](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions/)                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.svg)                     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.svg)                     |
| [Cosmos.Logging.Extensions.Exceptions.EntityFramework](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.EntityFramework/)         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.EntityFramework.svg)     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.EntityFramework.svg)     |
| [Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore/) | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore.svg) | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore.svg) |
| [Cosmos.Logging.Extensions.Exceptions.MySql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.MySql/)                             | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.MySql.svg)               | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.MySql.svg)               |
| [Cosmos.Logging.Extensions.Exceptions.MySqlConnector](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.MySqlConnector/)           | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.MySqlConnector.svg)      | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.MySqlConnector.svg)      |
| [Cosmos.Logging.Extensions.Exceptions.Oracle](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.Oracle/)                           | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.Oracle.svg)              | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.Oracle.svg)              |
| [Cosmos.Logging.Extensions.Exceptions.PostgreSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.PostgreSql/)                   | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.PostgreSql.svg)          | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.PostgreSql.svg)          |
| [Cosmos.Logging.Extensions.Exceptions.Sqlite](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.Sqlite/)                           | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.Sqlite.svg)              | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.Sqlite.svg)              |
| [Cosmos.Logging.Extensions.Exceptions.SqlServer](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.SqlServer/)                     | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.Exceptions.SqlServer.svg)           | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.Exceptions.SqlServer.svg)           |
| [Cosmos.Logging.Extensions.NodaTime](https://www.nuget.org/packages/Cosmos.Logging.Extensions.NodaTime/)                                             | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Extensions.NodaTime.svg)                       | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Extensions.NodaTime.svg)                       |
| [Cosmos.Logging.Sinks.AliyunSls](https://www.nuget.org/packages/Cosmos.Logging.Sinks.AliyunSls/)                                                     | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.AliyunSls.svg)                           | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.AliyunSls.svg)                           |
| [Cosmos.Logging.Sinks.JdColud](https://www.nuget.org/packages/Cosmos.Logging.Sinks.JdColud/)                                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.JdColud.svg)                             | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.JdColud.svg)                             |
| [Cosmos.Logging.Sinks.TencentCloudCls](https://www.nuget.org/packages/Cosmos.Logging.Sinks.TencentCloudCls/)                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.TencentCloudCls.svg)                     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.TencentCloudCls.svg)                     |
| [Cosmos.Logging.Sinks.Exceptionless](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Exceptionless/)                                             | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.Exceptionless.svg)                       | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.Exceptionless.svg)                       |
| [Cosmos.Logging.Sinks.TomatoLog](https://www.nuget.org/packages/Cosmos.Logging.Sinks.TomatoLog/)                                                     | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.TomatoLog.svg)                           | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.TomatoLog.svg)                           |
| [Cosmos.Logging.Sinks.Log4Net](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Log4Net/)                                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.Log4Net.svg)                             | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.Log4Net.svg)                             |
| [Cosmos.Logging.Sinks.NLog](https://www.nuget.org/packages/Cosmos.Logging.Sinks.NLog/)                                                               | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.NLog.svg)                                | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.NLog.svg)                                |
| [Cosmos.Logging.Sinks.Console](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Console/)                                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.Console.svg)                             | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.Console.svg)                             |
| [Cosmos.Logging.Sinks.File](https://www.nuget.org/packages/Cosmos.Logging.Sinks.File/)                                                               | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Sinks.File.svg)                                | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Sinks.File.svg)                                |
| [Cosmos.Logging.Renderers.Environment](https://www.nuget.org/packages/Cosmos.Logging.Renderers.Environment/)                                         | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Renderers.Environment.svg)                     | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Renderers.Environment.svg)                     |
| [Cosmos.Logging.Renderers.Process](https://www.nuget.org/packages/Cosmos.Logging.Renderers.Process/)                                                 | ![](https://img.shields.io/nuget/v/Cosmos.Logging.Renderers.Process.svg)                         | ![](https://img.shields.io/nuget/dt/Cosmos.Logging.Renderers.Process.svg)                         |

## Usage

### Install the package

```
Install-Package Cosmos.Logging
```

Install the specific sink packages, renderer packages or extension packages that you need.


### Work in console

Install console package first:

```
Install-Package Cosmos.Logging.RunsOn.Console
```

then: (in this case we integrated NLog sink)

```c#
static void Main(string[] args)
{
    //load configuration info
    var root = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();

    //initialize logger
    LOGGER.Initialize(root).RunsOnConsole().AddNLog().AddSampleLog().AllDone();

    //submit log manually
    var logger1 = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);
    logger1.LogWarning("hello， {$Date} {$MachineName}");
    logger1.SubmitLogger();

    //or submit log automatically
    var logger2 = LOGGER.GetLogger<Program>();
    logger2.LogWarning("world");

    //get a future logger
    var logger3 = LOGGER.GetLogger<Program>().ToFuture();

    //or convert a normal to future logger
    var logger4 = logger2.ToFuture();

    //or get a future logger directly
    var logger5 = FUTURE.GetFutureLogger<Program>();

    //and how to use future logger via a nice fluent api
    logger5.SetLevel(LogEventLevel.Warning)
        .SetMessage("future log===> Nice {@L}")
        .SetTags("Alex", "Lewis")
        .SetParameter(new {L = "KK2"})
        .SetException(new ArgumentNullException(nameof(args)))
        .Submit();

    //or you can use a optional-parameters-style api in your Application-Framework
    logger5.UseFields(
        Fields.Level(LogEventLevel.Warning),
        Fields.Message("future log===> Nice {@L}"),
        Fields.Tags("Alex", "Lewis"),
        Fields.Args(new {L = "KK3"}),
        Fields.Exception(new ArgumentNullException(nameof(args)))).Submit();
}
```

### Work with Microsoft ASP.NET Core Mvc

Install aspnetcore package first:

```c#
Install-Package Cosmos.Logging.RunsOn.AspNetCore
```

then write code in `Startup.cs`: (in this case, we integrated SqlSugar ORM)

```c#
public void ConfigureServices(IServiceCollection services)
{
    //...

    services.AddCosmosLogging(Configuration, config => config
            .ToGlobal(o => o.UseMinimumLevel(LogEventLevel.Information))
            .AddDatabaseIntegration(o => o.UseSqlSugar(sugar => sugar.UseAlias("Everything", LogEventLevel.Verbose)))
            .AddSampleLog());

    //...
}
```

finally, just to writing your code:

```c#
public class HomeController : Controller
{
    private readonly ILoggingServiceProvider _loggingProvider;

    public HomeController(ILoggingServiceProvider loggingProvider) {
        _loggingProvider = loggingProvider ?? throw new ArgumentNullException(nameof(loggingProvider));
    }

    // GET
    public IActionResult Index() {
        var log = _loggingProvider.GetLogger<HomeController>();
        log.LogInformation("Nice @ {$Date}");
        return Content("Nice");
    }
}

```

### Work with Microsoft ASP.NET Mvc

Install aspnet package first:

```
Install-Package Cosmos.Logging.RunsOn.AspNet
```

or (if you use Autofac as your default IoC container)

```
Install-Package Cosmos.Logging.RunsOn.AspNet.WithAutofac
```

then

```c#
//in Global.asax.cs
public class Global : HttpApplication
{
    //...
    this.RegisterCosmosLogging(s => s.ToGlobal(c => c.UseMinimumLevel(LogEventLevel.Verbose)).AddSampleLog());
}

```

## Thanks

People or projects that have made a great contribution to this project:

+ *Mr.* [刘浩杨](https://github.com/liuhaoyang)
+ *Mr.* [何镇汐](https://github.com/UtilCore)
- _The next one must be you_

### Organizations and projects

+ *Project* [AsyncQueue](https://github.com/Sunlighter/AsyncQueues), Apache License 2.0
+ 
---

## License

Member project of [COSMOS LOOPS PROGRAMME](https://github.com/cosmos-loops).

[Apache 2.0 License](/LICENSE)