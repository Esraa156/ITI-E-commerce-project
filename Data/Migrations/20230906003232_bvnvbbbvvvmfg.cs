using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class bvnvbbbvvvmfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Seller_SellerId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_SellerId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "sId",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_products_sId",
                table: "products",
                column: "sId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Seller_sId",
                table: "products",
                column: "sId",
                principalSchema: "security",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Seller_sId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_sId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "sId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_SellerId",
                table: "products",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Seller_SellerId",
                table: "products",
                column: "SellerId",
                principalSchema: "security",
                principalTable: "Seller",
                principalColumn: "Id");
        }
    }
}
