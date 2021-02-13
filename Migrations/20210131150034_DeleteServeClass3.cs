using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class DeleteServeClass3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_serveClass_ServeClassId",
                table: "AirLines");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_ServeClassId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "ServeClassId",
                table: "AirLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServeClassId",
                table: "AirLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_ServeClassId",
                table: "AirLines",
                column: "ServeClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_serveClass_ServeClassId",
                table: "AirLines",
                column: "ServeClassId",
                principalTable: "serveClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
