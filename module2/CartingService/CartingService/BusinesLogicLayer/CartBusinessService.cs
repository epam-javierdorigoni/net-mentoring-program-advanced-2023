using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;

namespace CartingService.BusinessLogicLayer;

public class CartBusinessService : ICartBusinessService
{
    private readonly ICartDataService _cartDataAccess;

    public CartBusinessService(ICartDataService cartDataAccess)
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

    public Cart? AddItemToCart(Guid cartId, CartItem cartItemToAdd)
    {
        try
        {
            var cart = _cartDataAccess.GetCartById(cartId);

            if (cart == null)
            {
                return null;
            }

            if (cart.Items.Contains(cartItemToAdd))
            {
                throw new CartItemAlreadyAddedException();
            }

            cart.Items.Add(cartItemToAdd);

            _cartDataAccess.Update(cart);
            return cart;
        }
        catch (CartNotFoundException)
        {
            return null;
        }
    }

    public bool RemoveItemFromCart(Guid cartId, int cartItemId)
    {
        try
        {
            var cart = _cartDataAccess.GetCartById(cartId);

            if (cart == null)
            {
                return false;
            }

            var cartItem = cart.Items.Find(x => x.Id == cartItemId);

            if (cartItem == null)
            {
                return true;
            }

            return cart.Items.Remove(cartItem);
        }
        catch (CartNotFoundException)
        {
            return false;
        }
    }
}