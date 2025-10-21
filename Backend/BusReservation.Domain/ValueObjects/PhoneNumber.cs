using System;
using System.Text.RegularExpressions;

namespace BusReservation.Domain.ValueObjects
{
    /// <summary>
    /// Value Object for Phone number with validation
    /// </summary>
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be empty", nameof(value));

            // Bangladesh phone number format: 01xxx-xxxxx or 01xxxxxxxxxx
            var phonePattern = @"^(?:\+?88)?01[3-9]\d{8}$";
            
            if (!Regex.IsMatch(value.Replace("-", ""), phonePattern))
                throw new ArgumentException("Invalid phone number format. Expected: 01xxx-xxxxx or 01xxxxxxxxxx", nameof(value));

            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PhoneNumber);
        }

        public bool Equals(PhoneNumber? other)
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

        public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
        {
            return !(left == right);
        }
    }
}
