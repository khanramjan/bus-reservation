using System;
using System.Text.Json.Serialization;

namespace BusReservation.ApplicationContracts.DTOs
{
    public class SearchRequestDto
    {
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;
        
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;
        
        [JsonPropertyName("journeyDate")]
        public DateTime JourneyDate { get; set; }
    }

    public class AvailableBusDto
    {
        [JsonPropertyName("scheduleId")]
        public int ScheduleId { get; set; }
        
        [JsonPropertyName("busName")]
        public string BusName { get; set; } = string.Empty;
        
        [JsonPropertyName("busNumber")]
        public string BusNumber { get; set; } = string.Empty;
        
        [JsonPropertyName("busType")]
        public string BusType { get; set; } = string.Empty;
        
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;
        
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;
        
        [JsonPropertyName("departureTime")]
        public DateTime DepartureTime { get; set; }
        
        [JsonPropertyName("arrivalTime")]
        public DateTime ArrivalTime { get; set; }
        
        [JsonPropertyName("journeyDate")]
        public DateTime JourneyDate { get; set; }
        
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        
        [JsonPropertyName("availableSeats")]
        public int AvailableSeats { get; set; }
        
        [JsonPropertyName("duration")]
        public TimeSpan Duration { get; set; }
        
        [JsonPropertyName("amenities")]
        public string Amenities { get; set; } = string.Empty;
    }

    public class BookingRequestDto
    {
        [JsonPropertyName("scheduleId")]
        public int ScheduleId { get; set; }
        
        [JsonPropertyName("passengerName")]
        public string PassengerName { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerEmail")]
        public string PassengerEmail { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerPhone")]
        public string PassengerPhone { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerGender")]
        public string PassengerGender { get; set; } = string.Empty;
        
        [JsonPropertyName("numberOfSeats")]
        public int NumberOfSeats { get; set; }
        
        [JsonPropertyName("seatNumbers")]
        public List<string> SeatNumbers { get; set; } = new List<string>();
    }

    public class BookingResponseDto
    {
        [JsonPropertyName("bookingId")]
        public int BookingId { get; set; }
        
        [JsonPropertyName("bookingReference")]
        public string BookingReference { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerName")]
        public string PassengerName { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerEmail")]
        public string PassengerEmail { get; set; } = string.Empty;
        
        [JsonPropertyName("busName")]
        public string BusName { get; set; } = string.Empty;
        
        [JsonPropertyName("busNumber")]
        public string BusNumber { get; set; } = string.Empty;
        
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;
        
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;
        
        [JsonPropertyName("departureTime")]
        public DateTime DepartureTime { get; set; }
        
        [JsonPropertyName("arrivalTime")]
        public DateTime ArrivalTime { get; set; }
        
        [JsonPropertyName("numberOfSeats")]
        public int NumberOfSeats { get; set; }
        
        [JsonPropertyName("seatNumbers")]
        public string SeatNumbers { get; set; } = string.Empty;
        
        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
        
        [JsonPropertyName("bookingDate")]
        public DateTime BookingDate { get; set; }
        
        [JsonPropertyName("bookingStatus")]
        public string BookingStatus { get; set; } = string.Empty;
    }

    public class CancellationRequestDto
    {
        [JsonPropertyName("bookingReference")]
        public string BookingReference { get; set; } = string.Empty;
        
        [JsonPropertyName("passengerEmail")]
        public string PassengerEmail { get; set; } = string.Empty;
    }
}

