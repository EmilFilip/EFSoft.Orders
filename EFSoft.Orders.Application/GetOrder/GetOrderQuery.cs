namespace EFSoft.Orders.Application.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<GetOrderQueryResult>;