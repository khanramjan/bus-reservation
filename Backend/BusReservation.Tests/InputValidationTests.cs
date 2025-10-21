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
    public class InputValidationTests
    {
        private readonly Mock<IScheduleRepository> _mockScheduleRepository;
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly BookingService _bookingService;

        public InputValidationTests()
        {
            _mockScheduleRepository = new Mock<IScheduleRepository>();
            _mockBookingRepository = new Mock<IBookingRepository>();
            
            _bookingService = new BookingService(
                _mockScheduleRepository.Object,
                _mockBookingRepository.Object
            );
        }

        #region Test Data Helpers

        private Schedule CreateTestSchedule()
        {
            return new Schedule
            {
                ScheduleId = 1,
                BusId = 1,
                RouteId = 1,
                DepartureTime = DateTime.UtcNow.AddDays(1),
                ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(5),
                Price = 500,
                AvailableSeats = 50,
                JourneyDate = DateTime.UtcNow.AddDays(1),
                Bus = new Bus 
                { 
                    BusId = 1, 
                    BusName = "Test Bus", 
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
            };
        }

        private BookingRequestDto CreateTestBookingRequest()
        {
            return new BookingRequestDto
            {
                ScheduleId = 1,
                PassengerName = "John Doe",
                PassengerEmail = "john@example.com",
                PassengerPhone = "01700000001",
                PassengerGender = "Male",
                NumberOfSeats = 2,
                SeatNumbers = new List<string> { "1", "2" }
            };
        }

        #endregion

        #region Email Validation Tests

        [Fact]
        public async Task CreateBooking_WithValidEmail_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerEmail = "valid.email@example.com";
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("BR123", result.BookingReference);
        }

        [Fact]
        public async Task CreateBooking_WithEmptyEmail_ShouldStillCreateBooking()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerEmail = "";
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
        }

        #endregion

        #region Phone Number Validation Tests

        [Fact]
        public async Task CreateBooking_WithValidPhoneNumber_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerPhone = "01700000001"; // Valid BD phone
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("BR123", result.BookingReference);
        }

        [Fact]
        public async Task CreateBooking_WithDifferentPhoneFormats_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var phoneNumbers = new[] { "01700000001", "01800000001", "01900000001", "01600000001" };
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act & Assert
            foreach (var phone in phoneNumbers)
            {
                var bookingRequest = CreateTestBookingRequest();
                bookingRequest.PassengerPhone = phone;

                var result = await _bookingService.CreateBookingAsync(bookingRequest);
                Assert.NotNull(result);
            }
        }

        #endregion

        #region Seat Number Validation Tests

        [Fact]
        public async Task CreateBooking_WithValidSeatNumbers_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.SeatNumbers = new List<string> { "5", "10", "15" };
            bookingRequest.NumberOfSeats = 3;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateBooking_WithSingleSeat_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.SeatNumbers = new List<string> { "5" };
            bookingRequest.NumberOfSeats = 1;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.NumberOfSeats);
        }

        [Fact]
        public async Task CreateBooking_WithMultipleSeats_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.SeatNumbers = new List<string> { "1", "2", "3", "4", "5", "6" };
            bookingRequest.NumberOfSeats = 6;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(6, result.NumberOfSeats);
        }

        #endregion

        #region Gender Validation Tests

        [Theory]
        [InlineData("Male")]
        [InlineData("Female")]
        [InlineData("Other")]
        public async Task CreateBooking_WithValidGenders_ShouldSucceed(string gender)
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerGender = gender;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateBooking_ShouldStorePassengerGender()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerGender = "Female";
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            Booking capturedBooking = null;
            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .Callback<Booking>(b => capturedBooking = b)
                .ReturnsAsync((Booking b) => b);

            // Act
            await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(capturedBooking);
            Assert.Equal("Female", capturedBooking.PassengerGender);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public async Task CreateBooking_WithMaximumSeats_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            schedule.AvailableSeats = 10;
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.SeatNumbers = Enumerable.Range(1, 10).Select(i => i.ToString()).ToList();
            bookingRequest.NumberOfSeats = 10;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.NumberOfSeats);
        }

        [Fact]
        public async Task CreateBooking_WithMinimumSeats_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.SeatNumbers = new List<string> { "1" };
            bookingRequest.NumberOfSeats = 1;
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.NumberOfSeats);
        }

        [Fact]
        public async Task CreateBooking_WithSpecialCharactersInName_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerName = "John O'Brien-Smith"; // Name with special chars
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking { BookingReference = "BR123" });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
        }

        #endregion
    }
}
