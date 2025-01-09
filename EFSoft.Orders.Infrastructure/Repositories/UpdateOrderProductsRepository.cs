namespace EFSoft.Orders.Infrastructure.Repositories;

public class UpdateOrderProductsRepository(OrdersDbContext ordersDbContext) : IUpdateOrderProductsRepository
{
    public async Task UpdateOrderProductsAsync(
        IEnumerable<OrderProductDomainModel> orderProducts,
        CancellationToken cancellationToken = default)
    {
        var entities = orderProducts.Select(MapToEntity);
        ordersDbContext.UpdateRange(entities);

        await ordersDbContext.SaveChangesAsync(cancellationToken);
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
