using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NamingRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServiceEntityOrderEntity");

            migrationBuilder.CreateTable(
                name: "AdditionalFacilityEntityBookingEntity",
                columns: table => new
                {
                    AdditionalFacilitiesId = table.Column<int>(type: "int", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalFacilityEntityBookingEntity");

            migrationBuilder.CreateTable(
                name: "AdditionalServiceEntityOrderEntity",
                columns: table => new
                {
                    AdditionalServicesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServiceEntityOrderEntity", x => new { x.AdditionalServicesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_AdditionalServiceEntityOrderEntity_AdditionalFacilities_AdditionalServicesId",
                        column: x => x.AdditionalServicesId,
                        principalTable: "AdditionalFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceEntityOrderEntity_Bookings_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceEntityOrderEntity_OrdersId",
                table: "AdditionalServiceEntityOrderEntity",
                column: "OrdersId");
        }
    }
}
