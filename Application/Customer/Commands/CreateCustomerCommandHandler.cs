using Domain.Customer;

namespace Application.Customer.Commands;

public sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository)
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken = default)
    {
        var customer = Domain.Customer.Customer.Create(
            FirstName.Create(request.FirstName),
            LastName.Create(request.LastName),
            Email.Create(request.Email),
            ShippingAddress.Create(request.ShippingAddress)
            );

        await customerRepository.Create(customer);
    }
}

