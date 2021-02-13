using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class Delete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_Tours_TourId",
                table: "AirLines");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_TourId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "AirLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "AirLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_TourId",
                table: "AirLines",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_Tours_TourId",
                table: "AirLines",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
