using System.Diagnostics.CodeAnalysis;
using CatalogService.Api.Extensions;
using CatalogService.Application.Endpoints.Category.Commands;
using CatalogService.Application.Endpoints.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("api/v{version:apiVersion}/catalog")]
[ApiVersion("1.0")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetCategoryAsync([FromQuery] CatalogQuery request) =>
        (await _mediator.Send(request)).ToActionResult();

    [HttpPost]
    public async Task<ActionResult> AddPersonAsync([FromBody] AddPersonCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}
