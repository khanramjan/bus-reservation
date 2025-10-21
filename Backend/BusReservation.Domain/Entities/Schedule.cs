using System;

namespace BusReservation.Domain.Entities
{
    /// <summary>
    /// Schedule entity - represents a bus schedule for a route
    /// Implements DDD principles with domain logic
    /// </summary>
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
        public Route Route { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// Domain method to check if seats can be booked
        /// </summary>
        public bool CanBookSeats(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
                return false;

            if (!IsActive)
                return false;

            // Cannot book if departure is less than 1 hour away
            if (DepartureTime <= DateTime.UtcNow.AddHours(1))
                return false;

            return AvailableSeats >= numberOfSeats;
        }

        /// <summary>
        /// Domain method to book seats
        /// </summary>
        public void BookSeats(int numberOfSeats)
        {
            if (!CanBookSeats(numberOfSeats))
                throw new InvalidOperationException("Cannot book the requested number of seats.");

            AvailableSeats -= numberOfSeats;
        }

        /// <summary>
        /// Domain method to release seats (for cancellations)
        /// </summary>
        public void ReleaseSeats(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
                throw new InvalidOperationException("Number of seats must be greater than zero.");

            AvailableSeats += numberOfSeats;

            // Ensure we don't exceed bus capacity
            if (AvailableSeats > Bus.TotalSeats)
                AvailableSeats = Bus.TotalSeats;
        }

        /// <summary>
        /// Gets the journey duration
        /// </summary>
        public TimeSpan GetJourneyDuration()
        {
            return ArrivalTime - DepartureTime;
        }

        /// <summary>
        /// Checks if schedule is fully booked
        /// </summary>
        public bool IsFullyBooked()
        {
            return AvailableSeats == 0;
        }

        /// <summary>
        /// Gets occupancy percentage
        /// </summary>
        public decimal GetOccupancyPercentage()
        {
            if (Bus.TotalSeats == 0)
                return 0;

            return ((Bus.TotalSeats - AvailableSeats) * 100m) / Bus.TotalSeats;
        }
    }
}
