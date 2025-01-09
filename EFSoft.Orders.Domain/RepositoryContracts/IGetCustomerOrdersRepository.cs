namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IGetCustomerOrdersRepository
{
    Task<IEnumerable<OrderDomainModel>> GetCustomerOrdersAsync(
          Guid customerId,
          CancellationToken cancellationToken = default);
}
