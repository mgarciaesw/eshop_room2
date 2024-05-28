using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed record ProductDescription
    {
        public const int MinimumLength = 3;

        private ProductDescription(string value) => Value = value;

        public string Value { get; init; }

        public static ProductDescription Create(string value)
        {
            if (
                string.IsNullOrWhiteSpace(value)
                || value.Length < MinimumLength)
            {
                throw new ProductDescriptionIsInvalidException();
            }

            return new ProductDescription(value);
        }
    }
}
