using CatalogService.Application.Models;
using MediatR;

namespace CatalogService.Application.Endpoints.Catalog.Queries;

public class GetAllCategoriesQuery : IRequest<EndpointResult<IEnumerable<CategoryViewModel>>>
{
}

