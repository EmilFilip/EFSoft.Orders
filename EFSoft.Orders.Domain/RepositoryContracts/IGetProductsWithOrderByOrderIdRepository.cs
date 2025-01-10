namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IGetProductsWithOrderByOrderIdRepository
{
    Task<IEnumerable<OrderProductDomainModel>> GetProductsWithOrderByOrderIdAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);
}
