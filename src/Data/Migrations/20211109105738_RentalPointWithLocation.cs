using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RentalPointWithLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "LocationX",
                table: "RentalPoints",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LocationY",
                table: "RentalPoints",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationX",
                table: "RentalPoints");

            migrationBuilder.DropColumn(
                name: "LocationY",
                table: "RentalPoints");
        }
    }
}
