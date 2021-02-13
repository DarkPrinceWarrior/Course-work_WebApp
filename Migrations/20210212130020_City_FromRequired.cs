using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class City_FromRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines");

            

            migrationBuilder.AlterColumn<int>(
                name: "CityBoardingId",
                table: "AirLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines",
                column: "CityBoardingId",
                principalTable: "city_From",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines");

           

            migrationBuilder.AlterColumn<int>(
                name: "CityBoardingId",
                table: "AirLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines",
                column: "CityBoardingId",
                principalTable: "city_From",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
