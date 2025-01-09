namespace EFSoft.Orders.Infrastructure.Repositories;

public class CreateOrderProductRepository(OrdersDbContext ordersDbContext) : ICreateOrderProductRepository
{
    public async Task CreateOrderProductAsync(
            IEnumerable<OrderProductDomainModel> orderProducts,
            CancellationToken cancellationToken = default)
    {
        var entities = orderProducts.Select(MapToEntity);

        await ordersDbContext.OrderProducts.AddRangeAsync(entities, cancellationToken);

        _ = await ordersDbContext.SaveChangesAsync(cancellationToken);
    }

    private static OrderProduct MapToEntity(
        OrderProductDomainModel domainOrder)
    {
        return new OrderProduct
        {
            OrderId = domainOrder.OrderId,
            OrderProductId = domainOrder.OrderProductId,
            ProductId = domainOrder.ProductId,
            Quantity = domainOrder.Quantity,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
