namespace EFSoft.Orders.Api.UpdateOrderStatus;

public sealed record UpdateOrderStatusRequest(
    Guid OrderId,
    OrderStatus OrderStatus);

