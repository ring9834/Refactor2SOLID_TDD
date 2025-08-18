using ClassLib_Unitest;
using Moq;

namespace Xunitest
{
    public class RetryLogicTests
    {
        private readonly Mock<IExternalService> _mockExternalService;
        private readonly RetryService _service;

        public RetryLogicTests()
        {
            _mockExternalService = new Mock<IExternalService>();
            _service = new RetryService(_mockExternalService.Object);
        }

        [Fact]
        public async Task ExecuteWithRetryAsync_SucceedsOnSecondAttempt_ReturnsTrue()
        {
            // Arrange
            _mockExternalService
                // Uses Moq’s SetupSequence to define a sequence of return values for consecutive calls to TryOperationAsync.
                .SetupSequence(s => s.TryOperationAsync())
                // The first call to TryOperationAsync returns false, simulating a failed attempt.
                .ReturnsAsync(false)
                // The second call returns true, simulating a successful attempt.
                .ReturnsAsync(true);

            // Act
            bool result = await _service.ExecuteWithRetryAsync();

            // Assert
            Assert.True(result);
            _mockExternalService.Verify(s => s.TryOperationAsync(), Times.Exactly(2));
        }

        [Fact]
        public async Task ExecuteWithRetryAsync_FailsAllAttempts_ReturnsFalse()
        {
            // Arrange
            _mockExternalService
                // Uses Moq’s Setup to define the behavior of TryOperationAsync.
                .Setup(s => s.TryOperationAsync())
                // .ReturnsAsync(false) ensures that every call to TryOperationAsync returns false, mimicking a persistent failure
                // (an API or database operation that consistently fails).
                .ReturnsAsync(false); // Always fails

            // Act
            bool result = await _service.ExecuteWithRetryAsync();

            // Assert
            Assert.False(result);
            _mockExternalService.Verify(s => s.TryOperationAsync(), Times.Exactly(3));
        }
    }
}
