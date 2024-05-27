namespace Domain.Product
{
    public sealed record ProductName
    {
        public const int MaximumLength = 100;

        private ProductName(string value) => Value = value;

        public string Value { get; init; }

        public static ProductName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {

                throw new Exception();
            }

            if (MaximumLength < value.Length)
            {
                throw new Exception();
            }

            return new ProductName(value);
        }
    }
}
