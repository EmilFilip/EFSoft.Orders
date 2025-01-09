namespace EFSoft.Orders.Application.GetCustomerOrders;

public class GetCustomerOrdersQueryResult
{
    public GetCustomerOrdersQueryResult(IEnumerable<OrderDomainModel> orders)
    {
        Orders = orders;
    }

    public IEnumerable<OrderDomainModel> Orders { get; }
}
