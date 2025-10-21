namespace BusReservation.API.Models
{
    public class Bus
    {
        public int BusId { get; set; }
        public string BusNumber { get; set; } = string.Empty;
        public string BusName { get; set; } = string.Empty;
        public string BusType { get; set; } = string.Empty; // AC, Non-AC, Sleeper
        public int TotalSeats { get; set; }
        public decimal BasePrice { get; set; }
        public string Amenities { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
