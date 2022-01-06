namespace EFSoft.Orders.Application.Queries.Results;

public class GetOrderQueryResult : IQueryResult
{
    public GetOrderQueryResult(OrderModel order)
    {
        Order = order;
    }

    public OrderModel Order { get; }
}