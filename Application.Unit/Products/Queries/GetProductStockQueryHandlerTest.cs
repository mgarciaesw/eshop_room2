using Application.Products.Queries;
using Domain.Products;
using Domain.Products.Exceptions;
using Moq;

namespace Application.Unit.Products.Queries
{
    public sealed class GetProductStockQueryHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly GetProductStockQueryHandler _handler;

        public GetProductStockQueryHandlerTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _handler = new GetProductStockQueryHandler(new ProductFinder(_productRepository.Object));
        }

        [Fact]
        public async Task Handle_Should_ReturnInt_WhenProductExists()
        {
            var id = Guid.NewGuid().ToString();
            var query = new GetProductStockQuery(id);

            var expectedProduct = CreateProduct();
            _productRepository.Setup(mock => mock.GetById(It.IsAny<Guid>()))
                .Returns(expectedProduct);

            var result = await _handler.Handle(query);

            Assert.IsType<int>(result);
            Assert.Equal(expectedProduct.Stock.Value, result);

            _productRepository.VerifyAll();
        }

        [Fact]
        public async Task Handle_Should_ThrowException_WhenProductNotExists()
        {
            var id = Guid.NewGuid().ToString();
            var query = new GetProductStockQuery(id);

            await Assert.ThrowsAsync<ProductNotFoundException>(() => _handler.Handle(query));
        }

        private static Product CreateProduct()
        {
            return Product.Create(Guid.NewGuid(), ProductName.Create("name"), StockQuantity.Create(0));
        }
    }
}
