using Application.Customer.Commands;
using Domain.Customer;
using Moq;

namespace Application.Unit.Customers.Commands;

public sealed class CreateCustomerCommandHandlerTest
{
    private readonly Mock<ICustomerRepository> _customerRepository;
    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerCommandHandlerTest()
    {
        _customerRepository = new Mock<ICustomerRepository>();
        _handler = new CreateCustomerCommandHandler(_customerRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_BeSuccessful_WhenCreatingCustomer()
    {
        var command = new CreateCustomerCommand("firstName", "lastName", "test@mail.com", "shipping address 1");

        _customerRepository.Setup(mock => mock.Add(It.IsAny<Domain.Customer.Customer>()));

        await _handler.Handle(command);

        _customerRepository.VerifyAll();
    }
    
    [Fact]
    public async Task Handle_Should_UnSuccessful_WhenCreatingCustomer_WithWrongFirstNameParameter()
    {
        var command = new CreateCustomerCommand("fir", "lastName", "test@mail.com", "shipping address 1");

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command));

        _customerRepository.VerifyAll();
    }
    
    [Fact]
    public async Task Handle_Should_UnSuccessful_WhenCreatingCustomer_WithWrongEmailParameter()
    {
        var command = new CreateCustomerCommand("fir", "lastName", "", "shipping address 1");

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command));

        _customerRepository.VerifyAll();
    }
}
