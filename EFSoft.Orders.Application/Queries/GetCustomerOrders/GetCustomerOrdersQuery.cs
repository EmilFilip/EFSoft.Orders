namespace EFSoft.Orders.Application.Queries.GetCustomerOrders;

public sealed record class GetCustomerOrdersQuery(Guid CustomerId) : IQuery<GetCustomerOrdersQueryResult>;