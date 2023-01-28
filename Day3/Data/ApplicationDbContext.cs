using Day3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IPN> IPNs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
               base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}