namespace EFSoft.Orders.Application.Queries.Handlers;

public class GetCustomerOrdersQueryHandler :
        IQueryHandler<GetCustomerOrdersQueryParameters, GetCustomerOrdersQueryResult>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public GetCustomerOrdersQueryHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        _orderProductsRepository = orderProductsRepository ?? throw new ArgumentNullException(nameof(orderProductsRepository));
    }

    public async Task<GetCustomerOrdersQueryResult> HandleAsync(
            GetCustomerOrdersQueryParameters parameters,
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
                order.OrderProducts.AddRange(orderProducts);
            }
        }

        return new GetCustomerOrdersQueryResult(orders);
    }
}

