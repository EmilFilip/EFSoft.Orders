namespace EFSoft.Orders.Application.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler(
    IUpdateOrderStatusRepository updateOrderStatusRepository) : ICommandHandler<UpdateOrderStatusCommand>
{
    public async Task Handle(
        UpdateOrderStatusCommand command,
        CancellationToken cancellationToken)
    {
        var order = new OrderDomainModel(command.OrderId);
        order.SetOrderStatus(command.OrderStatus);

        await updateOrderStatusRepository.UpdateOrderStatusAsync(
            order: order,
            cancellationToken: cancellationToken);

    }
}
