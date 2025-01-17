namespace EFSoft.Orders.Infrastructure.Repositories;

public class UpdateOrderRepository(OrdersDbContext ordersDbContext) : IUpdateOrderRepository
{
    public async Task UpdateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default)
    {
        var entity = await ordersDbContext.Orders.FindAsync(
            keyValues: [order.OrderId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.Description = order.Description;

            _ = ordersDbContext.Update(entity);
            _ = await ordersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
