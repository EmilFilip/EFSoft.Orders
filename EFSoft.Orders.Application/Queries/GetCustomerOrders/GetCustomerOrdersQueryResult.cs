namespace EFSoft.Orders.Application.Queries.GetCustomerOrders;

public class GetCustomerOrdersQueryResult
{
    public GetCustomerOrdersQueryResult(IEnumerable<OrderModel> orders)
    {
        Orders = orders;
    }

    public IEnumerable<OrderModel> Orders { get; }
}
