namespace EFSoft.Orders.Application.Queries.Handlers;

public class GetOrderQueryHandler :
        IQueryHandler<GetOrderQueryParameters, GetOrderQueryResult>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public GetOrderQueryHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        _orderProductsRepository = orderProductsRepository ?? throw new ArgumentNullException(nameof(orderProductsRepository));
    }

    public async Task<GetOrderQueryResult> HandleAsync(
            GetOrderQueryParameters parameters,
            CancellationToken cancellationToken = default)
    {
        var order = await _ordersRepository.GetOrderAsync(
            orderId: parameters.OrderId,
            cancellationToken: cancellationToken);


        if (order is null)
        {
            return null;
        }

        var products = await _orderProductsRepository.GetOrderProductsForOrderAsync(
            orderId: order.OrderId,
            cancellationToken: cancellationToken);

        order.OrderProducts = products;

        return new GetOrderQueryResult(order);
    }
}
