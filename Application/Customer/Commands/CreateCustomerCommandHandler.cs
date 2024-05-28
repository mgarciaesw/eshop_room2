using Application.Customer.Commands;
using Domain.Customer;

namespace Application.Customer.Commands;

public sealed class CreateCustomerCommandHandler(ICustomerRepository CustomerRepository)
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken = default)
    {
        Customer customer = Customer.Create(
            request.FirstName,
            request.LastName,
            request.ShippingAddress
        );

        await CustomerRepository.Create(customer);
    }
}

