using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed record ProductName
    {
        public const int MinimumLength = 3;

        private ProductName(string value) => Value = value;

        public string Value { get; init; }

        public static ProductName Create(string value)
        {
            if (
                string.IsNullOrWhiteSpace(value) 
                || value.Length < MinimumLength)
            {
                throw new ProductNameIsInvalidException();
            }

            return new ProductName(value);
        }
    }
}
