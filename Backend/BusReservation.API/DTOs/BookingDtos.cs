namespace BusReservation.API.DTOs
{
    public class SearchRequestDto
    {
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime JourneyDate { get; set; }
    }

    public class AvailableBusDto
    {
        public int ScheduleId { get; set; }
        public string BusName { get; set; } = string.Empty;
        public string BusNumber { get; set; } = string.Empty;
        public string BusType { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime JourneyDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public TimeSpan Duration { get; set; }
        public string Amenities { get; set; } = string.Empty;
    }

    public class BookingRequestDto
    {
        public int ScheduleId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public List<string> SeatNumbers { get; set; } = new List<string>();
    }

    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public string BookingReference { get; set; } = string.Empty;
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string BusName { get; set; } = string.Empty;
        public string BusNumber { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int NumberOfSeats { get; set; }
        public string SeatNumbers { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; } = string.Empty;
    }

    public class CancellationRequestDto
    {
        public string BookingReference { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
    }
}
