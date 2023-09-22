namespace EFSoft.Orders.Application.Commands.CreateOrder;

public sealed record class CreateOrderCommand(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderProduct> OrderProducts) : ICommand
{
}
