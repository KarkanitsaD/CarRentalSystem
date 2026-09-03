using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CarWithDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00882590-454e-43ed-a31d-cb424b7b0179"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5d10caf7-01ce-4366-8ad0-3666b0d26fce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed6cecda-4a07-4c96-aff0-c61d256f09e6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f939c8a5-1d97-481a-a063-3a499ba4942c"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("00882590-454e-43ed-a31d-cb424b7b0179"), "Admin" },
                    { new Guid("5d10caf7-01ce-4366-8ad0-3666b0d26fce"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[,]
                {
                    { new Guid("f939c8a5-1d97-481a-a063-3a499ba4942c"), "admin@mail.ru", "Dima", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Karkanitsa" },
                    { new Guid("ed6cecda-4a07-4c96-aff0-c61d256f09e6"), "user@mail.ru", "Vova", "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", null, "Petrov" }
                });
        }
    }
}
