using ClassLib_Unitest;

namespace Xunitest
{
    // It implements the IAsyncLifetime interface to manage asynchronous setup and cleanup tasks for tests that involve file operations.
    // IAsyncLifetime is provided by xUnit to support asynchronous setup and cleanup for tests.
    public class IAsyncLifetimeTests : IAsyncLifetime
    {
        // _testFilePath is a private, readonly field that stores the path to a temporary test file (test.txt) in the system's temporary directory (%TEMP% on Windows).
        // Using a temporary file ensures tests don’t clutter the file system or interfere with other tests or applications.
        private readonly string _testFilePath = Path.Combine(Path.GetTempPath(), "test.txt");

        // InitializeAsync(): Runs before each test method to set up the test environment.
        public async Task InitializeAsync()
        {
            // Setup: Create an empty test file
            await File.WriteAllTextAsync(_testFilePath, string.Empty);
        }

        // DisposeAsync(): Runs after each test method to clean up resources.
        public async Task DisposeAsync()
        {
            // Cleanup: Delete the test file
            if (File.Exists(_testFilePath))
            {
                await Task.Run(() => File.Delete(_testFilePath));
            }
        }

        [Fact]
        public async Task WriteToFileAsync_ValidContent_WritesCorrectly()
        {
            // Arrange
            var service = new FileService();
            string content = "Hello, xUnit!";

            // Act
            await service.WriteToFileAsync(_testFilePath, content);

            // Assert
            string result = await File.ReadAllTextAsync(_testFilePath);
            Assert.Equal(content, result);
        }

        [Fact]
        public async Task ReadFromFileAsync_ExistingFile_ReturnsContent()
        {
            // Arrange
            var service = new FileService();
            string content = "Test content";
            await File.WriteAllTextAsync(_testFilePath, content);

            // Act
            string result = await service.ReadFromFileAsync(_testFilePath);

            // Assert
            Assert.Equal(content, result);
        }
    }
}
