using CartingService.BusinessLogicLayer;
using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;
using Moq;

namespace CartingService.UnitTests.BusinessLogicLayer;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AddItemToCartTests
{
    private Mock<ICartDataService> _cartDataService;
    private CartBusinessService _cartBusinessService;

    private readonly Guid _cartId = Guid.NewGuid();
    private readonly CartItem _cartItemToAdd = new()
    {
        Id = 1,
        Name = "Product A",
        Price = 19.99m,
        Quantity = 5
    };

    [SetUp]
    public void Setup()
    {
        _cartDataService = new Mock<ICartDataService>();
        _cartBusinessService = new CartBusinessService(_cartDataService.Object);
    }

    [Test]
    public void Given_Cart_NotFound_When_Request_AddItemToCart_Then_Return_Null()
    {
        _cartDataService
            .Setup(x => x.GetCartById(_cartId))
            .Returns((Cart?)null);

        var result = _cartBusinessService.AddItemToCart(_cartId, _cartItemToAdd);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Given_Cart_DoesNotHaveItemToAdd_When_Request_AddItemToCart_Then_Return_CartWithAddedItem()
    {
        _cartDataService
            .Setup(x => x.GetCartById(It.IsAny<Guid>()))
            .Returns(new Cart()
            {
                Id = _cartId,
                Items = new List<CartItem>()
            });
        _cartDataService
            .Setup(x => x.Update(It.IsAny<Cart>()));

        var result = _cartBusinessService.AddItemToCart(_cartId, _cartItemToAdd);

        Assert.That(result, Is.Not.Null);
        Assert.That(result?.Items.Contains(_cartItemToAdd), Is.True);
    }

    [Test]
    public void Given_Cart_DoesHaveItemToAdd_When_Request_AddItemToCart_Then_Throws_CartItemAlreadyAddedException()
    {
        _cartDataService
            .Setup(x => x.GetCartById(It.IsAny<Guid>()))
            .Returns(new Cart()
            {
                Id = _cartId,
                Items = new List<CartItem>() { _cartItemToAdd }
            });

        Assert.Throws<CartItemAlreadyAddedException>(() => _cartBusinessService.AddItemToCart(_cartId, _cartItemToAdd));
    }
}