using CatalogService.Application;
using CatalogService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace CatalogService.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);

        services.AddApplication(Configuration);
        services.AddInfrastructure(Configuration);

        services.AddHttpContextAccessor();
        services.AddHealthChecks();

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = ApiVersion.Default;
        });

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatalogService.Api", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogService.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.Use(async (httpContext, next) =>
        {
            var apiMode = httpContext.Request.Path.StartsWithSegments("/api");
            if (apiMode)
            {
                httpContext.Request.Headers[HeaderNames.XRequestedWith] = "XMLHttpRequest";
            }
            await next();
        });

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
            endpoints.MapControllers();
        });
    }
}
