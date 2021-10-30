using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokenEntity_Users_UserId",
                table: "RefreshTokenEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokenEntity",
                table: "RefreshTokenEntity");

            migrationBuilder.RenameTable(
                name: "RefreshTokenEntity",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokenEntity_UserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshTokenEntity");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokenEntity",
                newName: "IX_RefreshTokenEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokenEntity",
                table: "RefreshTokenEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokenEntity_Users_UserId",
                table: "RefreshTokenEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}