using EFSoft.Orders.Application.CreateOrder;

namespace EFSoft.Orders.Application.UpdateOrder;

public sealed record UpdateOrderCommand(
         Guid OrderId,
         string Description,
         IEnumerable<OrderProductCreate> OrderProducts) : ICommand;
