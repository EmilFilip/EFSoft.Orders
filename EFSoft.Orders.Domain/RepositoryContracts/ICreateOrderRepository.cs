namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface ICreateOrderRepository
{
    Task CreateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);

}
