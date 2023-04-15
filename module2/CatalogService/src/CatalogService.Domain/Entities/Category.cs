using System.ComponentModel.DataAnnotations;

namespace CatalogService.Domain.Entities;

public class Category
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The Category/Product Name cannot exceed 50 characters.")]
    public string Name { get; set; } = "";

    public string? ImageUrl { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Category> ChildCategories { get; set; } = new List<Category>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
