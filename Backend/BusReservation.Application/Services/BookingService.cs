using BusReservation.ApplicationContracts.DTOs;
using BusReservation.ApplicationContracts.Interfaces;
using BusReservation.Domain.Entities;

namespace BusReservation.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IScheduleRepository scheduleRepository, IBookingRepository bookingRepository)
        {
            _scheduleRepository = scheduleRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<List<AvailableBusDto>> SearchAvailableBusesAsync(SearchRequestDto searchRequest)
        {
            var schedules = await _scheduleRepository.SearchAvailableBusesAsync(
                searchRequest.Source,
                searchRequest.Destination,
                searchRequest.JourneyDate
            );

            return schedules.Select(s => new AvailableBusDto
            {
                ScheduleId = s.ScheduleId,
                BusName = s.Bus.BusName,
                BusNumber = s.Bus.BusNumber,
                BusType = s.Bus.BusType,
                Source = s.Route.Source,
                Destination = s.Route.Destination,
                DepartureTime = s.DepartureTime,
                ArrivalTime = s.ArrivalTime,
                JourneyDate = s.JourneyDate,
                Price = s.Price,
                AvailableSeats = s.AvailableSeats,
                Duration = s.Route.EstimatedDuration,
                Amenities = s.Bus.Amenities
            }).ToList();
        }

        public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto bookingRequest)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(bookingRequest.ScheduleId);
            
            if (schedule == null)
                throw new Exception("Schedule not found");

            if (schedule.AvailableSeats < bookingRequest.NumberOfSeats)
                throw new Exception("Not enough seats available");

            // Generate booking reference
            var bookingReference = $"BR{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";

            var booking = new Booking
            {
                BookingReference = bookingReference,
                ScheduleId = bookingRequest.ScheduleId,
                PassengerName = bookingRequest.PassengerName,
                PassengerEmail = bookingRequest.PassengerEmail,
                PassengerPhone = bookingRequest.PassengerPhone,
                PassengerGender = bookingRequest.PassengerGender,
                NumberOfSeats = bookingRequest.NumberOfSeats,
                SeatNumbers = string.Join(", ", bookingRequest.SeatNumbers),
                TotalAmount = schedule.Price * bookingRequest.NumberOfSeats,
                BookingDate = DateTime.UtcNow,
                BookingStatus = "Confirmed"
            };

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);

            // Update available seats
            schedule.AvailableSeats -= bookingRequest.NumberOfSeats;
            await _scheduleRepository.UpdateScheduleAsync(schedule);

            return new BookingResponseDto
            {
                BookingId = createdBooking.BookingId,
                BookingReference = createdBooking.BookingReference,
                PassengerName = createdBooking.PassengerName,
                PassengerEmail = createdBooking.PassengerEmail,
                BusName = schedule.Bus.BusName,
                BusNumber = schedule.Bus.BusNumber,
                Source = schedule.Route.Source,
                Destination = schedule.Route.Destination,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                NumberOfSeats = createdBooking.NumberOfSeats,
                SeatNumbers = createdBooking.SeatNumbers,
                TotalAmount = createdBooking.TotalAmount,
                BookingDate = createdBooking.BookingDate,
                BookingStatus = createdBooking.BookingStatus
            };
        }

        public async Task<BookingResponseDto?> GetBookingDetailsAsync(string bookingReference)
        {
            var booking = await _bookingRepository.GetBookingByReferenceAsync(bookingReference);
            
            if (booking == null)
                return null;

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                BookingReference = booking.BookingReference,
                PassengerName = booking.PassengerName,
                PassengerEmail = booking.PassengerEmail,
                BusName = booking.Schedule.Bus.BusName,
                BusNumber = booking.Schedule.Bus.BusNumber,
                Source = booking.Schedule.Route.Source,
                Destination = booking.Schedule.Route.Destination,
                DepartureTime = booking.Schedule.DepartureTime,
                ArrivalTime = booking.Schedule.ArrivalTime,
                NumberOfSeats = booking.NumberOfSeats,
                SeatNumbers = booking.SeatNumbers,
                TotalAmount = booking.TotalAmount,
                BookingDate = booking.BookingDate,
                BookingStatus = booking.BookingStatus
            };
        }

        public async Task<List<BookingResponseDto>> GetBookingsByEmailAsync(string email)
        {
            var bookings = await _bookingRepository.GetBookingsByEmailAsync(email);
            
            return bookings.Select(b => new BookingResponseDto
            {
                BookingId = b.BookingId,
                BookingReference = b.BookingReference,
                PassengerName = b.PassengerName,
                PassengerEmail = b.PassengerEmail,
                BusName = b.Schedule.Bus.BusName,
                BusNumber = b.Schedule.Bus.BusNumber,
                Source = b.Schedule.Route.Source,
                Destination = b.Schedule.Route.Destination,
                DepartureTime = b.Schedule.DepartureTime,
                ArrivalTime = b.Schedule.ArrivalTime,
                NumberOfSeats = b.NumberOfSeats,
                SeatNumbers = b.SeatNumbers,
                TotalAmount = b.TotalAmount,
                BookingDate = b.BookingDate,
                BookingStatus = b.BookingStatus
            }).ToList();
        }

        public async Task<bool> CancelBookingAsync(CancellationRequestDto cancellationRequest)
        {
            var booking = await _bookingRepository.GetBookingByReferenceAsync(cancellationRequest.BookingReference);
            
            if (booking == null || booking.PassengerEmail.ToLower() != cancellationRequest.PassengerEmail.ToLower())
                return false;

            if (booking.BookingStatus == "Cancelled")
                return false;

            booking.BookingStatus = "Cancelled";
            booking.CancellationDate = DateTime.UtcNow;
            await _bookingRepository.UpdateBookingAsync(booking);

            // Restore available seats
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(booking.ScheduleId);
            if (schedule != null)
            {
                schedule.AvailableSeats += booking.NumberOfSeats;
                await _scheduleRepository.UpdateScheduleAsync(schedule);
            }

            return true;
        }
    }
}
