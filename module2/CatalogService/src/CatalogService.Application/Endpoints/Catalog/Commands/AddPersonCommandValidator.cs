using CatalogService.Application.Endpoints.Catalog.Commands;
using FluentValidation;

namespace CatalogService.Application.Endpoints.Catalog.Commands;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .Null();

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 50);
    }
}
