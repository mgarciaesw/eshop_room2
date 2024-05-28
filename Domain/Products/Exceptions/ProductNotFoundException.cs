namespace Domain.Products.Exceptions
{
    public sealed class ProductNotFoundException()
        : Exception("The product was not found");
}
