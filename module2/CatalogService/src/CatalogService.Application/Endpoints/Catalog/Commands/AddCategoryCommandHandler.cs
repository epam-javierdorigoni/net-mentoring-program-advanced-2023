using AutoMapper;
using CatalogService.Application.Interfaces;
using CatalogService.Application.Interfaces.Persistence.DataServices.Category.Commands;
using CatalogService.Application.Models;
using CatalogService.Application.Models.Enumerations;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Endpoints.Catalog.Commands;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, EndpointResult<CategoryViewModel>>
{
    public readonly IRequestValidator<AddCategoryCommand> _requestValidator;
    public readonly IAddCategoryDataService _addCategoryDataService;
    public readonly IMapper _mapper;

    public AddCategoryCommandHandler(
        IRequestValidator<AddCategoryCommand> requestValidator,
        IAddCategoryDataService addCategoryDataService,
        IMapper mapper
    )
    {
        _requestValidator = requestValidator;
        _addCategoryDataService = addCategoryDataService;
        _mapper = mapper;
    }

    public async Task<EndpointResult<CategoryViewModel>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationErrors = _requestValidator.ValidateRequest(request);
        if (validationErrors.Count() > 0)
            return new EndpointResult<CategoryViewModel>(EndpointResultStatus.Invalid, validationErrors.ToArray());

        var catalog = await _addCategoryDataService.ExecuteAsync(_mapper.Map<Category>(request));
        return new EndpointResult<CategoryViewModel>(_mapper.Map<CategoryViewModel>(catalog));
    }
}
