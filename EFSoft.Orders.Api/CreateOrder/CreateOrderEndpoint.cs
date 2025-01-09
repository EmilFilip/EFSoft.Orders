namespace EFSoft.Orders.Api.CreateOrder;

public static class CreateOrderEndpoint
{
    public static async Task<IResult> Post(
        [FromBody] CreateOrderRequest createOrderRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var createOrderCommand = new CreateOrderCommand(
            CustomerId: createOrderRequest.CustomerId,
            Description: createOrderRequest.Description,
            OrderProducts: createOrderRequest.OrderProducts);

        await mediator.Send(
            createOrderCommand,
            cancellationToken);

        return Results.Ok();
    }
}
