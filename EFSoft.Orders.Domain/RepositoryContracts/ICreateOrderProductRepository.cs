namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface ICreateOrderProductRepository
{
    Task CreateOrderProductAsync(
        IEnumerable<OrderProductDomainModel> order,
        CancellationToken cancellationToken = default);
}
