namespace Domain.Order;

using Domain.Primitives;
using Domain.Shared;

using System.Collections.Generic;

public class Order: AggregateRoot
{
    public Guid Guid { get; private set; }
    public Money Amount { get; set; }
    public Status Status { get; set; }
    public readonly List<LineDetail> _lines = new List<LineDetail>();   

    public List<LineDetail> Lines
    {
        get { return _lines; }
    }

    private Order(
        Guid guid,
        Money amount,
        Status status,
        List<LineDetail> lines
    ): base( guid )
    {
        Guid = guid;
        Amount = amount;
        Status = status;
        lines.ForEach( ( line ) => { _lines.Add( line ); } );
    }

    public static Order PlaceOrder(Money amount, List<LineDetail> lines) 
    {
        return new Order(Guid.NewGuid(), amount, Status.Initial, lines);
    }
}