using Domain.Products;
using MediatR;

namespace Application.Products.Commands
{
    public sealed class UpdateProductStockCommandHandler(
        IProductRepository productRepository,
        ProductFinder productFinder)
        : IRequestHandler<UpdateProductStockCommand>
    {
        public async Task Handle(UpdateProductStockCommand request, CancellationToken cancellationToken = default)
        {
            var product = productFinder.FindById(request.Id);

            product.UpdateStock(StockQuantity.Create(request.Stock));

            await productRepository.UpdateAsync(product, cancellationToken);
        }
    }
}
