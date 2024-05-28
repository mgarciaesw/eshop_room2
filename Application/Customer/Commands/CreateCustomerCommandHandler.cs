using Domain.Customer;

namespace Application.Customer.Commands;

public sealed class CreateCustomerCommandHandler(ICustomerRepository CustomerRepository)
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken = default)
    {
        var customer = Domain.Customer.Customer.Create(request.FirstName, request.LastName, request.Email, request.ShippingAddress);

        await CustomerRepository.Create(customer);
    }
}

