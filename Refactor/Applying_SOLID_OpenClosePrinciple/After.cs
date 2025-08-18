namespace MyLibrary;

// Introduced an abstract class to define a common contract for payment processors.
public abstract class PaymentProcessor
{
    public abstract decimal CalculatePayment(decimal amount);
}

// Each payment type is a separate class, adhering to Open/Closed Principle (new types can be added without modifying existing code).
// Eliminated magic strings and conditional logic.
public class CreditCardProcessor : PaymentProcessor
{
    public override decimal CalculatePayment(decimal amount)
    {
        return amount + (amount * 0.02m); // 2% fee
    }
}

public class PayPalProcessor : PaymentProcessor
{
    public override decimal CalculatePayment(decimal amount)
    {
        return amount + 0.50m; // Flat fee
    }
}

public class PaymentService
{
    private readonly PaymentProcessor _processor;

    public PaymentService(PaymentProcessor processor)
    {
        _processor = processor ?? throw new ArgumentNullException(nameof(processor));
    }

    public decimal ProcessPayment(decimal amount)
    {
        return _processor.CalculatePayment(amount);
    }
}
