using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DateTimeOffsetInBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("105e1b89-f0f8-4844-9b13-3350000810ea"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a222f51-0009-4cef-91bf-1c7d32cc7622"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fabbb912-8e4b-455f-a698-b07f20d27a8a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd65b64d-feb9-4f7b-9d0f-b2e05cdfa6b0"));

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
                    { new Guid("3a27995f-bde1-4291-8424-5755c83dbc8d"), "Admin" },
                    { new Guid("73819f26-dcbf-4a91-9e9d-a3b875518722"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[,]
                {
                    { new Guid("a3ffb6ad-fe85-4389-a9e8-89676df459e3"), "admin@mail.ru", "Dima", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Karkanitsa" },
                    { new Guid("4166a61f-976a-4910-bd58-4432275961e9"), "user@mail.ru", "Vova", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Petrov" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a27995f-bde1-4291-8424-5755c83dbc8d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("73819f26-dcbf-4a91-9e9d-a3b875518722"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4166a61f-976a-4910-bd58-4432275961e9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3ffb6ad-fe85-4389-a9e8-89676df459e3"));

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
                    { new Guid("7a222f51-0009-4cef-91bf-1c7d32cc7622"), "Admin" },
                    { new Guid("105e1b89-f0f8-4844-9b13-3350000810ea"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[,]
                {
                    { new Guid("fabbb912-8e4b-455f-a698-b07f20d27a8a"), "admin@mail.ru", "Dima", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Karkanitsa" },
                    { new Guid("fd65b64d-feb9-4f7b-9d0f-b2e05cdfa6b0"), "user@mail.ru", "Vova", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Petrov" }
                });
        }
    }
}
