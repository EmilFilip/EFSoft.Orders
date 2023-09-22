namespace EFSoft.Orders.Application.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public UpdateOrderCommandHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository;
        _orderProductsRepository = orderProductsRepository;
    }

    public async Task Handle(
        UpdateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = new OrderModel(
            orderId: command.OrderId,
            customerId: command.CustomerId,
            description: command.Description,
            orderStatus: command.OrderStatus);

        await _ordersRepository.UpdateOrderAsync(order);

        var orderProducts = command.OrderProducts.Select(op =>
            new OrderProductModel(
                orderProductId: op.OrderProductId,
                orderId: op.OrderId,
                productId: op.ProductId,
                quantity: op.Quantity));

        foreach (var orderProduct in orderProducts)
        {
            await _orderProductsRepository.UpdateOrderProductAsync(orderProduct);
        }
    }
}
