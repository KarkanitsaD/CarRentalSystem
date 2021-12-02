using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BookingWithPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

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
    }
}
