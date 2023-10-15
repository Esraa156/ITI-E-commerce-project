using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Security;

#nullable disable

namespace bnm.Data.Migrations
{
    public partial class AddAdminUserrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT[security].[Users]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [phone]) VALUES(N'5ade60d2-74b8-4bbb-820a-92fe5b8c095e', N'Admin1', N'ADMIN1', N'e@gmail.com', N'E@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOxU3/lMSkVg6R1XxoeSD7KE5cgTKOAwG/Zq3Kbp+HduDKMWeR/9AQY9d6yKfDDPcA==', N'YE5MD7PXWJIIL5D7OLUSQLC4B52JT7NO', N'8b390d21-0300-45a8-89c4-c26d50b6ad37', NULL, 0, 0, NULL, 1, 0, N'Admin1', N'ooooooo', N'011')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '5ade60d2-74b8-4bbb-820a-92fe5b8c095e'");
        }
    }
}
