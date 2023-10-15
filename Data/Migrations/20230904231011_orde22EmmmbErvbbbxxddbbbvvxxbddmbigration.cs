using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class orde22EmmmbErvbbbxxddbbbvvxxbddmbigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "orders");
        }
    }
}
