using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed record StockQuantity
    {
        public const int MinimumValue = 0;

        private StockQuantity(int value) => Value = value;

        public int Value { get; init; }

        public static StockQuantity Create(int value)
        {
            if (value < MinimumValue)
            {
                throw new StockQuantityIsInvalidException();
            }

            return new StockQuantity(value);
        }
    }
}
