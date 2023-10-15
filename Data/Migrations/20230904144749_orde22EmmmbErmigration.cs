using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Users_userappId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_userappId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "userappId",
                table: "carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userappId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userappId",
                table: "carts",
                column: "userappId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Users_userappId",
                table: "carts",
                column: "userappId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
