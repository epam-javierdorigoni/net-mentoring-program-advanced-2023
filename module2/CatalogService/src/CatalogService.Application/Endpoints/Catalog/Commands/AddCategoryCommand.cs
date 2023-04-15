using CatalogService.Application.Models;
using MediatR;

namespace CatalogService.Application.Endpoints.Catalog.Commands;

public class AddCategoryCommand : IRequest<EndpointResult<CategoryViewModel>>
{
    public int? Id { get; init; }
    public string Name { get; init; } = "";
    public string? ImageUrl { get; init; }
    public CategoryViewModel? ParentCategory { get; init; }
}
