namespace Domain.Order;

using Domain.Primitives;
using Domain.Shared;

public class Order: AggregateRoot
{
    public Guid Guid { get; private set; }
    public Money Amount { get; set; }
    public Status Status { get; set; }

    private Order(
        Guid guid,
        Money amount,
        Status status
    ): base( guid )
    {
        Guid = guid;
        Amount = amount;
        Status = status;
    }

    public static Order PlaceOrder(Money amount) 
    {
        return new Order(Guid.NewGuid(), amount, Status.Initial);
    }
}