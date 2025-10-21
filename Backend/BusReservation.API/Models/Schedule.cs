namespace BusReservation.API.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime JourneyDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public Bus Bus { get; set; } = null!;
        public BusRoute Route { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
