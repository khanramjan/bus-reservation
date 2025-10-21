using Microsoft.EntityFrameworkCore;
using BusReservation.API.Models;

namespace BusReservation.API.Data
{
    public class BusReservationDbContext : DbContext
    {
        public BusReservationDbContext(DbContextOptions<BusReservationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusRoute> Routes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Bus configuration
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.BusId);
                entity.Property(e => e.BusNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BusName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.BusType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BasePrice).HasColumnType("decimal(18,2)");
            });

            // Route configuration
            modelBuilder.Entity<BusRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId);
                entity.Property(e => e.Source).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Destination).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Distance).HasColumnType("decimal(18,2)");
            });

            // Schedule configuration
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                
                entity.HasOne(e => e.Bus)
                    .WithMany(b => b.Schedules)
                    .HasForeignKey(e => e.BusId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Route)
                    .WithMany(r => r.Schedules)
                    .HasForeignKey(e => e.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Booking configuration
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);
                entity.Property(e => e.BookingReference).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PassengerName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PassengerEmail).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PassengerPhone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.BookingStatus).IsRequired().HasMaxLength(50);

                entity.HasOne(e => e.Schedule)
                    .WithMany(s => s.Bookings)
                    .HasForeignKey(e => e.ScheduleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Buses - Expanded with more operators
            modelBuilder.Entity<Bus>().HasData(
                // Green Line Paribahan
                new Bus { BusId = 1, BusNumber = "DH-11-5678", BusName = "Green Line Paribahan", BusType = "AC Sleeper", TotalSeats = 40, BasePrice = 1200, Amenities = "WiFi, Charging Point, Water Bottle", IsActive = true },
                new Bus { BusId = 5, BusNumber = "DH-11-5679", BusName = "Green Line Paribahan", BusType = "AC Sleeper", TotalSeats = 40, BasePrice = 1250, Amenities = "WiFi, Charging Point, Water Bottle", IsActive = true },
                
                // Shyamoli Paribahan
                new Bus { BusId = 2, BusNumber = "CH-15-9012", BusName = "Shyamoli Paribahan", BusType = "Non-AC Seater", TotalSeats = 45, BasePrice = 800, Amenities = "Water Bottle", IsActive = true },
                new Bus { BusId = 6, BusNumber = "CH-15-9013", BusName = "Shyamoli Paribahan", BusType = "AC Seater", TotalSeats = 45, BasePrice = 950, Amenities = "WiFi, Water Bottle", IsActive = true },
                
                // Hanif Enterprise
                new Bus { BusId = 3, BusNumber = "DH-12-3456", BusName = "Hanif Enterprise", BusType = "AC Seater", TotalSeats = 50, BasePrice = 1000, Amenities = "WiFi, Water Bottle", IsActive = true },
                new Bus { BusId = 7, BusNumber = "DH-12-3457", BusName = "Hanif Enterprise", BusType = "AC Sleeper", TotalSeats = 38, BasePrice = 1300, Amenities = "WiFi, Charging Point, Blanket", IsActive = true },
                
                // Ena Transport
                new Bus { BusId = 4, BusNumber = "RJ-10-7890", BusName = "Ena Transport", BusType = "AC Sleeper", TotalSeats = 35, BasePrice = 1400, Amenities = "WiFi, Charging Point, Blanket, Water Bottle", IsActive = true },
                new Bus { BusId = 8, BusNumber = "RJ-10-7891", BusName = "Ena Transport", BusType = "AC Seater", TotalSeats = 48, BasePrice = 1100, Amenities = "WiFi, Water Bottle", IsActive = true },
                
                // National Travels (New)
                new Bus { BusId = 9, BusNumber = "CB-20-1001", BusName = "National Travels", BusType = "AC Sleeper", TotalSeats = 42, BasePrice = 1350, Amenities = "WiFi, Charging Point, Blanket, Water Bottle", IsActive = true },
                new Bus { BusId = 10, BusNumber = "CB-20-1002", BusName = "National Travels", BusType = "AC Seater", TotalSeats = 52, BasePrice = 1050, Amenities = "WiFi, Water Bottle", IsActive = true },
                
                // Grameen Travels (New)
                new Bus { BusId = 11, BusNumber = "DH-13-2001", BusName = "Grameen Travels", BusType = "AC Sleeper", TotalSeats = 39, BasePrice = 1280, Amenities = "WiFi, Charging Point, Blanket", IsActive = true },
                new Bus { BusId = 12, BusNumber = "DH-13-2002", BusName = "Grameen Travels", BusType = "Non-AC Seater", TotalSeats = 50, BasePrice = 750, Amenities = "Water Bottle", IsActive = true }
            );

            // Seed Routes - Expanded
            modelBuilder.Entity<BusRoute>().HasData(
                new BusRoute { RouteId = 1, Source = "Dhaka", Destination = "Rajshahi", Distance = 256, EstimatedDuration = TimeSpan.FromHours(6) },
                new BusRoute { RouteId = 2, Source = "Dhaka", Destination = "Chittagong", Distance = 264, EstimatedDuration = TimeSpan.FromHours(7) },
                new BusRoute { RouteId = 3, Source = "Dhaka", Destination = "Cox's Bazar", Distance = 400, EstimatedDuration = TimeSpan.FromHours(10) },
                new BusRoute { RouteId = 4, Source = "Dhaka", Destination = "Sylhet", Distance = 245, EstimatedDuration = TimeSpan.FromHours(6) },
                new BusRoute { RouteId = 5, Source = "Dhaka", Destination = "Khulna", Distance = 280, EstimatedDuration = TimeSpan.FromHours(7) },
                new BusRoute { RouteId = 6, Source = "Dhaka", Destination = "Barisal", Distance = 240, EstimatedDuration = TimeSpan.FromHours(6) },
                new BusRoute { RouteId = 7, Source = "Chittagong", Destination = "Cox's Bazar", Distance = 152, EstimatedDuration = TimeSpan.FromHours(3) },
                new BusRoute { RouteId = 8, Source = "Chittagong", Destination = "Sylhet", Distance = 350, EstimatedDuration = TimeSpan.FromHours(8) }
            );

            // Seed Schedules - Multiple per route with today and next 3 days
            var today = DateTime.Today;
            var day1 = today;
            var day2 = today.AddDays(1);
            var day3 = today.AddDays(2);
            var day4 = today.AddDays(3);

            modelBuilder.Entity<Schedule>().HasData(
                // ===== TODAY - Dhaka to Rajshahi =====
                new Schedule { ScheduleId = 1, BusId = 1, RouteId = 1, JourneyDate = day1, DepartureTime = day1.AddHours(22), ArrivalTime = day2.AddHours(4), Price = 1250, AvailableSeats = 35, IsActive = true },
                new Schedule { ScheduleId = 2, BusId = 5, RouteId = 1, JourneyDate = day1, DepartureTime = day1.AddHours(20), ArrivalTime = day2.AddHours(2), Price = 1300, AvailableSeats = 38, IsActive = true },
                new Schedule { ScheduleId = 101, BusId = 3, RouteId = 1, JourneyDate = day1, DepartureTime = day1.AddHours(18), ArrivalTime = day2.AddHours(0), Price = 1200, AvailableSeats = 42, IsActive = true },
                new Schedule { ScheduleId = 102, BusId = 11, RouteId = 1, JourneyDate = day1, DepartureTime = day1.AddHours(16), ArrivalTime = day1.AddHours(22), Price = 1350, AvailableSeats = 36, IsActive = true },
                
                // ===== TODAY - Dhaka to Chittagong =====
                new Schedule { ScheduleId = 3, BusId = 2, RouteId = 2, JourneyDate = day1, DepartureTime = day1.AddHours(7), ArrivalTime = day1.AddHours(14), Price = 850, AvailableSeats = 42, IsActive = true },
                new Schedule { ScheduleId = 4, BusId = 6, RouteId = 2, JourneyDate = day1, DepartureTime = day1.AddHours(10), ArrivalTime = day1.AddHours(17), Price = 1000, AvailableSeats = 40, IsActive = true },
                new Schedule { ScheduleId = 5, BusId = 9, RouteId = 2, JourneyDate = day1, DepartureTime = day1.AddHours(6), ArrivalTime = day1.AddHours(13), Price = 1400, AvailableSeats = 35, IsActive = true },
                new Schedule { ScheduleId = 103, BusId = 10, RouteId = 2, JourneyDate = day1, DepartureTime = day1.AddHours(12), ArrivalTime = day1.AddHours(19), Price = 950, AvailableSeats = 45, IsActive = true },
                new Schedule { ScheduleId = 104, BusId = 8, RouteId = 2, JourneyDate = day1, DepartureTime = day1.AddHours(8), ArrivalTime = day1.AddHours(15), Price = 1100, AvailableSeats = 43, IsActive = true },
                
                // ===== TODAY - Dhaka to Cox's Bazar =====
                new Schedule { ScheduleId = 6, BusId = 3, RouteId = 3, JourneyDate = day1, DepartureTime = day1.AddHours(21), ArrivalTime = day2.AddHours(7), Price = 1100, AvailableSeats = 48, IsActive = true },
                new Schedule { ScheduleId = 7, BusId = 7, RouteId = 3, JourneyDate = day1, DepartureTime = day1.AddHours(19), ArrivalTime = day2.AddHours(5), Price = 1450, AvailableSeats = 30, IsActive = true },
                new Schedule { ScheduleId = 105, BusId = 4, RouteId = 3, JourneyDate = day1, DepartureTime = day1.AddHours(20), ArrivalTime = day2.AddHours(6), Price = 1500, AvailableSeats = 32, IsActive = true },
                
                // ===== TODAY - Dhaka to Sylhet =====
                new Schedule { ScheduleId = 8, BusId = 4, RouteId = 4, JourneyDate = day1, DepartureTime = day1.AddHours(23), ArrivalTime = day2.AddHours(5), Price = 1450, AvailableSeats = 33, IsActive = true },
                new Schedule { ScheduleId = 9, BusId = 11, RouteId = 4, JourneyDate = day1, DepartureTime = day1.AddHours(22), ArrivalTime = day2.AddHours(4), Price = 1320, AvailableSeats = 34, IsActive = true },
                new Schedule { ScheduleId = 106, BusId = 1, RouteId = 4, JourneyDate = day1, DepartureTime = day1.AddHours(21), ArrivalTime = day2.AddHours(3), Price = 1380, AvailableSeats = 37, IsActive = true },
                
                // ===== TODAY - Dhaka to Khulna =====
                new Schedule { ScheduleId = 10, BusId = 8, RouteId = 5, JourneyDate = day1, DepartureTime = day1.AddHours(21), ArrivalTime = day2.AddHours(4), Price = 1200, AvailableSeats = 41, IsActive = true },
                new Schedule { ScheduleId = 11, BusId = 10, RouteId = 5, JourneyDate = day1, DepartureTime = day1.AddHours(20), ArrivalTime = day2.AddHours(3), Price = 1100, AvailableSeats = 46, IsActive = true },
                new Schedule { ScheduleId = 107, BusId = 6, RouteId = 5, JourneyDate = day1, DepartureTime = day1.AddHours(19), ArrivalTime = day2.AddHours(2), Price = 950, AvailableSeats = 42, IsActive = true },
                
                // ===== TODAY - Dhaka to Barisal =====
                new Schedule { ScheduleId = 12, BusId = 12, RouteId = 6, JourneyDate = day1, DepartureTime = day1.AddHours(8), ArrivalTime = day1.AddHours(14), Price = 800, AvailableSeats = 48, IsActive = true },
                new Schedule { ScheduleId = 13, BusId = 2, RouteId = 6, JourneyDate = day1, DepartureTime = day1.AddHours(14), ArrivalTime = day1.AddHours(20), Price = 850, AvailableSeats = 38, IsActive = true },
                new Schedule { ScheduleId = 108, BusId = 9, RouteId = 6, JourneyDate = day1, DepartureTime = day1.AddHours(11), ArrivalTime = day1.AddHours(17), Price = 900, AvailableSeats = 44, IsActive = true },
                
                // ===== TODAY - Chittagong to Cox's Bazar =====
                new Schedule { ScheduleId = 14, BusId = 9, RouteId = 7, JourneyDate = day1, DepartureTime = day1.AddHours(6), ArrivalTime = day1.AddHours(9), Price = 600, AvailableSeats = 37, IsActive = true },
                new Schedule { ScheduleId = 15, BusId = 6, RouteId = 7, JourneyDate = day1, DepartureTime = day1.AddHours(14), ArrivalTime = day1.AddHours(17), Price = 650, AvailableSeats = 39, IsActive = true },
                new Schedule { ScheduleId = 109, BusId = 5, RouteId = 7, JourneyDate = day1, DepartureTime = day1.AddHours(10), ArrivalTime = day1.AddHours(13), Price = 620, AvailableSeats = 36, IsActive = true },
                
                // ===== TODAY - Chittagong to Sylhet =====
                new Schedule { ScheduleId = 16, BusId = 11, RouteId = 8, JourneyDate = day1, DepartureTime = day1.AddHours(8), ArrivalTime = day1.AddHours(16), Price = 1350, AvailableSeats = 33, IsActive = true },
                new Schedule { ScheduleId = 110, BusId = 7, RouteId = 8, JourneyDate = day1, DepartureTime = day1.AddHours(9), ArrivalTime = day1.AddHours(17), Price = 1400, AvailableSeats = 29, IsActive = true },
                
                // ===== TOMORROW - Multiple routes =====
                new Schedule { ScheduleId = 111, BusId = 1, RouteId = 1, JourneyDate = day2, DepartureTime = day2.AddHours(22), ArrivalTime = day3.AddHours(4), Price = 1250, AvailableSeats = 40, IsActive = true },
                new Schedule { ScheduleId = 112, BusId = 2, RouteId = 2, JourneyDate = day2, DepartureTime = day2.AddHours(7), ArrivalTime = day2.AddHours(14), Price = 850, AvailableSeats = 45, IsActive = true },
                new Schedule { ScheduleId = 113, BusId = 3, RouteId = 3, JourneyDate = day2, DepartureTime = day2.AddHours(21), ArrivalTime = day3.AddHours(7), Price = 1100, AvailableSeats = 50, IsActive = true },
                new Schedule { ScheduleId = 114, BusId = 4, RouteId = 4, JourneyDate = day2, DepartureTime = day2.AddHours(23), ArrivalTime = day3.AddHours(5), Price = 1450, AvailableSeats = 35, IsActive = true },
                new Schedule { ScheduleId = 115, BusId = 8, RouteId = 5, JourneyDate = day2, DepartureTime = day2.AddHours(21), ArrivalTime = day3.AddHours(4), Price = 1200, AvailableSeats = 44, IsActive = true },
                new Schedule { ScheduleId = 116, BusId = 12, RouteId = 6, JourneyDate = day2, DepartureTime = day2.AddHours(8), ArrivalTime = day2.AddHours(14), Price = 800, AvailableSeats = 50, IsActive = true },
                new Schedule { ScheduleId = 117, BusId = 9, RouteId = 7, JourneyDate = day2, DepartureTime = day2.AddHours(6), ArrivalTime = day2.AddHours(9), Price = 600, AvailableSeats = 39, IsActive = true },
                new Schedule { ScheduleId = 118, BusId = 11, RouteId = 8, JourneyDate = day2, DepartureTime = day2.AddHours(8), ArrivalTime = day2.AddHours(16), Price = 1350, AvailableSeats = 35, IsActive = true }
            );
        }
    }
}
