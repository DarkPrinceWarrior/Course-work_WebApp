using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency1._0.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotelRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "serveClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servingClass = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serveClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descrip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Resources\\Photos\\deffaultPic.jpg")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLineName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TheSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServeClassId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirLines_serveClass_ServeClassId",
                        column: x => x.ServeClassId,
                        principalTable: "serveClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirLines_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Hotel_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NightPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descrip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreePlaces = table.Column<int>(type: "int", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Resources\\Photos\\deffaultPic.jpg")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    series = table.Column<int>(type: "int", nullable: false),
                    PNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userData_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roomNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomNumber = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    RoomSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    roomTypeId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomNumber_hotelRoom_roomTypeId",
                        column: x => x.roomTypeId,
                        principalTable: "hotelRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roomNumber_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    Number_of_people = table.Column<int>(type: "int", nullable: false),
                    Number_of_days = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    RoomNumberId = table.Column<int>(type: "int", nullable: false),
                    TouristId = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => new { x.BookingId, x.Number_of_days, x.Number_of_people, x.AirLineId });
                    table.ForeignKey(
                        name: "FK_Booking_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_roomNumber_RoomNumberId",
                        column: x => x.RoomNumberId,
                        principalTable: "roomNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_userData_TouristId",
                        column: x => x.TouristId,
                        principalTable: "userData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_AirLineName",
                table: "AirLines",
                column: "AirLineName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_ServeClassId",
                table: "AirLines",
                column: "ServeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_TourId",
                table: "AirLines",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AirLineId",
                table: "Booking",
                column: "AirLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomNumberId",
                table: "Booking",
                column: "RoomNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TouristId",
                table: "Booking",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelRoom_RoomType",
                table: "hotelRoom",
                column: "RoomType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Hotel_Name",
                table: "Hotels",
                column: "Hotel_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_TourId",
                table: "Hotels",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roomNumber_HotelId",
                table: "roomNumber",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_roomNumber_roomTypeId",
                table: "roomNumber",
                column: "roomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_serveClass_servingClass",
                table: "serveClass",
                column: "servingClass",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_City",
                table: "Tours",
                column: "City",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Tour_Name",
                table: "Tours",
                column: "Tour_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userData_FIO",
                table: "userData",
                column: "FIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userData_PNumber",
                table: "userData",
                column: "PNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userData_series",
                table: "userData",
                column: "series",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userData_UserId",
                table: "userData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_password",
                table: "Users",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "AirLines");

            migrationBuilder.DropTable(
                name: "roomNumber");

            migrationBuilder.DropTable(
                name: "userData");

            migrationBuilder.DropTable(
                name: "serveClass");

            migrationBuilder.DropTable(
                name: "hotelRoom");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
