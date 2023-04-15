using AutoMapper;
using CatalogService.Application.Interfaces.Persistence.DataServices.Category.Queries;
using CatalogService.Application.Models;
using MediatR;

namespace CatalogService.Application.Endpoints.Catalog.Queries;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, EndpointResult<IEnumerable<CategoryViewModel>>>
{
    public readonly IGetAllCategoriesService _getCategoryDataService;
    public readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IGetAllCategoriesService getCategoryDataService, IMapper mapper)
    {
        _getCategoryDataService = getCategoryDataService;
        _mapper = mapper;
    }

    public async Task<EndpointResult<IEnumerable<CategoryViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken = default)
    {
        var categories = await _getCategoryDataService.ExecuteAsync(cancellationToken);

        return new EndpointResult<IEnumerable<CategoryViewModel>>(_mapper.Map<CategoryViewModel[]>(categories));
    }
}
