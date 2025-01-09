namespace EFSoft.Orders.Application.CreateOrder;

public sealed record OrderProductCreate(
         Guid ProductId,
         int Quantity);
