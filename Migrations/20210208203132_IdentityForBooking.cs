using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class IdentityForBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "Number_of_days", "Number_of_people", "RoomNumberId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "BookingId", "Number_of_days", "Number_of_people", "RoomNumberId" });
        }
    }
}
