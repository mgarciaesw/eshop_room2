namespace Domain.Products
{
    public interface IProductRepository
    {
        Product? GetById(Guid id);
        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
    }
}
