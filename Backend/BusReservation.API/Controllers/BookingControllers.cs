using Microsoft.AspNetCore.Mvc;
using BusReservation.API.DTOs;
using BusReservation.API.Services;

namespace BusReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BusesController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<AvailableBusDto>>> SearchBuses([FromBody] SearchRequestDto searchRequest)
        {
            try
            {
                var availableBuses = await _bookingService.SearchAvailableBusesAsync(searchRequest);
                return Ok(availableBuses);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<BookingResponseDto>> CreateBooking([FromBody] BookingRequestDto bookingRequest)
        {
            try
            {
                var booking = await _bookingService.CreateBookingAsync(bookingRequest);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{bookingReference}")]
        public async Task<ActionResult<BookingResponseDto>> GetBooking(string bookingReference)
        {
            try
            {
                var booking = await _bookingService.GetBookingDetailsAsync(bookingReference);
                
                if (booking == null)
                    return NotFound(new { message = "Booking not found" });
                
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<List<BookingResponseDto>>> GetBookingsByEmail(string email)
        {
            try
            {
                var bookings = await _bookingService.GetBookingsByEmailAsync(email);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("cancel")]
        public async Task<ActionResult> CancelBooking([FromBody] CancellationRequestDto cancellationRequest)
        {
            try
            {
                var result = await _bookingService.CancelBookingAsync(cancellationRequest);
                
                if (!result)
                    return BadRequest(new { message = "Unable to cancel booking. Please check your details." });
                
                return Ok(new { message = "Booking cancelled successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
