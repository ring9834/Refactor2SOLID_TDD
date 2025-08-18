using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.InMemory;

namespace ClassLib_Unitest
{
    public class DatabaseFixture2 : IDisposable
    {
        public DbContextOptions<TestDbContext> Options { get; }

        public DatabaseFixture2()
        {
            // This creates a builder for configuring options for a specific DbContext.
            // The DbContextOptionsBuilder is used to set up how the DbContext will connect to a database and configure its behavior.
            Options = new DbContextOptionsBuilder<TestDbContext>()
                // Configures the DbContext to use EF Core's in-memory database provider instead of a real database like SQL Server or SQLite.
                // The Guid.NewGuid().ToString() generates a unique database name for each test fixture, ensuring that each test runs against a fresh, isolated in-memory database.
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique database per fixture
                .Options;
        }

        public void Dispose()
        {
            // Cleanup if needed
        }
    }

    public class TestDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
    }

    public class ProductRepository
    {
        private readonly TestDbContext _context;

        public ProductRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
