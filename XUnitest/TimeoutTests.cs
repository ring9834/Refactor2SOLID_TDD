using ClassLib_Unitest;

namespace Xunitest
{
    public class TimeoutTests
    {
        // Uses [Fact(Timeout = 100)] to enforce a maximum execution time.
        [Fact(Timeout = 100)]
        public async Task PerformLongOperationAsync_TakesTooLong_ThrowsTimeout()
        {
            // Arrange
            var service = new OperationService();

            // Act & Assert
            await Assert.ThrowsAsync<TimeoutException>(() => service.PerformLongOperationAsync());
        }
    }
}
