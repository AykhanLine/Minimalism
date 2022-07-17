using Marvel.Models;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        public DbSet<Banner> Banners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Callout> Callouts { get; set; }
        public DbSet<CallToAct> CallToActs { get; set; }
        public DbSet<Stylish> Stylishes { get; set; }

    }
}
