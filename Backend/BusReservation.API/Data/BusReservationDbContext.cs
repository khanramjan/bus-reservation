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
            // Seed Buses
            modelBuilder.Entity<Bus>().HasData(
                new Bus { BusId = 1, BusNumber = "DH-11-5678", BusName = "Green Line Paribahan", BusType = "AC Sleeper", TotalSeats = 40, BasePrice = 1200, Amenities = "WiFi, Charging Point, Water Bottle", IsActive = true },
                new Bus { BusId = 2, BusNumber = "CH-15-9012", BusName = "Shyamoli Paribahan", BusType = "Non-AC Seater", TotalSeats = 45, BasePrice = 800, Amenities = "Water Bottle", IsActive = true },
                new Bus { BusId = 3, BusNumber = "DH-12-3456", BusName = "Hanif Enterprise", BusType = "AC Seater", TotalSeats = 50, BasePrice = 1000, Amenities = "WiFi, Water Bottle", IsActive = true },
                new Bus { BusId = 4, BusNumber = "RJ-10-7890", BusName = "Ena Transport", BusType = "AC Sleeper", TotalSeats = 35, BasePrice = 1400, Amenities = "WiFi, Charging Point, Blanket, Water Bottle", IsActive = true }
            );

            // Seed Routes
            modelBuilder.Entity<BusRoute>().HasData(
                new BusRoute { RouteId = 1, Source = "Dhaka", Destination = "Rajshahi", Distance = 256, EstimatedDuration = TimeSpan.FromHours(6) },
                new BusRoute { RouteId = 2, Source = "Dhaka", Destination = "Chittagong", Distance = 264, EstimatedDuration = TimeSpan.FromHours(7) },
                new BusRoute { RouteId = 3, Source = "Dhaka", Destination = "Cox's Bazar", Distance = 400, EstimatedDuration = TimeSpan.FromHours(10) },
                new BusRoute { RouteId = 4, Source = "Dhaka", Destination = "Sylhet", Distance = 245, EstimatedDuration = TimeSpan.FromHours(6) }
            );

            // Seed Schedules
            var baseDate = DateTime.Today.AddDays(1);
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { ScheduleId = 1, BusId = 1, RouteId = 1, JourneyDate = baseDate, DepartureTime = baseDate.AddHours(22), ArrivalTime = baseDate.AddDays(1).AddHours(4), Price = 1250, AvailableSeats = 40, IsActive = true },
                new Schedule { ScheduleId = 2, BusId = 2, RouteId = 2, JourneyDate = baseDate, DepartureTime = baseDate.AddHours(7), ArrivalTime = baseDate.AddHours(14), Price = 850, AvailableSeats = 45, IsActive = true },
                new Schedule { ScheduleId = 3, BusId = 3, RouteId = 3, JourneyDate = baseDate, DepartureTime = baseDate.AddHours(21), ArrivalTime = baseDate.AddDays(1).AddHours(7), Price = 1100, AvailableSeats = 50, IsActive = true },
                new Schedule { ScheduleId = 4, BusId = 4, RouteId = 4, JourneyDate = baseDate, DepartureTime = baseDate.AddHours(23), ArrivalTime = baseDate.AddDays(1).AddHours(5), Price = 1450, AvailableSeats = 35, IsActive = true }
            );
        }
    }
}
