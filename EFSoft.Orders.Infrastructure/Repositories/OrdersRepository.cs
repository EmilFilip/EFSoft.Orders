namespace EFSoft.Orders.Infrastructure.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrdersDbContext _ordersDbContext;

    public OrdersRepository(OrdersDbContext ordersDbContext)
    {
        _ordersDbContext = ordersDbContext;
    }

    public async Task CreateOrderAsync(
        OrderModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(order);

        _ordersDbContext.Orders.Add(entity);

        await _ordersDbContext
            .SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<OrderModel>> GetCustomerOrdersAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        var entities = await _ordersDbContext.Orders.Where(
            o => o.CustomerId == customerId)
            .ToListAsync(cancellationToken);

        if (!entities.Any())
        {
            return new List<OrderModel>();
        }

        return entities.Select(MapToDomain);
    }

    public async Task<OrderModel> GetOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var entity = await _ordersDbContext.Orders.FirstOrDefaultAsync(
            c => c.OrderId == orderId,
            cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public async Task UpdateOrderAsync(
        OrderModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = await _ordersDbContext.Orders.FindAsync(
            keyValues: new object[] { order.OrderId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.Description = order.Description;
            entity.OrderStatus = order.OrderStatus;

            _ordersDbContext.Update(entity);
            await _ordersDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private static OrderModel MapToDomain(
        Order entityOrder)
    {
        return new OrderModel(
            orderId: entityOrder.OrderId,
            customerId: entityOrder.CustomerId,
            description: entityOrder.Description,
            orderStatus: entityOrder.OrderStatus);
    }

    private static Order MapToEntity(
        OrderModel domainOrder)
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
