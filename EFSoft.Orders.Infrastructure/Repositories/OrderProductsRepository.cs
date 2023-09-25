namespace EFSoft.Orders.Infrastructure.Repositories;

public class OrderProductsRepository : IOrderProductsRepository
{
    private readonly OrdersDbContext _ordersDbContext;

    public OrderProductsRepository(OrdersDbContext ordersDbContext)
    {
        _ordersDbContext = ordersDbContext;
    }

    public async Task<List<OrderProductModel>> GetOrderProductsForOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var entities = await _ordersDbContext.OrderProducts
            .AsQueryable()
            .Where(o => o.OrderId == orderId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (!entities.Any())
        {
            return new List<OrderProductModel>();
        }

        return entities.Select(MapToDomain).ToList();
    }

    public async Task CreateOrderProductsAsync(
        IEnumerable<OrderProductModel> orderProducts,
        CancellationToken cancellationToken = default)
    {
        var entities = orderProducts.Select(MapToEntity);

        await _ordersDbContext.OrderProducts.AddRangeAsync(entities);

        await _ordersDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateOrderProductAsync(
        OrderProductModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = await _ordersDbContext.OrderProducts.FindAsync(
            keyValues: new object[] { order.OrderId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Quantity = order.Quantity;

            _ordersDbContext.Update(entity);
            await _ordersDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private static OrderProductModel MapToDomain(
        OrderProduct entityOrder)
    {
        return new OrderProductModel(
            orderId: entityOrder.OrderId,
            orderProductId: entityOrder.OrderProductId,
            productId: entityOrder.ProductId,
            quantity: entityOrder.Quantity);
    }

    private static OrderProduct MapToEntity(
        OrderProductModel domainOrder)
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
