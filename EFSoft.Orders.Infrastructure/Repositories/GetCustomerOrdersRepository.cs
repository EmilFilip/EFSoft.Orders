namespace EFSoft.Orders.Infrastructure.Repositories;

public class GetCustomerOrdersRepository(OrdersDbContext ordersDbContext) : IGetCustomerOrdersRepository
{
    public async Task<IEnumerable<OrderDomainModel>> GetCustomerOrdersAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        var entities = await ordersDbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .ToListAsync(cancellationToken);

        if (entities.IsNullOrEmpty())
        {
            return Enumerable.Empty<OrderDomainModel>();
        }

        return entities.Select(MapToDomain);
    }

    private static OrderDomainModel MapToDomain(
        Order entityOrder)
    {
        return new OrderDomainModel(
            orderId: entityOrder.OrderId,
            customerId: entityOrder.CustomerId,
            description: entityOrder.Description,
            orderStatus: entityOrder.OrderStatus);
    }
}
