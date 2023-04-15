using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces.Persistence.DataServices.Category.Queries;

public interface IGetAllCategoriesService
{
    Task<IEnumerable<Category>> ExecuteAsync(CancellationToken cancellationToken = default);
}
