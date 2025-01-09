namespace EFSoft.Orders.Infrastructure.Repositories;

public class GetOrderProductsForOrderRepository(OrdersDbContext ordersDbContext) : IGetOrderProductsForOrderRepository
{
    public async Task<IEnumerable<OrderProductDomainModel>> GetOrderProductsForOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var entities = await ordersDbContext.OrderProducts
            .AsQueryable()
            .Where(o => o.OrderId == orderId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (entities.IsNullOrEmpty())
        {
            return Enumerable.Empty<OrderProductDomainModel>();
        }
        return entities.Select(MapToDomain).ToList();
    }

    private static OrderProductDomainModel MapToDomain(
        OrderProduct entityOrder)
    {
        return new OrderProductDomainModel(
            orderId: entityOrder.OrderId,
            orderProductId: entityOrder.OrderProductId,
            productId: entityOrder.ProductId,
            quantity: entityOrder.Quantity);
    }
}
