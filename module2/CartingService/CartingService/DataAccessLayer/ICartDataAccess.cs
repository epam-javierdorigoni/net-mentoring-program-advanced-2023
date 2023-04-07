using CartingService.DomainModelLayer;

namespace CartingService.DataAccessLayer;

public interface ICartDataAccess
{
    Cart? GetCartById(Guid id);
    void RemoveItemFromCart(Guid cartId, int itemCartId);
}