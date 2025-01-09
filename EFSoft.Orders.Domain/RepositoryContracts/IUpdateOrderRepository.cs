namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IUpdateOrderRepository
{
    Task UpdateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);
}
