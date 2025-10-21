using BusReservation.ApplicationContracts.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusReservation.ApplicationContracts.Interfaces
{
    public interface IBookingService
    {
        Task<List<AvailableBusDto>> SearchAvailableBusesAsync(SearchRequestDto searchRequest);
        Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto bookingRequest);
        Task<BookingResponseDto?> GetBookingDetailsAsync(string bookingReference);
        Task<List<BookingResponseDto>> GetBookingsByEmailAsync(string email);
        Task<bool> CancelBookingAsync(CancellationRequestDto cancellationRequest);
    }
}
