using Domain.Primitives;
using Domain.Shared;

namespace Domain.Products
{
    public sealed class Product : AggregateRoot
    {
        public Guid Id { get; private set; }
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public StockQuantity Stock { get; private set; }
        public Money Price { get; private set; }

        private Product(Guid id, ProductName name, ProductDescription description, StockQuantity stock, Money price) : base(id)
        {
            Id = id;
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
        }

        public void UpdateStock(StockQuantity stock)
        {
            Stock = stock;
        }

        public static Product Create(ProductName name, ProductDescription description, StockQuantity stock, Money price)
        {
            return new Product(Guid.NewGuid(), name, description, stock, price);
        }
    }
}
