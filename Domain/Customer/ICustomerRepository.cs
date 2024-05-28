namespace Domain.Products;

public interface ICustomerRepository
{
    Task Create(Customer customer);
}

