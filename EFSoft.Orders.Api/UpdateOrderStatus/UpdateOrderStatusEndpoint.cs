namespace EFSoft.Orders.Api.UpdateOrderStatus;

public static class UpdateOrderStatusEndpoint
{
    public static async Task<IResult> Put(
        [FromBody] UpdateOrderStatusRequest updateOrderStatusRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var updateOrderCommand = new UpdateOrderStatusCommand(
            OrderId: updateOrderStatusRequest.OrderId,
            OrderStatus: updateOrderStatusRequest.OrderStatus);

        await mediator.Send(
            updateOrderCommand,
            cancellationToken);

        return Results.Ok();
    }
}
