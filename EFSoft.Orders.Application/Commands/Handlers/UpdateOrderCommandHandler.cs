namespace EFSoft.Orders.Application.Commands.Handlers;

public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommandParameters>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public UpdateOrderCommandHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        _orderProductsRepository = orderProductsRepository ?? throw new ArgumentNullException(nameof(orderProductsRepository));
    }

    public async Task HandleAsync(
        UpdateOrderCommandParameters command)
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
