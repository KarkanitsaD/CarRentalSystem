using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
