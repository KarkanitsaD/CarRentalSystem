using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalFacilityEntityBookingEntity");

            migrationBuilder.DropTable(
                name: "AdditionalFacilities");

            migrationBuilder.CreateTable(
                name: "RefreshTokenEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokenEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokenEntity_UserId",
                table: "RefreshTokenEntity",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokenEntity");

            migrationBuilder.CreateTable(
                name: "AdditionalFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalFacilityEntityBookingEntity",
                columns: table => new
                {
                    AdditionalFacilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFacilityEntityBookingEntity", x => new { x.AdditionalFacilitiesId, x.BookingsId });
                    table.ForeignKey(
                        name: "FK_AdditionalFacilityEntityBookingEntity_AdditionalFacilities_AdditionalFacilitiesId",
                        column: x => x.AdditionalFacilitiesId,
                        principalTable: "AdditionalFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalFacilityEntityBookingEntity_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFacilityEntityBookingEntity_BookingsId",
                table: "AdditionalFacilityEntityBookingEntity",
                column: "BookingsId");
        }
    }
}
