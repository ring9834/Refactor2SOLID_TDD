namespace MyLibrary;

// Used domain-specific names (CustomerStatus instead of string).
// Added input validation to align with business rules.
// Introduced an enum to represent valid states.
public class After10
{
    public void UpdateCustomerStatus(int customerId, CustomerStatus status)
    {
        if (customerId <= 0)
            throw new ArgumentException("Customer ID must be positive", nameof(customerId));

        Console.WriteLine($"Updating customer {customerId} to status {status}");
    }

    public enum CustomerStatus { Active, Suspended, Terminated }
}
