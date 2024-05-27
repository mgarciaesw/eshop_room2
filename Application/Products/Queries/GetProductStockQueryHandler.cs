using Domain.Products;

namespace Application.Products.Queries
{
    public sealed class GetProductStockQueryHandler(IProductRepository productRepository)
    {
        public async Task<int> Handle(GetProductStockQuery query)
        {
            var product = await productRepository.GetById(new Guid(query.Id));

            return product.Stock.Value;
        }
    }
}
