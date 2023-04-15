using CatalogService.Application.Interfaces.Persistence;
using CatalogService.Application.Interfaces.Persistence.DataServices.Category.Queries;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.DataServices.Category.Queries;

public class GetCategoryDataService : IGetAllCategoriesService
{
    private readonly ICatalog _dbContext;

    public GetCategoryDataService(ICatalog dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> ExecuteAsync(bool includeInactive, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Category.Where(p => includeInactive || p.Active).ToListAsync(cancellationToken);
    }
}
