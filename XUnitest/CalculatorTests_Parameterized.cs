using ClassLib_Unitest;

namespace Xunitest
{
    public class CalculatorTests_Parameterized
    {
        // [Theory]: Tests multiple scenarios with different inputs in a single test method.
        // [InlineData] provides test data, reducing code duplication.
        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-2, 7, 5)]
        [InlineData(0, 0, 0)]
        public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
