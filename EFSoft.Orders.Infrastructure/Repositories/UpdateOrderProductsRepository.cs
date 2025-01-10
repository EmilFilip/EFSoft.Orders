namespace EFSoft.Orders.Infrastructure.Repositories;

public class UpdateOrderProductsRepository(OrdersDbContext ordersDbContext) : IUpdateOrderProductsRepository
{
    public async Task UpdateOrderProductsAsync(
        IEnumerable<OrderProductDomainModel> orderProducts,
        CancellationToken cancellationToken = default)
    {
        var orderIds = orderProducts.Select(x => x.OrderId);
        var productIds = orderProducts.Select(x => x.ProductId);

        var entities = await ordersDbContext.OrderProducts
            .AsQueryable()
            .Where(o => orderIds.Contains(o.OrderId) && productIds.Contains(o.ProductId))
            .ToListAsync();

        entities.ForEach(domainModel => domainModel.Quantity = orderProducts.First(d => d.ProductId == domainModel.ProductId).Quantity);

        ordersDbContext.UpdateRange(entities);

        _ = await ordersDbContext.SaveChangesAsync(cancellationToken);
    }
}
