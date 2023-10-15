﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class bvnvbbbvvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(

               table: "Roles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

                     values: new object[] { Guid.NewGuid().ToString(), "Seller", "Seller".ToUpper(), Guid.NewGuid().ToString() },
                schema: "security"
            );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Buyer", "Buyer".ToUpper(), Guid.NewGuid().ToString() },
                schema: "security"


               );
        }

    

    protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.Sql("DELETE FROM [security].[Roles]");

    }
}
}
