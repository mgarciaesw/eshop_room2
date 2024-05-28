namespace Domain.Customer;

public interface ICustomerRepository
{
    Task Add(Customer customer);
}

