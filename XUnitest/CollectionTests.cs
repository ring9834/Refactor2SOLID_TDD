using ClassLib_Unitest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunitest
{
    public class CollectionTests
    {
        [Fact]
        public void FilterPositiveNumbers_MixedNumbers_ReturnsOnlyPositive()
        {
            // Arrange
            var processor = new ListProcessor();
            var input = new List<int> { -1, 0, 1, 2, -3, 4 };
            var expected = new List<int> { 1, 2, 4 };

            // Act
            var result = processor.FilterPositiveNumbers(input);

            // Assert
            // Uses Assert.Equal for exact collection matching and Assert.Contains/Assert.DoesNotContain for specific checks.
            Assert.Equal(expected, result);
            Assert.Contains(1, result);
            Assert.DoesNotContain(-1, result);
        }
    }
}
