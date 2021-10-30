using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CountyCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "RentalPoints",
                newName: "CountryId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RentalPoints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "RentalPoints",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.UniqueConstraint("AK_Countries_Title", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalPoints_CityId",
                table: "RentalPoints",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPoints_CountryId",
                table: "RentalPoints",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPoints_Cities_CityId",
                table: "RentalPoints",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPoints_Countries_CountryId",
                table: "RentalPoints",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPoints_Cities_CityId",
                table: "RentalPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPoints_Countries_CountryId",
                table: "RentalPoints");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_RentalPoints_CityId",
                table: "RentalPoints");

            migrationBuilder.DropIndex(
                name: "IX_RentalPoints_CountryId",
                table: "RentalPoints");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "RentalPoints");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "RentalPoints");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "RentalPoints",
                newName: "LocationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryEntity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RentalPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_RentalPoints_RentalPointId",
                        column: x => x.RentalPointId,
                        principalTable: "RentalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RentalPointId",
                table: "Locations",
                column: "RentalPointId",
                unique: true,
                filter: "[RentalPointId] IS NOT NULL");
        }
    }
}
