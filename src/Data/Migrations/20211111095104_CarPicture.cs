using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CarPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7cf47bf1-8d8c-4052-aca8-0c9fe552af61"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("aa9a2a71-f067-496b-ae27-ac9bfc92de19"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b9648ce7-ea43-4a38-b4ce-2c6e45e0bd33"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c39d5d90-5a66-455f-86f8-375b56b5fbae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("19833c78-0c21-474d-b5de-7d6b00271434"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5679e3dc-1f0a-4989-85a4-a14dccc47bb5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("486839dc-6d7a-4dec-a88c-f345b7e47e47"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7274cc9f-146d-4ebe-886b-da90968fd42f"));

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: new Guid("1d923094-1728-4c78-9169-7a7dfd95c8ae"));

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: new Guid("2030b8bb-8ec5-49ab-9300-a10430f65f5e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("42a1105d-4a06-438e-8343-b58a73c58466"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fa4a64cb-8a48-4db3-b15b-15de6fb2f5bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec06f33f-f038-4a1a-838d-b5930e1a75da"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec25bc88-148b-4219-be94-90b986a93b94"));

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CarPictureEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPictureEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPictureEntities_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("b42689fa-c196-4a91-9c7c-7560eaf142a2"), "Belarus" },
                    { new Guid("4bb86572-d916-4de5-ad4b-7664f6edf11e"), "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("5a26a613-a53f-47b5-a770-d9b00f48bb76"), "Admin" },
                    { new Guid("d0014d6e-cc4d-4957-9556-624504291be9"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Surname" },
                values: new object[,]
                {
                    { new Guid("b44c72f6-d61f-4e49-a625-6a248ebacfc3"), "admin1@mail.ru", null, "123456", null },
                    { new Guid("9529dcc8-5137-447f-b128-a9ab85e7529e"), "user1@mail.ru", null, "123456", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Title" },
                values: new object[] { new Guid("3fb8fddf-d9d3-4678-a235-ae9ff3a5c92f"), new Guid("b42689fa-c196-4a91-9c7c-7560eaf142a2"), "Minsk" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Title" },
                values: new object[] { new Guid("398e9c3c-2dc8-4068-bcb6-befa6b87df0f"), new Guid("4bb86572-d916-4de5-ad4b-7664f6edf11e"), "Warsaw" });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "Address", "CityId", "CountryId", "LocationX", "LocationY", "Title" },
                values: new object[] { new Guid("949694b8-0204-4796-999c-5afb4c58d4bf"), null, new Guid("3fb8fddf-d9d3-4678-a235-ae9ff3a5c92f"), new Guid("b42689fa-c196-4a91-9c7c-7560eaf142a2"), null, null, "Title 1!" });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "Address", "CityId", "CountryId", "LocationX", "LocationY", "Title" },
                values: new object[] { new Guid("fe05c837-2253-4282-b07f-45b49726c1b1"), null, new Guid("398e9c3c-2dc8-4068-bcb6-befa6b87df0f"), new Guid("4bb86572-d916-4de5-ad4b-7664f6edf11e"), null, null, "Title 2!" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBrand", "Color", "FuelConsumptionPerHundredKilometers", "IsBooked", "LastViewTime", "NumberOfSeats", "PricePerDay", "RentalPointId", "TransmissionType", "VehicleNumber" },
                values: new object[,]
                {
                    { new Guid("5329b90f-4717-412a-833b-fd4eaa42df21"), "Porsche 911", "Red", 12m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 150m, new Guid("949694b8-0204-4796-999c-5afb4c58d4bf"), "Automate", null },
                    { new Guid("10ce6fd2-3d35-4023-8ba4-db331cd47941"), "Renault Kadjar", "Black", 4m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 60m, new Guid("949694b8-0204-4796-999c-5afb4c58d4bf"), "Mechanic", null },
                    { new Guid("effed9d0-ccae-42a8-8761-4a08ed2729ee"), "Mazda cx 5", "Blue", 6.7m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 65m, new Guid("949694b8-0204-4796-999c-5afb4c58d4bf"), "Mechanic", null },
                    { new Guid("5b41df87-3680-437a-969c-53f13f5c8ab3"), "Mazda cx 5", "Red", 6.7m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 65m, new Guid("fe05c837-2253-4282-b07f-45b49726c1b1"), "Mechanic", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPictureEntities_CarId",
                table: "CarPictureEntities",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPictureEntities");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("10ce6fd2-3d35-4023-8ba4-db331cd47941"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5329b90f-4717-412a-833b-fd4eaa42df21"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5b41df87-3680-437a-969c-53f13f5c8ab3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("effed9d0-ccae-42a8-8761-4a08ed2729ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5a26a613-a53f-47b5-a770-d9b00f48bb76"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d0014d6e-cc4d-4957-9556-624504291be9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9529dcc8-5137-447f-b128-a9ab85e7529e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b44c72f6-d61f-4e49-a625-6a248ebacfc3"));

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: new Guid("949694b8-0204-4796-999c-5afb4c58d4bf"));

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: new Guid("fe05c837-2253-4282-b07f-45b49726c1b1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("398e9c3c-2dc8-4068-bcb6-befa6b87df0f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3fb8fddf-d9d3-4678-a235-ae9ff3a5c92f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4bb86572-d916-4de5-ad4b-7664f6edf11e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b42689fa-c196-4a91-9c7c-7560eaf142a2"));

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("ec06f33f-f038-4a1a-838d-b5930e1a75da"), "Belarus" },
                    { new Guid("ec25bc88-148b-4219-be94-90b986a93b94"), "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("5679e3dc-1f0a-4989-85a4-a14dccc47bb5"), "Admin" },
                    { new Guid("19833c78-0c21-474d-b5de-7d6b00271434"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Surname" },
                values: new object[,]
                {
                    { new Guid("486839dc-6d7a-4dec-a88c-f345b7e47e47"), "admin@mail.ru", null, "123456", null },
                    { new Guid("7274cc9f-146d-4ebe-886b-da90968fd42f"), "user@mail.ru", null, "123456", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Title" },
                values: new object[] { new Guid("42a1105d-4a06-438e-8343-b58a73c58466"), new Guid("ec06f33f-f038-4a1a-838d-b5930e1a75da"), "Minsk" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Title" },
                values: new object[] { new Guid("fa4a64cb-8a48-4db3-b15b-15de6fb2f5bb"), new Guid("ec25bc88-148b-4219-be94-90b986a93b94"), "Warsaw" });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "Address", "CityId", "CountryId", "LocationX", "LocationY", "Title" },
                values: new object[] { new Guid("1d923094-1728-4c78-9169-7a7dfd95c8ae"), null, new Guid("42a1105d-4a06-438e-8343-b58a73c58466"), new Guid("ec06f33f-f038-4a1a-838d-b5930e1a75da"), null, null, "Title 1!" });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "Address", "CityId", "CountryId", "LocationX", "LocationY", "Title" },
                values: new object[] { new Guid("2030b8bb-8ec5-49ab-9300-a10430f65f5e"), null, new Guid("fa4a64cb-8a48-4db3-b15b-15de6fb2f5bb"), new Guid("ec25bc88-148b-4219-be94-90b986a93b94"), null, null, "Title 2!" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBrand", "Color", "FuelConsumptionPerHundredKilometers", "IsBooked", "LastViewTime", "NumberOfSeats", "PricePerDay", "RentalPointId", "TransmissionType", "VehicleNumber" },
                values: new object[,]
                {
                    { new Guid("aa9a2a71-f067-496b-ae27-ac9bfc92de19"), "Porsche 911", "Red", 12m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 150m, new Guid("1d923094-1728-4c78-9169-7a7dfd95c8ae"), "Automate", null },
                    { new Guid("c39d5d90-5a66-455f-86f8-375b56b5fbae"), "Renault Kadjar", "Black", 4m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 60m, new Guid("1d923094-1728-4c78-9169-7a7dfd95c8ae"), "Mechanic", null },
                    { new Guid("b9648ce7-ea43-4a38-b4ce-2c6e45e0bd33"), "Mazda cx 5", "Blue", 6.7m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 65m, new Guid("1d923094-1728-4c78-9169-7a7dfd95c8ae"), "Mechanic", null },
                    { new Guid("7cf47bf1-8d8c-4052-aca8-0c9fe552af61"), "Mazda cx 5", "Red", 6.7m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 65m, new Guid("2030b8bb-8ec5-49ab-9300-a10430f65f5e"), "Mechanic", null }
                });
        }
    }
}
