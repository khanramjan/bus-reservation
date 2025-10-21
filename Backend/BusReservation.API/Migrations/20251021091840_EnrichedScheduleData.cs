using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class EnrichedScheduleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "AvailableSeats", "DepartureTime", "JourneyDate" },
                values: new object[] { new DateTime(2025, 10, 22, 4, 0, 0, 0, DateTimeKind.Local), 35, new DateTime(2025, 10, 21, 22, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 22, 2, 0, 0, 0, DateTimeKind.Local), 38, 5, new DateTime(2025, 10, 21, 20, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1300m, 1 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Local), 42, 2, new DateTime(2025, 10, 21, 7, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 850m, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local), 40, 6, new DateTime(2025, 10, 21, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1000m, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 13,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 20, 0, 0, 0, DateTimeKind.Local), 38, 2, new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 14,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 9, 0, 0, 0, DateTimeKind.Local), 37, 9, new DateTime(2025, 10, 21, 6, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 15,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local), 39, 6, new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 16,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Local), 33, 11, new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Local), 35, 9, new DateTime(2025, 10, 21, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 2 },
                    { 6, new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), 48, 3, new DateTime(2025, 10, 21, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 7, new DateTime(2025, 10, 22, 5, 0, 0, 0, DateTimeKind.Local), 30, 7, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 3 },
                    { 8, new DateTime(2025, 10, 22, 5, 0, 0, 0, DateTimeKind.Local), 33, 4, new DateTime(2025, 10, 21, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 9, new DateTime(2025, 10, 22, 4, 0, 0, 0, DateTimeKind.Local), 34, 11, new DateTime(2025, 10, 21, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1320m, 4 },
                    { 10, new DateTime(2025, 10, 22, 4, 0, 0, 0, DateTimeKind.Local), 41, 8, new DateTime(2025, 10, 21, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 11, new DateTime(2025, 10, 22, 3, 0, 0, 0, DateTimeKind.Local), 46, 10, new DateTime(2025, 10, 21, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 12, new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Local), 48, 12, new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 101, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 42, 3, new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 102, new DateTime(2025, 10, 21, 22, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 1 },
                    { 103, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Local), 45, 10, new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },
                    { 104, new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Local), 43, 8, new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 2 },
                    { 105, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), 32, 4, new DateTime(2025, 10, 21, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1500m, 3 },
                    { 106, new DateTime(2025, 10, 22, 3, 0, 0, 0, DateTimeKind.Local), 37, 1, new DateTime(2025, 10, 21, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1380m, 4 },
                    { 107, new DateTime(2025, 10, 22, 2, 0, 0, 0, DateTimeKind.Local), 42, 6, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 950m, 5 },
                    { 108, new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local), 44, 9, new DateTime(2025, 10, 21, 11, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 900m, 6 },
                    { 109, new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Local), 36, 5, new DateTime(2025, 10, 21, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 620m, 7 },
                    { 110, new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local), 29, 7, new DateTime(2025, 10, 21, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 8 },
                    { 111, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 40, 1, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 112, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 45, 2, new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 2 },
                    { 113, new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), 50, 3, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 114, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 35, 4, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 115, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 44, 8, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 116, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 50, 12, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 117, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), 39, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 118, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 118);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "AvailableSeats", "DepartureTime", "JourneyDate" },
                values: new object[] { new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 40, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 45, 2, new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), 50, 3, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 35, 4, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 13,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Local), 35, 5, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1300m, 1 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 14,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), 42, 6, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1000m, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 15,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Local), 38, 9, new DateTime(2025, 10, 22, 6, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 16,
                columns: new[] { "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 32, 7, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 3 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
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
    }
}
