using System;

namespace BusReservation.Domain.Entities
{
    /// <summary>
    /// Bus entity - represents a bus vehicle
    /// Implements DDD principles with domain logic
    /// </summary>
    public class Bus
    {
        public int BusId { get; set; }
        public string BusName { get; set; } = string.Empty;
        public string BusNumber { get; set; } = string.Empty;
        public string BusType { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public decimal BasePrice { get; set; }
        public string Amenities { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

        /// <summary>
        /// Domain method to validate bus information
        /// </summary>
        public void ValidateBusInfo()
        {
            if (string.IsNullOrWhiteSpace(BusName))
                throw new InvalidOperationException("Bus name is required.");

            if (string.IsNullOrWhiteSpace(BusNumber))
                throw new InvalidOperationException("Bus number is required.");

            if (TotalSeats <= 0)
                throw new InvalidOperationException("Bus must have at least 1 seat.");

            if (BasePrice < 0)
                throw new InvalidOperationException("Base price cannot be negative.");
        }

        /// <summary>
        /// Gets bus type description
        /// </summary>
        public string GetBusTypeDescription()
        {
            return BusType switch
            {
                "AC Sleeper" => "Air-conditioned sleeper with beds",
                "AC Seater" => "Air-conditioned seating",
                "Non-AC" => "Non air-conditioned seating",
                _ => BusType
            };
        }

        /// <summary>
        /// Calculates price based on bus type
        /// </summary>
        public decimal CalculateDynamicPrice(DateTime journeyDate, int availableSeats)
        {
            // Base price
            var price = BasePrice;

            // Peak hour surcharge (weekends and evenings)
            if (journeyDate.DayOfWeek == DayOfWeek.Friday || journeyDate.DayOfWeek == DayOfWeek.Saturday)
                price *= 1.2m;

            // High occupancy surcharge (less than 20% seats available)
            if (availableSeats < 0)
                price *= 1.15m;

            return price;
        }
    }
}
