namespace Domain.Customer;

public interface ICustomerRepository
{
    Task Create(Customer customer);
}

