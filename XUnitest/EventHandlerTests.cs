using ClassLib_Unitest;

namespace Xunitest
{
    public class EventHandlerTests
    {
        [Fact]
        public void UpdateStock_ValidLevel_RaisesStockLevelChangedEvent()
        {
            // Arrange
            var stock = new Stock();
            int receivedLevel = 0;
            stock.StockLevelChanged += (sender, level) => receivedLevel = level;

            // Act
            stock.UpdateStock(100);

            // Assert
            Assert.Equal(100, receivedLevel);
        }
    }
}
