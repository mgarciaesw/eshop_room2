using Domain.Products;
using MediatR;

namespace Application.Products.Queries
{
    public sealed class GetProductStockQueryHandler(ProductFinder productFinder)
        : IRequestHandler<GetProductStockQuery, int>
    {
        public Task<int> Handle(GetProductStockQuery query, CancellationToken cancellationToken = default)
        {
            var product = productFinder.FindById(query.Id);

            return Task.FromResult(product.Stock.Value);
        }
    }
}
