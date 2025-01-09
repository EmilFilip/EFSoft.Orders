namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IGetOrderProductsForOrderRepository
{
    Task<IEnumerable<OrderProductDomainModel>> GetOrderProductsForOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);
}
