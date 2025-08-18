using ClassLib_Unitest;

namespace Xunitest
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 5;
            int b = 3;
            int expected = 8;

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act & Assert
            // Uses Assert.Throws to verify the correct exception is thrown.
            var exception = Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
            Assert.Equal("Cannot divide by zero.", exception.Message);
        }
    }
}
