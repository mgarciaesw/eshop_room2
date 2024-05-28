using Domain.Customer;

namespace Application.Customer.Commands;

public sealed record CreateCustomerCommand()
{
    public FirstName? FirstName {get; init; }
    public LastName? LastName {get; init; }
    public Email? Email {get; init; }
    public ShippingAddress? ShippingAddress {get; init; }

    private CreateCustomerCommand(FirstName firstName, LastName lastName, Email email, ShippingAddress shippingAddress) : this()
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ShippingAddress = shippingAddress;
    }
    public static CreateCustomerCommand Create(string firstName, string lastName, string email, string shippingAddress)
    {
        return new CreateCustomerCommand(
            FirstName.Create(firstName),
            LastName.Create(lastName),
            Email.Create(email),
            ShippingAddress.Create(shippingAddress)
        );
        
    }
}

