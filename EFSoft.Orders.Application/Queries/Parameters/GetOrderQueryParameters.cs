namespace EFSoft.Orders.Application.Queries.Parameters;

public class GetOrderQueryParameters : IQueryParameters
{
    public GetOrderQueryParameters(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; set; }
}
