using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusReservation.Infrastructure.Migrations
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
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BusNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BusType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TotalSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amenities = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EstimatedDuration = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingReference = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassengerEmail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassengerPhone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PassengerGender = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatNumbers = table.Column<string>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingStatus = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "TEXT", nullable: true)
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
                    { 1, "WiFi, Charging Point, Water Bottle", 1200m, "Green Line Paribahan", "DH-11-5678", "AC Sleeper", true, 40 },
                    { 2, "Water Bottle", 800m, "Shyamoli Paribahan", "CH-15-9012", "Non-AC Seater", true, 45 },
                    { 3, "WiFi, Water Bottle", 1000m, "Hanif Enterprise", "DH-12-3456", "AC Seater", true, 50 },
                    { 4, "WiFi, Charging Point, Blanket, Water Bottle", 1400m, "Ena Transport", "RJ-10-7890", "AC Sleeper", true, 35 },
                    { 5, "WiFi, Charging Point, Water Bottle", 1250m, "Green Line Paribahan", "DH-11-5679", "AC Sleeper", true, 40 },
                    { 6, "WiFi, Water Bottle", 950m, "Shyamoli Paribahan", "CH-15-9013", "AC Seater", true, 45 },
                    { 7, "WiFi, Charging Point, Blanket", 1300m, "Hanif Enterprise", "DH-12-3457", "AC Sleeper", true, 38 },
                    { 8, "WiFi, Water Bottle", 1100m, "Ena Transport", "RJ-10-7891", "AC Seater", true, 48 },
                    { 9, "WiFi, Charging Point, Blanket, Water Bottle", 1350m, "National Travels", "CB-20-1001", "AC Sleeper", true, 42 },
                    { 10, "WiFi, Water Bottle", 1050m, "National Travels", "CB-20-1002", "AC Seater", true, 52 },
                    { 11, "WiFi, Charging Point, Blanket", 1280m, "Grameen Travels", "DH-13-2001", "AC Sleeper", true, 39 },
                    { 12, "Water Bottle", 750m, "Grameen Travels", "DH-13-2002", "Non-AC Seater", true, 50 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Destination", "EstimatedDuration", "Source" },
                values: new object[,]
                {
                    { 1, "Rajshahi", new TimeSpan(0, 6, 0, 0, 0), "Dhaka" },
                    { 2, "Chittagong", new TimeSpan(0, 7, 0, 0, 0), "Dhaka" },
                    { 3, "Cox's Bazar", new TimeSpan(0, 10, 0, 0, 0), "Dhaka" },
                    { 4, "Sylhet", new TimeSpan(0, 6, 0, 0, 0), "Dhaka" },
                    { 5, "Khulna", new TimeSpan(0, 7, 0, 0, 0), "Dhaka" },
                    { 6, "Barisal", new TimeSpan(0, 6, 0, 0, 0), "Dhaka" },
                    { 7, "Cox's Bazar", new TimeSpan(0, 3, 0, 0, 0), "Chittagong" },
                    { 8, "Sylhet", new TimeSpan(0, 8, 0, 0, 0), "Chittagong" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 35, 1, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 2, new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Local), 38, 5, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1300m, 1 },
                    { 3, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 42, 2, new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 2 },
                    { 4, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 40, 6, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1000m, 2 },
                    { 5, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), 35, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 2 },
                    { 6, new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), 48, 3, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 7, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 30, 7, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 3 },
                    { 8, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 33, 4, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 9, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 34, 11, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1320m, 4 },
                    { 10, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 41, 8, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 11, new DateTime(2025, 10, 23, 3, 0, 0, 0, DateTimeKind.Local), 46, 10, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 12, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 48, 12, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 13, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), 38, 2, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 },
                    { 14, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), 37, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 15, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 39, 6, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 },
                    { 16, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), 33, 11, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },
                    { 101, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, 3, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 102, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 1 },
                    { 103, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), 45, 10, new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },
                    { 104, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Local), 43, 8, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 2 },
                    { 105, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), 32, 4, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1500m, 3 },
                    { 106, new DateTime(2025, 10, 23, 3, 0, 0, 0, DateTimeKind.Local), 37, 1, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1380m, 4 },
                    { 107, new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Local), 42, 6, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 950m, 5 },
                    { 108, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 44, 9, new DateTime(2025, 10, 22, 11, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 900m, 6 },
                    { 109, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), 36, 5, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 620m, 7 },
                    { 110, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 29, 7, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 8 },
                    { 111, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), 40, 1, new DateTime(2025, 10, 23, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 112, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 45, 2, new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 850m, 2 },
                    { 113, new DateTime(2025, 10, 24, 7, 0, 0, 0, DateTimeKind.Local), 50, 3, new DateTime(2025, 10, 23, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 114, new DateTime(2025, 10, 24, 5, 0, 0, 0, DateTimeKind.Local), 35, 4, new DateTime(2025, 10, 23, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 115, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), 44, 8, new DateTime(2025, 10, 23, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 116, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 50, 12, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 117, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Local), 39, 9, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 118, new DateTime(2025, 10, 23, 16, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 }
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
