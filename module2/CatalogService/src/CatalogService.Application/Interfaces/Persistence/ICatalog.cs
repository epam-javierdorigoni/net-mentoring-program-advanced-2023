using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Interfaces.Persistence;

public interface ICatalog
{
    DbSet<Category> Category { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
