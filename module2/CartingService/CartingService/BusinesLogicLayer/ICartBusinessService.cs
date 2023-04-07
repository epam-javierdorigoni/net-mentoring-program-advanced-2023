using CartingService.DomainModelLayer;

namespace CartingService.BusinessLogicLayer;

public interface ICartBusinessService
{
    IEnumerable<CartItem> GetItemsByCartId(Guid id);
    decimal? GetAmmountToPayCart(Guid id);
}