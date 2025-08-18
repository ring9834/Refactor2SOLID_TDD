using ClassLib_Unitest;
using Microsoft.EntityFrameworkCore;

namespace Xunitest
{
    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture2>
    {
        // This class has no code; it defines the collection.
    }

    // The creation of the ProductRepositoryTests object is handled automatically by the testing framework
    // (xUnit, as indicated by the [Fact] attributes) when the tests are executed.
    // The [Collection("DatabaseCollection")] attribute indicates that all tests in the ProductRepositoryTests class share the same instance of the DatabaseFixture2 fixture.
    [Collection("DatabaseCollection")]
    public class ProductRepositoryTests
    {
        private readonly TestDbContext _context;
        private readonly ProductRepository _repository;

        // The DatabaseFixture2 is a test fixture that provides shared setup logic, likely including the DbContextOptions for an in-memory database
        // xUnit injects the DatabaseFixture2 instance into the constructor when it creates the ProductRepositoryTests object.
        public ProductRepositoryTests(DatabaseFixture2 fixture)
        {
            _context = new TestDbContext(fixture.Options);
            _repository = new ProductRepository(_context);
        }

        // xUnit creates a new instance of the test class (ProductRepositoryTests) for each test method.
        [Fact]
        public async Task AddProductAsync_ValidProduct_SavesToDatabase()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Tablet" };

            // Act
            await _repository.AddProductAsync(product);

            // Assert
            var savedProduct = await _context.Products.FindAsync(1);
            Assert.NotNull(savedProduct);
            Assert.Equal("Tablet", savedProduct.Name);
        }

        [Fact]
        public async Task GetProductAsync_ExistingProduct_ReturnsProduct()
        {
            // Arrange
            var product = new Product { Id = 2, Name = "Phone" };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetProductAsync(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Phone", result.Name);
        }
    }
}
