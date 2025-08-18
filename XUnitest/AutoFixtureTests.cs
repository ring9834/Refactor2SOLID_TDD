using ClassLib_Unitest;
using AutoFixture;

namespace Xunitest
{
    public class AutoFixtureTests
    {
        private readonly Fixture _fixture;

        public AutoFixtureTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ProcessOrder_ValidOrder_ReturnsTrue()
        {
            // Arrange
            // Uses AutoFixture to generate test data for Order, reducing manual setup.
            var order = _fixture.Build<Order>()
                .With(o => o.Total, 100.50m)
                .Create();
            var processor = new OrderProcessor();

            // Act
            bool result = processor.ProcessOrder(order);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ProcessOrder_NullOrder_ReturnsFalse()
        {
            // Arrange
            var processor = new OrderProcessor();

            // Act
            bool result = processor.ProcessOrder(null);

            // Assert
            Assert.False(result);
        }
    }
}
