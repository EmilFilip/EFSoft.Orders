namespace EFSoft.Orders.Infrastructure.Repositories;

public class GetOrderRepository(OrdersDbContext ordersDbContext) : IGetOrderRepository
{
    public async Task<OrderDomainModel?> GetOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var entity = await ordersDbContext.Orders.FirstOrDefaultAsync(
            c => c.OrderId == orderId,
            cancellationToken: cancellationToken);

        if (entity == null)
        {
            return default;
        }

        return MapToDomain(entity);
    }
    private static OrderDomainModel MapToDomain(Order entityOrder)
    {
        return new OrderDomainModel(
            orderId: entityOrder.OrderId,
            customerId: entityOrder.CustomerId,
            description: entityOrder.Description,
            orderStatus: entityOrder.OrderStatus);
    }
}
