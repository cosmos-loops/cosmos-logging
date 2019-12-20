# COSMOSLOOPS/Cosmos.Logging

Logging component for .NET Core with nice APIs for developers to use. Cosmos.Logging is support for structured logging message in several kinds of .NET applications.

This repository belongs to [Cosmosloops Labs.](https://github.com/cosmos-loops/).

## Nuget Packages

+ [Cosmos.Logging](https://www.nuget.org/packages/Cosmos.Logging/)
+  RunsOn Extensions
    + [Cosmos.Logging.RunsOn.AspNet](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNet/) 
    + [Cosmos.Logging.RunsOn.AspNet.WithAutofac](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNet.WithAutofac/) 
    + [Cosmos.Logging.RunsOn.AspNetCore](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.AspNetCore/) 
    + [Cosmos.Logging.RunsOn.Console](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.Console/) 
    + [Cosmos.Logging.RunsOn.NancyFX](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.NancyFX/) 
    + [Cosmos.Logging.RunsOn.NancyFX.WithAutofac](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.NancyFX.WithAutofac/) 
    + [Cosmos.Logging.RunsOn.ZkWeb](https://www.nuget.org/packages/Cosmos.Logging.RunsOn.ZkWeb/)
+ Common Extensions
    + [Cosmos.Logging.Extensions.Microsoft](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Microsoft/)
    + [Cosmos.Logging.Extensions.NodaTime](https://www.nuget.org/packages/Cosmos.Logging.Extensions.NodaTime/)
+ Data provider and ORM Extensions / Enrichers
    + [Cosmos.Logging.Extensions.EntityFramework](https://www.nuget.org/packages/Cosmos.Logging.Extensions.EntityFramework/)
    + [Cosmos.Logging.Extensions.EntityFrameworkCore](https://www.nuget.org/packages/Cosmos.Logging.Extensions.EntityFrameworkCore/)
    + [Cosmos.Logging.Extensions.NHibernate](https://www.nuget.org/packages/Cosmos.Logging.Extensions.NHibernate/)
    + [Cosmos.Logging.Extensions.FreeSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.FreeSql/)
    + [Cosmos.Logging.Extensions.SqlSugar](https://www.nuget.org/packages/Cosmos.Logging.Extensions.SqlSugar/) 
    + [Cosmos.Logging.Extensions.PostgreSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.PostgreSql/)
+ Exception Extensions / Enrichers
    + [Cosmos.Logging.Extensions.Exceptions](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions/)
    + [Cosmos.Logging.Extensions.Exceptions.EntityFramework](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.EntityFramework/)
    + [Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.EntityFrameworkCore/)
    + [Cosmos.Logging.Extensions.Exceptions.MySql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.MySql/)
    + [Cosmos.Logging.Extensions.Exceptions.MySqlConnector](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.MySqlConnector/)
    + [Cosmos.Logging.Extensions.Exceptions.Oracle](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.Oracle/)
    + [Cosmos.Logging.Extensions.Exceptions.PostgreSql](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.PostgreSql/)
    + [Cosmos.Logging.Extensions.Exceptions.Sqlite](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.Sqlite/)
    + [Cosmos.Logging.Extensions.Exceptions.SqlServer](https://www.nuget.org/packages/Cosmos.Logging.Extensions.Exceptions.SqlServer/)
+ Payload Clients / Sinks
    + [Cosmos.Logging.Sinks.File](https://www.nuget.org/packages/Cosmos.Logging.Sinks.File/)
    + [Cosmos.Logging.Sinks.Console](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Console/)
    + [Cosmos.Logging.Sinks.NLog](https://www.nuget.org/packages/Cosmos.Logging.Sinks.NLog/) 
    + [Cosmos.Logging.Sinks.Exceptionless](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Exceptionless/)
    + [Cosmos.Logging.Sinks.AliyunSls](https://www.nuget.org/packages/Cosmos.Logging.Sinks.AliyunSls/)
    + [Cosmos.Logging.Sinks.JdCloud](https://www.nuget.org/packages/Cosmos.Logging.Sinks.JdCloud/)
    + [Cosmos.Logging.Sinks.TencentCloudCls](https://www.nuget.org/packages/Cosmos.Logging.Sinks.TencentCloudCls/)
    + [Cosmos.Logging.Sinks.Log4Net](https://www.nuget.org/packages/Cosmos.Logging.Sinks.Log4Net/)
    + [Cosmos.Logging.Sinks.TomatoLog](https://www.nuget.org/packages/Cosmos.Logging.Sinks.TomatoLog/)
+ Renderers
    + [Cosmos.Logging.Renderers.Environment](https://www.nuget.org/packages/Cosmos.Logging.Renderers.Environment/)
    + [Cosmos.Logging.Renderers.Process](https://www.nuget.org/packages/Cosmos.Logging.Renderers.Process/)

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
- _The next one must be yours_

---

## License

Member project of [Cosmosloops Labs.](https://github.com/cosmos-loops).

[Apache License 2.0](/LICENSE)