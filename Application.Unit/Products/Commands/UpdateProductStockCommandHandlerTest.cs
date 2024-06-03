using Application.Products.Commands;
using Domain.Products;
using Domain.Products.Exceptions;
using Moq;

namespace Application.Unit.Products.Commands
{
    public class UpdateProductStockCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly UpdateProductStockCommandHandler _handler;

        public UpdateProductStockCommandHandlerTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _handler = new UpdateProductStockCommandHandler(_productRepository.Object, new ProductFinder(_productRepository.Object));
        }

        [Theory]
        [ClassData(typeof(UpdateStockSuccessfullyTestData))]
        public async Task Handle_Should_BeSuccessful_WhenProductExists(string id, int stock)
        {
            var command = new UpdateProductStockCommand(id, stock);

            var expectedProduct = CreateProduct(new Guid(id));
            RepositoryWillReturnProduct(expectedProduct);

            _productRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()));

            await _handler.Handle(command);

            _productRepository.VerifyAll();
        }

        [Fact]
        public async Task Handle_Should_ThrowException_WhenProductNotExists()
        {
            var id = Guid.NewGuid().ToString();
            var query = new UpdateProductStockCommand(id, 0);

            await Assert.ThrowsAsync<ProductNotFoundException>(() => _handler.Handle(query));
        }

        [Theory]
        [ClassData(typeof(UpdateStockUnsuccessfullyTestData))]
        public async Task Handle_Should_ThrowException_WhenStockIsNotValid(Type expectedException, string id, int stock)
        {
            var expectedProduct = CreateProduct(new Guid(id));
            RepositoryWillReturnProduct(expectedProduct);

            var query = new UpdateProductStockCommand(id, stock);

            await Assert.ThrowsAsync(expectedException, () => _handler.Handle(query));
        }

        private static Product CreateProduct(Guid? id = null)
        {
            return Product.Create(
                id ?? Guid.NewGuid(),
                ProductName.Create("name"),
                StockQuantity.Create(0));
        }

        private void RepositoryWillReturnProduct(Product product)
        {
            _productRepository
                .Setup(mock => mock.GetById(product.Id))
                .Returns(product);
        }
    }

    public class UpdateStockSuccessfullyTestData : TheoryData<string, int>
    {
        public UpdateStockSuccessfullyTestData()
        {
            Add(Guid.NewGuid().ToString(), 0);
            Add(Guid.NewGuid().ToString(), 100);
        }
    }

    public class UpdateStockUnsuccessfullyTestData : TheoryData<Type, string, int>
    {
        public UpdateStockUnsuccessfullyTestData()
        {
            Add(
                typeof(StockQuantityIsInvalidException),
                Guid.NewGuid().ToString(),
                -1);
        }
    }
}
