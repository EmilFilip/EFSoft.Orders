namespace EFSoft.Orders.Application.Queries.GetOrder;

public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, GetOrderQueryResult>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public GetOrderQueryHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository;
        _orderProductsRepository = orderProductsRepository;
    }

    public async Task<GetOrderQueryResult> Handle(
            GetOrderQuery parameters,
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
