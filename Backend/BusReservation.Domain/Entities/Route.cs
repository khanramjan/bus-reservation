using System;

namespace BusReservation.Domain.Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public TimeSpan EstimatedDuration { get; set; }
        
        // Navigation properties
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
