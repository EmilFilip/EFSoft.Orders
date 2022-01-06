namespace EFSoft.Orders.Application.Queries.Results;

public class GetCustomerOrdersQueryResult : IQueryResult
{
    public GetCustomerOrdersQueryResult(IEnumerable<OrderModel> orders)
    {
        Orders = orders;
    }

    public IEnumerable<OrderModel> Orders { get; }
}
