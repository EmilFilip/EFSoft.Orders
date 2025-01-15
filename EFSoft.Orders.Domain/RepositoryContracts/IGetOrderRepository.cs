namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IGetOrderRepository
{
    Task<OrderDomainModel?> GetOrderAsync(
             Guid orderId,
             CancellationToken cancellationToken = default);
}
