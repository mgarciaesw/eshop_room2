using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed class ProductFinder(IProductRepository productRepository)
    {
        public async Task<Product> FindById(Guid id)
        {
            var product = await productRepository.GetById(id);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }
    }
}
