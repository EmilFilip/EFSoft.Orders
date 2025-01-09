namespace EFSoft.Orders.Application.UpdateOrderStatus;

public sealed record UpdateOrderStatusCommand(
    Guid OrderId,
    OrderStatus OrderStatus) : ICommand;
