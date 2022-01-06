namespace EFSoft.Orders.Application.Queries.Parameters;

public class GetCustomerOrdersQueryParameters : IQueryParameters
{
    public GetCustomerOrdersQueryParameters(Guid customerId)
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; set; }
}
