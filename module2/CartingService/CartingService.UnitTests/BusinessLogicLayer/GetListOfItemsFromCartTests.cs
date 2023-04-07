using CartingService.BusinessLogicLayer;
using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;
using Moq;

namespace CartingService.UnitTests.BusinessLogicLayer;

public class GetListOfItemsFromCartTests
{
    private Mock<CartDataAccess> _cartDataAccess;
    private CartBusinessService _cartBusinessService;

    [SetUp]
    public void Setup()
    {
        _cartDataAccess = new Mock<CartDataAccess>();
        _cartBusinessService = new CartBusinessService(_cartDataAccess.Object);
    }

    [Test]
    public void Given_Cart_HasManyItems_When_Request_GetItemsByCartId_Then_Return_Collection_Of_Items()
    {
        _cartDataAccess
            .Setup(x => x.GetCartById(It.IsAny<Guid>()))
            .Returns(new Cart()
            {
                Id = Guid.NewGuid(),
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Id = 1,
                        Name = "Item1",
                        Price = 20.50m,
                        Quantity = 3
                    },
                    new CartItem()
                    {
                        Id = 2,
                        Name = "Item2",
                        Price = 15.25m,
                        Quantity = 5
                    } 
                }
            });

        var result = _cartBusinessService.GetItemsByCartId(Guid.NewGuid());

        Assert.That(result, Is.Not.Null );
        Assert.That(result.Count, Is.EqualTo(2));
    }
}