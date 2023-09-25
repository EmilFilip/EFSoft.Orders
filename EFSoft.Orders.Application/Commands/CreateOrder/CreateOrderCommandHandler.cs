namespace EFSoft.Orders.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;
    private readonly IServiceBus _serviceBus;

    public CreateOrderCommandHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository,
        IServiceBus serviceBus)
    {
        _ordersRepository = ordersRepository;
        _orderProductsRepository = orderProductsRepository;
        _serviceBus = serviceBus;
    }

    public async Task Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = OrderModel.CreateNew(
            description: command.Description,
            customerId: command.CustomerId);

        await _ordersRepository.CreateOrderAsync(
            order,
            cancellationToken);

        var orderProducts = new List<OrderProductModel>();

        foreach (var orderProduct in command.OrderProducts)
        {
            var newOrderProduct = OrderProductModel.CreateNew(
                orderId: order.OrderId,
                productId: orderProduct.ProductId,
                quantity: orderProduct.Quantity);

            orderProducts.Add(newOrderProduct);
        }

        await _orderProductsRepository.CreateOrderProductsAsync(
            orderProducts,
            cancellationToken);

        foreach (var orderProduct in orderProducts)
        {
            await _serviceBus.SendToTopicAsync<OrderPlaced>(
                message: new
                {
                    command.CustomerId,
                    orderProduct.ProductId,
                    orderProduct.Quantity
                },
                topicName: TopicNames.Orders);
        }
    }
}
