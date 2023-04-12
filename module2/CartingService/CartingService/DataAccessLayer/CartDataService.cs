using CartingService.DomainModelLayer;

namespace CartingService.DataAccessLayer;

public class CartDataService : ICartDataService
{
    private readonly IRepository<Cart> _cartRepository;

    public CartDataService(IRepository<Cart> cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public void Create(Cart cart)
    {
        _cartRepository.Create(cart);
    }

    public void Update(Cart cart)
    {
        _cartRepository.Update(cart);
    }

    public void Delete(Guid id)
    {
        _cartRepository.Delete(id);
    }

    public Cart? GetCartById(Guid id)
    {
        return _cartRepository.GetById(id);
    }

    public IEnumerable<Cart> GetAll()
    {
        return _cartRepository.GetAll();
    }
}
