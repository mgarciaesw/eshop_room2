using Domain.Products;
using MediatR;

namespace Application.Products.Queries
{
    public sealed class GetProductStockQueryHandler(ProductFinder productFinder)
        : IRequestHandler<GetProductStockQuery, int>
    {
        public async Task<int> Handle(GetProductStockQuery query, CancellationToken cancellationToken = default)
        {
            var product = productFinder.FindById(query.Id);

            return product.Stock.Value;
        }
    }
}
