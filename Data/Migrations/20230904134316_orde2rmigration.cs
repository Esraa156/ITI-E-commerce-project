using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde2rmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userappId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_Users_userappId",
                        column: x => x.userappId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_OrderId",
                table: "carts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userappId",
                table: "orders",
                column: "userappId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropIndex(
                name: "IX_carts_OrderId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "carts");
        }
    }
}
