using CartingService.DomainModelLayer;
using LiteDB;

namespace CartingService.DataAccessLayer;

public class CartDataAccess : ICartDataAccess
{
    public Cart? GetCartById(Guid cartId)
    {
        using (var db = new LiteDatabase("CartingService.db"))
        {
            var carts = db.GetCollection<Cart>("carts");
            
            return carts
                .Include(x => x.Items)
                .Find(x => x.Id == cartId)
                .SingleOrDefault();
        }
    }

    public void RemoveItemFromCart(Guid cartId, int itemCartId)
    {
        using (var db = new LiteDatabase("CartingService.db"))
        {
            var carts = db.GetCollection<Cart>("carts");

            var cartFound = carts
                .Include(x => x.Items)
                .Find(x => x.Id == cartId)
                .SingleOrDefault() 
                ?? throw new Exception($"Cart {cartId} not found");

            var itemFound = (cartFound.Items?.SingleOrDefault(x => x.Id == itemCartId)) 
                ?? throw new Exception($"Item {itemCartId} not found.");

            cartFound.Items.ToList().Remove(itemFound);    
            
            // TODO persist the changes on CartFound with this item removed

        }
    }
}