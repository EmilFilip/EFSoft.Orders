namespace EFSoft.Orders.Application.Events;

public sealed record class OrderPlaced(
    Guid CustomerId,
    Guid ProductId,
    int Quantity)
{
}
