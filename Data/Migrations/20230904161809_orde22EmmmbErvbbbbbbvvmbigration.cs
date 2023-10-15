using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErvbbbbbbvvmbigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts");

            migrationBuilder.AlterColumn<string>(
                name: "UserAppId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts",
                column: "UserAppId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts");

            migrationBuilder.AlterColumn<string>(
                name: "UserAppId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Users_UserAppId",
                table: "carts",
                column: "UserAppId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
