namespace EFSoft.Orders.Application.Dtos;

public sealed record class OrderProductCreate(
         Guid OrderProductId,
         Guid OrderId,
         Guid ProductId,
         int Quantity);
