using System;
using BusReservation.Domain.ValueObjects;

namespace BusReservation.Domain.Entities
{
    /// <summary>
    /// Booking Aggregate Root - represents a bus ticket booking
    /// Implements DDD principles with domain logic and value objects
    /// </summary>
    public class Booking
    {
        public int BookingId { get; set; }
        public string BookingReference { get; set; } = string.Empty;
        public int ScheduleId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
        public string PassengerGender { get; set; } = "Not Specified";
        public int NumberOfSeats { get; set; }
        public string SeatNumbers { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string BookingStatus { get; set; } = "Confirmed";
        public DateTime? CancellationDate { get; set; }
        
        public Schedule Schedule { get; set; } = null!;

        /// <summary>
        /// Domain method to cancel a booking
        /// Ensures business rules are enforced
        /// </summary>
        public bool CanBeCancelled()
        {
            // Cannot cancel if already cancelled
            if (BookingStatus == "Cancelled")
                return false;

            // Cannot cancel if past journey date (24 hours before departure)
            if (Schedule != null && Schedule.DepartureTime <= DateTime.UtcNow.AddHours(24))
                return false;

            return true;
        }

        /// <summary>
        /// Domain method to cancel booking
        /// </summary>
        public void Cancel()
        {
            if (!CanBeCancelled())
                throw new InvalidOperationException("This booking cannot be cancelled at this time.");

            BookingStatus = "Cancelled";
            CancellationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Domain method to validate booking integrity
        /// </summary>
        public void ValidateBooking()
        {
            if (NumberOfSeats <= 0)
                throw new InvalidOperationException("Number of seats must be greater than zero.");

            if (string.IsNullOrEmpty(PassengerName))
                throw new InvalidOperationException("Passenger name is required.");

            if (string.IsNullOrEmpty(PassengerEmail) || !PassengerEmail.Contains("@"))
                throw new InvalidOperationException("Valid email is required.");

            if (TotalAmount < 0)
                throw new InvalidOperationException("Total amount cannot be negative.");
        }

        /// <summary>
        /// Calculates the refund amount based on cancellation policy
        /// </summary>
        public decimal CalculateRefundAmount()
        {
            if (BookingStatus != "Cancelled")
                return 0;

            var hoursSinceCancellation = (DateTime.UtcNow - CancellationDate!.Value).TotalHours;
            
            // 100% refund if cancelled more than 24 hours before departure
            if (hoursSinceCancellation > 24)
                return TotalAmount;

            // 50% refund if cancelled 12-24 hours before departure
            if (hoursSinceCancellation > 12)
                return TotalAmount * 0.5m;

            // No refund if cancelled within 12 hours
            return 0;
        }
    }
}
