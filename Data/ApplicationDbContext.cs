using bnm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bnm.Entities
{

    public class ApplicationDbContext : IdentityDbContext<UserApp>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)

        {

        }
        //       "ConnectionStrings": {
        //  "DefaultConnection": "Server=LAPTOP-ASFDTF01\\MSSQLSERVERR;Database=Finallll;Trusted_Connection=True;MultipleActiveResultSets=true"
        //}
        public virtual DbSet<Product> products { set; get; }
     
        public DbSet<Cart> carts { get; set; }
        public DbSet<ORDER> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserApp>().ToTable("User", "security");

            builder.Entity<Seller>().ToTable("Seller", "security");
            builder.Entity<Buyer>().ToTable("Buyer", "security");

            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
        }
    }
}
