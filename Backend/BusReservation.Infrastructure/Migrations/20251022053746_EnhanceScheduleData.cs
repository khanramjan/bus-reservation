using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnhanceScheduleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add more schedules for same operators on same routes throughout the day
            // This creates realistic scenarios where operators have multiple departures

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    // Dhaka -> Rajshahi (Route 1) - More Green Line (Bus 1, 5) schedules
                    { 201, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), 38, 1, new DateTime(2025, 10, 22, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 202, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Local), 37, 5, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 203, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), 39, 1, new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 204, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 40, 5, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },

                    // Dhaka -> Chittagong (Route 2) - More Shyamoli (Bus 2, 6) schedules
                    { 205, new DateTime(2025, 10, 22, 11, 0, 0, 0, DateTimeKind.Local), 43, 2, new DateTime(2025, 10, 22, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },
                    { 206, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Local), 44, 6, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },
                    { 207, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Local), 42, 2, new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },
                    { 208, new DateTime(2025, 10, 23, 1, 0, 0, 0, DateTimeKind.Local), 45, 6, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },

                    // Dhaka -> Cox's Bazar (Route 3) - More Hanif (Bus 3, 7) schedules
                    { 209, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), 49, 3, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 210, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), 36, 7, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 3 },
                    { 211, new DateTime(2025, 10, 23, 15, 0, 0, 0, DateTimeKind.Local), 48, 3, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },

                    // Dhaka -> Sylhet (Route 4) - More Ena (Bus 4, 11) schedules
                    { 212, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), 34, 4, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 213, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 4 },
                    { 214, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), 38, 4, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 4 },

                    // Dhaka -> Khulna (Route 5) - More National (Bus 8, 10) schedules
                    { 215, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Local), 47, 8, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 216, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Local), 50, 10, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 217, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), 48, 8, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 218, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Local), 51, 10, new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1050m, 5 },

                    // Dhaka -> Barisal (Route 6) - More Grameen (Bus 12) schedules
                    { 219, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), 49, 12, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 220, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Local), 40, 2, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 },
                    { 221, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 48, 12, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },

                    // Chittagong -> Cox's Bazar (Route 7) - More National (Bus 9, 6) schedules
                    { 222, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), 38, 9, new DateTime(2025, 10, 22, 7, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 223, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), 40, 6, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 },
                    { 224, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Local), 36, 9, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },

                    // Chittagong -> Sylhet (Route 8) - More Grameen (Bus 11) schedules
                    { 225, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), 34, 11, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },
                    { 226, new DateTime(2025, 10, 23, 16, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },

                    // Add more variety for tomorrow (10/23)
                    { 227, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), 40, 1, new DateTime(2025, 10, 23, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 228, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 44, 2, new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },
                    { 229, new DateTime(2025, 10, 24, 6, 0, 0, 0, DateTimeKind.Local), 49, 3, new DateTime(2025, 10, 23, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 230, new DateTime(2025, 10, 24, 5, 0, 0, 0, DateTimeKind.Local), 33, 4, new DateTime(2025, 10, 23, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 231, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), 43, 8, new DateTime(2025, 10, 23, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 232, new DateTime(2025, 10, 23, 14, 0, 0, 0, DateTimeKind.Local), 49, 12, new DateTime(2025, 10, 23, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 233, new DateTime(2025, 10, 23, 9, 0, 0, 0, DateTimeKind.Local), 37, 9, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete the enhanced schedules
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 201);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 202);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 203);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 204);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 205);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 206);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 207);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 208);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 209);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 210);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 211);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 212);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 213);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 214);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 215);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 216);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 217);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 218);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 219);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 220);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 221);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 222);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 223);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 224);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 225);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 226);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 227);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 228);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 229);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 230);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 231);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 232);
            migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: 233);
        }
    }
}
