using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order;

public class LineDetail
{
    public Guid Guid { get; internal set; }
    public Order Order { get; internal set; }
    public Guid ProductId { get; internal set; }
    public Money PriceAtOrder { get; internal set; }
    public Money TotalLine {  get; internal set; }
    public Quantity Quantity { get; internal set; }

    private LineDetail(
        Guid guid,
        Order order,
        Guid productId,
        Money priceAtOrder,
        Money totalLine,
        Quantity quantity) 
    {
        Guid = guid;
        Order = order;
        ProductId = productId;
        PriceAtOrder = priceAtOrder;
        TotalLine = totalLine;
        Quantity = quantity;
    }

    public static LineDetail CreateLine(
        Order order, 
        Guid productId, 
        Money priceAtOrder, 
        Money totaLine, 
        Quantity quantity
    )
    {
        return new LineDetail(
            Guid.NewGuid(),
            order,
            productId,
            priceAtOrder,
            totaLine,
            quantity
        );
    }
}
