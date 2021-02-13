using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class DeleteRelatUserDataBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_userData_TouristId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TouristId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TouristId",
                table: "Booking",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_userData_TouristId",
                table: "Booking",
                column: "TouristId",
                principalTable: "userData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
