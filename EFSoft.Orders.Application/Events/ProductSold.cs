namespace EFSoft.Orders.Application.Events;

internal interface OrderPlaced
{
    public Guid CustomerId { get; }

    public Guid ProductId { get; }

    public int Quantity { get; }
}
