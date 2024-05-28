using MediatR;

namespace Application.Products.Commands
{
    public sealed record UpdateProductStockCommand(string Id, int Stock) : IRequest;
}
