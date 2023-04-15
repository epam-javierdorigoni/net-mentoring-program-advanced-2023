using AutoMapper;
using CatalogService.Application.Mapping;
using Xunit;

namespace CatalogService.Application.Tests.Mapping;

public class CategoryProfileTests
{
    [Fact]
    public void VerifyConfiguration()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<CatalogProfile>());

        configuration.AssertConfigurationIsValid();
    }
}
