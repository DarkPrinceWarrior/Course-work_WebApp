using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class SetNullairLineId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AirLines_AirLineId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "AirLineId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "BookingId", "Number_of_days", "Number_of_people" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AirLines_AirLineId",
                table: "Booking",
                column: "AirLineId",
                principalTable: "AirLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AirLines_AirLineId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "AirLineId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "BookingId", "Number_of_days", "Number_of_people", "AirLineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AirLines_AirLineId",
                table: "Booking",
                column: "AirLineId",
                principalTable: "AirLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
