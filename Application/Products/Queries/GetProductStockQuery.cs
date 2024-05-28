using MediatR;

namespace Application.Products.Queries
{
    public sealed record GetProductStockQuery(string Id) : IRequest<int>;
}
