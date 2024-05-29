using Application.Products.Commands;
using Domain.Products;
using Domain.Products.Exceptions;
using Domain.Shared;
using Moq;

namespace Application.Unit.Products.Commands
{
    public sealed class UpdateProductStockCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly UpdateProductStockCommandHandler _handler;

        public UpdateProductStockCommandHandlerTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _handler = new UpdateProductStockCommandHandler(_productRepository.Object, new ProductFinder(_productRepository.Object));
        }

        [Fact]
        public async Task Handle_Should_BeSuccessful_WhenProductExists()
        {
            var id = Guid.NewGuid().ToString();
            var query = new UpdateProductStockCommand(id, 8);

            var expectedProduct = CreateProduct();
            _productRepository.Setup(mock => mock.GetById(It.IsAny<Guid>()))
                .Returns(expectedProduct);

            _productRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()));

            await _handler.Handle(query);

            _productRepository.VerifyAll();
        }

        [Fact]
        public async Task Handle_Should_ThrowException_WhenProductNotExists()
        {
            var id = Guid.NewGuid().ToString();
            var query = new UpdateProductStockCommand(id, 0);

            await Assert.ThrowsAsync<ProductNotFoundException>(() => _handler.Handle(query));
        }

        private static Product CreateProduct()
        {
            return Product.Create(Guid.NewGuid(), ProductName.Create("name"), StockQuantity.Create(0));
        }
    }
}
