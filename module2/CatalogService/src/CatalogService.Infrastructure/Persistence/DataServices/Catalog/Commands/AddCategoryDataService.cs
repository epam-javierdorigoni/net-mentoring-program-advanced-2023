using CatalogService.Application.Interfaces.Persistence;
using CatalogService.Application.Interfaces.Persistence.DataServices.Catalog.Commands;

namespace CatalogService.Infrastructure.Persistence.DataServices.Catalog.Commands;

public class AddCategoryDataService : IAddCategoryDataService
{
    private readonly ICatalog _dbContext;

    public AddCategoryDataService(ICatalog dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> ExecuteAsync(Category person, CancellationToken cancellationToken = default)
    {
        _dbContext.Category.Add(person);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return person;
    }
}
