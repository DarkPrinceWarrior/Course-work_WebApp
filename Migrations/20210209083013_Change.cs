using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "Id", "Number_of_days", "Number_of_people", "RoomNumberId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Booking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                columns: new[] { "Number_of_days", "Number_of_people", "RoomNumberId" });
        }
    }
}
