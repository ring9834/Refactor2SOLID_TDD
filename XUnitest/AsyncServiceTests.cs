using ClassLib_Unitest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunitest
{
    // test an asynchronous method using async/await in xUnit.
    public class AsyncServiceTests
    {
        [Fact]
        public async Task FetchDataAsync_ValidId_ReturnsData()
        {
            // Arrange
            var dataService = new DataAsyncService();
            int id = 1;
            string expected = "Data-1";

            // Act
            string result = await dataService.FetchDataAsync(id);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task FetchDataAsync_NegativeId_ThrowsArgumentException()
        {
            // Arrange
            var dataService = new DataAsyncService();
            int id = -1;

            // Act & Assert
            // Uses Assert.ThrowsAsync for async exception handling.
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => dataService.FetchDataAsync(id));
            Assert.Equal("Invalid ID", exception.Message);
        }
    }
}
