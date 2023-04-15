using AutoMapper;
using CatalogService.Application.Endpoints.Catalog;
using CatalogService.Application.Endpoints.Catalog.Commands;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Mapping;

public class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        CreateMap<Category, CategoryViewModel>()
            .ReverseMap();
        CreateMap<AddCategoryCommand, Category>();
    }
}
