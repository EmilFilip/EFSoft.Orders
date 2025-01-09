namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IUpdateOrderProductsRepository
{
    Task UpdateOrderProductsAsync(
        IEnumerable<OrderProductDomainModel> orderProducts,
        CancellationToken cancellationToken = default);
}
