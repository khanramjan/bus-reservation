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
    public class BookingServiceTests
    {
        private readonly Mock<IScheduleRepository> _mockScheduleRepository;
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly BookingService _bookingService;

        public BookingServiceTests()
        {
            _mockScheduleRepository = new Mock<IScheduleRepository>();
            _mockBookingRepository = new Mock<IBookingRepository>();
            
            _bookingService = new BookingService(
                _mockScheduleRepository.Object,
                _mockBookingRepository.Object
            );
        }

        #region Test Data Helpers

        private Schedule CreateTestSchedule(int availableSeats = 50)
        {
            return new Schedule
            {
                ScheduleId = 1,
                BusId = 1,
                RouteId = 1,
                DepartureTime = DateTime.UtcNow.AddDays(1),
                ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(5),
                Price = 500,
                AvailableSeats = availableSeats,
                JourneyDate = DateTime.UtcNow.AddDays(1),
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
            };
        }

        private BookingRequestDto CreateTestBookingRequest(int numberOfSeats = 2)
        {
            return new BookingRequestDto
            {
                ScheduleId = 1,
                PassengerName = "John Doe",
                PassengerEmail = "john@example.com",
                PassengerPhone = "01700000001",
                PassengerGender = "Male",
                NumberOfSeats = numberOfSeats,
                SeatNumbers = Enumerable.Range(1, numberOfSeats).Select(i => i.ToString()).ToList()
            };
        }

        #endregion

        #region Booking Available Seats Tests

        [Fact]
        public async Task CreateBooking_WithAvailableSeats_ShouldSucceed()
        {
            // Arrange
            var schedule = CreateTestSchedule(availableSeats: 50);
            var bookingRequest = CreateTestBookingRequest(numberOfSeats: 2);
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync((Booking b) => new Booking 
                { 
                    BookingId = 1,
                    BookingReference = b.BookingReference,
                    ScheduleId = b.ScheduleId,
                    PassengerName = b.PassengerName,
                    PassengerEmail = b.PassengerEmail,
                    PassengerPhone = b.PassengerPhone,
                    PassengerGender = b.PassengerGender,
                    NumberOfSeats = b.NumberOfSeats,
                    SeatNumbers = b.SeatNumbers,
                    TotalAmount = b.TotalAmount,
                    BookingDate = b.BookingDate,
                    BookingStatus = b.BookingStatus
                });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.BookingReference);
            Assert.Equal("John Doe", result.PassengerName);
            Assert.Equal("john@example.com", result.PassengerEmail);
            Assert.Equal(2, result.NumberOfSeats);
            Assert.Equal(1000, result.TotalAmount); // 2 seats * 500 price
            _mockBookingRepository.Verify(r => r.CreateBookingAsync(It.IsAny<Booking>()), Times.Once);
        }

        [Fact]
        public async Task CreateBooking_WithValidPassengerGender_ShouldStoreGender()
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

        #region Booking Unavailable Seats Tests

        [Fact]
        public async Task CreateBooking_WithInsufficientSeats_ShouldThrowException()
        {
            // Arrange
            var schedule = CreateTestSchedule(availableSeats: 1);
            var bookingRequest = CreateTestBookingRequest(numberOfSeats: 5);
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => 
                _bookingService.CreateBookingAsync(bookingRequest)
            );
        }

        [Fact]
        public async Task CreateBooking_WithZeroSeatsAvailable_ShouldThrowException()
        {
            // Arrange
            var schedule = CreateTestSchedule(availableSeats: 0);
            var bookingRequest = CreateTestBookingRequest(numberOfSeats: 1);
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => 
                _bookingService.CreateBookingAsync(bookingRequest)
            );
        }

        [Fact]
        public async Task CreateBooking_WithNonexistentSchedule_ShouldThrowException()
        {
            // Arrange
            var bookingRequest = CreateTestBookingRequest();
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Schedule)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => 
                _bookingService.CreateBookingAsync(bookingRequest)
            );
        }

        #endregion

        #region Seat Status Update Tests

        [Fact]
        public async Task CreateBooking_ShouldUpdateAvailableSeatsCount()
        {
            // Arrange
            var schedule = CreateTestSchedule(availableSeats: 50);
            var bookingRequest = CreateTestBookingRequest(numberOfSeats: 5);
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking());

            Schedule capturedSchedule = null;
            _mockScheduleRepository
                .Setup(r => r.UpdateScheduleAsync(It.IsAny<Schedule>()))
                .Callback<Schedule>(s => capturedSchedule = s)
                .Returns(Task.CompletedTask);

            // Act
            await _bookingService.CreateBookingAsync(bookingRequest);

            // Assert
            Assert.NotNull(capturedSchedule);
            Assert.Equal(45, capturedSchedule.AvailableSeats); // 50 - 5 = 45
            _mockScheduleRepository.Verify(r => r.UpdateScheduleAsync(It.IsAny<Schedule>()), Times.Once);
        }

        [Fact]
        public async Task CreateBooking_ShouldSetBookingStatusToConfirmed()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            
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
            Assert.Equal("Confirmed", capturedBooking.BookingStatus);
        }

        [Fact]
        public async Task CreateBooking_ShouldGenerateUniqueBookingReference()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest1 = CreateTestBookingRequest();
            var bookingRequest2 = CreateTestBookingRequest();
            
            _mockScheduleRepository
                .Setup(r => r.GetScheduleByIdAsync(1))
                .ReturnsAsync(schedule);

            string bookingRef1 = null;
            string bookingRef2 = null;

            _mockBookingRepository
                .Setup(r => r.CreateBookingAsync(It.IsAny<Booking>()))
                .Callback<Booking>(b => 
                {
                    if (bookingRef1 == null)
                        bookingRef1 = b.BookingReference;
                    else
                        bookingRef2 = b.BookingReference;
                })
                .ReturnsAsync((Booking b) => b);

            // Act
            await _bookingService.CreateBookingAsync(bookingRequest1);
            await _bookingService.CreateBookingAsync(bookingRequest2);

            // Assert
            Assert.NotNull(bookingRef1);
            Assert.NotNull(bookingRef2);
            Assert.NotEqual(bookingRef1, bookingRef2);
        }

        #endregion

        #region Input Validation Tests

        [Fact]
        public async Task CreateBooking_WithEmptyPassengerName_ShouldStillCreateBooking()
        {
            // Arrange - empty name is allowed, booking still proceeds
            var schedule = CreateTestSchedule();
            var bookingRequest = CreateTestBookingRequest();
            bookingRequest.PassengerName = "";
            
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
        public async Task CreateBooking_ShouldCalculateTotalAmountCorrectly()
        {
            // Arrange
            var schedule = CreateTestSchedule(); // Price = 500
            var bookingRequest = CreateTestBookingRequest(numberOfSeats: 3);
            
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
            Assert.Equal(1500, capturedBooking.TotalAmount); // 3 seats * 500 price
        }

        [Fact]
        public async Task CreateBooking_ShouldStoreSeatNumbersCommaSeparated()
        {
            // Arrange
            var schedule = CreateTestSchedule();
            var bookingRequest = new BookingRequestDto
            {
                ScheduleId = 1,
                PassengerName = "Test User",
                PassengerEmail = "test@example.com",
                PassengerPhone = "01700000001",
                PassengerGender = "Male",
                NumberOfSeats = 3,
                SeatNumbers = new List<string> { "1", "2", "3" }
            };
            
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
            Assert.Equal("1, 2, 3", capturedBooking.SeatNumbers);
        }

        #endregion
    }
}
