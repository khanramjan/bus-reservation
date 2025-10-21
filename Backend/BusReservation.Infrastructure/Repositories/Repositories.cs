using Microsoft.EntityFrameworkCore;
using BusReservation.ApplicationContracts.Interfaces;
using BusReservation.Domain.Entities;
using BusReservation.Infrastructure.Data;

namespace BusReservation.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly BusReservationDbContext _context;

        public ScheduleRepository(BusReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> SearchAvailableBusesAsync(string source, string destination, DateTime journeyDate)
        {
            return await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Route)
                .Where(s => s.Route.Source.ToLower() == source.ToLower() &&
                           s.Route.Destination.ToLower() == destination.ToLower() &&
                           s.JourneyDate.Date == journeyDate.Date &&
                           s.AvailableSeats > 0 &&
                           s.IsActive)
                .OrderBy(s => s.DepartureTime)
                .ToListAsync();
        }

        public async Task<Schedule?> GetScheduleByIdAsync(int scheduleId)
        {
            return await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Route)
                .FirstOrDefaultAsync(s => s.ScheduleId == scheduleId);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
    }

    public class BookingRepository : IBookingRepository
    {
        private readonly BusReservationDbContext _context;

        public BookingRepository(BusReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> GetBookingByReferenceAsync(string bookingReference)
        {
            return await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(s => s.Bus)
                .Include(b => b.Schedule)
                .ThenInclude(s => s.Route)
                .FirstOrDefaultAsync(b => b.BookingReference == bookingReference);
        }

        public async Task<List<Booking>> GetBookingsByEmailAsync(string email)
        {
            return await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(s => s.Bus)
                .Include(b => b.Schedule)
                .ThenInclude(s => s.Route)
                .Where(b => b.PassengerEmail.ToLower() == email.ToLower())
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
