namespace Application.Customer.Commands;
public sealed record CreateCustomerCommand(string Id, string FirstName, string LastName, string ShippingAddress);

