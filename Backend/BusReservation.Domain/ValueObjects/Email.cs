using System;

namespace BusReservation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object for Email address with validation
    /// </summary>
    public class Email : IEquatable<Email>
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty", nameof(value));

            if (!value.Contains("@") || !value.Contains("."))
                throw new ArgumentException("Invalid email format", nameof(value));

            Value = value.ToLower();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Email);
        }

        public bool Equals(Email? other)
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

        public static bool operator ==(Email? left, Email? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Email? left, Email? right)
        {
            return !(left == right);
        }
    }
}
