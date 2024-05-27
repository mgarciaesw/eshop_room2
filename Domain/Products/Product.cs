using Domain.Primitives;

namespace Domain.Products
{
    public sealed class Product : AggregateRoot
    {
        public Guid Id { get; private set; }
        public ProductName Name { get; private set; }
        public StockQuantity Stock { get; private set; }

        private Product(Guid id, ProductName name, StockQuantity stock) : base(id)
        {
            Id = id;
            Name = name;
            Stock = stock;
        }

        public void UpdateStock(StockQuantity stock)
        {
            Stock = stock;
        }

        public static Product Create(ProductName name, StockQuantity stock)
        {
            return new Product(Guid.NewGuid(), name, stock);
        }
    }
}
