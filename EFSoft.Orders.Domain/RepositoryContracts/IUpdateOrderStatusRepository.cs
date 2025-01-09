namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IUpdateOrderStatusRepository
{
    Task UpdateOrderStatusAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);
}
