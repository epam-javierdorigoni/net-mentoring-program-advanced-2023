using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces.Persistence.DataServices.Catalog.Commands;

public interface IAddCategoryDataService
{
    Task<Category> ExecuteAsync(Cat category, CancellationToken cancellationToken = default);
}

