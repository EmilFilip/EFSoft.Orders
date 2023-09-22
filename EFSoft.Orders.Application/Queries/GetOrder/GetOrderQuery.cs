namespace EFSoft.Orders.Application.Queries.GetOrder;

public sealed record class GetOrderQuery(Guid OrderId) : IQuery<GetOrderQueryResult>
{
}
