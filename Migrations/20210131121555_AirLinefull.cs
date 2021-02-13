using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class AirLinefull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AirLines_AirLineName",
                table: "AirLines");

            migrationBuilder.AlterColumn<string>(
                name: "AirLineName",
                table: "AirLines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "AirCompId",
                table: "AirLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityBoardingId",
                table: "AirLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityLandingId",
                table: "AirLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "airCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirCompName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "city_From",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city_From", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cityLanding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityLanding", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_AirCompId",
                table: "AirLines",
                column: "AirCompId");

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_CityBoardingId",
                table: "AirLines",
                column: "CityBoardingId");

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_CityLandingId",
                table: "AirLines",
                column: "CityLandingId");

            migrationBuilder.CreateIndex(
                name: "IX_airCompany_AirCompName",
                table: "airCompany",
                column: "AirCompName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_From_City",
                table: "city_From",
                column: "City",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cityLanding_City",
                table: "cityLanding",
                column: "City",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_airCompany_AirCompId",
                table: "AirLines",
                column: "AirCompId",
                principalTable: "airCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines",
                column: "CityBoardingId",
                principalTable: "city_From",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_cityLanding_CityLandingId",
                table: "AirLines",
                column: "CityLandingId",
                principalTable: "cityLanding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_airCompany_AirCompId",
                table: "AirLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_city_From_CityBoardingId",
                table: "AirLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_cityLanding_CityLandingId",
                table: "AirLines");

            migrationBuilder.DropTable(
                name: "airCompany");

            migrationBuilder.DropTable(
                name: "city_From");

            migrationBuilder.DropTable(
                name: "cityLanding");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_AirCompId",
                table: "AirLines");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_CityBoardingId",
                table: "AirLines");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_CityLandingId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "AirCompId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "CityBoardingId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "CityLandingId",
                table: "AirLines");

            migrationBuilder.AlterColumn<string>(
                name: "AirLineName",
                table: "AirLines",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_AirLineName",
                table: "AirLines",
                column: "AirLineName",
                unique: true);
        }
    }
}
