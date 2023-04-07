using CartingService.DomainModelLayer;

namespace CartingService.BusinessLogicLayer;

public interface ICartBusinessService
{
    IEnumerable<CartItem> GetItemsByCartId(Guid id);
    Cart AddItemToCart(Guid cartId, CartItem item);
    decimal? GetAmmountToPayCart(Guid id);
}