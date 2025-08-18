using ClassLib_Unitest;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Xunitest
{
    // Verifies HTTP status codes (Ok, NotFound) and response content.
    public class ControllerTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly ProductsController _controller;

        public ControllerTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetProduct_ExistingId_ReturnsOkWithProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Laptop" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetProduct(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(product, returnedProduct);
            _mockRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once());
        }

        [Fact]
        public async Task GetProduct_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(2)).ReturnsAsync((Product?)null!);

            // Act
            var result = await _controller.GetProduct(2);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockRepository.Verify(repo => repo.GetByIdAsync(2), Times.Once());
        }
    }
}
