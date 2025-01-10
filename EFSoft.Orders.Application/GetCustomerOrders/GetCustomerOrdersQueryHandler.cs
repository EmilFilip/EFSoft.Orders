using System.Collections.Generic;

namespace EFSoft.Orders.Application.GetCustomerOrders;

public class GetCustomerOrdersQueryHandler(
    IGetCustomerOrdersRepository getCustomerOrdersRepository,
    IGetOrderProductsForOrderRepository getOrderProductsForOrderRepository) : IQueryHandler<GetCustomerOrdersQuery, GetCustomerOrdersQueryResult>
{
    public async Task<GetCustomerOrdersQueryResult> Handle(
            GetCustomerOrdersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var orders = await getCustomerOrdersRepository.GetCustomerOrdersAsync(
            customerId: parameters.CustomerId,
            cancellationToken: cancellationToken);


        if (!orders.Any())
        {
            return new GetCustomerOrdersQueryResult(Enumerable.Empty<OrderDomainModel>());
        }

        var ordersAndProducts = new List<OrderDomainModel>();

        foreach (var order in orders)
        {

            var orderProducts = await getOrderProductsForOrderRepository.GetOrderProductsForOrderAsync(
                orderId: order.OrderId,
                cancellationToken: cancellationToken);

            if (orderProducts.Any())
            {
                order.OrderProducts = orderProducts;
            }
            ordersAndProducts.Add(order);
        }

        return new GetCustomerOrdersQueryResult(ordersAndProducts);
    }
}

