using Domain.Products;

namespace Application.Products.Queries
{
    public sealed class GetProductStockQueryHandler(ProductFinder productFinder)
    {
        public async Task<int> Handle(GetProductStockQuery query, CancellationToken cancellationToken = default)
        {
            var product = await productFinder.FindById(new Guid(query.Id));

            return product.Stock.Value;
        }
    }
}
