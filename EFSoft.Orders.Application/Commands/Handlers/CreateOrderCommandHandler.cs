namespace EFSoft.Orders.Application.Commands.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommandParameters>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;

    public CreateOrderCommandHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        _orderProductsRepository = orderProductsRepository ?? throw new ArgumentNullException(nameof(orderProductsRepository));
    }

    public async Task HandleAsync(
        CreateOrderCommandParameters command)
    {
        var order = OrderModel.CreateNew(
            description: command.Description,
            customerId: command.CustomerId);

        await _ordersRepository.CreateOrderAsync(order);

        var orderProducts = command.OrderProducts.Select(op =>
            new OrderProductModel(
                orderProductId: op.OrderProductId,
                orderId: order.OrderId,
                productId: op.ProductId,
                quantity: op.Quantity));

        await _orderProductsRepository.CreateOrderProductsAsync(orderProducts);
    }
}
