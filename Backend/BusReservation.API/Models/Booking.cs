namespace BusReservation.API.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string BookingReference { get; set; } = string.Empty;
        public int ScheduleId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public string SeatNumbers { get; set; } = string.Empty; // Comma-separated
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string BookingStatus { get; set; } = "Confirmed"; // Confirmed, Cancelled
        public DateTime? CancellationDate { get; set; }
        
        // Navigation properties
        public Schedule Schedule { get; set; } = null!;
    }
}
