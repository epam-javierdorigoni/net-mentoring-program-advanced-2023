using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;

namespace CartingService.BusinessLogicLayer;

public class CartBusinessService : ICartBusinessService
{
    private readonly ICartDataAccess _cartDataAccess;

    public CartBusinessService(ICartDataAccess cartDataAccess)
    {
        _cartDataAccess = cartDataAccess;
    }

    public IEnumerable<CartItem> GetItemsByCartId(Guid id)
    {
        var cart = _cartDataAccess.GetCartById(id);

        if (cart == null)
        {
            return new List<CartItem>();
        }

        return cart.Items;
    }

    public decimal? GetAmmountToPayCart(Guid id)
    {
        var cart = _cartDataAccess.GetCartById(id);

        if (cart == null || cart.Items == null || !cart.Items.Any())
        {
            return null;
        }

        var ammountToPay = 0.0m;
        foreach (var item in cart.Items)
        {
            ammountToPay += item.Price;
        }

        return ammountToPay;
    }

    public Cart AddItemToCart(Guid cartId, CartItem item) 
    {
        // Validation that the Cart doesn't contain the item


        // Call the DataAccessLayer to add and persist this new item

        // Return Cart
        throw new NotImplementedException();
    }

    public bool RemoveItemFromCart(Guid cartId, int itemCartId) 
    {
        try
        {
            _cartDataAccess.RemoveItemFromCart(cartId, itemCartId);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}