using Domain.Products;

namespace Infrastructure.Persistence.InMemory
{
    public sealed class InMemoryProductRepository : IProductRepository
    {
        private static IEnumerable<Product> InMemoryProducts => [
            CreateProduct(
                "fd0327a1-7cb5-46e7-90fe-03a8835ccdec",
                "Product A",
                0),
            CreateProduct(
                "2f5dcb07-2d4b-461d-bb9d-4693916d51d5",
                "Product B",
                5),
            CreateProduct(
                "ecdb3a9c-3f67-4b8d-abd3-577199e7a2da",
                "Product C",
                101),
        ];

        public Product? GetById(Guid id)
        {
            return InMemoryProducts.SingleOrDefault(product => product.Id == id);
        }

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        private static Product CreateProduct(string id, string name, int stock)
        {
            return Product.Create(
                new Guid(id),
                ProductName.Create(name),
                StockQuantity.Create(stock));
        }
    }
}
