namespace ClassLib_Unitest
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string? currency)
        {
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public override bool Equals(object? obj) =>
            obj is Money other &&
            Amount == other.Amount &&
            Currency == other.Currency;

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
    }
}
