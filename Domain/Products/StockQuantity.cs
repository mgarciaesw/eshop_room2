using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed record StockQuantity
    {
        public const decimal MinimumValue = 0;

        private StockQuantity(decimal value) => Value = value;

        public decimal Value { get; init; }

        public static StockQuantity Create(decimal value)
        {
            if (MinimumValue < value)
            {
                throw new StockQuantityIsInvalidException();
            }

            return new StockQuantity(value);
        }
    }
}
