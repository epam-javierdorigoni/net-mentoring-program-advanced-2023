using System.Text.RegularExpressions;
using CatalogService.Application.Interfaces.Persistence;
using CatalogService.Application.Interfaces.Services;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure;

public static class DependencyInjection
{
    private static readonly Regex InterfacePattern = new Regex("I(?:.+)DataService", RegexOptions.Compiled);

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<Catalog>()
            .AddScoped<ICatalog, Catalog>();

        (from c in typeof(Application.DependencyInjection).Assembly.GetTypes()
         where c.IsInterface && InterfacePattern.IsMatch(c.Name)
         from i in typeof(DependencyInjection).Assembly.GetTypes()
         where c.IsAssignableFrom(i)
         select new
         {
             Contract = c,
             Implementation = i
         }).ToList()
        .ForEach(x => services.AddScoped(x.Contract, x.Implementation));

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

        return services;
    }
}
