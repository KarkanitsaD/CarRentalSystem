using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdditionalFacilities",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, null, 3.6m, "Moika mashiny" },
                    { 2, null, 2.5m, "Water to car" },
                    { 3, null, 3.6m, "Vacuum cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "Country", "RentalPointId" },
                values: new object[,]
                {
                    { 1, "Lenina 1", "Grodno", "Belarus", null },
                    { 2, "Real 1", "Madrid", "Spain", null },
                    { 3, "Sun 33a", "Barcelona", "Spain", null },
                    { 4, "Red Square 56", "Moscow", "Russia", null }
                });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "LocationId", "Title" },
                values: new object[,]
                {
                    { 4, 4, "Best cars4" },
                    { 3, 3, "Best cars3" },
                    { 2, 2, "Best cars2" },
                    { 1, 1, "Best cars" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Surname" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "aakarkanica@gmail.com", "Dima", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "Karkanitsa" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "mail1@gmail.com", "User 1", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "Karkanitsa" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "mail2@gmail.com", "User 2", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "Karkanitsa" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "mail3@gmail.com", "User 3", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "Karkanitsa" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBrand", "Color", "FuelConsumptionPerHundredKilometers", "IsBooked", "LastViewTime", "NumberOfSeats", "PricePerDay", "RentalPointId", "TransmissionType", "VehicleNumber" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Audi A4", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 1, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Car 2", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 1, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Car 3", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 1, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Car 4", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 1, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Car 5", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 1, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Car 2", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 2, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Car 3", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 2, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Car 4", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 3, "Automate", "7300EK-4" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Car 5", "Green", 7.44m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 20.5m, 4, "Automate", "7300EK-4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdditionalFacilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdditionalFacilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdditionalFacilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalPoints",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
