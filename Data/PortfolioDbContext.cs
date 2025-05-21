using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models; // assuming your models are in Models/

namespace PortfolioApp.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
