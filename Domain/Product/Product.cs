namespace Domain.Product
{
    public sealed class Product
    {
        public Guid Id { get; private set; }

        private Product(Guid id)
        {
            Id = id;
        }

        public static Product Create()
        {
            return new Product(Guid.NewGuid());
        }
    }
}
