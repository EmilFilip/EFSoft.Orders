namespace EFSoft.Orders.Application.Dtos;

public sealed record class OrderProduct(
         Guid ProductId,
         int Quantity)
{
}
