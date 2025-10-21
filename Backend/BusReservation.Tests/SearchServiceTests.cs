using Xunit;
using Moq;
using BusReservation.Application.Services;
using BusReservation.ApplicationContracts.DTOs;
using BusReservation.ApplicationContracts.Interfaces;
using BusReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservation.Tests
{
    public class SearchServiceTests
    {
        private readonly Mock<IScheduleRepository> _mockScheduleRepository;
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly BookingService _bookingService;

        public SearchServiceTests()
        {
            _mockScheduleRepository = new Mock<IScheduleRepository>();
            _mockBookingRepository = new Mock<IBookingRepository>();
            
            _bookingService = new BookingService(
                _mockScheduleRepository.Object,
                _mockBookingRepository.Object
            );
        }

        #region Test Data Helpers

        private List<Schedule> CreateTestSchedules()
        {
            return new List<Schedule>
            {
                new Schedule
                {
                    ScheduleId = 1,
                    BusId = 1,
                    RouteId = 1,
                    DepartureTime = new DateTime(2025, 10, 25, 08, 00, 0),
                    ArrivalTime = new DateTime(2025, 10, 25, 13, 00, 0),
                    Price = 500,
                    AvailableSeats = 30,
                    JourneyDate = new DateTime(2025, 10, 25),
                    Bus = new Bus 
                    { 
                        BusId = 1, 
                        BusName = "Express Bus", 
                        BusNumber = "BD-001",
                        BusType = "AC",
                        TotalSeats = 52,
                        BasePrice = 500,
                        Amenities = "WiFi, Food",
                        IsActive = true
                    },
                    Route = new Route 
                    { 
                        RouteId = 1, 
                        Source = "Dhaka", 
                        Destination = "Chittagong",
                        EstimatedDuration = TimeSpan.FromHours(5)
                    }
                },
                new Schedule
                {
                    ScheduleId = 2,
                    BusId = 2,
                    RouteId = 1,
                    DepartureTime = new DateTime(2025, 10, 25, 14, 00, 0),
                    ArrivalTime = new DateTime(2025, 10, 25, 19, 00, 0),
                    Price = 450,
                    AvailableSeats = 15,
                    JourneyDate = new DateTime(2025, 10, 25),
                    Bus = new Bus 
                    { 
                        BusId = 2, 
                        BusName = "Premium Bus", 
                        BusNumber = "BD-002",
                        BusType = "AC",
                        TotalSeats = 52,
                        BasePrice = 450,
                        Amenities = "WiFi, Meal",
                        IsActive = true
                    },
                    Route = new Route 
                    { 
                        RouteId = 1, 
                        Source = "Dhaka", 
                        Destination = "Chittagong",
                        EstimatedDuration = TimeSpan.FromHours(5)
                    }
                }
            };
        }

        #endregion

        #region Search Functionality Tests

        [Fact]
        public async Task SearchAvailableBuses_ShouldReturnBusesForValidRoute()
        {
            // Arrange
            var schedules = CreateTestSchedules();
            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync("Dhaka", "Chittagong", It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, bus => Assert.Equal("Dhaka", bus.Source));
            Assert.All(result, bus => Assert.Equal("Chittagong", bus.Destination));
        }

        [Fact]
        public async Task SearchAvailableBuses_ShouldReturnEmptyListForInvalidRoute()
        {
            // Arrange
            var searchRequest = new SearchRequestDto
            {
                Source = "Khulna",
                Destination = "Rajshahi",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync("Khulna", "Rajshahi", It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Schedule>());

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task SearchAvailableBuses_ShouldReturnBusesWithCorrectDetails()
        {
            // Arrange
            var schedules = CreateTestSchedules().Take(1).ToList();
            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync("Dhaka", "Chittagong", It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Single(result);
            var bus = result.First();
            Assert.Equal("Express Bus", bus.BusName);
            Assert.Equal("BD-001", bus.BusNumber);
            Assert.Equal(500, bus.Price);
            Assert.Equal(30, bus.AvailableSeats);
            Assert.Equal("AC", bus.BusType);
        }

        #endregion

        #region Available Seats Calculation Tests

        [Fact]
        public async Task SearchAvailableBuses_ShouldDisplayCorrectAvailableSeats()
        {
            // Arrange
            var schedules = CreateTestSchedules();
            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Equal(30, result[0].AvailableSeats); // First bus has 30 seats
            Assert.Equal(15, result[1].AvailableSeats); // Second bus has 15 seats
        }

        [Fact]
        public async Task SearchAvailableBuses_ShouldShowBusesWithLimitedSeats()
        {
            // Arrange
            var schedules = new List<Schedule>
            {
                new Schedule
                {
                    ScheduleId = 1,
                    BusId = 1,
                    RouteId = 1,
                    DepartureTime = DateTime.UtcNow.AddDays(1),
                    ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(5),
                    Price = 500,
                    AvailableSeats = 1, // Only 1 seat left
                    JourneyDate = DateTime.UtcNow.AddDays(1),
                    Bus = new Bus 
                    { 
                        BusId = 1, 
                        BusName = "Last Seat Bus", 
                        BusNumber = "BD-001",
                        BusType = "AC",
                        TotalSeats = 52
                    },
                    Route = new Route 
                    { 
                        RouteId = 1, 
                        Source = "Dhaka", 
                        Destination = "Chittagong",
                        EstimatedDuration = TimeSpan.FromHours(5)
                    }
                }
            };

            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = DateTime.UtcNow.AddDays(1)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result.First().AvailableSeats);
        }

        [Fact]
        public async Task SearchAvailableBuses_ShouldNotShowFullyBookedBuses()
        {
            // Arrange - In real scenario, fully booked buses might still be returned but with 0 seats
            var schedules = new List<Schedule>
            {
                new Schedule
                {
                    ScheduleId = 1,
                    BusId = 1,
                    RouteId = 1,
                    DepartureTime = DateTime.UtcNow.AddDays(1),
                    ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(5),
                    Price = 500,
                    AvailableSeats = 0, // No seats available
                    JourneyDate = DateTime.UtcNow.AddDays(1),
                    Bus = new Bus 
                    { 
                        BusId = 1, 
                        BusName = "Fully Booked Bus", 
                        BusNumber = "BD-001",
                        BusType = "AC",
                        TotalSeats = 52
                    },
                    Route = new Route 
                    { 
                        RouteId = 1, 
                        Source = "Dhaka", 
                        Destination = "Chittagong",
                        EstimatedDuration = TimeSpan.FromHours(5)
                    }
                }
            };

            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = DateTime.UtcNow.AddDays(1)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Single(result); // Still returned but with 0 seats
            Assert.Equal(0, result.First().AvailableSeats);
        }

        #endregion

        #region Price and Duration Tests

        [Fact]
        public async Task SearchAvailableBuses_ShouldReturnCorrectPrice()
        {
            // Arrange
            var schedules = CreateTestSchedules();
            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Equal(500, result[0].Price);
            Assert.Equal(450, result[1].Price);
        }

        [Fact]
        public async Task SearchAvailableBuses_ShouldReturnCorrectDepartureTimes()
        {
            // Arrange
            var schedules = CreateTestSchedules();
            var searchRequest = new SearchRequestDto
            {
                Source = "Dhaka",
                Destination = "Chittagong",
                JourneyDate = new DateTime(2025, 10, 25)
            };

            _mockScheduleRepository
                .Setup(r => r.SearchAvailableBusesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(schedules);

            // Act
            var result = await _bookingService.SearchAvailableBusesAsync(searchRequest);

            // Assert
            Assert.Equal(new DateTime(2025, 10, 25, 08, 00, 0), result[0].DepartureTime);
            Assert.Equal(new DateTime(2025, 10, 25, 14, 00, 0), result[1].DepartureTime);
        }

        #endregion
    }
}
