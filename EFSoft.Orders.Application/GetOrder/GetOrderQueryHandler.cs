namespace EFSoft.Orders.Application.GetOrder;

public class GetOrderQueryHandler(
    IGetOrderRepository getOrderRepository,
    IGetOrderProductsForOrderRepository getOrderProductsForOrderRepository) : IQueryHandler<GetOrderQuery, GetOrderQueryResult?>
{
    public async Task<GetOrderQueryResult?> Handle(
            GetOrderQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var order = await getOrderRepository.GetOrderAsync(
            orderId: parameters.OrderId,
            cancellationToken: cancellationToken);


        if (order is null)
        {
            return default;
        }

        var products = await getOrderProductsForOrderRepository.GetOrderProductsForOrderAsync(
            orderId: order.OrderId,
            cancellationToken: cancellationToken);

        order.OrderProducts = products;

        return new GetOrderQueryResult(order);
    }
}
