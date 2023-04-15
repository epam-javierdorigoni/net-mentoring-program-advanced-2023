using System.Diagnostics.CodeAnalysis;
using CatalogService.Application.Interfaces.Services;

namespace CatalogService.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
