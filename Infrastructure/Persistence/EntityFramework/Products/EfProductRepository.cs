using Domain.Products;

namespace Infrastructure.Persistence.EntityFramework.Products
{
    internal class EfProductRepository(ApplicationDbContext context) : IProductRepository
    {
        public Product? GetById(Guid id)
        {
            return context.Products.FirstOrDefault(user => user.Id == id);
        }

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
