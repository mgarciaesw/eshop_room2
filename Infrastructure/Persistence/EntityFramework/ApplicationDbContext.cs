using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }
    }
}
