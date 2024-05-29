using Domain.Primitives;
using Domain.Shared;

namespace Domain.Products
{
    public sealed class Product : AggregateRoot
    {
        public ProductName Name { get; private set; }
        public StockQuantity Stock { get; private set; }

        private Product(
            Guid id,
            ProductName name,
            StockQuantity stock) : base(id)
        {
            Name = name;
            Stock = stock;
        }

        public void UpdateStock(StockQuantity stock)
        {
            Stock = stock;
        }

        public static Product Create(
            Guid id,
            ProductName name,
            StockQuantity stock)
        {
            return new Product(id, name, stock);
        }
    }
}
