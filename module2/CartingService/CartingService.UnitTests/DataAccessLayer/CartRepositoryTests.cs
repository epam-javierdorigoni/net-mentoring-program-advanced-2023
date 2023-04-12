using CartingService.DataAccessLayer;
using CartingService.DomainModelLayer;
using LiteDB;

namespace CartingService.UnitTests.DataAccessLayer;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[NonParallelizable]
public class CartRepositoryTests
{
    private const string TestDbName = "C:\\testDb.db";
    private const string TestCollectionName = "carts";

    private LiteDatabase _testDb;
    private LiteDbRepository<Cart> _repository;

    [SetUp]
    public void Setup()
    {
        // Create a new in-memory database for each test
        _testDb = new LiteDatabase(new MemoryStream());
        _repository = new LiteDbRepository<Cart>(TestDbName, TestCollectionName);
    }

    [Test]
    public void GetCartById_ReturnsCart_WhenCartExists()
    {
        // Arrange
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            Items = new List<CartItem>
            {
                new CartItem { Name = "Product A", Price = 9.99m, Quantity = 2 },
                new CartItem { Name = "Product B", Price = 19.99m, Quantity = 1 }
            }
        };

        // Add the cart to the test database
        var collection = _testDb.GetCollection<Cart>(TestCollectionName);
        collection.Insert(cart);

        // Act
        var retrievedCart = _repository.GetById(cart.Id);

        // Assert
        Assert.IsNotNull(retrievedCart);
        Assert.That(retrievedCart.Id, Is.EqualTo(cart.Id));
        Assert.That(retrievedCart.Items.Count, Is.EqualTo(cart.Items.Count));
    }

    [Test]
    public void GetCartById_ReturnsNull_WhenCartDoesNotExist()
    {
        // Arrange
        var nonexistentId = Guid.NewGuid();

        // Act
        var retrievedCart = _repository.GetById(nonexistentId);

        // Assert
        Assert.IsNull(retrievedCart);
    }

    [Test]
    public void Add_InsertsCartIntoDatabase()
    {
        // Arrange
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            Items = new List<CartItem>
            {
                new CartItem { Name = "Product C", Price = 14.99m, Quantity = 3 }
            }
        };

        // Act
        _repository.Create(cart);

        // Assert
        var collection = _testDb.GetCollection<Cart>(TestCollectionName);
        var retrievedCart = collection.FindById(cart.Id);
        Assert.IsNotNull(retrievedCart);
        Assert.That(retrievedCart.Id, Is.EqualTo(cart.Id));
        Assert.That(retrievedCart.Items.Count, Is.EqualTo(cart.Items.Count));
    }

    [Test]
    public void Update_ModifiesCartInDatabase()
    {
        // Arrange
        var cartId = Guid.NewGuid();

        var cart = new Cart
        {
            Id = cartId,
            Items = new List<CartItem>
            {
                new CartItem { Name = "Product A", Price = 9.99m, Quantity = 2 },
                new CartItem { Name = "Product B", Price = 19.99m, Quantity = 1 }
            }
        };

        // Add the cart to the test database
        var collection = _testDb.GetCollection<Cart>(TestCollectionName);
        collection.Insert(cart);

        // Update the cart's customer name and quantity of the first item
        var retrievedCart = _repository.GetById(cart.Id);
        retrievedCart.Id = cartId;
        retrievedCart.Items[0].Quantity = 3;

        // Act
        _repository.Update(retrievedCart);

        // Assert
        var updatedCart = collection.FindById(cart.Id);
        Assert.IsNotNull(updatedCart);
        Assert.That(updatedCart.Id, Is.EqualTo(retrievedCart.Id));
        Assert.That(retrievedCart.Items.Count, Is.EqualTo(cart.Items.Count));
    }
}
