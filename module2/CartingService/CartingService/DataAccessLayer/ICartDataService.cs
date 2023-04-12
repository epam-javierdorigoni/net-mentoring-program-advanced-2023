using CartingService.DomainModelLayer;

namespace CartingService.DataAccessLayer;

public interface ICartDataService
{
    void Create(Cart cart);
    void Update(Cart cart);
    void Delete(Guid id);
    Cart? GetCartById(Guid id);
    IEnumerable<Cart> GetAll();
}
