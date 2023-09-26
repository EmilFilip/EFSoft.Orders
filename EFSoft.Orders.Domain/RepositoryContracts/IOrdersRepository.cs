namespace EFSoft.Orders.Domain.RepositoryContracts;

public interface IOrdersRepository
{
    Task<OrderModel> GetOrderAsync(
             Guid orderId,
             CancellationToken cancellationToken = default);

    Task<IEnumerable<OrderModel>> GetCustomerOrdersAsync(
          Guid customerId,
          CancellationToken cancellationToken = default);

    Task CreateOrderAsync(
        OrderModel order,
        CancellationToken cancellationToken = default);

    Task UpdateOrderAsync(
        OrderModel order,
        CancellationToken cancellationToken = default);
}
