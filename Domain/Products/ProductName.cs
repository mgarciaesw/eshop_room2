using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed record ProductName
    {
        public const int MaximumLength = 100;

        private ProductName(string value) => Value = value;

        public string Value { get; init; }

        public static ProductName Create(string value)
        {
            if (
                string.IsNullOrWhiteSpace(value) 
                || MaximumLength < value.Length)
            {
                throw new ProductNameIsInvalidException();
            }

            return new ProductName(value);
        }
    }
}
