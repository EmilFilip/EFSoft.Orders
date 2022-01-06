namespace EFSoft.Orders.Application.RepositoryContracts;

public interface IOrderProductsRepository
{
    Task<List<OrderProductModel>> GetOrderProductsForOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);

    Task CreateOrderProductsAsync(
        IEnumerable<OrderProductModel> order,
        CancellationToken cancellationToken = default);

    Task UpdateOrderProductAsync(
        OrderProductModel order,
        CancellationToken cancellationToken = default);
}
