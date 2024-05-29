using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Products
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(e => e.Name)
                .HasConversion(
                    v => v.Value,
                    v => ProductName.Create(v))
                .IsRequired();

            builder
                .Property(e => e.Stock)
                .HasConversion(
                    v => v.Value,
                    v => StockQuantity.Create(v))
                .IsRequired();
        }
    }
}
