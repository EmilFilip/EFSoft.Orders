namespace EFSoft.Orders.Application.Queries.GetCustomerOrders;

public class GetCustomerOrdersQueryHandler : IQueryHandler<GetCustomerOrdersQuery, GetCustomerOrdersQueryResult>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public GetCustomerOrdersQueryHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository;
        _orderProductsRepository = orderProductsRepository;
    }

    public async Task<GetCustomerOrdersQueryResult> Handle(
            GetCustomerOrdersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var orders = await _ordersRepository.GetCustomerOrdersAsync(
            customerId: parameters.CustomerId,
            cancellationToken: cancellationToken);


        if (!orders.Any())
        {
            return new GetCustomerOrdersQueryResult(new List<OrderModel>());
        }

        foreach (var order in orders)
        {
            var orderProducts = await _orderProductsRepository.GetOrderProductsForOrderAsync(
                orderId: order.OrderId,
                cancellationToken: cancellationToken);

            if (orderProducts.Any())
            {
                order.OrderProducts = new List<OrderProductModel>();
                order.OrderProducts.AddRange(orderProducts);
            }
        }

        return new GetCustomerOrdersQueryResult(orders);
    }
}

