using Moq;
using Xunit;
namespace MyLibrary;

// Injectable dependency
public class OrderProcessor_xunittest
{
    [Fact]
    public void CalculateTotal_ReturnsSumOfItemPrices()
    {
        // Arrange
        var mockDb = new Mock<IDatabase>();
        mockDb.Setup(db => db.GetItems()).Returns(new List<Item>
        {
            new Item { Price = 10.0m },
            new Item { Price = 20.0m }
        });
        var processor = new OrderProcessor_After(mockDb.Object);

        // Act
        var total = processor.CalculateTotal();

        // Assert
        Assert.Equal(30.0m, total);
    }
}
