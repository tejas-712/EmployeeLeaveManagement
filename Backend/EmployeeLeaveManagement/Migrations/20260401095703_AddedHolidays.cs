using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeLeaveManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedHolidays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Date", "LocationId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Republic Day", "National" },
                    { 2, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Republic Day", "National" },
                    { 6, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "May Day", "National" },
                    { 7, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "May Day", "National" },
                    { 11, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gandhi Jayanti", "National" },
                    { 12, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Gandhi Jayanti", "National" },
                    { 16, new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Christmas", "National" },
                    { 17, new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Christmas", "National" },
                    { 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "New Year", "Regional" },
                    { 24, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pongal/Sankranti", "Regional" },
                    { 27, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Holi", "Regional" },
                    { 29, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ugadi", "Regional" },
                    { 31, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ramzan", "Regional" },
                    { 32, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ramzan", "Regional" },
                    { 38, new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Telangana Formation", "Regional" },
                    { 39, new DateTime(2026, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ganesh Chaturthi", "Regional" },
                    { 42, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "VijayaDasami", "Regional" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 3, "Chennai" },
                    { 4, "Kolkata" },
                    { 5, "Bangalore" }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Date", "LocationId", "Name", "Type" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Republic Day", "National" },
                    { 4, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Republic Day", "National" },
                    { 5, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Republic Day", "National" },
                    { 8, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "May Day", "National" },
                    { 9, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "May Day", "National" },
                    { 10, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "May Day", "National" },
                    { 13, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Gandhi Jayanti", "National" },
                    { 14, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Gandhi Jayanti", "National" },
                    { 15, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gandhi Jayanti", "National" },
                    { 18, new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Christmas", "National" },
                    { 19, new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Christmas", "National" },
                    { 20, new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Christmas", "National" },
                    { 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "New Year", "Regional" },
                    { 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "New Year", "Regional" },
                    { 25, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pongal/Sankranti", "Regional" },
                    { 26, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Pongal/Sankranti", "Regional" },
                    { 28, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Doljatra", "Regional" },
                    { 30, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ugadi", "Regional" },
                    { 33, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ramzan", "Regional" },
                    { 34, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ramzan", "Regional" },
                    { 35, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ramzan", "Regional" },
                    { 36, new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Tamil New Year", "Regional" },
                    { 37, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bengali New Year", "Regional" },
                    { 40, new DateTime(2026, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ganesh Chaturthi", "Regional" },
                    { 41, new DateTime(2026, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ganesh Chaturthi", "Regional" },
                    { 43, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "VijayaDasami", "Regional" },
                    { 44, new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Durga Puja", "Regional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_LocationId",
                table: "Holidays",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
