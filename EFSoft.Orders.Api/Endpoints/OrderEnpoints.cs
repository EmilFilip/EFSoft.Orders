using Microsoft.AspNetCore.Builder;

namespace EFSoft.Orders.Api.Endpoints;

public static class OrderEnpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/order");

        group.MapGet("{orderId:guid}", Get);
        group.MapGet("[action]/{customerId:guid}", GetCustomerOrders).WithName("GetCustomerOrders");
        group.MapPost("", Post);
        group.MapPut("", Put);
    }

    public static async Task<Results<Ok<GetOrderQueryResult>, NotFound>> Get(
        Guid orderId,
        IMediator mediator)
    {
        var results = await mediator.Send(new GetOrderQuery(orderId));

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
    public static async Task<Results<Ok<GetCustomerOrdersQueryResult>, NotFound>> GetCustomerOrders(
        Guid customerId,
        IMediator mediator)
    {
        var results = await mediator.Send(new GetCustomerOrdersQuery(customerId));

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateOrderCommand parameters,
        IMediator mediator)
    {
        await mediator.Send(parameters);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateOrderCommand parameters,
        IMediator mediator)
    {
        await mediator.Send(parameters);

        return Results.Ok();
    }
}
