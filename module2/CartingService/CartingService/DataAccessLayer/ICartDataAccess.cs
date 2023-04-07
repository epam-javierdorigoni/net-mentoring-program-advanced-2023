using CartingService.DomainModelLayer;

namespace CartingService.DataAccessLayer;

public interface ICartDataAccess
{
    Cart? GetCartById(Guid id); 
    Cart AddItemToCart(Guid cartId, CartItem item);
    void RemoveItemFromCart(Guid cartId, int itemCartId);
}