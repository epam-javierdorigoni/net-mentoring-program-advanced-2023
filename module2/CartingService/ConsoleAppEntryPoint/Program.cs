using CartingService.BusinessLogicLayer;
using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppEntryPoint;

internal class Program
{
    static void Main(string[] args)
    {
        // Create a service collection and register dependencies
        var services = new ServiceCollection();

        services.AddSingleton<IRepository<Cart>>(serviceProvider => ActivatorUtilities.CreateInstance<LiteDbRepository<Cart>>(serviceProvider, "C:\\carts.db", "carts"));
        services.AddTransient<ICartDataService, CartDataService>();
        services.AddTransient<ICartBusinessService, CartBusinessService>();

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        Console.ReadLine();
    }
}