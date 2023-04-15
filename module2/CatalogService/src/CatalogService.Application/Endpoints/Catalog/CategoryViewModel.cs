using CatalogService.Application.Endpoints.Item;

namespace CatalogService.Application.Endpoints.Catalog;

public record CategoryViewModel
{
    public int? Id { get; init; }
    public string Name { get; init; } = "";
    public string? ImageUrl { get; init; }
    public CategoryViewModel? ParentCategory { get; init; }

    public IEnumerable<ItemViewModel> Items = new List<ItemViewModel>();
}

