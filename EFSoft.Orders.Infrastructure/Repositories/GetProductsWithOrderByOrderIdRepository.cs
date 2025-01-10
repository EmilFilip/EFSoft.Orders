namespace EFSoft.Orders.Infrastructure.Repositories;

public class GetProductsWithOrderByOrderIdRepository(OrdersDbContext ordersDbContext) : IGetProductsWithOrderByOrderIdRepository
{
    public async Task<IEnumerable<OrderProductDomainModel>> GetProductsWithOrderByOrderIdAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var entities = await ordersDbContext.OrderProducts
            .AsQueryable()
            .Include(x => x.Order)
            .Where(o => o.OrderId == orderId)
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
