using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;

namespace PortfolioApp.Data
{
    public class PortfolioContext : IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public PortfolioContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin");
            admin.Id = "3fd74a41-6d88-4f1a-b31a-7d0e57c8505b";
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.Id = "353b80d2-b41b-496c-9f7a-460949d38355";
            client.NormalizedName = "client";

            modelBuilder.Entity<IdentityRole>().HasData(admin, client);
        }
    }
}
