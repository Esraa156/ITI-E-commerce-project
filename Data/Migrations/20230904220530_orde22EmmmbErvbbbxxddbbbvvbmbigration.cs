using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErvbbbxxddbbbvvbmbigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAppId",
                table: "orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserAppId",
                table: "orders",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users_UserAppId",
                table: "orders",
                column: "UserAppId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users_UserAppId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserAppId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "orders");
        }
    }
}
