namespace EFSoft.Orders.Application.Dtos;

public sealed record class OrderCreate(
         Guid ProductId,
         int Quantity);
