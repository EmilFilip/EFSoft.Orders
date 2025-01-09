namespace EFSoft.Orders.Application.GetCustomerOrders;

public sealed record GetCustomerOrdersQuery(Guid CustomerId) : IQuery<GetCustomerOrdersQueryResult>;