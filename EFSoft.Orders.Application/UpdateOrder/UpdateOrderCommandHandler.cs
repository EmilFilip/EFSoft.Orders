namespace EFSoft.Orders.Application.UpdateOrder;

public class UpdateOrderCommandHandler(
    IUpdateOrderRepository updateOrderRepository,
    IUpdateOrderProductsRepository updateOrderProductsRepository) : ICommandHandler<UpdateOrderCommand>
{
    public async Task Handle(
        UpdateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = new OrderDomainModel(
            orderId: command.OrderId,
            description: command.Description);

        //Update the order and it's product within the same db transaction
        await updateOrderRepository.UpdateOrderAsync(
            order: order,
            cancellationToken: cancellationToken);

        var orderProducts = command.OrderProducts.Select(op =>
            new OrderProductDomainModel(
                orderId: command.OrderId,
                productId: op.ProductId,
                quantity: op.Quantity));

        await updateOrderProductsRepository.UpdateOrderProductsAsync(
            orderProducts: orderProducts,
            cancellationToken: cancellationToken);
    }
}
