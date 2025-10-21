using System;

namespace BusReservation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object for Booking Reference
    /// </summary>
    public class BookingReference : IEquatable<BookingReference>
    {
        public string Value { get; }

        public BookingReference(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Booking reference cannot be empty", nameof(value));

            if (value.Length < 10 || value.Length > 20)
                throw new ArgumentException("Booking reference must be between 10 and 20 characters", nameof(value));

            Value = value;
        }

        public static BookingReference Generate()
        {
            var reference = $"BR{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
            return new BookingReference(reference);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookingReference);
        }

        public bool Equals(BookingReference? other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(BookingReference? left, BookingReference? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(BookingReference? left, BookingReference? right)
        {
            return !(left == right);
        }
    }
}
