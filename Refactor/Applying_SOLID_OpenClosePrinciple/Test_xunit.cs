using Xunit;
namespace MyLibrary;

// Injectable dependency
// Improved testability and maintainability.
public class PaymentService_xunittest
{
    [Fact]
    public void ProcessPayment_CreditCard_AddsTwoPercentFee()
    {
        // Arrange
        var processor = new CreditCardProcessor();
        var service = new PaymentService(processor);

        // Act
        var result = service.ProcessPayment(100.0m);

        // Assert
        Assert.Equal(102.0m, result);
    }
}
