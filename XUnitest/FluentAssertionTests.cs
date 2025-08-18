using ClassLib_Unitest;
using FluentAssertions;

namespace Xunitest
{
    // Uses FluentAssertions for readable and flexible object comparison
    // with Richer, More Descriptive Failure Messages
    // FluentAssertions comes with many powerful assertions that xUnit lacks: ContainInOrder, BeEquivalentTo, HaveCount, etc.
    // FluentAssertions allows chaining for multiple checks in one statement: result.Should().BeGreaterThan(0).And.BeLessThan(100);
    public class FluentAssertionTests
    {
        [Fact]
        public void CreateOrder_ValidInput_ReturnsCorrectOrder()
        {
            // Arrange
            var service = new OrderService();
            int id = 1;
            string customerName = "John Doe";
            decimal total = 99.99m;
            var expected = new Order { Id = 1, CustomerName = "John Doe", Total = 99.99m };

            // Act
            var result = service.CreateOrder(id, customerName, total);

            // Assert
            result.Should().BeEquivalentTo(expected); // Using FluentAssertions
        }
    }
}
