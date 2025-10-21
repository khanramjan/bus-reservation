using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedBusData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 1200m, "Green Line Paribahan", "DH-11-5678" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 2,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 800m, "Shyamoli Paribahan", "CH-15-9012" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 3,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 1000m, "Hanif Enterprise", "DH-12-3456" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 4,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 1400m, "Ena Transport", "RJ-10-7890" });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "Amenities", "BasePrice", "BusName", "BusNumber", "BusType", "IsActive", "TotalSeats" },
                values: new object[,]
                {
                    { 5, "WiFi, Charging Point, Water Bottle", 1250m, "Green Line Paribahan", "DH-11-5679", "AC Sleeper", true, 40 },
                    { 6, "WiFi, Water Bottle", 950m, "Shyamoli Paribahan", "CH-15-9013", "AC Seater", true, 45 },
                    { 7, "WiFi, Charging Point, Blanket", 1300m, "Hanif Enterprise", "DH-12-3457", "AC Sleeper", true, 38 },
                    { 8, "WiFi, Water Bottle", 1100m, "Ena Transport", "RJ-10-7891", "AC Seater", true, 48 },
                    { 9, "WiFi, Charging Point, Blanket, Water Bottle", 1350m, "National Travels", "CB-20-1001", "AC Sleeper", true, 42 },
                    { 10, "WiFi, Water Bottle", 1050m, "National Travels", "CB-20-1002", "AC Seater", true, 52 },
                    { 11, "WiFi, Charging Point, Blanket", 1280m, "Grameen Travels", "DH-13-2001", "AC Sleeper", true, 39 },
                    { 12, "Water Bottle", 750m, "Grameen Travels", "DH-13-2002", "Non-AC Seater", true, 50 }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 1,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Rajshahi", 256m, new TimeSpan(0, 6, 0, 0, 0), "Dhaka" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 2,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Chittagong", 264m, new TimeSpan(0, 7, 0, 0, 0), "Dhaka" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 3,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Cox's Bazar", 400m, new TimeSpan(0, 10, 0, 0, 0), "Dhaka" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 4,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Sylhet", 245m, new TimeSpan(0, 6, 0, 0, 0), "Dhaka" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[,]
                {
                    { 5, "Khulna", 280m, new TimeSpan(0, 7, 0, 0, 0), "Dhaka" },
                    { 6, "Barisal", 240m, new TimeSpan(0, 6, 0, 0, 0), "Dhaka" },
                    { 7, "Cox's Bazar", 152m, new TimeSpan(0, 3, 0, 0, 0), "Chittagong" },
                    { 8, "Sylhet", 350m, new TimeSpan(0, 8, 0, 0, 0), "Chittagong" }
                });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 1250m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), 850m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), 1100m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), 1450m });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { 13, new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Local), 35, 5, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1300m, 1 },
                    { 14, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 42, 6, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1000m, 2 },
                    { 15, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), 38, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 2 },
                    { 16, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 32, 7, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 3 },
                    { 17, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1320m, 4 },
                    { 18, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 44, 8, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 19, new DateTime(2025, 10, 23, 3, 0, 0, 0, DateTimeKind.Local), 48, 10, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 20, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 50, 12, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 21, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), 40, 2, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 },
                    { 22, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), 39, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 23, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 41, 6, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 },
                    { 24, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 800m, "National Travels", "KA-01-AB-1234" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 2,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 500m, "Royal Coaches", "KA-02-CD-5678" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 3,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 600m, "Intercity Express", "KA-03-EF-9012" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 4,
                columns: new[] { "BasePrice", "BusName", "BusNumber" },
                values: new object[] { 900m, "Greenline Travels", "KA-04-GH-3456" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 1,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Mumbai", 984m, new TimeSpan(0, 16, 0, 0, 0), "Bangalore" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 2,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Jaipur", 280m, new TimeSpan(0, 5, 0, 0, 0), "Delhi" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 3,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Bangalore", 346m, new TimeSpan(0, 7, 0, 0, 0), "Chennai" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 4,
                columns: new[] { "Destination", "Distance", "EstimatedDuration", "Source" },
                values: new object[] { "Pune", 565m, new TimeSpan(0, 10, 0, 0, 0), "Hyderabad" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 850m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), 550m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), 650m });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime", "Price" },
                values: new object[] { new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), 950m });
        }
    }
}
