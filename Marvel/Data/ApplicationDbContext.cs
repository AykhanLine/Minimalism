using Marvel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data
{
    public class ApplicationDbContext : IdentityDbContext<M001User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        public DbSet<Banner> Banners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Callout> Callouts { get; set; }
        public DbSet<CallToAct> CallToActs { get; set; }
        public DbSet<Stylish> Stylishes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<M001User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }

    }

    
}
