namespace EFSoft.Orders.Api.Endpoints;

public static class OrderEnpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/order");

        group.MapGet("{orderId:guid}", Get);
        group.MapGet("getCustomerOrders/{customerId:guid}", GetCustomerOrders);
        group.MapPost("", Post);
        group.MapPut("", Put);
    }

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
    public static async Task<Results<Ok<GetCustomerOrdersQueryResult>, NotFound>> GetCustomerOrders(
        Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetCustomerOrdersQuery(customerId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateOrderCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateOrderCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }
}
