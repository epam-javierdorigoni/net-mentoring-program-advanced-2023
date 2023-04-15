using System.Reflection;
using CatalogService.Application.Interfaces.Persistence;
using CatalogService.Application.Interfaces.Services;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CatalogService.Infrastructure.Persistence;

public class Catalog : DbContext, ICatalog
{
    private readonly IPrincipalService _principalService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IConfiguration _configuration;

    public DbSet<Category> Category { get; set; } = null!;

    public Catalog(
        DbContextOptions options,
        IPrincipalService principalService,
        IDateTimeService dateTimeService,
        IConfiguration configuration) : base(options)
    {
        _principalService = principalService;
        _dateTimeService = dateTimeService;
        _configuration = configuration;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("sic"),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory")
        );
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.SeedData();
    }
}
