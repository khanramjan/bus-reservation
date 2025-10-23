using BusReservation.ApplicationContracts.DTOs;
using BusReservation.ApplicationContracts.Interfaces;

namespace BusReservation.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<SearchScheduleResponseDto>> SearchSchedulesAsync(string source, string destination, string journeyDate)
        {
            try
            {
                if (!DateTime.TryParse(journeyDate, out var date))
                {
                    throw new ArgumentException("Invalid journey date format. Use YYYY-MM-DD");
                }

                var schedules = await _scheduleRepository.SearchAvailableBusesAsync(source, destination, date);

                var result = schedules.Select(s => new SearchScheduleResponseDto
                {
                    ScheduleId = s.ScheduleId.ToString(),
                    BusName = s.Bus.BusName,
                    BusNumber = s.Bus.BusNumber,
                    DepartureTime = s.DepartureTime.ToString("HH:mm"),
                    ArrivalTime = s.ArrivalTime.ToString("HH:mm"),
                    SeatsLeft = s.AvailableSeats,
                    Price = s.Price.ToString(),
                    BusType = s.Bus.BusType
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching schedules: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ScheduleResponseDto>> GetAllSchedulesAsync()
        {
            try
            {
                var schedules = await _scheduleRepository.SearchAvailableBusesAsync("", "", DateTime.MinValue);
                return schedules.Select(s => new ScheduleResponseDto
                {
                    ScheduleId = s.ScheduleId.ToString(),
                    RouteId = s.RouteId.ToString(),
                    BusId = s.BusId.ToString(),
                    DepartureTime = s.DepartureTime.ToString("HH:mm"),
                    ArrivalTime = s.ArrivalTime.ToString("HH:mm"),
                    JourneyDate = s.JourneyDate.ToString("yyyy-MM-dd"),
                    Price = s.Price.ToString(),
                    AvailableSeats = s.AvailableSeats,
                    TotalSeats = 40
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedules: {ex.Message}", ex);
            }
        }

        public async Task<ScheduleResponseDto> GetScheduleByIdAsync(string scheduleId)
        {
            try
            {
                if (!int.TryParse(scheduleId, out var id))
                {
                    throw new ArgumentException("Invalid schedule ID format");
                }

                var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
                if (schedule == null) return null;

                return new ScheduleResponseDto
                {
                    ScheduleId = schedule.ScheduleId.ToString(),
                    RouteId = schedule.RouteId.ToString(),
                    BusId = schedule.BusId.ToString(),
                    DepartureTime = schedule.DepartureTime.ToString("HH:mm"),
                    ArrivalTime = schedule.ArrivalTime.ToString("HH:mm"),
                    JourneyDate = schedule.JourneyDate.ToString("yyyy-MM-dd"),
                    Price = schedule.Price.ToString(),
                    AvailableSeats = schedule.AvailableSeats,
                    TotalSeats = 40
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedule: {ex.Message}", ex);
            }
        }

        public async Task<ScheduleSeatsResponseDto> GetScheduleSeatsAsync(string scheduleId)
        {
            try
            {
                if (!int.TryParse(scheduleId, out var id))
                {
                    throw new ArgumentException("Invalid schedule ID format");
                }

                var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
                if (schedule == null) return null;

                var seats = new List<SeatDto>();
                var rows = new[] { "A", "B", "C", "D" };
                
                foreach (var row in rows)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        seats.Add(new SeatDto
                        {
                            SeatNumber = $"{row}{i}",
                            Row = row,
                            Column = i,
                            Status = "Available",
                            Price = schedule.Price.ToString()
                        });
                    }
                }

                return new ScheduleSeatsResponseDto
                {
                    ScheduleId = schedule.ScheduleId.ToString(),
                    TotalSeats = 40,
                    AvailableSeats = schedule.AvailableSeats,
                    Seats = seats
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedule seats: {ex.Message}", ex);
            }
        }
    }
}
