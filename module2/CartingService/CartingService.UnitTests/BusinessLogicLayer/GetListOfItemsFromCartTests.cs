using CartingService.BusinessLogicLayer;
using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;
using Moq;

namespace CartingService.UnitTests.BusinessLogicLayer;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class GetListOfItemsFromCartTests
{
    private Mock<ICartDataService> _cartDataService;
    private CartBusinessService _cartBusinessService;

    private readonly Guid _cartId = Guid.NewGuid();

    [SetUp]
    public void Setup()
    {
        _cartDataService = new Mock<ICartDataService>();
        _cartBusinessService = new CartBusinessService(_cartDataService.Object);
    }

    [Test]
    public void Given_Cart_HasManyItems_When_Request_GetItemsByCartId_Then_Return_Collection_Of_Items()
    {
        _cartDataService
            .Setup(x => x.GetCartById(_cartId))
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

        var result = _cartBusinessService.GetItemsByCartId(_cartId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    public void Given_Cart_HasNoItems_When_Request_GetItemsByCartId_Then_Return_Empty_Items_Collection()
    {
        _cartDataService
            .Setup(x => x.GetCartById(_cartId))
            .Returns(new Cart()
            {
                Id = _cartId,
                Items = new List<CartItem>()
            });

        var result = _cartBusinessService.GetItemsByCartId(_cartId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]
    public void Given_CartId_NotFound_When_Request_GetItemsByCartId_Then_Return_Empty()
    {
        _cartDataService
            .Setup(x => x.GetCartById(It.IsAny<Guid>()))
            .Returns((Cart?)null);

        var result = _cartBusinessService.GetItemsByCartId(Guid.NewGuid());

        Assert.That(result, Is.Empty);
    }
}