using EFSoft.Orders.Application.CreateOrder;

namespace EFSoft.Orders.Api.CreateOrder;

public sealed record CreateOrderRequest(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderCreateDto> OrderProducts);
