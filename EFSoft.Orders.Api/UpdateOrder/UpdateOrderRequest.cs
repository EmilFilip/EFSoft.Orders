using EFSoft.Orders.Application.CreateOrder;

namespace EFSoft.Orders.Api.UpdateOrder;

public sealed record UpdateOrderRequest(
         Guid OrderId,
         string Description,
         IEnumerable<OrderProductCreate> OrderProducts);
