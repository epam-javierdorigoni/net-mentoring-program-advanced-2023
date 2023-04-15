using System.ComponentModel.DataAnnotations;

namespace CatalogService.Domain.Entities;

public class Item
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The Category/Product Name cannot exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }
}
