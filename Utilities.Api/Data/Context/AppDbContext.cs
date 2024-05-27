using Api.Utilities.Data.Mappings;
using Api.Utilities.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Utilities.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmailProvider> EmailProviders => Set<EmailProvider>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailProvider>(new EmailDomainMap().Configure);
        }
    }
}
