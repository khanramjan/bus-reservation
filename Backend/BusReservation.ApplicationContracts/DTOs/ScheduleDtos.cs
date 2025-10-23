using System.Text.Json.Serialization;

namespace BusReservation.ApplicationContracts.DTOs
{
    public class SearchScheduleRequestDto
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("journeyDate")]
        public string JourneyDate { get; set; }
    }

    public class SearchScheduleResponseDto
    {
        [JsonPropertyName("scheduleId")]
        public string ScheduleId { get; set; }

        [JsonPropertyName("busName")]
        public string BusName { get; set; }

        [JsonPropertyName("busNumber")]
        public string BusNumber { get; set; }

        [JsonPropertyName("departureTime")]
        public string DepartureTime { get; set; }

        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }

        [JsonPropertyName("seatsLeft")]
        public int SeatsLeft { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("busType")]
        public string BusType { get; set; }
    }

    public class ScheduleResponseDto
    {
        [JsonPropertyName("scheduleId")]
        public string ScheduleId { get; set; }

        [JsonPropertyName("routeId")]
        public string RouteId { get; set; }

        [JsonPropertyName("busId")]
        public string BusId { get; set; }

        [JsonPropertyName("departureTime")]
        public string DepartureTime { get; set; }

        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }

        [JsonPropertyName("journeyDate")]
        public string JourneyDate { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("availableSeats")]
        public int AvailableSeats { get; set; }

        [JsonPropertyName("totalSeats")]
        public int TotalSeats { get; set; }
    }

    public class ScheduleSeatsResponseDto
    {
        [JsonPropertyName("scheduleId")]
        public string ScheduleId { get; set; }

        [JsonPropertyName("totalSeats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("availableSeats")]
        public int AvailableSeats { get; set; }

        [JsonPropertyName("seats")]
        public List<SeatDto> Seats { get; set; } = new();
    }

    public class SeatDto
    {
        [JsonPropertyName("seatNumber")]
        public string SeatNumber { get; set; }

        [JsonPropertyName("row")]
        public string Row { get; set; }

        [JsonPropertyName("column")]
        public int Column { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } // "Available" or "Booked"

        [JsonPropertyName("price")]
        public string Price { get; set; }
    }
}
