using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComprehensiveSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add comprehensive schedules for Oct 24-25 with 2-3 buses per route per day
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "AvailableSeats", "BusId", "DepartureTime", "IsActive", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    // Oct 24 - Route 1: Dhaka → Rajshahi (3 buses)
                    { 301, new DateTime(2025, 10, 24, 10, 0, 0, 0, DateTimeKind.Local), 38, 1, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 302, new DateTime(2025, 10, 24, 14, 0, 0, 0, DateTimeKind.Local), 37, 5, new DateTime(2025, 10, 24, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 303, new DateTime(2025, 10, 24, 20, 0, 0, 0, DateTimeKind.Local), 39, 1, new DateTime(2025, 10, 24, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },

                    // Oct 24 - Route 2: Dhaka → Chittagong (3 buses)
                    { 304, new DateTime(2025, 10, 24, 11, 0, 0, 0, DateTimeKind.Local), 43, 2, new DateTime(2025, 10, 24, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },
                    { 305, new DateTime(2025, 10, 24, 15, 0, 0, 0, DateTimeKind.Local), 44, 6, new DateTime(2025, 10, 24, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },
                    { 306, new DateTime(2025, 10, 24, 21, 0, 0, 0, DateTimeKind.Local), 42, 2, new DateTime(2025, 10, 24, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },

                    // Oct 24 - Route 3: Dhaka → Cox's Bazar (3 buses)
                    { 307, new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Local), 49, 3, new DateTime(2025, 10, 24, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 308, new DateTime(2025, 10, 25, 6, 0, 0, 0, DateTimeKind.Local), 36, 7, new DateTime(2025, 10, 24, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 3 },
                    { 309, new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Local), 48, 3, new DateTime(2025, 10, 25, 2, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },

                    // Oct 24 - Route 4: Dhaka → Sylhet (3 buses)
                    { 310, new DateTime(2025, 10, 24, 22, 0, 0, 0, DateTimeKind.Local), 34, 4, new DateTime(2025, 10, 24, 16, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 311, new DateTime(2025, 10, 24, 15, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 4 },
                    { 312, new DateTime(2025, 10, 25, 5, 0, 0, 0, DateTimeKind.Local), 38, 4, new DateTime(2025, 10, 24, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 4 },

                    // Oct 24 - Route 5: Dhaka → Khulna (3 buses)
                    { 313, new DateTime(2025, 10, 25, 4, 0, 0, 0, DateTimeKind.Local), 47, 8, new DateTime(2025, 10, 24, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 314, new DateTime(2025, 10, 24, 16, 0, 0, 0, DateTimeKind.Local), 50, 10, new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 315, new DateTime(2025, 10, 25, 3, 0, 0, 0, DateTimeKind.Local), 48, 8, new DateTime(2025, 10, 24, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },

                    // Oct 24 - Route 6: Dhaka → Barisal (3 buses)
                    { 316, new DateTime(2025, 10, 24, 15, 0, 0, 0, DateTimeKind.Local), 49, 12, new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 317, new DateTime(2025, 10, 24, 21, 0, 0, 0, DateTimeKind.Local), 40, 2, new DateTime(2025, 10, 24, 15, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 },
                    { 318, new DateTime(2025, 10, 25, 11, 0, 0, 0, DateTimeKind.Local), 48, 12, new DateTime(2025, 10, 25, 5, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },

                    // Oct 24 - Route 7: Chittagong → Cox's Bazar (2 buses)
                    { 319, new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Local), 38, 9, new DateTime(2025, 10, 24, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 320, new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Local), 40, 6, new DateTime(2025, 10, 24, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 },

                    // Oct 24 - Route 8: Chittagong → Sylhet (2 buses)
                    { 321, new DateTime(2025, 10, 24, 16, 0, 0, 0, DateTimeKind.Local), 34, 11, new DateTime(2025, 10, 24, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },
                    { 322, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 25, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },

                    // Oct 25 - Route 1: Dhaka → Rajshahi (3 buses)
                    { 323, new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Local), 38, 1, new DateTime(2025, 10, 25, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },
                    { 324, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Local), 37, 5, new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1250m, 1 },
                    { 325, new DateTime(2025, 10, 25, 20, 0, 0, 0, DateTimeKind.Local), 39, 1, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 1 },

                    // Oct 25 - Route 2: Dhaka → Chittagong (3 buses)
                    { 326, new DateTime(2025, 10, 25, 11, 0, 0, 0, DateTimeKind.Local), 43, 2, new DateTime(2025, 10, 25, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },
                    { 327, new DateTime(2025, 10, 25, 15, 0, 0, 0, DateTimeKind.Local), 44, 6, new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 950m, 2 },
                    { 328, new DateTime(2025, 10, 25, 21, 0, 0, 0, DateTimeKind.Local), 42, 2, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 800m, 2 },

                    // Oct 25 - Route 3: Dhaka → Cox's Bazar (3 buses)
                    { 329, new DateTime(2025, 10, 26, 8, 0, 0, 0, DateTimeKind.Local), 49, 3, new DateTime(2025, 10, 25, 22, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },
                    { 330, new DateTime(2025, 10, 26, 6, 0, 0, 0, DateTimeKind.Local), 36, 7, new DateTime(2025, 10, 25, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 3 },
                    { 331, new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Local), 48, 3, new DateTime(2025, 10, 26, 4, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 3 },

                    // Oct 25 - Route 4: Dhaka → Sylhet (3 buses)
                    { 332, new DateTime(2025, 10, 25, 22, 0, 0, 0, DateTimeKind.Local), 34, 4, new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1450m, 4 },
                    { 333, new DateTime(2025, 10, 25, 15, 0, 0, 0, DateTimeKind.Local), 35, 11, new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 4 },
                    { 334, new DateTime(2025, 10, 26, 5, 0, 0, 0, DateTimeKind.Local), 38, 4, new DateTime(2025, 10, 25, 23, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1400m, 4 },

                    // Oct 25 - Route 5: Dhaka → Khulna (3 buses)
                    { 335, new DateTime(2025, 10, 26, 4, 0, 0, 0, DateTimeKind.Local), 47, 8, new DateTime(2025, 10, 25, 21, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1200m, 5 },
                    { 336, new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Local), 50, 10, new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },
                    { 337, new DateTime(2025, 10, 26, 3, 0, 0, 0, DateTimeKind.Local), 48, 8, new DateTime(2025, 10, 25, 20, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1100m, 5 },

                    // Oct 25 - Route 6: Dhaka → Barisal (3 buses)
                    { 338, new DateTime(2025, 10, 25, 15, 0, 0, 0, DateTimeKind.Local), 49, 12, new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },
                    { 339, new DateTime(2025, 10, 25, 21, 0, 0, 0, DateTimeKind.Local), 40, 2, new DateTime(2025, 10, 25, 15, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 850m, 6 },
                    { 340, new DateTime(2025, 10, 26, 11, 0, 0, 0, DateTimeKind.Local), 48, 12, new DateTime(2025, 10, 26, 5, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), 800m, 6 },

                    // Oct 25 - Route 7: Chittagong → Cox's Bazar (2 buses)
                    { 341, new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Local), 38, 9, new DateTime(2025, 10, 25, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 600m, 7 },
                    { 342, new DateTime(2025, 10, 25, 17, 0, 0, 0, DateTimeKind.Local), 40, 6, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 650m, 7 },

                    // Oct 25 - Route 8: Chittagong → Sylhet (2 buses)
                    { 343, new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Local), 34, 11, new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 },
                    { 344, new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Local), 36, 11, new DateTime(2025, 10, 26, 6, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), 1350m, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete the comprehensive schedules (Oct 24-25)
            for (int i = 301; i <= 344; i++)
            {
                migrationBuilder.DeleteData(table: "Schedules", keyColumn: "ScheduleId", keyValue: i);
            }
        }
    }
}
