using BusReservation.ApplicationContracts.DTOs;

namespace BusReservation.ApplicationContracts.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<SearchScheduleResponseDto>> SearchSchedulesAsync(string source, string destination, string journeyDate);
        Task<IEnumerable<ScheduleResponseDto>> GetAllSchedulesAsync();
        Task<ScheduleResponseDto> GetScheduleByIdAsync(string scheduleId);
        Task<ScheduleSeatsResponseDto> GetScheduleSeatsAsync(string scheduleId);
    }
}
