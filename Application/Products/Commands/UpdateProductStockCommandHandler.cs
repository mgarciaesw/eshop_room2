using Domain.Products;

namespace Application.Products.Commands
{
    public sealed class UpdateProductStockCommandHandler(
        IProductRepository productRepository,
        ProductFinder productFinder)
    {
        public async Task Handle(UpdateProductStockCommand request, CancellationToken cancellationToken = default)
        {
            var product = await productFinder.FindById(new Guid(request.Id));

            product.UpdateStock(StockQuantity.Create(request.Stock));

            await productRepository.Update(product);
        }
    }
}
