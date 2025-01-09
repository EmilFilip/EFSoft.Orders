namespace EFSoft.Orders.Api.UpdateOrder;

public static class UpdateOrderEndpoint
{
    public static async Task<IResult> Put(
        [FromBody] UpdateOrderRequest updateOrderRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var updateOrderCommand = new UpdateOrderCommand(
            OrderId: updateOrderRequest.OrderId,
            Description: updateOrderRequest.Description,
            OrderProducts: updateOrderRequest.OrderProducts);

        await mediator.Send(
            updateOrderCommand,
            cancellationToken);

        return Results.Ok();
    }
}
