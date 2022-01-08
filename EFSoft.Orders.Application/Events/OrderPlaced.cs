namespace EFSoft.Orders.Application.Events;

public class OrderPlaced
{
    public Guid CustomerId { get; }

    public Guid ProductId { get; }

    public int Quantity { get; }
}
