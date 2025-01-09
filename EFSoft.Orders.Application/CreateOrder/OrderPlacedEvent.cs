namespace EFSoft.Orders.Application.CreateOrder;

public sealed record OrderPlacedEvent(
    Guid CustomerId,
    Guid ProductId,
    int Quantity);
