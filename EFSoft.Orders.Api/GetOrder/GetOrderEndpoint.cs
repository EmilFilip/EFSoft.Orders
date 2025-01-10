namespace EFSoft.Orders.Api.GetOrder;

public static class GetOrderEndpoint
{
    public static async Task<Results<Ok<GetOrderQueryResult>, NotFound>> Get(
        Guid orderId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetOrderQuery(orderId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
