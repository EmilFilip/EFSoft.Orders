namespace EFSoft.Orders.Infrastructure.Repositories;

public class CreateOrderRepository(OrdersDbContext ordersDbContext) : ICreateOrderRepository
{
    public async Task CreateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(order);

        _ = ordersDbContext.Orders.Add(entity);

        _ = await ordersDbContext
            .SaveChangesAsync(cancellationToken);
    }

    private static Order MapToEntity(
        OrderDomainModel domainOrder)
    {
        return new Order
        {
            OrderId = domainOrder.OrderId,
            CustomerId = domainOrder.CustomerId,
            Description = domainOrder.Description,
            OrderStatus = domainOrder.OrderStatus,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
