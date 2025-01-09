namespace EFSoft.Orders.Application.CreateOrder;

public sealed record OrderCreateDto(
         Guid ProductId,
         int Quantity);
