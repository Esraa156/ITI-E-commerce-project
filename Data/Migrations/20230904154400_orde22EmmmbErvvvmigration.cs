using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErvvvmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_ORDERId",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "ORDERId",
                table: "carts",
                newName: "oRDERId");

            migrationBuilder.RenameIndex(
                name: "IX_carts_ORDERId",
                table: "carts",
                newName: "IX_carts_oRDERId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_oRDERId",
                table: "carts",
                column: "oRDERId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_oRDERId",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "oRDERId",
                table: "carts",
                newName: "ORDERId");

            migrationBuilder.RenameIndex(
                name: "IX_carts_oRDERId",
                table: "carts",
                newName: "IX_carts_ORDERId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_ORDERId",
                table: "carts",
                column: "ORDERId",
                principalTable: "orders",
                principalColumn: "Id");
        }
    }
}
