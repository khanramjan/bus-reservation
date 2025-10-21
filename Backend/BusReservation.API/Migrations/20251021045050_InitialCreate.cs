using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BusType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedDuration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassengerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassengerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    SeatNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "Amenities", "BasePrice", "BusName", "BusNumber", "BusType", "IsActive", "TotalSeats" },
                values: new object[,]
                {
                    { 1, "WiFi, Charging Point, Water Bottle", 800m, "National Travels", "KA-01-AB-1234", "AC Sleeper", true, 40 },
                    { 2, "Water Bottle", 500m, "Royal Coaches", "KA-02-CD-5678", "Non-AC Seater", true, 45 },
                    { 3, "WiFi, Water Bottle", 600m, "Intercity Express", "KA-03-EF-9012", "AC Seater", true, 50 },
                    { 4, "WiFi, Charging Point, Blanket, Water Bottle", 900m, "Greenline Travels", "KA-04-GH-3456", "AC Sleeper", true, 35 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[,]
                {
                    { 1, "Mumbai", 984m, new TimeSpan(0, 16, 0, 0, 0), "Bangalore" },
                    { 2, "Jaipur", 280m, new TimeSpan(0, 5, 0, 0, 0), "Delhi" },
                    { 3, "Bangalore", 346m, new TimeSpan(0, 7, 0, 0, 0), "Chennai" },
                    { 4, "Pune", 565m, new TimeSpan(0, 10, 0, 0, 0), "Hyderabad" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 40, 1, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 1 },
                    { 2, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), 45, 2, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 550m, 2 },
                    { 3, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), 50, 3, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 650m, 3 },
                    { 4, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), 35, 4, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 950m, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScheduleId",
                table: "Bookings",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_BusId",
                table: "Schedules",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
