namespace CartingService.DomainModelLayer;

public class CartItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Image? Image { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}