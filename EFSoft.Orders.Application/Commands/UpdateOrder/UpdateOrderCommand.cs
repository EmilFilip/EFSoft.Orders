namespace EFSoft.Orders.Application.Commands.UpdateOrder;

public sealed record class UpdateOrderCommand(
         Guid OrderId,
         Guid CustomerId,
         string Description,
         OrderStatus OrderStatus,
         IEnumerable<OrderProductCreate> OrderProducts) : ICommand;
