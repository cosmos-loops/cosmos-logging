# Cosmos.Logging.Extensions.CorrelationId

You should add CorrelationId into service collection before use Cosmos.Logging:

```
public vod ConfigureServices(IServiceCollection services)
{
    services.AddCorrelationId();
}
```

and register CorrelationId as a middleware before all middleware:

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseCorrelationId();
    
    if(env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    
    app.UseMvc();
}
```

This extension depends on `Cosmos.Logging.RunsOn.AspNetCore`.