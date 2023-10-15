using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErvvvmbigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAppId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_carts_UserAppId",
                table: "carts",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts",
                column: "UserAppId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_UserAppId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "carts");
        }
    }
}
