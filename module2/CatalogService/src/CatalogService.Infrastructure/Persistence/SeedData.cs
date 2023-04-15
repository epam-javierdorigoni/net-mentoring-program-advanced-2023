using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence;

public static class SeedDataExtension
{
    public static void SeedData(this ModelBuilder builder)
    {
        // TODO: Use this file to seed the database with any initial data that
        // should exist the first time the application is run.

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Brandon", LastName = "Smith", Active = true, CreatedBy = 1, CreatedOn = DateTime.UtcNow },
            new Category { Id = 2, Name = "Allison", LastName = "Brown", Active = true, CreatedBy = 1, CreatedOn = DateTime.UtcNow },
            new Category { Id = 3, Name = "Patricia", LastName = "McDonald", CreatedBy = 1, CreatedOn = DateTime.UtcNow }
        );
    }
}
