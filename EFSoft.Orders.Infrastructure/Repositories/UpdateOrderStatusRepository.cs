namespace EFSoft.Orders.Infrastructure.Repositories;

public class UpdateOrderStatusRepository(OrdersDbContext ordersDbContext) : IUpdateOrderStatusRepository
{
    public async Task UpdateOrderStatusAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = await ordersDbContext.Orders.FindAsync(
            keyValues: [order.OrderId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.OrderStatus = order.OrderStatus;

            _ = ordersDbContext.Update(entity);
            _ = await ordersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
