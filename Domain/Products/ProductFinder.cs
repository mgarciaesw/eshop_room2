using Domain.Products.Exceptions;

namespace Domain.Products
{
    public sealed class ProductFinder(IProductRepository productRepository)
    {
        public Product FindById(string id)
        {
            var product = productRepository.GetById(new Guid(id));

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }
    }
}
