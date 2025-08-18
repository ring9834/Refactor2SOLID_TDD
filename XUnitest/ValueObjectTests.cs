using ClassLib_Unitest;

namespace Xunitest
{
    // Tests equality and constructor validation for a value object.
    // Each test focuses on one aspect of the Money class (equality or validation).
    public class ValueObjectTests
    {
        [Fact]
        public void Equals_SameAmountAndCurrency_ReturnsTrue()
        {
            // Arrange
            var money1 = new Money(100.50m, "USD");
            var money2 = new Money(100.50m, "USD");

            // Act
            bool areEqual = money1.Equals(money2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_DifferentAmount_ReturnsFalse()
        {
            // Arrange
            var money1 = new Money(100.50m, "USD");
            var money2 = new Money(200.50m, "USD");

            // Act
            bool areEqual = money1.Equals(money2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void Constructor_NullCurrency_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Money(100, null));
        }
    }
}
