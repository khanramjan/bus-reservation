using System;

namespace BusReservation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object for Money representing price
    /// </summary>
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency = "BDT")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative", nameof(amount));

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency cannot be empty", nameof(currency));

            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money? other)
        {
            if (other is null) return false;
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Currency} {Amount:F2}";
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot add monies with different currencies");
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator *(Money money, int multiplier)
        {
            return new Money(money.Amount * multiplier, money.Currency);
        }

        public static bool operator ==(Money? left, Money? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Money? left, Money? right)
        {
            return !(left == right);
        }
    }
}
