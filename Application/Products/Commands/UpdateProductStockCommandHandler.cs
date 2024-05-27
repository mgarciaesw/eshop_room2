using Domain.Products;

namespace Application.Products.Commands
{
    public sealed class UpdateProductStockCommandHandler(IProductRepository ProductRepository)
    {
        public async Task Handle(UpdateProductStockCommand request, CancellationToken cancellationToken = default)
        {
            var product = await ProductRepository.GetById(new Guid(request.Id));

            product.UpdateStock(StockQuantity.Create(request.Stock));

            await ProductRepository.Update(product);
        }
    }
}
