using Microsoft.AspNetCore.Mvc;
using BusReservation.ApplicationContracts.DTOs;
using BusReservation.ApplicationContracts.Interfaces;

namespace BusReservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// Search for available buses by source, destination, and journey date
        /// </summary>
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchScheduleRequestDto request)
        {
            try
            {
                var schedules = await _scheduleService.SearchSchedulesAsync(
                    request.Source,
                    request.Destination,
                    request.JourneyDate);

                if (schedules == null || !schedules.Any())
                {
                    return Ok(new List<SearchScheduleResponseDto>());
                }

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get all available schedules
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get seat layout for a specific schedule
        /// </summary>
        [HttpGet("{scheduleId}/seats")]
        public async Task<IActionResult> GetSeats(string scheduleId)
        {
            try
            {
                var seats = await _scheduleService.GetScheduleSeatsAsync(scheduleId);
                
                if (seats == null)
                {
                    return NotFound(new { message = "Schedule not found" });
                }

                return Ok(seats);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get a specific schedule by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByIdAsync(id);
                
                if (schedule == null)
                {
                    return NotFound(new { message = "Schedule not found" });
                }

                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
