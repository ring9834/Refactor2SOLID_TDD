using ClassLib_Unitest;

namespace Xunitest
{
    public class IClassFixtureTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;


        public IClassFixtureTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetData_ValidId_ReturnsData()
        {
            // Arrange
            var repository = _fixture.Repository; // Assume Repository uses the fixture

            // Act
            var result = repository.IsUserActive(1);

            // Assert
            Assert.True(result);
        }
    }
}
