namespace MyLibrary;

// A class handles different types of calculations with conditionals, making it hard to extend.
// Violates Open/Closed Principle (adding a new payment type requires modifying the class).
// Uses magic strings for payment types.
public class PaymentCalculator
{
    public decimal CalculatePayment(string paymentType, decimal amount)
    {
        if (paymentType == "CreditCard")
        {
            return amount + (amount * 0.02m); // 2% fee
        }
        else if (paymentType == "PayPal")
        {
            return amount + 0.50m; // Flat fee
        }
        else
        {
            throw new ArgumentException("Unknown payment type");
        }
    }
}
