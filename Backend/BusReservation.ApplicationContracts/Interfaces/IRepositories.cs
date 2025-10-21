using BusReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusReservation.ApplicationContracts.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> SearchAvailableBusesAsync(string source, string destination, DateTime journeyDate);
        Task<Schedule?> GetScheduleByIdAsync(int scheduleId);
        Task UpdateScheduleAsync(Schedule schedule);
    }

    public interface IBookingRepository
    {
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking?> GetBookingByReferenceAsync(string bookingReference);
        Task<List<Booking>> GetBookingsByEmailAsync(string email);
        Task UpdateBookingAsync(Booking booking);
    }
}
