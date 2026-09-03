using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BookingWithCustomerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07180e0f-83cf-4f6a-95a7-a8abba451f3c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("38fb64f0-9fe9-451d-b0b0-1714600b19c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("056ae3a0-63c3-4a81-9a61-3b942bfbe056"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5fe769b0-0608-4dd8-ba6c-dbd487d530d1"));

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("07180e0f-83cf-4f6a-95a7-a8abba451f3c"), "Admin" },
                    { new Guid("38fb64f0-9fe9-451d-b0b0-1714600b19c0"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[,]
                {
                    { new Guid("056ae3a0-63c3-4a81-9a61-3b942bfbe056"), "admin@mail.ru", "Dima", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Karkanitsa" },
                    { new Guid("5fe769b0-0608-4dd8-ba6c-dbd487d530d1"), "user@mail.ru", "Vova", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Petrov" }
                });
        }
    }
}
