using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CitiesWithOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33c8bfbe-f54f-4b8c-a0e8-20ccd77d55fe"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f5b8f85c-c63f-45fe-9e2a-f590153fe3fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4576e150-02d1-454d-b804-0f3755c2c193"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8311b2a8-3a2a-484a-86ef-00a679f6a12f"));

            migrationBuilder.AddColumn<float>(
                name: "TimeOffset",
                table: "Cities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KeyReceivingTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KeyHandOverTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TimeOffset",
                table: "Cities");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "KeyReceivingTime",
                table: "Bookings",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "KeyHandOverTime",
                table: "Bookings",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BookingTime",
                table: "Bookings",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("f5b8f85c-c63f-45fe-9e2a-f590153fe3fb"), "Admin" },
                    { new Guid("33c8bfbe-f54f-4b8c-a0e8-20ccd77d55fe"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[,]
                {
                    { new Guid("8311b2a8-3a2a-484a-86ef-00a679f6a12f"), "admin@mail.ru", "Dima", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Karkanitsa" },
                    { new Guid("4576e150-02d1-454d-b804-0f3755c2c193"), "user@mail.ru", "Vova", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Petrov" }
                });
        }
    }
}
